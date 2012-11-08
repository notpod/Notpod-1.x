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
            IList<WindowsPortableDevice> devices = portableDeviceService.Devices;
            
            foreach(WindowsPortableDevice device in devices) {
                
                lbDevices.Items.Add(device);
            }
        }
        
        public WindowsPortableDevice SelectedDevice 
        {
            get { return lbDevices.SelectedItem; }
        }
    }
}
