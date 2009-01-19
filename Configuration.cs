using System;
using System.Collections.Generic;
using System.Text;

namespace Jaranweb.iTunesAgent.Configuration12
{
    /// <summary>
    /// Application configuration class.
    /// </summary>
    public class Configuration
    {

        private bool showNotificationPopups;

        private bool useListFolder;

        private bool closeSyncWindowOnSuccess = true;

        /// <summary>
        /// Accessor for showNotificationPopups.
        /// </summary>
        public bool ShowNotificationPopups
        {
            get { return showNotificationPopups; }
            set { showNotificationPopups = value; }
        }

        /// <summary>
        /// Accessor for useListFolder.
        /// </summary>
        public bool UseListFolder
        {
            get { return useListFolder; }
            set { useListFolder = value; }
        }

        /// <summary>
        /// Accessor for closeSynchWindowOnSuccess.
        /// </summary>
        public bool CloseSyncWindowOnSuccess
        {
            get { return closeSyncWindowOnSuccess; }
            set { closeSyncWindowOnSuccess = value; }
        }

    }
}
