using System;
using System.Collections.Generic;
using System.Text;

namespace Notpod.Configuration12
{
    public class SyncPattern
    {
        private string identifier;

        private string name;

        private string pattern;

        private string description;

        private string compilationsPattern;

        /// <summary>
        /// Accessor for identifier.
        /// </summary>
        public string Identifier
        {
            get { return identifier; }
            set { identifier = value; }
        }

        /// <summary>
        /// Accessor for name.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Accessor for pattern.
        /// </summary>
        public string Pattern
        {
            get { return pattern; }
            set { pattern = value; }
        }

        /// <summary>
        /// Accessor for description.
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// Accessor for collectionsPattern.
        /// </summary>
        public string CompilationsPattern
        {
            get { return compilationsPattern; }
            set { compilationsPattern = value; }
        }
        
    }
}
