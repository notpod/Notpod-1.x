using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Xml.Serialization;

namespace Notpod.Configuration12
{
    public class Device
    {
        private string name;

        private string mediaRoot;

        private string syncPattern;

        private string recognizePattern;

        private string playlist;

        private ArrayList initialTracks = new ArrayList();

        /// <summary>
        /// Accessor for name.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        /// <summary>
        /// Accessor for mediaRoot.
        /// </summary>
        public string MediaRoot
        {
            get { return mediaRoot; }
            set { mediaRoot = value; }
        }

        /// <summary>
        /// Accessor for syncPattern.
        /// </summary>
        public string SyncPattern
        {
            get { return syncPattern; }
            set { syncPattern = value; }
        }

        /// <summary>
        /// Accessor for recognizePattern.
        /// </summary>
        public string RecognizePattern
        {
            get { return recognizePattern; }
            set { recognizePattern = value; }
        }

        /// <summary>
        /// Accessor for playlist.
        /// </summary>
        public string Playlist
        {
            get { return playlist; }
            set { playlist = value; }
        }

        /// <summary>
        /// Accessor for intialTracks.
        /// </summary>
        [XmlIgnore]
        public ArrayList InitialTracks
        {
            get { return initialTracks; }
            set { initialTracks = value; }
        }
    }
}
