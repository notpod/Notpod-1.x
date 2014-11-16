using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Xml.Serialization;

namespace Notpod.Configuration12
{
    public class Device
    {
        public Device() {
            ExportPlaylist = new ExportPlaylist();
            InitialTracks = new ArrayList();
        }

        /// <summary>
        /// Accessor for name.
        /// </summary>
        [XmlElement]
        public string Name { get; set; }
        
        /// <summary>
        /// Accessor for mediaRoot.
        /// </summary>
        [XmlElement]
        public string MediaRoot { get; set; }

        /// <summary>
        /// Accessor for syncPattern.
        /// </summary>
        [XmlElement]
        public string SyncPattern { get; set; }

        /// <summary>
        /// Accessor for recognizePattern.
        /// </summary>
        [XmlElement]
        public string RecognizePattern { get; set; }

        /// <summary>
        /// Accessor for playlist.
        /// </summary>
        [XmlElement]
        public string Playlist { get; set; }

        /// <summary>
        /// Accessor for ExportPlaylist.
        /// </summary>
        /// 
        [XmlElement(typeof(ExportPlaylist))]
        public ExportPlaylist ExportPlaylist { get; set; }

        /// <summary>
        /// Accessor for intialTracks.
        /// </summary>
        [XmlIgnore]
        public ArrayList InitialTracks { get; set; }
    }
}
