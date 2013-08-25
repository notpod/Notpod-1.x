using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

using iTunesLib;

namespace Notpod
{
    /// <summary>
    /// Generates playlist files in the WPL playlist format used by Windows Media Player.
    /// </summary>
    class WPLPlaylistWriter : IPlaylistWriter
    {
        private XmlWriter xmlWriter;

        public WPLPlaylistWriter(string fileName, string playlist) : base(fileName, playlist)
        {            
            xmlWriter = new XmlTextWriter(fileName, System.Text.Encoding.GetEncoding("utf-8"));

            xmlWriter.WriteRaw("<?wpl version=\"1.0\"?>\n");
            xmlWriter.WriteStartElement("smil");
            xmlWriter.WriteStartElement("head");
            xmlWriter.WriteElementString("author", "");
            xmlWriter.WriteElementString("title", playlist);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("body");
            xmlWriter.WriteStartElement("seq");
        }

        public override void WriteTrack(string trackName, IITTrack track)
        {
            xmlWriter.WriteStartElement("media");
            xmlWriter.WriteAttributeString("src", trackName);
            xmlWriter.WriteEndElement();
        }

        public override void Close()
        {
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.Close();
        }
    }
}
