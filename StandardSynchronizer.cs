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
using Notpod.Configuration12;
using System.Security.AccessControl;
using Common.Logging;
using WindowsPortableDevicesLib.Domain;

namespace Notpod
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
        /// <see cref="Notpod.ISynchronizer#SynchronizeDevice(IITUserPlaylist, string, Device)"/>
        /// </summary>
        public void SynchronizeDevice(IITUserPlaylist playlist, WindowsPortableDevice portableDevice, Device deviceConfig)
        {
            //Check that configuration has been set.
            if (configuration == null)
                throw new SynchronizeException("Configuration has not been set.");

            l.DebugFormat("Checking if media location exists on device {0}", deviceConfig.Name);
            try
            {

                string parentIdentifier = deviceConfig.MediaLocation.LocationParentIdentifier;
                string folderIdentifier = deviceConfig.MediaLocation.LocationIdentifier;
                if (portableDevice.DeviceType == WpdDeviceTypes.WPD_DEVICE_TYPE_GENERIC)
                {
                    // Due to the setup of GENERIC devices, the first "drive" below the device root indicates the drive letter for the device 
                    // once it's connected to the system. For these devices we use this to build the rest of the path.
                    PortableDeviceFolder deviceRoot = portableDevice.GetContents();
                    PortableDeviceObject firstDrive = deviceRoot.Files[0];
                    parentIdentifier = firstDrive.Id;
                    folderIdentifier = parentIdentifier + folderIdentifier;
                }
                PortableDeviceFolder folder = portableDevice.GetFolder(parentIdentifier, folderIdentifier);
                if (folder == null)
                {
                    MessageBox.Show(String.Format("The configured media location \"{0}\" does not exist on the device {1}. Please ensure the path exists and try again.",
                        deviceConfig.MediaLocation.LocationName, deviceConfig.Name), "Unable to find media location", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                l.DebugFormat("Location {0} ({1}/{2}) found on device {3}.", deviceConfig.MediaLocation.LocationName, parentIdentifier, folderIdentifier, deviceConfig.Name);
            }
            catch (Exception ex)
            {
                l.ErrorFormat("An error occured while checking configured device folder (parent={0}, id={1}) for device{2}.", deviceConfig.MediaLocation.LocationParentIdentifier,
                    deviceConfig.MediaLocation.LocationIdentifier, deviceConfig.Name);
                l.Error("Exception: ", ex);
                if (MessageBox.Show("An error occured while checking media location on device. Please make sure the device is connected and that the media location exists.",
                    "Media location", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.Cancel)
                {

                    return;
                }

            }



            // Check if the media root directory actually exists 
            // Thanks to Robert Grabowski for the contribution.

            //Find correct synchronize pattern for the device.
            SyncPattern devicePattern = null;
            foreach (SyncPattern sp in configuration.SyncPattern)
            {
                if (sp.Identifier == deviceConfig.SyncPattern)
                    devicePattern = sp;
            }

            //Throw an exception if the pattern could not be found.
            if (devicePattern == null)
            {
                OnSynchronizeError(deviceConfig, "Illegal synchronize pattern '" + deviceConfig.SyncPattern + "' for device '" + deviceConfig.Name + "'. Unable to complete synchronization.");
                return;
            }

            syncForm.AddLogText("Synchronizing '" + deviceConfig.Name + "'...");
            syncForm.SetDeviceName(deviceConfig.Name, null);

            syncForm.SetCurrentStatus("Initializing...");
            syncForm.SetMaxProgressValue(playlist.Tracks.Count);
            syncForm.SetProgressValue(0);


            // maintain a filename -> track object dictionary for the tracks to be copied onto the device           
            // Thanks to Robert Grabowski for the contribution.
            Dictionary<string, IITFileOrCDTrack> syncList = new Dictionary<string, IITFileOrCDTrack>();

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
                    if (track.Kind != ITTrackKind.ITTrackKindFile)
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

                    // Check if the list already contains a key - this happens in cases where there are duplicate 
                    // entries in the playlist for the same track. Although the track may have different locations on 
                    // the user's computer, Notpod will not handle this.
                    if (syncList.ContainsKey(pathOnDevice))
                    {
                        syncForm.AddLogText("You have duplicate listings for " + track.Artist + " - " + track.Name
                            + " in your playlist. I will continue for now, but you should remove any duplicates "
                            + "when the synchronization is complete.", Color.Orange);
                        continue;
                    }

                    syncList.Add(pathOnDevice, (IITFileOrCDTrack)addTrack);
                }
            }
            catch (Exception ex)
            {
                syncForm.SetCurrentStatus("");
                String message = "Error occured while initializing: " + ex.Message;
                syncForm.AddLogText(message, Color.Red);
                syncForm.DisableCancelButton();
                syncForm.SetProgressValue(0);
                OnSynchronizeError(deviceConfig, message);

                l.Error(message, ex);
                return;
            }
            syncForm.AddLogText("Initialization completed.");

            //syncForm.SetCurrentStatus("Checking tracks. Removing those that are no longer in the playlist...");
            //int totalTracks = files.Length;
            //syncForm.SetMaxProgressValue(totalTracks);
            //syncForm.SetProgressValue(0);

            int tracksRemoved = 0;
            int tracksAdded = 0;
            long existingSize = 0;

            //try
            //{
            //    //Remove tracks from device which are no longer in the playlist.
            //    foreach (FileInfo file in files)
            //    {
            //        l.Debug("Checking file: " + file.FullName);

            //        // Check for cancelled operation.
            //        if (syncForm.GetOperationCancelled())
            //        {
            //            syncForm.SetCurrentStatus("Synchronization cancelled. " + tracksAdded
            //                + " track(s) added, " + tracksRemoved + " track(s) removed.");
            //            syncForm.AddLogText("Synchronization cancelled.", Color.OrangeRed);
            //            OnSynchronizeCancelled();
            //            return;
            //        }

            //        //Increase progress bar
            //        syncForm.SetProgressValue(syncForm.GetProgressValue() + 1);

            //        //Continue with next track if it is not of a supported extension.
            //        //if (file.Extension != ".mp3" && file.Extension != ".acc" && file.Extension != ".m4p" && file.Extension != ".m4a")
            //        if (!extensions.Contains(file.Extension))
            //            continue;

            //        if (syncList.ContainsKey(file.FullName))
            //        {
            //            FileInfo fi = new FileInfo(file.FullName);
            //            existingSize += fi.Length;
            //            continue;
            //        }

            //        //If the track was not found --- delete it!
            //        string fileFullName = file.FullName;
            //        file.Delete();

            //        l.Debug("Removing file no longer in playlist: " + fileFullName);

            //        CheckAndRemoveFolders(fileFullName, drive, deviceConfig);

            //        tracksRemoved++;

            //    }

            //    syncForm.AddLogText(tracksRemoved + " track(s) was removed from the device.",
            //        Color.Orange);
            //}
            //catch (MissingTrackException ex)
            //{
            //    syncForm.SetCurrentStatus("");
            //    String message = "You have a missing file in your library. Please clean up "
            //        + "your playlist and remove the track '" + ex.Track.Artist + " - "
            //        + ex.Track.Name + "' before re-synchronizing.";
            //    syncForm.AddLogText(message, Color.Red);
            //    syncForm.DisableCancelButton();
            //    syncForm.SetProgressValue(0);
            //    OnSynchronizeError(deviceConfig, message);

            //    l.Error(message, ex);

            //    return;
            //}
            //catch (Exception ex)
            //{
            //    syncForm.SetCurrentStatus("");
            //    String message = "Error occured while checking for deleted tracks: " + ex.Message;
            //    syncForm.AddLogText(message, Color.Red);
            //    syncForm.DisableCancelButton();
            //    syncForm.SetProgressValue(0);
            //    OnSynchronizeError(deviceConfig, message);

            //    l.Error(message, ex);
            //    return;
            //}

            //files = null;

            //// Check free space on the device
            //double playlistSize = playlist.Size;
            //DriveInfo driveInfo = new DriveInfo(drive.Substring(0, 1));
            //long freeOnDisk = driveInfo.AvailableFreeSpace;

            //if (freeOnDisk < playlistSize - existingSize)
            //{
            //    string message = "There is not enough space on your device to synchronize the playlist.";
            //    OnSynchronizeError(deviceConfig, message);
            //    syncForm.AddLogText(message, Color.Red);
            //    syncForm.SetCurrentStatus(message);
            //    syncForm.DisableCancelButton();
            //    syncForm.SetProgressValue(0);
            //    return;
            //}

            try
            {
                syncForm.SetCurrentStatus("Copying new files...");
                syncForm.AddLogText("Preparing to copy new files.", Color.Black);
                syncForm.SetMaxProgressValue(syncList.Count);
                syncForm.SetProgressValue(0);

                string mediaLocationId = deviceConfig.MediaLocation.LocationIdentifier;
                string mediaLocationParentId = deviceConfig.MediaLocation.LocationParentIdentifier;
                if (portableDevice.DeviceType == WpdDeviceTypes.WPD_DEVICE_TYPE_GENERIC)
                {
                    PortableDeviceFolder deviceRoot = portableDevice.GetContents();
                    PortableDeviceFolder root = (PortableDeviceFolder)deviceRoot.Files[0];
                    mediaLocationId = root.Id + mediaLocationId;
                    mediaLocationParentId = root.Id + mediaLocationParentId;

                }

                PortableDeviceFolder mediaRootFolder = portableDevice.GetFolder(mediaLocationParentId, mediaLocationId);

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

                    l.Debug("Working with file: " + filePath);

                    PortableDeviceFolder currentFolder = mediaRootFolder;

                    string[] pathSegments = filePath.Split('\\');
                    if (pathSegments.Length > 1)
                    {
                        string currentPath = mediaLocationId;
                        for (int i = 0; i < pathSegments.Length - 1; i++)
                        {
                            string pathSegment = pathSegments[i];
                            currentPath += "\\" + pathSegment;
                            PortableDeviceFolder segmentPortableDeviceFolder = portableDevice.GetFolder(currentFolder.Id, currentPath);
                            if (segmentPortableDeviceFolder == null)
                            {
                                l.DebugFormat("Segment does not exist: {0}. Attempting to create.", pathSegment);

                                string newFolderId = portableDevice.CreateFolder(currentFolder.Id, pathSegment);
                                currentFolder = portableDevice.GetFolder(currentFolder.Id, newFolderId);

                            }
                            else
                            {
                                l.DebugFormat("Segment found: {0}", pathSegment);
                                currentFolder = segmentPortableDeviceFolder;
                            }

                        }
                    }

                    try
                    {
                        syncForm.SetCurrentStatus("Copying " + filePath
                            + " (" + syncForm.GetProgressValue() + "/" + syncForm.GetMaxProgressValue() + ")");

                        portableDevice.TransferContentToDevice(((IITFileOrCDTrack)track).Location, currentFolder.Id);

                        syncForm.AddLogText(filePath + " copied successfully.", Color.Green);

                        l.Debug("Copied: " + filePath);
                    }
                    catch (Exception ex)
                    {
                        String message = "Failed to copy " + filePath + ".\n-> " + ex.Message;
                        syncForm.AddLogText(message, Color.Red);
                        OnSynchronizeError(deviceConfig, message);

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
                OnSynchronizeError(deviceConfig, message);

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
                OnSynchronizeError(deviceConfig, message);

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

                l.Debug("Creating folder " + directoryPath);

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
