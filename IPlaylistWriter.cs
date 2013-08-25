using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using iTunesLib;

namespace Notpod
{
    /// <summary>
    /// Provides common functionality to playlist writer implementations.
    /// </summary>
    abstract class IPlaylistWriter
    {
        protected string fileName;
        protected string playlist;

        public IPlaylistWriter(string fileName, string playlist)
        {
            // Cleans up playlists with * characters in name.
            this.fileName = fileName.Replace('*', '_');            
            this.playlist = playlist;
        }

        /// <summary>
        /// Writes the passed track to the current playlist file.
        /// </summary>
        /// <param name="trackName">The display name details for the track.</param>
        /// <param name="track">Typed reference for the track, providing additional data.</param>
        public abstract void WriteTrack( string trackName, IITTrack track );

        /// <summary>
        /// Closes the file handle for the playlist being written.
        /// </summary>
        public abstract void Close();

        /// <summary>
        /// Deletes the current playlist file from disk.
        /// </summary>
        public void Delete()
        {
            new FileInfo(fileName).Delete();
        }
    }
}
