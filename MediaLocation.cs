using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notpod
{
    public class MediaLocation
    {
        
        public string LocationIdentifier { get; set; }
        
        public string LocationParentIdentifier { get; set; }

        public string LocationPersistentIdentifier { get; set; }

        public string LocationName { get; set; }

        public MediaLocation()
        {

        }

        public MediaLocation(string name, string parent, string identifier)
        {
            this.LocationName = name;
            this.LocationParentIdentifier = parent;
            this.LocationIdentifier = identifier;
        }
    }
}
