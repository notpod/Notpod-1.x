using System;
using System.Collections;
using System.Text;
using iTunesLib;
using Jaranweb.iTunesAgent.DeviceRec;
using System.IO;
using Jaranweb.Xml.Configuration;

namespace Jaranweb.iTunesAgent
{
    public delegate void SynchronizeDeviceCompleteEventHandler();
    public delegate void SynchronizeDeviceErrorEventHandler(string message, Device device);

    /// <summary>
    /// Class which sychronizes your devices with the iTunes playlist.
    /// </summary>
    public class DeviceSynchronizer
    {
        private iTunesApp itunes;
        private Hashtable devices;
        private XmlConfiguration configuration;

        public event SynchronizeDeviceCompleteEventHandler SynchronizeComplete;
        public event SynchronizeDeviceErrorEventHandler SynchronizeError;
        /// <summary>
        /// Create a new instance of iTunes.
        /// </summary>
        /// <param name="itunes">iTunes application handle.</param>
        /// <param name="devices">List of devices to synchronize.</param>
        /// <param name="configuration">XML configuration</param>
        public DeviceSynchronizer(iTunesApp itunes, Hashtable devices, XmlConfiguration configuration)
        {
            this.itunes = itunes;
            this.devices = devices;
            this.configuration = configuration;

            //Check that necessary configuration is available.
            if (configuration.GetValue("SyncModule/FileStructure") == null ||
                configuration.GetValue("SyncModule/Priority") == null)
                throw new ArgumentException("Missing necessary configuration.");
        }

        /// <summary>
        /// Synchronize the player with iTunes.
        /// </summary>
        public void Synchronize()
        {
            IEnumerator e = devices.Keys.GetEnumerator();
            while (e.MoveNext())
            {
                //Get drive letter
                string driveletter = ((string)e.Current).Substring(0, 1);

                Device device = (Device)devices[e.Current];
                string usepath = GetWorkingPath(driveletter, device.Folderpattern);
                
                //check that we have a path to use, report error if not
                if (usepath == null)
                    OnSynchronizeError("Could not locate the correct folder on the device.", device);
                else
                {
                    foreach (IITSource source in itunes.Sources)
                    {
                        foreach (IITPlaylist playlist in source.Playlists)
                        {
                            if (playlist.Name != device.Name)
                                continue;

                            foreach (IITTrack track in playlist.Tracks)
                            {
                                //Check that the track is a file. iTA currently only supports synchronization of files.
                                if (track.Kind != ITTrackKind.ITTrackKindFile)
                                {
                                    OnSynchronizeError("The track '" + track.Artist + " - " + track.Name
                                        + " can not be copied. iTunes Agent currently only supports synchronization "
                                        + "of music files, not CD-tracks or other types of media.", device);
                                    continue;
                                }

                                IITFileOrCDTrack fileTrack = (IITFileOrCDTrack)track;
                                string playerFileName = GetPlayerLocation(fileTrack);
                                                                                                        
                                string priority = configuration.GetValue("SyncModule/Priority");
                                //Priority == itunes means that only the files in the playlist in iTunes will be available on 
                                //the device. All other music files in the media folder for the device will be removed!
                                if (priority == "itunes")
                                {
                                    DirectoryInfo di = new DirectoryInfo(usepath);
                                    FileInfo[] files = di.GetFiles("*", SearchOption.AllDirectories);

                                }
                                else
                                {
                                    string fullPathOnDevice = usepath + "\\" + playerFileName;
                                    if (File.Exists(fullPathOnDevice))
                                        continue;
                                    
                                    try
                                    {
                                        ConstructDirectories(usepath, playerFileName);
                                        File.Copy(fileTrack.Location, fullPathOnDevice);
                                    }
                                    catch (Exception ex)
                                    {
                                        OnSynchronizeError("Failed to copy '" + fileTrack.Artist + " - " + fileTrack.Name 
                                            + "' (" + ex.Message + ").", device);
                                    }                                        
                                }

                            }

                        }
                    }
                }

            }

            OnSynchronizeComplete();
        }

        /// <summary>
        /// Construct the necessary paths on the device.
        /// </summary>
        /// <param name="mediafolder">The media root folder.</param>
        /// <param name="filepath">The path of the file on the device, relative to the 
        /// media folder.</param>
        private void ConstructDirectories(string mediafolder, string filepath)
        {

            string[] parts = filepath.Split('\\');
            for(int d = 0; d < parts.Length-1; d++)
            {
                string dir = parts[d];
                if(Directory.Exists(mediafolder + "\\" + dir))
                    continue;

                mediafolder += "\\" + dir;
                Directory.CreateDirectory(mediafolder);

            }

        }

        /// <summary>
        /// Generates the filename the way it will be stored on the device.
        /// </summary>
        /// <param name="track">Track to generate name for.</param>
        /// <returns>File name for the device.</returns>
        private string GetPlayerLocation(IITFileOrCDTrack track)
        {
            string structure = configuration.GetValue("SyncModule/FileStructure");
            if (structure == "organized")
                return track.Artist + " - " + track.Album + "\\" + (track.TrackNumber > 0 ? (track.TrackNumber < 9 ? "0" + track.TrackNumber.ToString() : track.TrackNumber.ToString()) + " " : "") + track.Name + GetExtension(track.Location);
            else
                return track.Artist + " - " + track.Name + GetExtension(track.Location);
        }

        /// <summary>
        /// Get the extension of a file.
        /// </summary>
        /// <param name="file">File path</param>
        /// <returns>The extension of a file.</returns>
        private string GetExtension(string file)
        {
            int dotindex = file.LastIndexOf(".");
            return file.Substring(dotindex, file.Length - dotindex);
        }

        /// <summary>
        /// Get the first path which exists for the device, if it has more 
        /// than one path in the folderpattern.
        /// </summary>
        /// <param name="driveletter">Drive letter.</param>
        /// <param name="folderpattern">Folder pattern.</param>
        /// <returns>The first path existing on the device.</returns>
        private string GetWorkingPath(string driveletter, string folderpattern)
        {
            string[] patterns = folderpattern.Split(',');
            foreach(string pattern in patterns)
            {
                string path = pattern.Replace("%", driveletter);

                //Remove trailing slash
                path.TrimEnd(new char[] { '\\', '/' });
                if(Directory.Exists(path))
                    return path;
            }

            return null;
        }

        protected virtual void OnSynchronizeComplete()
        {
            if (SynchronizeComplete != null)
                SynchronizeComplete();
        }

        protected virtual void OnSynchronizeError(string message, Device device)
        {
            if (SynchronizeError != null)
                SynchronizeError(message, device);
        }
    }
}
