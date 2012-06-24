namespace Notpod
{
    partial class ConfigurationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkConfirmMusicLocation = new System.Windows.Forms.CheckBox();
            this.checkWarnOnSystemDrives = new System.Windows.Forms.CheckBox();
            this.checkAutocloseSyncWindow = new System.Windows.Forms.CheckBox();
            this.checkUseListFolder = new System.Windows.Forms.CheckBox();
            this.checkNotifications = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonBrowseMediaRoot = new System.Windows.Forms.Button();
            this.comboSyncPatterns = new System.Windows.Forms.ComboBox();
            this.buttonCreateUniqueFile = new System.Windows.Forms.Button();
            this.textMediaRoot = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupDeviceInformation = new System.Windows.Forms.GroupBox();
            this.clbAssociatedWith = new System.Windows.Forms.CheckedListBox();
            this.labelLinked = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textDeviceName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listDevices = new System.Windows.Forms.ListView();
            this.columnName = new System.Windows.Forms.ColumnHeader();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupDeviceInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkConfirmMusicLocation);
            this.groupBox1.Controls.Add(this.checkWarnOnSystemDrives);
            this.groupBox1.Controls.Add(this.checkAutocloseSyncWindow);
            this.groupBox1.Controls.Add(this.checkUseListFolder);
            this.groupBox1.Controls.Add(this.checkNotifications);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 96);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application behaviour";
            // 
            // checkConfirmMusicLocation
            // 
            this.checkConfirmMusicLocation.AutoSize = true;
            this.checkConfirmMusicLocation.Location = new System.Drawing.Point(9, 66);
            this.checkConfirmMusicLocation.Name = "checkConfirmMusicLocation";
            this.checkConfirmMusicLocation.Size = new System.Drawing.Size(231, 17);
            this.checkConfirmMusicLocation.TabIndex = 4;
            this.checkConfirmMusicLocation.Text = "Confirm music location before synchronizing";
            this.toolTip.SetToolTip(this.checkConfirmMusicLocation, "Checking this will display a confirmation message before devices are synchronized" +
                        " to prevent misconfiguration.");
            this.checkConfirmMusicLocation.UseVisualStyleBackColor = true;
            this.checkConfirmMusicLocation.Click += new System.EventHandler(this.checkConfirmMusicLocation_Click);
            // 
            // checkWarnOnSystemDrives
            // 
            this.checkWarnOnSystemDrives.AutoSize = true;
            this.checkWarnOnSystemDrives.Location = new System.Drawing.Point(274, 43);
            this.checkWarnOnSystemDrives.Name = "checkWarnOnSystemDrives";
            this.checkWarnOnSystemDrives.Size = new System.Drawing.Size(203, 17);
            this.checkWarnOnSystemDrives.TabIndex = 3;
            this.checkWarnOnSystemDrives.Text = "Warn if device looks like system drive";
            this.toolTip.SetToolTip(this.checkWarnOnSystemDrives, "Enabling this will make Notpod check if your device seems to be a system drive.");
            this.checkWarnOnSystemDrives.UseVisualStyleBackColor = true;
            this.checkWarnOnSystemDrives.Click += new System.EventHandler(this.checkWarnOnSystemDrives_Click);
            // 
            // checkAutocloseSyncWindow
            // 
            this.checkAutocloseSyncWindow.AutoSize = true;
            this.checkAutocloseSyncWindow.Location = new System.Drawing.Point(9, 43);
            this.checkAutocloseSyncWindow.Name = "checkAutocloseSyncWindow";
            this.helpProvider.SetShowHelp(this.checkAutocloseSyncWindow, false);
            this.checkAutocloseSyncWindow.Size = new System.Drawing.Size(238, 17);
            this.checkAutocloseSyncWindow.TabIndex = 2;
            this.checkAutocloseSyncWindow.Text = "Close status window automatically if no errors";
            this.toolTip.SetToolTip(this.checkAutocloseSyncWindow, "If checked, the status window shown during synchronization will be automatically " +
                        "closed unless there are errors.");
            this.checkAutocloseSyncWindow.UseVisualStyleBackColor = true;
            this.checkAutocloseSyncWindow.Click += new System.EventHandler(this.checkAutocloseSyncWindow_Click);
            // 
            // checkUseListFolder
            // 
            this.checkUseListFolder.AutoSize = true;
            this.checkUseListFolder.Location = new System.Drawing.Point(274, 20);
            this.checkUseListFolder.Name = "checkUseListFolder";
            this.checkUseListFolder.Size = new System.Drawing.Size(219, 17);
            this.checkUseListFolder.TabIndex = 1;
            this.checkUseListFolder.Text = "Put device playlists in \'My Devices\' folder";
            this.toolTip.SetToolTip(this.checkUseListFolder, resources.GetString("checkUseListFolder.ToolTip"));
            this.checkUseListFolder.UseVisualStyleBackColor = true;
            this.checkUseListFolder.Click += new System.EventHandler(this.checkUseListFolder_Click);
            // 
            // checkNotifications
            // 
            this.checkNotifications.AutoSize = true;
            this.checkNotifications.Location = new System.Drawing.Point(9, 20);
            this.checkNotifications.Name = "checkNotifications";
            this.checkNotifications.Size = new System.Drawing.Size(147, 17);
            this.checkNotifications.TabIndex = 0;
            this.checkNotifications.Text = "Show baloon notifications";
            this.toolTip.SetToolTip(this.checkNotifications, "Checking this option will cause a baloon to appear in your system tray whenever a" +
                        " device is connected, disconnected and on several other events.");
            this.checkNotifications.Click += new System.EventHandler(this.checkNotifications_Click);
            // 
            // buttonBrowseMediaRoot
            // 
            this.buttonBrowseMediaRoot.Enabled = false;
            this.buttonBrowseMediaRoot.Location = new System.Drawing.Point(428, 65);
            this.buttonBrowseMediaRoot.Name = "buttonBrowseMediaRoot";
            this.buttonBrowseMediaRoot.Size = new System.Drawing.Size(65, 23);
            this.buttonBrowseMediaRoot.TabIndex = 6;
            this.buttonBrowseMediaRoot.Text = "Choose";
            this.toolTip.SetToolTip(this.buttonBrowseMediaRoot, "Browse for the folder if the device is already connected.");
            this.buttonBrowseMediaRoot.UseVisualStyleBackColor = true;
            this.buttonBrowseMediaRoot.Click += new System.EventHandler(this.buttonBrowseMediaRoot_Click);
            // 
            // comboSyncPatterns
            // 
            this.comboSyncPatterns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSyncPatterns.Enabled = false;
            this.comboSyncPatterns.FormattingEnabled = true;
            this.comboSyncPatterns.Location = new System.Drawing.Point(140, 40);
            this.comboSyncPatterns.Name = "comboSyncPatterns";
            this.comboSyncPatterns.Size = new System.Drawing.Size(354, 21);
            this.comboSyncPatterns.TabIndex = 3;
            this.toolTip.SetToolTip(this.comboSyncPatterns, "To see a description of the synchronization patterns, select one, then press F1.");
            this.comboSyncPatterns.SelectedIndexChanged += new System.EventHandler(this.comboSyncPatterns_SelectedIndexChanged);
            // 
            // buttonCreateUniqueFile
            // 
            this.buttonCreateUniqueFile.Enabled = false;
            this.buttonCreateUniqueFile.Location = new System.Drawing.Point(330, 89);
            this.buttonCreateUniqueFile.Name = "buttonCreateUniqueFile";
            this.buttonCreateUniqueFile.Size = new System.Drawing.Size(163, 23);
            this.buttonCreateUniqueFile.TabIndex = 14;
            this.buttonCreateUniqueFile.Text = "Link to drive...";
            this.toolTip.SetToolTip(this.buttonCreateUniqueFile, "Choose the location of your device and Notpod will create a unique file for you.");
            this.buttonCreateUniqueFile.UseVisualStyleBackColor = true;
            this.buttonCreateUniqueFile.Click += new System.EventHandler(this.buttonCreateUniqueFile_Click);
            // 
            // textMediaRoot
            // 
            this.textMediaRoot.Enabled = false;
            this.textMediaRoot.Location = new System.Drawing.Point(140, 67);
            this.textMediaRoot.Name = "textMediaRoot";
            this.textMediaRoot.Size = new System.Drawing.Size(283, 20);
            this.textMediaRoot.TabIndex = 5;
            this.toolTip.SetToolTip(this.textMediaRoot, "Specify the location on your device where I will store the music when synchronizi" +
                        "ng. Note that this should be a folder on your device, not on your local computer" +
                        ".");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupDeviceInformation);
            this.groupBox2.Controls.Add(this.listDevices);
            this.groupBox2.Controls.Add(this.buttonNew);
            this.groupBox2.Location = new System.Drawing.Point(2, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(712, 357);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "My devices";
            // 
            // groupDeviceInformation
            // 
            this.groupDeviceInformation.Controls.Add(this.clbAssociatedWith);
            this.groupDeviceInformation.Controls.Add(this.labelLinked);
            this.groupDeviceInformation.Controls.Add(this.buttonCreateUniqueFile);
            this.groupDeviceInformation.Controls.Add(this.label5);
            this.groupDeviceInformation.Controls.Add(this.buttonDelete);
            this.groupDeviceInformation.Controls.Add(this.buttonSave);
            this.groupDeviceInformation.Controls.Add(this.label4);
            this.groupDeviceInformation.Controls.Add(this.buttonBrowseMediaRoot);
            this.groupDeviceInformation.Controls.Add(this.textMediaRoot);
            this.groupDeviceInformation.Controls.Add(this.label3);
            this.groupDeviceInformation.Controls.Add(this.comboSyncPatterns);
            this.groupDeviceInformation.Controls.Add(this.label2);
            this.groupDeviceInformation.Controls.Add(this.textDeviceName);
            this.groupDeviceInformation.Controls.Add(this.label1);
            this.groupDeviceInformation.Location = new System.Drawing.Point(206, 9);
            this.groupDeviceInformation.Name = "groupDeviceInformation";
            this.groupDeviceInformation.Size = new System.Drawing.Size(500, 342);
            this.groupDeviceInformation.TabIndex = 1;
            this.groupDeviceInformation.TabStop = false;
            this.groupDeviceInformation.Text = "Device information";
            // 
            // clbAssociatedWith
            // 
            this.clbAssociatedWith.FormattingEnabled = true;
            this.clbAssociatedWith.Location = new System.Drawing.Point(140, 119);
            this.clbAssociatedWith.Name = "clbAssociatedWith";
            this.clbAssociatedWith.Size = new System.Drawing.Size(353, 169);
            this.clbAssociatedWith.TabIndex = 16;
            // 
            // labelLinked
            // 
            this.labelLinked.Enabled = false;
            this.labelLinked.Location = new System.Drawing.Point(140, 90);
            this.labelLinked.Name = "labelLinked";
            this.labelLinked.Size = new System.Drawing.Size(184, 22);
            this.labelLinked.TabIndex = 15;
            this.labelLinked.Text = "Not linked. Click button to link ->";
            this.labelLinked.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Associate with playlist:";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Location = new System.Drawing.Point(369, 303);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(125, 33);
            this.buttonDelete.TabIndex = 11;
            this.buttonDelete.Text = "&Delete this device";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(6, 303);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(135, 33);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "&Save device settings";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Link to removable drive:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Music location on device:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Synchronize pattern:";
            // 
            // textDeviceName
            // 
            this.textDeviceName.Enabled = false;
            this.textDeviceName.Location = new System.Drawing.Point(140, 16);
            this.textDeviceName.Name = "textDeviceName";
            this.textDeviceName.Size = new System.Drawing.Size(354, 20);
            this.textDeviceName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // listDevices
            // 
            this.listDevices.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listDevices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                    this.columnName});
            this.listDevices.FullRowSelect = true;
            this.listDevices.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listDevices.Location = new System.Drawing.Point(9, 16);
            this.listDevices.MultiSelect = false;
            this.listDevices.Name = "listDevices";
            this.listDevices.Size = new System.Drawing.Size(191, 289);
            this.listDevices.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listDevices.TabIndex = 0;
            this.listDevices.UseCompatibleStateImageBehavior = false;
            this.listDevices.View = System.Windows.Forms.View.Details;
            this.listDevices.ItemActivate += new System.EventHandler(this.listDevices_ItemActivate);
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 410;
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(6, 311);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(194, 33);
            this.buttonNew.TabIndex = 9;
            this.buttonNew.Text = "Add new device";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(2, 467);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(712, 31);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "&Close preferences";
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(717, 502);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = global::Notpod.Properties.Resources.ita_new;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notpod Preferences";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigurationForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupDeviceInformation.ResumeLayout(false);
            this.groupDeviceInformation.PerformLayout();
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.CheckedListBox clbAssociatedWith;
        private System.Windows.Forms.Label labelLinked;

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkNotifications;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ListView listDevices;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.GroupBox groupDeviceInformation;
        private System.Windows.Forms.ComboBox comboSyncPatterns;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textDeviceName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonBrowseMediaRoot;
        private System.Windows.Forms.TextBox textMediaRoot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.HelpProvider helpProvider;
        private System.Windows.Forms.CheckBox checkUseListFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkAutocloseSyncWindow;
        private System.Windows.Forms.Button buttonCreateUniqueFile;
        private System.Windows.Forms.CheckBox checkWarnOnSystemDrives;
        private System.Windows.Forms.CheckBox checkConfirmMusicLocation;
    }
}