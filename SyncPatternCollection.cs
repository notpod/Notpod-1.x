using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Notpod.Configuration12
{
    [XmlRoot]
    public class SyncPatternCollection
    {

        public SyncPatternCollection()
        {
            SyncPatterns = new List<SyncPattern>();
        }

        /// <summary>
        /// Accessor for SyncPatterns.
        /// </summary>
        [XmlArray("SyncPatterns")]
        [XmlArrayItem("SyncPattern")]
        public List<SyncPattern> SyncPatterns { get; set; }

    }
}
