using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Runtime.InteropServices;
using iTunesLib;
using Notpod.Configuration12;
using log4net;
using System.Security.Cryptography;
using WindowsPortableDevicesLib.Domain;

namespace Notpod
{
    /// <summary>
    /// Form for modifying settings for the application.
    /// </summary>
    public partial class ConfigurationForm : Form
    {
        private ILog l = LogManager.GetLogger(typeof(ConfigurationForm));

        private Configuration configuration;
        private DeviceConfiguration deviceConfiguration;

        private bool deviceConfigurationChanged = false;
        private bool configurationChanged = false;

        private String selectedDeviceConfigLinkFile = null;

        /// <summary>
        /// Create a new instance of configuration form.
        /// </summary>
        /// <param name="configuration">Configuration containing the configuration for the application.</param>
        /// <param name="deviceConfiguration">DeviceConfiguration containing all the configured devices.</param>
        /// <param name="itunes">Reference to iTunes interface.</param>
        public ConfigurationForm(ref Configuration configuration, ref DeviceConfiguration deviceConfiguration, ref iTunesApp itunes)
        {
            InitializeComponent();

            this.configuration = configuration;
            this.checkNotifications.Checked = configuration.ShowNotificationPopups;
            this.checkUseListFolder.Checked = configuration.UseListFolder;
            this.checkAutocloseSyncWindow.Checked = configuration.CloseSyncWindowOnSuccess;
            this.checkWarnOnSystemDrives.Checked = configuration.WarnOnSystemDrives;
            this.checkConfirmMusicLocation.Checked = configuration.ConfirmMusicLocation;

            this.deviceConfiguration = deviceConfiguration;
            for (int d = 0; d < deviceConfiguration.Devices.Length; d++)
            {
                Device device = deviceConfiguration.Devices[d];
                ListViewItem item = new ListViewItem(device.Name);
                if (listDevices.Items.Contains(item))
                {
                    MessageBox.Show(this, "Duplicate devices with name '" + device.Name
                                    + "' was found. The duplicated items will be removed from the "
                                    + "configuration.", "Invalid configuration", MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);

                    deviceConfigurationChanged = true;
                    buttonOK.Enabled = true;
                    deviceConfiguration.RemoveDevice(device);
                    continue;
                }

                listDevices.Items.Add(device.Name);
            }

            //Add synchronize patterns to combo box.
            for (int s = 0; s < deviceConfiguration.SyncPattern.Count; s++)
            {
                SyncPattern pattern = deviceConfiguration.SyncPattern.ElementAt(s);
                comboSyncPatterns.Items.Add(pattern.Name);
            }

            //Add playlists to "Associate with playlist" combo
            bool retry = true;
            while (retry)
            {
                try
                {
                    foreach (IITPlaylist pl in itunes.LibrarySource.Playlists)
                    {
                        if (pl.Kind != ITPlaylistKind.ITPlaylistKindLibrary
                            && pl.Kind != ITPlaylistKind.ITPlaylistKindRadioTuner
                            && pl.Kind != ITPlaylistKind.ITPlaylistKindDevice
                            && pl.Kind != ITPlaylistKind.ITPlaylistKindCD
                            && pl.Visible)
                            comboAssociatePlaylist.Items.Add(pl.Name);
                    }

                    comboAssociatePlaylist.SelectedIndex = 0;
                    retry = false;
                }
                catch (COMException comex)
                {
                    l.Warn(comex);

                    if (MessageBox.Show(this, "An error occured while getting the list of playlists from iTunes. This may be because iTunes is busy. Do you want to retry?\n\n(" + comex.Message + ")", "Communication error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        retry = true;
                        comboAssociatePlaylist.Items.Clear();
                    }
                    else
                    {
                        retry = false;
                    }
                }

            }

        }

        /// <summary>
        /// Event handler for OK button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            SaveConfiguration();
            buttonOK.Enabled = false;
        }

