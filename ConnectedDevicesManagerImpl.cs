using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;
using System.Linq;
using Notpod.Configuration12;
using WindowsPortableDevicesLib.Domain;

namespace Notpod
{
    /// <summary>
    /// Implementation of IConnectedDevicesManger.
    /// </summary>
    public class ConnectedDevicesManagerImpl : IConnectedDevicesManager
    {
        private DeviceConfiguration deviceConfig;

        private ISet<WindowsPortableDevice> connectedDevices = new HashSet<WindowsPortableDevice>();

        #region IConnectedDevicesManager Members

        public event DeviceConnectedEventHandler DeviceConnected;

        public event DeviceDisconnectedEventHandler DeviceDisconnected;

        /// <summary>
        /// <see cref="Notpod.IConnectedDevicesManagerImpl#DeviceConfiguration"/>
        /// </summary>
        public DeviceConfiguration DeviceConfig
        {
            get
            {
                return deviceConfig;
            }
            set
            {
                deviceConfig = value;
                
            }
        }

        /// <summary>
        /// <see cref="Notpod.IConnectedDevicesManagerImpl#Synchronize(DriveInfo[])"/>
        /// </summary>
        /// <param name="drives"></param>
        public void Synchronize(IList<WindowsPortableDevice> drives)
        {

            CheckForDisconnectedDevices(drives);
            CheckForConnectedDevices(drives);
            
        }

        /// <summary>
        /// Check if any of the registered devices has been removed from the system.
        /// </summary>
        /// <param name="drives">List of currently available removable drives.</param>
        private void CheckForDisconnectedDevices(IList<WindowsPortableDevice> drives)
        {
            //IEnumerator keys = connectedDevices.Keys.GetEnumerator();
            //while (keys.MoveNext())
            //{
            //    string driveLetter = (string)keys.Current;
            //    bool found = false;

            //    Device device = (Device)connectedDevices[keys.Current];

            //    //Loop through all drive info objects to look for the current drive.
            //    foreach (DriveInfo di in drives)
            //    {
            //        Device recognized = RecognizeDevice(di);
            //        if (di.Name == driveLetter && (recognized != null && recognized.Name == device.Name))
            //        {
            //            found = true;
            //            break;
            //        }
            //    }

            //    if (!found)
            //    {
            //        RemoveDevice(driveLetter);
            //        OnDeviceDisconnected(driveLetter, device);
            //        keys = connectedDevices.Keys.GetEnumerator();
            //    }
            //}
        }

        /// <summary>
        /// Check for connected devices.
        /// </summary>
        /// <param name="devices">List of currently connected removable drives.</param>
        private void CheckForConnectedDevices(IList<WindowsPortableDevice> devices)
        {

            //Loop over all DriveInfo's and check if any of them matches 
            //the defined patterns for devices that Notpod recognizes.
            foreach (WindowsPortableDevice device in devices)
            {
                Device recognized = RecognizeDevice(device);
                if (recognized == null)
                    continue;

                if (connectedDevices.Contains(device))
                    continue;

                connectedDevices.Add(device);
                OnDeviceConnected(device, recognized);

            }
        }

        /// <summary>
        /// Check if a drive is recognized as a supported device.
        /// </summary>
        /// <param name="portableDevice">The drive where the device is located.</param>
        /// <returns>Device with device info if it has been recognized, null otherwise.</returns>
        private Device RecognizeDevice(WindowsPortableDevice portableDevice)
        {
            var recognizedDevices = from d in deviceConfig.Devices where d.RecognizePattern.Equals(portableDevice.DeviceID) select d;
            return recognizedDevices.First();
        }

        /// <summary>
        /// Remove a device from the list of disconnected devices.
        /// </summary>
        /// <param name="drive">The name of the drive where the device was connected.</param>
        private void RemoveDevice(WindowsPortableDevice device)
        {
            connectedDevices.Remove(device);
        }

        /// <summary>
        /// Method for sending out device disconnected events.
        /// </summary>
        /// <param name="driveName">The name of the drive where the device was located.</param>
        /// <param name="device">Device object describing the device that was disconnected.</param>
        protected void OnDeviceDisconnected(string driveName, Device device)
        {
            if (DeviceDisconnected != null)
            {
                CDMEventArgs args = new CDMEventArgs(null, device);
                DeviceDisconnected(this, driveName, args);
            }
        }

        /// <summary>
        /// Method for dispatching device connected events.
        /// </summary>
        /// <param name="portableDevice">The drive where the device is connected.</param>
        /// <param name="deviceConfiguration">Info on the connected device.</param>
        protected void OnDeviceConnected(WindowsPortableDevice portableDevice, Device deviceConfiguration)
        {
            if (DeviceConnected != null)
            {
                CDMEventArgs args = new CDMEventArgs(portableDevice, deviceConfiguration);
                DeviceConnected(this, args);
            }
        }

        /// <summary>
        /// <see cref="Notpod.IConnectedDevicesManager#GetConnectedDevices()"/>
        /// </summary>
        /// <returns>A Hashtable with Device objects representing the connected devices.</returns>
        public ICollection<WindowsPortableDevice> GetConnectedDevices()
        {
            return connectedDevices;
        }

        #endregion
}
}
