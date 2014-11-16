using System;
using System.Collections;
using System.Text;
using System.IO;
using Notpod.Configuration12;
using System.Collections.Generic;

namespace Notpod
{

    public delegate void DeviceConnectedEventHandler(object sender, CDMEventArgs args);

    public delegate void DeviceDisconnectedEventHandler(object sender, string driveName, CDMEventArgs args);

    /// <summary>
    /// Interface for classes managing connected devices.
    /// </summary>
    public interface IConnectedDevicesManager
    {
        /// <summary>
        /// Accessor for device configuration.
        /// </summary>
        DeviceConfiguration DeviceConfig { get; set; }

        /// <summary>
        /// Event for connected devices.
        /// </summary>
        event DeviceConnectedEventHandler DeviceConnected;

        /// <summary>
        /// Event for disconnected devices.
        /// </summary>
        event DeviceDisconnectedEventHandler DeviceDisconnected;

        /// <summary>
        /// Synchronize the list of currently connected devices with the 
        /// list of REMOVABLE drives currently connected to the system.
        /// </summary>
        /// <param name="drives"></param>
        void Synchronize(ArrayList drives);

        /// <summary>
        /// Get a collection of connected devices.
        /// </summary>
        /// <returns>A collection containing Device objects representing the 
        /// connected devices.</returns>
        HashSet<Device> GetConnectedDevices();

        /// <summary>
        /// Get the Hashtable containing all connected devices and what drives they are connected at.
        /// </summary>
        /// <returns>Hashtable containing all connected Devices.</returns>
        Dictionary<String, HashSet<Device>> GetConnectedDevicesWithDrives();
    }
}
