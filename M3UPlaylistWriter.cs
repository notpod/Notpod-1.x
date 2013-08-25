using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using iTunesLib;

namespace Notpod
{
    /// <summary>
    /// Generates basic M3U playlist files.
    /// </summary>
    class M3UPlaylistWriter : IPlaylistWriter
    {
        private StreamWriter writer;

        public M3UPlaylistWriter(String fileName, string playlist ) : base(fileName, playlist)
        {            
            writer = new StreamWriter(fileName, false, System.Text.Encoding.GetEncoding("utf-8"));
        }

        public override void WriteTrack(string trackName, IITTrack track)
        {
            writer.WriteLine( trackName );
        }

        public override void Close()
        {
            writer.Close();
        }
    }
}
