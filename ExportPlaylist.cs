using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Xml.Serialization;

namespace Notpod.Configuration12
{
    public class ExportPlaylist
    {
        public ExportPlaylist()
        {
            Type = PlaylistType.None;
        }

        /// <summary>
        /// Accessor for Type.
        /// </summary>
        [XmlElement("Type", typeof(PlaylistType))]
        public PlaylistType Type { get; set; }

        /// <summary>
        /// Accessor for File.
        /// </summary>
        [XmlElement("File")]
        public String File { get; set; }
    }
}
