using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Xml.Serialization;

namespace Notpod.Configuration12
{
    public enum PlaylistType {
        [XmlEnum(Name = "None")]
        None = 0,
        [XmlEnum(Name = "M3U")]
        M3U = 1,
        [XmlEnum(Name = "EXT")]
        EXT = 2,
        [XmlEnum(Name = "WPL")]
        WPL = 3,
        [XmlEnum(Name = "ZPL")]
        ZPL = 4
    };
}
