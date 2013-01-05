using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notpod
{
    public class MediaLocation
    {
        
        public string LocationIdentifier { get; set; }

        public string LocationName { get; set; }

        public MediaLocation()
        {

        }

        public MediaLocation(string name, string identifier)
        {
            this.LocationName = name;
            this.LocationIdentifier = identifier;
        }
    }
}
