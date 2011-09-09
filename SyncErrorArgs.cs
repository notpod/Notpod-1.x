using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Notpod.Configuration12;

namespace Notpod
{
    public class SyncErrorArgs : EventArgs
    {

        private string errorMessage;
        private Device device;

        /// <summary>
        /// Property for getting and setting the device.
        /// </summary>
        public Device Device
        {
            get { return device; }
            set { device = value; }
        }

        /// <summary>
        /// Property for getting and setting the error message.
        /// </summary>
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }



    }
}
