/*
 * Created by SharpDevelop.
 * User: jaran
 * Date: 08.11.2012
 * Time: 19:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsPortableDevicesLib;
using WindowsPortableDevicesLib.Domain;
using System.Collections.Generic;

namespace Notpod
{
    /// <summary>
    /// Description of DeviceSelectionDialog.
    /// </summary>
    public partial class DeviceSelectionDialog : Form
    {
        private WindowsPortableDeviceService portableDeviceService = new StandardWindowsPortableDeviceService();

        public DeviceSelectionDialog()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

        }

        void ButtonCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

        void DeviceSelectionDialogLoad(object sender, EventArgs e)
        {
            UpdateDeviceList();
        }

        private void UpdateDeviceList()
        {
            IList<WindowsPortableDevice> devices = portableDeviceService.Devices;

            lbDevices.Items.Clear();
            foreach (WindowsPortableDevice device in devices)
            {

                lbDevices.Items.Add(device);
            }
        }

        public WindowsPortableDevice SelectedDevice
        {
            get { return (WindowsPortableDevice)lbDevices.SelectedItem; }
        }

        private void lbDevices_SelectedValueChanged(object sender, EventArgs e)
        {
            buttonOk.Enabled = true;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lbDevices_DoubleClick(object sender, EventArgs e)
        {
            if (lbDevices.SelectedItem != null)
            {
                this.DialogResult = DialogResult.OK;
                buttonOk_Click(sender, e);
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            UpdateDeviceList();
        }
    }
}
