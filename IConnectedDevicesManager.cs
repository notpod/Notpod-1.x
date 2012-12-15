using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Notpod.Configuration12;
using WindowsPortableDevicesLib.Domain;

namespace Notpod
{

    public delegate void DeviceConnectedEventHandler(object sender, CDMEventArgs args);

    public delegate void DeviceDisconnectedEventHandler(object sender, CDMEventArgs args);

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
        void Synchronize(IList<WindowsPortableDevice> drives);

        /// <summary>
        /// Get a collection of connected devices.
        /// </summary>
        /// <returns>A collection containing Device objects representing the 
        /// connected devices.</returns>
        IDictionary<WindowsPortableDevice, Device> GetConnectedDevices();
    }
}