        /// <summary>
        /// Event handler for when changes are made to the Device file structure combo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboStructure_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Display a warning message about how the change of file structure works and how it
            //inflicts any changes on the already managed devices.
            MessageBox.Show("Note that this setting only applies to devices not already managed "
                            + "by Notpod. If you want to change the file structure of a device already "
                            + "synchronized with Notpod you will have to clear the music folder of your "
                            + "device, including the '.itastruct' file, in order for Notpod to manage "
                            + "the device with the new structure.\n\nFor new devices the new structure setting "
                            + "will be applied upon first iTunes-to-device synchronization.", "Please note",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Event handler for when an item is activated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listDevices_ItemActivate(object sender, EventArgs e)
        {
            EnableEditFields(false);

            ListViewItem seletedItem = listDevices.SelectedItems[0];
            foreach (Device device in deviceConfiguration.Devices)
            {
                if (device.Name != seletedItem.Text)
                    continue;

                textDeviceName.Text = device.Name;
                textMediaRoot.Text = device.MediaRoot;

                this.selectedDeviceConfigLinkFile = device.RecognizePattern;
                if (!String.IsNullOrWhiteSpace(selectedDeviceConfigLinkFile))
                {

                    labelLinked.Text = "Linked.";
                    buttonCreateUniqueFile.Text = "Link to another device...";
                }

                foreach (SyncPattern pattern in deviceConfiguration.SyncPattern)
                {
                    if (pattern.Identifier != device.SyncPattern)
                        continue;

                    for (int i = 0; i < comboSyncPatterns.Items.Count; i++)
                    {
                        if ((string)comboSyncPatterns.Items[i] != pattern.Name)
                            continue;

                        comboSyncPatterns.SelectedIndex = i;
                        break;
                    }

                    //helpProvider.SetHelpString(comboSyncPatterns, pattern.Description);

                    break;
                }

                //Set selected associated playlist.
                comboAssociatePlaylist.SelectedIndex = 0;
                if (device.Playlist != null && device.Playlist.Length > 0)
                {

                    foreach (string playlist in comboAssociatePlaylist.Items)
                    {
                        if (playlist == device.Playlist)
                        {
                            comboAssociatePlaylist.SelectedItem = playlist;
                        }
                    }


                }

                break;
            }

        }

        /// <summary>
        /// Enable the edit fields.
        /// </summary>
        /// <param name="forNewDevice"></param>
        private void EnableEditFields(bool forNewDevice)
        {
            if (forNewDevice)
            {
                textDeviceName.Enabled = true;
                textMediaRoot.Enabled = false;
                buttonBrowseMediaRoot.Enabled = false;
            }
            comboSyncPatterns.Enabled = true;

            labelLinked.Text = "Not linked. Click button to link ->";
            labelLinked.Enabled = false;
            comboAssociatePlaylist.Enabled = true;

            if (!forNewDevice)
            {
                buttonDelete.Enabled = true;
                textMediaRoot.Enabled = true;
                buttonBrowseMediaRoot.Enabled = true;
            }
            buttonSave.Enabled = true;
            buttonCreateUniqueFile.Text = "Link to drive...";
            buttonCreateUniqueFile.Enabled = true;
            comboAssociatePlaylist.Enabled = true;

        }

        /// <summary>
        /// Disable all edit fields.
        /// </summary>
        private void DisableEditFields()
        {
            textDeviceName.Enabled = false;
            comboSyncPatterns.Enabled = false;
            textMediaRoot.Enabled = false;
            labelLinked.Text = "Not linked. Click button to link ->";
            labelLinked.Enabled = false;
            comboAssociatePlaylist.Enabled = false;

            buttonBrowseMediaRoot.Enabled = false;
            buttonCreateUniqueFile.Text = "Link to drive...";
            buttonCreateUniqueFile.Enabled = false;
            buttonDelete.Enabled = false;
            buttonSave.Enabled = false;
            comboAssociatePlaylist.Enabled = false;
        }

        private void comboSyncPatterns_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (SyncPattern pattern in deviceConfiguration.SyncPattern)
            {
                if (pattern.Name != (string)comboSyncPatterns.SelectedItem)
                    continue;

                helpProvider.SetHelpString(comboSyncPatterns, pattern.Description);
            }
        }

