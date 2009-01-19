using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Jaranweb.iTunesAgent
{
    public partial class StandardSynchronizerForm : Form, ISynchronizeForm
    {
        delegate void SetDeviceNameCallback(string deviceName, string driveLetter);

        delegate void SetCurrentStatusCallback(string statusText);

        delegate void AddLogTextCallback(string text, Color color);

        delegate void SetMaxProgressValueCallback(int value);

        delegate void SetProgressValueCallback(int value);

        delegate void CloseCallback();

        delegate void EnableCancelButtonCallback();

        delegate void DisableCancelButtonCallback();
                
        private bool operationCancelled = false;

        public StandardSynchronizerForm()
        {
            InitializeComponent();
        }
                
        /// <summary>
        /// Toggle log view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkToggle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.Height > 160)
                this.Height = 160;
            else
                this.Height = 315;
        }

        /// <summary>
        /// Set name of the device that is being synchronized.
        /// </summary>
        /// <param name="deviceName"></param>
        public void SetDeviceName(string deviceName, string driveLetter)
        {
            if (labelDeviceName.InvokeRequired)
            {
                SetDeviceNameCallback d = new SetDeviceNameCallback(SetDeviceName);
                Invoke(d, new object[] { deviceName, driveLetter });
            }
            else
            {
                labelDeviceName.Text = deviceName + " on drive " + driveLetter;
                labelDeviceName.Refresh();
            }
            
        }

        /// <summary>
        /// Set name of the file that is currently being processed, or other status info.
        /// </summary>
        /// <param name="trackName"></param>
        public void SetCurrentStatus(string status)
        {
            if (labelCurrentStatus.InvokeRequired)
            {
                SetCurrentStatusCallback d = new SetCurrentStatusCallback(SetCurrentStatus);
                Invoke(d, new object[] { status });
            }
            else
            {
                labelCurrentStatus.Text = status;
                labelCurrentStatus.Refresh();
            }
            
        }

        /// <summary>
        /// Add output to the log.
        /// </summary>
        /// <param name="text">Text to add to the log view.</param>
        /// <param name="color">Color of the text.</param>
        public void AddLogText(string text, Color color)
        {
            if (rtbLogView.InvokeRequired)
            {
                AddLogTextCallback d = new AddLogTextCallback(AddLogText);
                Invoke(d, new object[] { text, color });
            }
            else
            {
                int currentEnd = rtbLogView.Text.Length;
                rtbLogView.AppendText((text.EndsWith("\n") ? text : text + "\n"));
                rtbLogView.Select(currentEnd, rtbLogView.Text.Length - currentEnd);
                rtbLogView.SelectionColor = color;

                rtbLogView.SelectionStart = rtbLogView.Text.Length;
                rtbLogView.ScrollToCaret();
                rtbLogView.Refresh();
                
            }

            
        }

        /// <summary>
        /// Add text to the log view. Using default color Black.
        /// </summary>
        /// <param name="text">Text to add to the log view.</param>
        public void AddLogText(string text)
        {
            AddLogText(text, Color.Black);
        }

        /// <see cref="ISynchronizeForm#SetMaxProgressValue(int)"/>
        public void SetMaxProgressValue(int value) 
        {
            if(progressSynchronize.InvokeRequired)
            {
                SetMaxProgressValueCallback d = new SetMaxProgressValueCallback(SetMaxProgressValue);
                Invoke(d, new object[] { value });
            }
            else 
            {                
                progressSynchronize.Maximum = value; progressSynchronize.Refresh(); 
            }
            
        }

        public int GetMaxProgressValue()
        {
            return progressSynchronize.Maximum;
        }

        public void SetProgressValue(int value)
        {
            if(progressSynchronize.InvokeRequired)
            {
                SetProgressValueCallback d = new SetProgressValueCallback(SetProgressValue);
                Invoke(d, new object[] { value });
            }
            else 
            {
                progressSynchronize.Value = value; progressSynchronize.Refresh(); 
            }

        }

        public int GetProgressValue()
        {
            return progressSynchronize.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StandardSynchronizerForm_Activated(object sender, EventArgs e)
        {
            linkToggle.Refresh();
        }


        /// <summary>
        /// 
        /// </summary>
        public void CloseSafe()
        {

            if (this.InvokeRequired)
            {
                CloseCallback d = new CloseCallback(CloseSafe);
                Invoke(d);
            }
            else
            {
                Close();
            }
               
        }

        /// <summary>
        /// Event handler for the "Cancel synchronization button"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            operationCancelled = true;
        }

        /// <summary>
        /// Accessor for operationCancelled.
        /// </summary>
        public bool GetOperationCancelled()
        {
            return operationCancelled;
        }

        /// <summary>
        /// Enable the cancel operation button.
        /// </summary>
        public void EnableCancelButton()
        {
            if (progressSynchronize.InvokeRequired)
            {
                EnableCancelButtonCallback d = new EnableCancelButtonCallback(EnableCancelButton);
                Invoke(d);
            }
            else
            {
                this.buttonCancel.Enabled = true;
            }

            
        }

        /// <summary>
        /// Disable the cancel operation button.
        /// </summary>
        public void DisableCancelButton()
        {
            if (progressSynchronize.InvokeRequired)
            {
                DisableCancelButtonCallback d = new DisableCancelButtonCallback(DisableCancelButton);
                Invoke(d);
            }
            else
            {
                this.buttonCancel.Enabled = false;
            }
        }
     }
}