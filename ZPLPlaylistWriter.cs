using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

using iTunesLib;

namespace Notpod
{
    /// <summary>
    /// Generates playlist files in the ZPL playlist format used by Microsoft Zune Media Player.
    /// </summary>
    class ZPLPlaylistWriter : IPlaylistWriter
    {
        private XmlWriter xmlWriter;

        public ZPLPlaylistWriter(string fileName, string playlist) : base(fileName, playlist)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            settings.Encoding = System.Text.Encoding.GetEncoding("utf-8");

            xmlWriter = XmlWriter.Create(fileName, settings);

            xmlWriter.WriteRaw("<?zpl version=\"1.0\"?>\n");
            xmlWriter.WriteStartElement("smil");
            xmlWriter.WriteStartElement("head");

            xmlWriter.WriteStartElement("meta");
            xmlWriter.WriteAttributeString("name", "Generator");
            xmlWriter.WriteAttributeString("content", "Zune -- 1.3.5728.0");
            xmlWriter.WriteEndElement();

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
