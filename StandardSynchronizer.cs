using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using iTunesLib;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Jaranweb.iTunesAgent.Configuration12;
using System.Security.AccessControl;
using log4net;

namespace Jaranweb.iTunesAgent
{
    /// <summary>
    /// Standard Synchronizer. Implementation of ISynchronizer. Has a simple progressbar UI.
    /// </summary>
    public class StandardSynchronizer : ISynchronizer
    {
        private ILog l = LogManager.GetLogger(typeof(StandardSynchronizer));

        private bool hasGui = true;
        private bool showGui = true;
        private DeviceConfiguration configuration;
        private ISynchronizeForm syncForm;
        private ArrayList extensions = new ArrayList();

        #region ISynchronizer Members

        public event SynchronizeErrorEventHandler SynchronizeError;

        public event SynchronizeCompleteEventHandler SynchronizeComplete;

        public event SynchronizeCancelledEventHandler SynchronizeCancelled;

        /// <summary>
        /// Create a new instance of StandardSynchronizer.
        /// </summary>
        public StandardSynchronizer()
        {
            // Add supported extensions.
            extensions.Add(".mp3");
            extensions.Add(".acc");
            extensions.Add(".m4p");
            extensions.Add(".m4a");
            extensions.Add(".m4v");
            extensions.Add(".m4b");
            extensions.Add(".wav");

        }

