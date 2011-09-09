using System;
using System.Collections.Generic;
using System.Text;

namespace Notpod.Configuration12
{
    /// <summary>
    /// Application configuration class.
    /// </summary>
    public class Configuration
    {

        private bool showNotificationPopups;

        private bool useListFolder;

        private bool closeSyncWindowOnSuccess = true;

        private bool warnOnSystemDrives = true;

        private bool confirmMusicLocation = true;
                
        /// <summary>
        /// Accessor for showNotificationPopups.
        /// </summary>
        public bool ShowNotificationPopups
        {
            get
            {
                return showNotificationPopups;
            }
            set
            {
                showNotificationPopups = value;
            }
        }

        /// <summary>
        /// Accessor for useListFolder.
        /// </summary>
        public bool UseListFolder
        {
            get
            {
                return useListFolder;
            }
            set
            {
                useListFolder = value;
            }
        }

        /// <summary>
        /// Accessor for closeSynchWindowOnSuccess.
        /// </summary>
        public bool CloseSyncWindowOnSuccess
        {
            get
            {
                return closeSyncWindowOnSuccess;
            }
            set
            {
                closeSyncWindowOnSuccess = value;
            }
        }

        /// <summary>
        /// Accessor for warnOnSystemDrives.
        /// </summary>
        public bool WarnOnSystemDrives
        {
            get
            {
                return warnOnSystemDrives;
            }
            set
            {
                warnOnSystemDrives = value;
            }
        }

        /// <summary>
        /// Accessor for confirmMusicLocation.
        /// </summary>
        public bool ConfirmMusicLocation
        {

            get
            {
                return confirmMusicLocation;
            }
            set
            {
                confirmMusicLocation = value;
            }
        }

    }
}