        /// <summary>
        /// Event handler for the "new" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNew_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Please note that any media present in the folder specified as 'Music location on device' "
                            + "will be deleted upon the first synchronization by Notpod, unless "
                            + "this media matches any track added to the device's playlist in iTunes.\n\nIf "
                            + "the media already present on your device is of critical importance, please make sure you take a proper "
                            + "backup, or make sure it is located outside the folder you configure as the "
                            + "'Music location on device'.", "Before you continue...",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            PrepareForNewDeviceConfiguration();

        }

        private void PrepareForNewDeviceConfiguration()
        {

            DisableEditFields();
            EnableEditFields(true);

            textDeviceName.Text = "";
            textMediaRoot.Text = "";
            comboSyncPatterns.SelectedIndex = 0;
            comboAssociatePlaylist.SelectedIndex = 0;
        }

        /// <summary>
        /// Event handler for the delete button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string deleteDevice = textDeviceName.Text;
            if (MessageBox.Show(this, "Are you sure you want to delete '" + deleteDevice + "'?", "Please confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            foreach (Device device in deviceConfiguration.Devices)
            {
                if (device.Name != deleteDevice)
                    continue;

                foreach (ListViewItem lvi in listDevices.Items)
                {
                    if (lvi.Text != deleteDevice)
                        continue;

                    listDevices.Items.Remove(lvi);
                    break;
                }

                deviceConfiguration.RemoveDevice(device);
                break;
            }

            PrepareForNewDeviceConfiguration();
            DisableEditFields();
            SaveDeviceConfiguration();
        }

        /// <summary>
        /// Event handler for the save button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            string deviceName = textDeviceName.Text;
            string syncPattern = (string)comboSyncPatterns.SelectedItem;
            string mediaroot = textMediaRoot.Text;
            string recognizePattern = selectedDeviceConfigLinkFile;
            string associatedPlaylist = (string)comboAssociatePlaylist.SelectedItem;

            if (deviceName.Length == 0)
            {
                MessageBox.Show(this, "Please enter a name for the device.", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (syncPattern == null)
            {
                MessageBox.Show(this, "Please select a synchronize pattern for the device.", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (recognizePattern.Length == 0)
            {
                MessageBox.Show(this, "Please enter a recognize pattern for the device.", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }



            Device newDevice = new Device();
            newDevice.Name = deviceName;
            newDevice.MediaRoot = mediaroot;
            newDevice.RecognizePattern = recognizePattern;
            newDevice.Playlist = (associatedPlaylist == "Use device name..." ? "" : associatedPlaylist);
            foreach (SyncPattern sp in deviceConfiguration.SyncPattern)
            {
                if (sp.Name != syncPattern)
                    continue;

                newDevice.SyncPattern = sp.Identifier;
            }

            //Add new device
            if (textDeviceName.Enabled)
            {
                //Check that the name does not already exist
                foreach (Device device in deviceConfiguration.Devices)
                {
                    if (device.Name != deviceName)
                        continue;

                    MessageBox.Show(this, "There is already a device configuration with the name '" + deviceName + "'. Please enter a unique name.", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                deviceConfiguration.AddDevice(newDevice);
                listDevices.Items.Add(newDevice.Name);
            }
            //Update existing device
            else
            {
                foreach (Device device in deviceConfiguration.Devices)
                {
                    if (device.Name != newDevice.Name)
                        continue;

                    device.MediaRoot = newDevice.MediaRoot;
                    device.RecognizePattern = newDevice.RecognizePattern;
                    device.SyncPattern = newDevice.SyncPattern;
                    device.Playlist = newDevice.Playlist;

                    break;
                }
            }

            deviceConfigurationChanged = true;
            SaveDeviceConfiguration();

            PrepareForNewDeviceConfiguration();
            DisableEditFields();

            MessageBox.Show(this, "New device configuration registered successfully.", "New device configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Event handler for browse for media root button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBrowseMediaRoot_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;

            //This check is to make sure that the application do not throw an exception if a path
            //of length less than 3 is selected. Normally this do not occur, but there has been
            //reportet incidents where unsupported, special devices have given an empty path in return...
            //See bug report 1443246.
            // https://sourceforge.net/tracker/index.php?func=detail&aid=1443246&group_id=149133&atid=773786
            if (dlg.SelectedPath.Length >= 3)
            {
                textMediaRoot.Text = dlg.SelectedPath.Substring(3, dlg.SelectedPath.Length - 3);
            }
        }

        /// <summary>
        /// Event handler for "form closing" events.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigurationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (configurationChanged || deviceConfigurationChanged)
            {
                if (MessageBox.Show(this, "Configuration has been modified. Do you want to save the changes?", "Please confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (configurationChanged)
                        SaveConfiguration();
                    if (deviceConfigurationChanged)
                        SaveDeviceConfiguration();
                }
            }

        }

        /// <summary>
        /// Save the configuration.
        /// </summary>
        private void SaveConfiguration()
        {
            configuration.ShowNotificationPopups = checkNotifications.Checked;
            configuration.UseListFolder = checkUseListFolder.Checked;
            configuration.CloseSyncWindowOnSuccess = checkAutocloseSyncWindow.Checked;
            configuration.WarnOnSystemDrives = checkWarnOnSystemDrives.Checked;
            configuration.ConfirmMusicLocation = checkConfirmMusicLocation.Checked;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
                TextWriter writer = new StreamWriter(MainForm.DATA_PATH + "\\ita-config.xml");
                serializer.Serialize(writer, configuration);
                writer.Flush();
                writer.Close();

                configurationChanged = false;
            }
            catch (Exception ex)
            {
                l.Error(ex);
                MessageBox.Show(this, "Failed to write configuration! " + ex.Message, "Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        /// <summary>
        /// Save the device configuration.
        /// </summary>
        private void SaveDeviceConfiguration()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(DeviceConfiguration));
                TextWriter writer = new StreamWriter(MainForm.DATA_PATH + "\\device-config.xml");
                serializer.Serialize(writer, deviceConfiguration);
                writer.Flush();
                writer.Close();

                deviceConfigurationChanged = false;
            }
            catch (Exception ex)
            {
                l.Error(ex);
                MessageBox.Show(this, "Failed to write device configuration! " + ex.Message, "Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Event handler for clicks on checkNotifications.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkNotifications_Click(object sender, EventArgs e)
        {
            configurationChanged = true;
            buttonOK.Enabled = true;
        }

        /// <summary>
        /// Event handler for clicks on checkUseListFolder.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkUseListFolder_Click(object sender, EventArgs e)
        {
            configurationChanged = true;
            buttonOK.Enabled = true;
        }

        /// <summary>
        /// Event handler for clicks on checkAutocloseSyncWindow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkAutocloseSyncWindow_Click(object sender, EventArgs e)
        {
            configurationChanged = true;
            buttonOK.Enabled = true;
        }

        /// <summary>
        /// Event handler for buttonCreateUniqueFile clicks. Lets the
        /// user select a folder and creates a unique file in this folder
        /// which is used to identify the device.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateUniqueFile_Click(object sender, EventArgs e)
        {
            DeviceSelectionDialog dialog = new DeviceSelectionDialog();
            if (dialog.ShowDialog(this) == DialogResult.Cancel)
            {

                return;
            }

            WindowsPortableDevice device = dialog.SelectedDevice;
            l.DebugFormat("Selected device: {0}", device.DeviceID);

            var existingDevices = from d in deviceConfiguration.Devices where d.RecognizePattern.Equals(device.DeviceID) select d;
            if (existingDevices.Count() > 0)
            {
                Device existingDevice = existingDevices.First();
                MessageBox.Show(this, "The selected device is already linked to '" + existingDevice.Name + "'. Please choose a different device to link to.",
                    "Device already linked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }



            this.selectedDeviceConfigLinkFile = device.DeviceID;
            if (String.IsNullOrWhiteSpace(textDeviceName.Text))
            {
                textDeviceName.Text = device.FriendlyName;
            }

            labelLinked.Text = "Linked.";
            buttonCreateUniqueFile.Text = "Link to another device...";

            textMediaRoot.Enabled = true;
            buttonBrowseMediaRoot.Enabled = true;

        }

        private void checkWarnOnSystemDrives_Click(object sender, EventArgs e)
        {
            configurationChanged = true;
            buttonOK.Enabled = true;
        }

        private void checkConfirmMusicLocation_Click(object sender, EventArgs e)
        {
            configurationChanged = true;
            buttonOK.Enabled = true;
        }

    }
}