        /// <summary>
        /// <see cref="Jaranweb.iTunesAgent.ISynchronizer#SynchronizeDevice(IITUserPlaylist, string, Device)"/>
        /// </summary>
        public void SynchronizeDevice(IITUserPlaylist playlist, string drive, Device device)
        {
            //Check that configuration has been set.
            if (configuration == null)
                throw new SynchronizeException("Configuration has not been set.");

            DirectoryInfo di = new DirectoryInfo(drive + device.MediaRoot);

            // Perform a write check to make sure iTunes Agent has write 
            // access to the music folder of the device.
            String writeCheckPath = drive + device.MediaRoot + "\\wrtchk.ita";            
            try
            {                
                FileStream writeCheckStream = File.Create(writeCheckPath);
                writeCheckStream.Close();
                File.Delete(writeCheckPath);
            }
            catch (Exception e)
            {
                l.Error("Could not write " + writeCheckPath + ".", e);

                MessageBox.Show("I am unable to write to the music folder of "
                    + "your device. Please make sure I have the right permissions"
                    + " and try again.", "Unable to write to music folder", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Check if the media root directory actually exists 
            // Thanks to Robert Grabowski for the contribution.
            try
            {
                if (!di.Exists)
                    di.Create();
            }
            catch (IOException ex)
            {
                string message = "Could not create directory '"
                    + di.Name + "' for device '" + device.Name
                    + "'. Unable to complete synchronization.";
                l.Error(message, ex);
                throw new SynchronizeException(message, ex);
            }

            FileInfo[] files = di.GetFiles("*.*", SearchOption.AllDirectories);

            //Find correct synchronize pattern for the device.
            SyncPattern devicePattern = null;
            foreach (SyncPattern sp in configuration.SyncPatterns)
            {
                if (sp.Identifier == device.SyncPattern)
                    devicePattern = sp;
            }

            //Throw an exception if the pattern could not be found.
            if (devicePattern == null)
            {
                OnSynchronizeError(device, "Illegal synchronize pattern '" + device.SyncPattern + "' for device '" + device.Name + "'. Unable to complete synchronization.");
                return;
            }

            syncForm.AddLogText("Synchronizing '" + device.Name + "'...");
            syncForm.SetDeviceName(device.Name, drive);

            syncForm.SetCurrentStatus("Initializing...");
            syncForm.SetMaxProgressValue(playlist.Tracks.Count);
            syncForm.SetProgressValue(0);


            // maintain a filename -> track object dictionary for the tracks to be copied onto the device           
            // Thanks to Robert Grabowski for the contribution.
            Dictionary<string, IITFileOrCDTrack> syncList = new Dictionary<string, IITFileOrCDTrack>();

            string deviceMediaRoot = drive + (device.MediaRoot.Length > 0 ? device.MediaRoot + "\\" : "");

            try
            {
                foreach (IITTrack track in playlist.Tracks)
                {
                    if (syncForm.GetOperationCancelled())
                    {
                        syncForm.SetCurrentStatus("Synchronization cancelled. 0 tracks added, 0 tracks removed.");
                        syncForm.AddLogText("Synchronization cancelled.", Color.OrangeRed);
                        OnSynchronizeCancelled();
                        return;
                    }

                    syncForm.SetProgressValue(syncForm.GetProgressValue() + 1);

                    //Continue if the track is not of kind "file" or the track is one of the initial tracks on the device.
                    if (track.Kind != ITTrackKind.ITTrackKindFile || device.InitialTracks.Contains(track))
                        continue;


                    string pathOnDevice = "";

                    IITTrack addTrack = track;

                    try
                    {
                        pathOnDevice = SyncPatternTranslator.Translate(devicePattern, (IITFileOrCDTrack)addTrack);
                    }
                    catch (Exception ex)
                    {
                        syncForm.AddLogText("An error occured while working with \"" + track.Artist + " - " + track.Name
                            + "\". This may be because the track has been deleted from disk. Look for an exclamation mark"
                            + "next to the track in your playlist.", Color.Orange);
                        continue;
                    }
                    string fullPath = deviceMediaRoot + pathOnDevice;

                    // Check if the list already contains a key - this happens in cases where there are duplicate 
                    // entries in the playlist for the same track. Although the track may have different locations on 
                    // the user's computer, iTunes Agent will not handle this.
                    if (syncList.ContainsKey(fullPath))
                    {
                        syncForm.AddLogText("You have duplicate listings for " + track.Artist + " - " + track.Name
                            + " in your playlist. I will continue for now, but you should remove any duplicates "
                            + "when the synchronization is complete.", Color.Orange);
                        continue;
                    }

                    syncList.Add(fullPath, (IITFileOrCDTrack)addTrack);
                }
            }
            catch (Exception ex)
            {
                syncForm.SetCurrentStatus("");
                String message = "Error occured while initializing: " + ex.Message;
                syncForm.AddLogText(message, Color.Red);
                syncForm.DisableCancelButton();
                syncForm.SetProgressValue(0);
                OnSynchronizeError(device, message);

                l.Error(message, ex);
                return;
            }
            syncForm.AddLogText("Initialization completed.");

            syncForm.SetCurrentStatus("Checking tracks. Removing those that are no longer in the playlist...");
            int totalTracks = files.Length;
            syncForm.SetMaxProgressValue(totalTracks);
            syncForm.SetProgressValue(0);

            int tracksRemoved = 0;
            int tracksAdded = 0;
            long existingSize = 0;

            try
            {
                //Remove tracks from device which are no longer in the playlist.
                foreach (FileInfo file in files)
                {
                    // Check for cancelled operation.
                    if (syncForm.GetOperationCancelled())
                    {
                        syncForm.SetCurrentStatus("Synchronization cancelled. " + tracksAdded
                            + " track(s) added, " + tracksRemoved + " track(s) removed.");
                        syncForm.AddLogText("Synchronization cancelled.", Color.OrangeRed);
                        OnSynchronizeCancelled();
                        return;
                    }

                    //Increase progress bar
                    syncForm.SetProgressValue(syncForm.GetProgressValue() + 1);

                    //Continue with next track if it is not of a supported extension.
                    //if (file.Extension != ".mp3" && file.Extension != ".acc" && file.Extension != ".m4p" && file.Extension != ".m4a")
                    if (!extensions.Contains(file.Extension))
                        continue;

                    if (syncList.ContainsKey(file.FullName))
                    {
                        FileInfo fi = new FileInfo(file.FullName);
                        existingSize += fi.Length;
                        continue;
                    }

                    //If the track was not found --- delete it!
                    string fileFullName = file.FullName;
                    file.Delete();
                    CheckAndRemoveFolders(fileFullName, drive, device);

                    tracksRemoved++;

                }

                syncForm.AddLogText(tracksRemoved + " track(s) was removed from the device.",
                    Color.Orange);
            }
            catch (MissingTrackException ex)
            {
                syncForm.SetCurrentStatus("");
                String message = "You have a missing file in your library. Please clean up "
                    + "your playlist and remove the track '" + ex.Track.Artist + " - " 
                    + ex.Track.Name + "' before re-synchronizing.";
                syncForm.AddLogText(message, Color.Red);
                syncForm.DisableCancelButton();
                syncForm.SetProgressValue(0);
                OnSynchronizeError(device, message);

                l.Error(message, ex);

                return;
            }
            catch (Exception ex)
            {
                syncForm.SetCurrentStatus("");
                String message = "Error occured while checking for deleted tracks: " + ex.Message;
                syncForm.AddLogText(message, Color.Red);
                syncForm.DisableCancelButton();
                syncForm.SetProgressValue(0);
                OnSynchronizeError(device, message);

                l.Error(message, ex);
                return;
            }

            files = null;

            // Check free space on the device
            double playlistSize = playlist.Size;
            DriveInfo driveInfo = new DriveInfo(drive.Substring(0, 1));
            long freeOnDisk = driveInfo.AvailableFreeSpace;

            if (freeOnDisk < playlistSize - existingSize)
            {
                string message = "There is not enough space on your device to synchronize the playlist.";
                OnSynchronizeError(device, message);
                syncForm.AddLogText(message, Color.Red);
                syncForm.SetCurrentStatus(message);
                syncForm.DisableCancelButton();
                syncForm.SetProgressValue(0);
                return;
            }

            try
            {
                syncForm.SetCurrentStatus("Copying new files...");
                syncForm.AddLogText("Preparing to copy new files.", Color.Black);
                syncForm.SetMaxProgressValue(playlist.Tracks.Count);
                syncForm.SetProgressValue(0);

                //Check for new track in the playlist which should be copied to the device
                // NEW foreach: traverse synchronization list instead of playlist
                // Thanks to Robert Grabowski.                
                foreach (string filePath in syncList.Keys)
                {
                    IITTrack track = syncList[filePath];

                    // Check for cancelled operation.
                    if (syncForm.GetOperationCancelled())
                    {
                        syncForm.SetCurrentStatus("Synchronization cancelled. " + tracksAdded
                            + " track(s) added, " + tracksRemoved + " track(s) removed.");
                        syncForm.AddLogText("Synchronization cancelled.", Color.OrangeRed);
                        syncForm.DisableCancelButton();
                        syncForm.SetProgressValue(0);
                        OnSynchronizeCancelled();
                        return;
                    }


                    //Increase progress bar
                    syncForm.SetProgressValue(syncForm.GetProgressValue() + 1);

                    string trackPath = filePath.Substring(deviceMediaRoot.Length); // hack: cut out media root

                    if (File.Exists(filePath))
                        continue;

                    try
                    {
                        CheckAndCreateFolders(trackPath, drive, device);
                        syncForm.SetCurrentStatus("Copying " + filePath
                            + " (" + syncForm.GetProgressValue() + "/" + syncForm.GetMaxProgressValue() + ")");

                        File.Copy(((IITFileOrCDTrack)track).Location, filePath, true);
                        File.SetAttributes(filePath, FileAttributes.Normal);


                        syncForm.AddLogText(filePath + " copied successfully.", Color.Green);

                    }
                    catch (Exception ex)
                    {
                        String message = "Failed to copy " + filePath + ".\n-> " + ex.Message;
                        syncForm.AddLogText(message, Color.Red);
                        OnSynchronizeError(device, message);

                        l.Error(message, ex);

                        return;
                    }

                    tracksAdded++;

                }
            }
            catch (MissingTrackException ex)
            {
                syncForm.SetCurrentStatus("");
                String message = "You have a missing file in your library. Please remove the track '" + ex.Track.Artist + " - " + ex.Track.Name + "' and try again. I am sorry for the inconvenience.";
                syncForm.AddLogText(message, Color.Red);
                syncForm.DisableCancelButton();
                syncForm.SetProgressValue(0);
                OnSynchronizeError(device, message);

                l.Error(message, ex);

                return;
            }
            catch (Exception ex)
            {
                string message = "An error occured while copying new tracks: " + ex.Message;
                syncForm.SetCurrentStatus("");
                syncForm.AddLogText(message,
                    Color.Red);
                syncForm.DisableCancelButton();
                syncForm.SetProgressValue(0);
                OnSynchronizeError(device, message);

                l.Error(message, ex);

                return;
            }

            syncForm.SetCurrentStatus("Synchronization completed. " + tracksAdded
                + " track(s) added, " + tracksRemoved + " track(s) removed.");
            syncForm.AddLogText("Completed. " + tracksAdded + " track(s) copied to your device.", Color.Green);
            syncForm.DisableCancelButton();
            OnSynchronizeComplete();

        }


        /// <summary>
        /// Check if the necessary folders for the given track exists. If not, create them.
        /// </summary>
        /// <param name="trackPath">The path of the track, relative to the device media root.</param>
        /// <param name="drive">The drive where the device is located.</param>
        /// <param name="device">Device information.</param>
        private void CheckAndCreateFolders(string trackPath, string drive, Device device)
        {
            string[] folders = trackPath.Split('\\');
            string directoryPath = drive + device.MediaRoot;
            for (int f = 0; f < folders.Length - 1; f++)
            {
                string folder = folders[f];
                directoryPath += "\\" + folder;
                if (Directory.Exists(directoryPath))
                    continue;

                Directory.CreateDirectory(directoryPath);

            }

        }

        /// <summary>
        /// Check if the folder for the current artist/album is empty. If it is, then remove it.
        /// </summary>
        /// <param name="trackPath"></param>
        /// <param name="drive"></param>
        /// <param name="device"></param>
        private void CheckAndRemoveFolders(string trackPath, string drive, Device device)
        {
            if (device.MediaRoot.Length == 0)
                trackPath = trackPath.Replace(drive, "");
            else
                trackPath = trackPath.Replace(drive + device.MediaRoot + "\\", "");

            string[] folders = trackPath.Split('\\');
            string directoryPath = drive + device.MediaRoot;
            for (int f = folders.Length - 2; f >= 0; f--)
            {
                string parents = "";
                for (int pf = 0; pf < f; pf++)
                    parents += "\\" + folders[pf];

                string dirToDelete = directoryPath + parents + "\\" + folders[f];
                try
                {
                    DirectoryInfo di = new DirectoryInfo(dirToDelete);
                    if (di.GetFiles().Length == 0 && di.GetDirectories().Length == 0)
                        di.Delete();
                }
                catch (Exception ex)
                {
                    l.Error(ex);
                    throw new SynchronizeException("Unable to delete empty folder on device.", ex);
                }
            }
        }

        /// <summary>
        /// Get / Set whether the gui should be shown.
        /// </summary>
        public bool ShowGui
        {
            get
            {
                return showGui;
            }
            set
            {
                showGui = value;
            }
        }

        /// <summary>
        /// Get value indicating if the synchronizer has a GUI.
        /// </summary>
        public bool HasGui
        {
            get
            {
                return hasGui;
            }
        }

        /// <summary>
        /// Get / Set the DeviceConfiguration for the Synchronizer
        /// </summary>
        public DeviceConfiguration Configuration
        {
            get
            {
                return configuration;
            }
            set
            {
                configuration = value;
            }
        }

        /// <summary>
        /// Event dispatcher for SynchronizeError events.
        /// </summary>
        /// <param name="device">The device that failed.</param>
        /// <param name="message">An error message.</param>
        protected void OnSynchronizeError(Device device, string message)
        {
            if (SynchronizeError != null)
            {
                SyncErrorArgs args = new SyncErrorArgs();
                args.Device = device;
                args.ErrorMessage = message;

                SynchronizeError(this, args);
            }
        }

        /// <summary>
        /// Event dispatcher for SynchronizeComplete.
        /// </summary>
        protected void OnSynchronizeComplete()
        {
            if (SynchronizeComplete != null)
            {
                SynchronizeComplete(this);
            }
        }

        /// <summary>
        /// Event dispatcher for SynchronizeCancelled.
        /// </summary>
        protected void OnSynchronizeCancelled()
        {
            if (SynchronizeCancelled != null)
            {
                SynchronizeCancelled(this);
            }
        }

        /// <summary>
        /// Set or get the ISynchronizeForm used by this synchronizer.
        /// </summary>
        public ISynchronizeForm Form
        {
            get
            {
                return syncForm;
            }
            set
            {
                syncForm = value;
            }
        }

        #endregion
    }
}
