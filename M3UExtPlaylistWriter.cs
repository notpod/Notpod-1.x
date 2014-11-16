using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using iTunesLib;

namespace Notpod
{
    /// <summary>
    /// Creates an M3U playlist in the Extended format. This format is described at
    /// these URLs:
    ///         http://hanna.pyxidis.org/tech/m3u.html
    ///         http://en.wikipedia.org/wiki/M3U
    ///         http://www.assistanttools.com/articles/m3u_playlist_format.shtml
    /// </summary>
    class M3UExtPlaylistWriter : IPlaylistWriter
    {        
        private StreamWriter _writer;
        private string _thePlaylist;

        private const string FILE_HEADER = "#EXTM3U";
        private const string LINE_FORMAT_STRING = "{0}{1}, {2} - {3}";
        private const string LINE_PREFIX = "#EXTINF:";

        public M3UExtPlaylistWriter(string fileName, string playlist) : base(fileName, playlist)
        {            
            _thePlaylist = playlist;
            _writer = new StreamWriter(fileName, false, System.Text.Encoding.GetEncoding("utf-8"));

            /// File format requires a single line header
            _writer.WriteLine(FILE_HEADER);
        }

        public override void WriteTrack(string trackName, IITTrack track)
        {
            /// Each track has two lines in the playlist file. The first contains
            /// display info (seconds, name), plus the path/filename.
            _writer.WriteLine(string.Format(LINE_FORMAT_STRING, LINE_PREFIX, track.Time.ToString(), track.Artist, track.Name));
            _writer.WriteLine(trackName);
        }

        public override void Close()
        {
            _writer.Close();
            _writer.Dispose();
        }
    }
}
