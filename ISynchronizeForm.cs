using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Jaranweb.iTunesAgent
{
    /// <summary>
    /// Interface for synchronize forms.
    /// </summary>
    public interface ISynchronizeForm
    {
        /// <summary>
        /// Set the device name.
        /// </summary>
        /// <param name="deviceName">The name of the device.</param>
        void SetDeviceName(string deviceName, string driveLetter);

        /// <summary>
        /// Set the current status label text.
        /// </summary>
        /// <param name="statusText">Text to be displayed in the status label.</param>
        void SetCurrentStatus(string statusText);


        /// <summary>
        /// Add text to the log view.
        /// </summary>
        /// <param name="text">Log text.</param>
        /// <param name="color">Text color.</param>
        void AddLogText(string text, Color color);

        /// <summary>
        /// Add text to the log view. Uses default color; black.
        /// </summary>
        /// <param name="text">Log text.</param>
        void AddLogText(string text);

        /// <summary>
        /// Set the max value for the progress bar.
        /// </summary>
        void SetMaxProgressValue(int value);

        /// <summary>
        /// Get the max value of the progress bar.
        /// </summary>
        /// <returns></returns>
        int GetMaxProgressValue();
                
        /// <summary>
        /// Set the current value of the progress bar.
        /// </summary>
        void SetProgressValue(int value);

        /// <summary>
        /// Get the current value of the progress bar.
        /// </summary>
        /// <returns></returns>
        int GetProgressValue();
                
        /// <summary>
        /// Close the form.
        /// </summary>
        void CloseSafe();

        /// <summary>
        /// Get boolean value indicating if the cancel 
        /// operation button has been pressed.
        /// </summary>
        /// <returns>True if operation should be cancelled, 
        /// false otherwise.</returns>
        bool GetOperationCancelled();

        /// <summary>
        /// Show form.
        /// </summary>
        void Show();

        /// <summary>
        /// Enable the cancel operation button.
        /// </summary>
        void EnableCancelButton();

        /// <summary>
        /// Disable the cancel operation button.
        /// </summary>
        void DisableCancelButton();

    }
}
