using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;
using Notpod.Configuration12;

namespace Notpod
{
    /// <summary>
    /// Implementation of IConnectedDevicesManger.
    /// </summary>
    public class ConnectedDevicesManagerImpl : IConnectedDevicesManager
    {
        private DeviceConfiguration deviceConfig;

        private Dictionary<String, HashSet<Device>> connectedDevices = new Dictionary<String, HashSet<Device>>();

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
        public void Synchronize(ArrayList drives)
        {

            CheckForDisconnectedDevices(drives);
            CheckForConnectedDevices(drives);
            
        }

        /// <summary>
        /// Check if any of the registered devices has been removed from the system.
        /// </summary>
        /// <param name="drives">List of currently available removable drives.</param>
        private void CheckForDisconnectedDevices(ArrayList drives)
        {
            IDictionaryEnumerator keys = connectedDevices.GetEnumerator();
            while (keys.MoveNext())
            {
                String driveLetter = (String)keys.Key;
                bool found = false;

                HashSet<Device> devices = (HashSet<Device>)keys.Value;

                List<Device> recognized = new List<Device>();

                //Loop through all drive info objects to look for the current drive.
                foreach (DriveInfo di in drives)
                {
                    recognized = RecognizeDevice(di);
                    if (di.Name == driveLetter && (recognized != null && recognized.Count > 0))
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    foreach (Device device in recognized)
                    {
                        OnDeviceDisconnected(driveLetter, device);
                    }
                    RemoveDevice(driveLetter);
                    keys = connectedDevices.GetEnumerator();
                }
            }
        }

        /// <summary>
        /// Check for connected devices.
        /// </summary>
        /// <param name="drives">List of currently connected removable drives.</param>
        private void CheckForConnectedDevices(ArrayList drives)
        {

            //Loop over all DriveInfo's and check if any of them matches 
            //the defined patterns for devices that Notpod recognizes.
            foreach (DriveInfo di in drives)
            {
                List<Device> recognized = RecognizeDevice(di);
                if (recognized == null || recognized.Count == 0)
                    continue;

                if (!connectedDevices.ContainsKey(di.Name))
                    connectedDevices.Add(di.Name, new HashSet<Device>());

                foreach (Device device in recognized)
                {
                    if (!connectedDevices[di.Name].Contains(device))
                    {
                        connectedDevices[di.Name].Add(device);
                        OnDeviceConnected(di, device);
                    }
                }
            }
        }

        /// <summary>
        /// Check if a drive is recognized as a supported device.
        /// </summary>
        /// <param name="drive">The drive where the device is located.</param>
        /// <returns>Device with device info if it has been recognized, null otherwise.</returns>
        private List<Device> RecognizeDevice(DriveInfo drive)
        {
            List<Device> result = new List<Device>();
            foreach (Device d in deviceConfig.Devices)
            {
                if (Directory.Exists(drive.Name + d.RecognizePattern) ||
                    File.Exists(drive.Name + d.RecognizePattern) ||
                    drive.VolumeLabel == d.RecognizePattern)
                {
                    result.Add(d);
                }
            }
            return result;
        }

        /// <summary>
        /// Remove a device from the list of disconnected devices.
        /// </summary>
        /// <param name="drive">The name of the drive where the device was connected.</param>
        private void RemoveDevice(string device)
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
        /// <param name="drive">The drive where the device is connected.</param>
        /// <param name="device">Info on the connected device.</param>
        protected void OnDeviceConnected(DriveInfo drive, Device device)
        {
            if (DeviceConnected != null)
            {
                CDMEventArgs args = new CDMEventArgs(drive, device);
                DeviceConnected(this, args);
            }
        }

        /// <summary>
        /// <see cref="Notpod.IConnectedDevicesManager#GetConnectedDevices()"/>
        /// </summary>
        /// <returns>A Hashtable with Device objects representing the connected devices.</returns>
        public HashSet<Device> GetConnectedDevices()
        {
            HashSet<Device> result = new HashSet<Device>();
            foreach (HashSet<Device> devices in connectedDevices.Values)
            {
                foreach (Device device in devices)
                {
                    if (!result.Contains(device))
                    {
                        result.Add(device);
                    }
                }
            }
            return result;
        }


        /// <summary>
        /// <see cref="Notpod.IConnectedDevicesManager#GetConnectedDevicesWithDrives()"/>
        /// </summary>
        public Dictionary<String,HashSet<Device>> GetConnectedDevicesWithDrives()
        {
            return connectedDevices;
        }

        #endregion
}
}
