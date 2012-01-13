using System;
using System.Collections.Generic;
using System.Text;
using iTunesLib;
using Notpod.Configuration12;

namespace Notpod
{

    public delegate void SynchronizeErrorEventHandler(object sender, SyncErrorArgs args);

    public delegate void SynchronizeCompleteEventHandler(object sender);

    public delegate void SynchronizeCancelledEventHandler(object sender);

    /// <summary>
    /// Interface for synchronizers used in the agent.
    /// </summary>
    public interface ISynchronizer
    {
                
        /// <summary>
        /// Synchronize a device with the tracks in an iTunes playlist.
        /// </summary>
        /// <param name="playlist">iTunes playlist representing the device.</param>
        /// <param name="drive">The drive where the device is located, e.g. K:\</param>
        /// <param name="device">Device object describing the device to synchronize.</param>
        void SynchronizeDevice(List<IITPlaylist> playlist, string drive, Device device);

        /// <summary>
        /// Property for setting whether the GUI for the synchronizer (if available) should be 
        /// shown upon synchronization.
        /// </summary>
        bool ShowGui { get; set; }

        /// <summary>
        /// Get boolean value indicating whether this Synchronizer has gui or not.
        /// </summary>
        bool HasGui { get; }

        /// <summary>
        /// Set the ISynchronizeForm to use for status information when synchronizing.
        /// </summary>
        /// <param name="form">Form to use with this synchronizer.</param>
        ISynchronizeForm Form { set; get; }

        /// <summary>
        /// Property for getting and setting the device configuration for the synchronizer.
        /// </summary>
        DeviceConfiguration Configuration { get; set; }


        /// <summary>
        /// Event for synchronize errors.
        /// </summary>
        event SynchronizeErrorEventHandler SynchronizeError;

        /// <summary>
        /// Event for synchronize complete.
        /// </summary>
        event SynchronizeCompleteEventHandler SynchronizeComplete;

        /// <summary>
        /// Event for cancelled synchronizations.
        /// </summary>
        event SynchronizeCancelledEventHandler SynchronizeCancelled;
    }
}
