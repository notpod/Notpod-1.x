namespace Jaranweb.iTunesAgent
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
            this.checkAutocloseSyncWindow = new System.Windows.Forms.CheckBox();
            this.checkUseListFolder = new System.Windows.Forms.CheckBox();
            this.checkNotifications = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonBrowseMediaRoot = new System.Windows.Forms.Button();
            this.comboSyncPatterns = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupDeviceInformation = new System.Windows.Forms.GroupBox();
            this.comboAssociatePlaylist = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonNew = new System.Windows.Forms.Button();
            this.textRecognizePattern = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textMediaRoot = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textDeviceName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listDevices = new System.Windows.Forms.ListView();
            this.columnName = new System.Windows.Forms.ColumnHeader();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupDeviceInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkAutocloseSyncWindow);
            this.groupBox1.Controls.Add(this.checkUseListFolder);
            this.groupBox1.Controls.Add(this.checkNotifications);
            this.groupBox1.Location = new System.Drawing.Point(2, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agent";
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
            this.checkUseListFolder.Location = new System.Drawing.Point(249, 20);
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
            this.buttonBrowseMediaRoot.Location = new System.Drawing.Point(454, 66);
            this.buttonBrowseMediaRoot.Name = "buttonBrowseMediaRoot";
            this.buttonBrowseMediaRoot.Size = new System.Drawing.Size(40, 23);
            this.buttonBrowseMediaRoot.TabIndex = 6;
            this.buttonBrowseMediaRoot.Text = "...";
            this.toolTip.SetToolTip(this.buttonBrowseMediaRoot, "Browse for the folder if the device is already connected.");
            this.buttonBrowseMediaRoot.UseVisualStyleBackColor = true;
            this.buttonBrowseMediaRoot.Click += new System.EventHandler(this.buttonBrowseMediaRoot_Click);
            // 
            // comboSyncPatterns
            // 
            this.comboSyncPatterns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSyncPatterns.Enabled = false;
            this.comboSyncPatterns.FormattingEnabled = true;
            this.comboSyncPatterns.Location = new System.Drawing.Point(134, 40);
            this.comboSyncPatterns.Name = "comboSyncPatterns";
            this.comboSyncPatterns.Size = new System.Drawing.Size(360, 21);
            this.comboSyncPatterns.TabIndex = 3;
            this.toolTip.SetToolTip(this.comboSyncPatterns, "To see a description of the synchronization patterns, select one, the press F1.");
            this.comboSyncPatterns.SelectedIndexChanged += new System.EventHandler(this.comboSyncPatterns_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupDeviceInformation);
            this.groupBox2.Controls.Add(this.listDevices);
            this.groupBox2.Location = new System.Drawing.Point(2, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(512, 377);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Devices";
            // 
            // groupDeviceInformation
            // 
            this.groupDeviceInformation.Controls.Add(this.comboAssociatePlaylist);
            this.groupDeviceInformation.Controls.Add(this.label5);
            this.groupDeviceInformation.Controls.Add(this.buttonDelete);
            this.groupDeviceInformation.Controls.Add(this.buttonSave);
            this.groupDeviceInformation.Controls.Add(this.buttonNew);
            this.groupDeviceInformation.Controls.Add(this.textRecognizePattern);
            this.groupDeviceInformation.Controls.Add(this.label4);
            this.groupDeviceInformation.Controls.Add(this.buttonBrowseMediaRoot);
            this.groupDeviceInformation.Controls.Add(this.textMediaRoot);
            this.groupDeviceInformation.Controls.Add(this.label3);
            this.groupDeviceInformation.Controls.Add(this.comboSyncPatterns);
            this.groupDeviceInformation.Controls.Add(this.label2);
            this.groupDeviceInformation.Controls.Add(this.textDeviceName);
            this.groupDeviceInformation.Controls.Add(this.label1);
            this.groupDeviceInformation.Location = new System.Drawing.Point(6, 204);
            this.groupDeviceInformation.Name = "groupDeviceInformation";
            this.groupDeviceInformation.Size = new System.Drawing.Size(500, 167);
            this.groupDeviceInformation.TabIndex = 1;
            this.groupDeviceInformation.TabStop = false;
            this.groupDeviceInformation.Text = "Device information";
            // 
            // comboAssociatePlaylist
            // 
            this.comboAssociatePlaylist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAssociatePlaylist.Enabled = false;
            this.comboAssociatePlaylist.FormattingEnabled = true;
            this.comboAssociatePlaylist.Items.AddRange(new object[] {
            "Use device name..."});
            this.comboAssociatePlaylist.Location = new System.Drawing.Point(134, 115);
            this.comboAssociatePlaylist.Name = "comboAssociatePlaylist";
            this.comboAssociatePlaylist.Size = new System.Drawing.Size(360, 21);
            this.comboAssociatePlaylist.TabIndex = 13;
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
            this.buttonDelete.Location = new System.Drawing.Point(284, 139);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 11;
            this.buttonDelete.Text = "&Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(209, 139);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "&Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(134, 139);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(75, 23);
            this.buttonNew.TabIndex = 9;
            this.buttonNew.Text = "&New";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // textRecognizePattern
            // 
            this.textRecognizePattern.Enabled = false;
            this.helpProvider.SetHelpString(this.textRecognizePattern, "The name of a file or a folder which iTunes Agent should use to recognize this de" +
                    "vice. The path name should be relative to the root of the device. ");
            this.textRecognizePattern.Location = new System.Drawing.Point(134, 91);
            this.textRecognizePattern.Name = "textRecognizePattern";
            this.helpProvider.SetShowHelp(this.textRecognizePattern, true);
            this.textRecognizePattern.Size = new System.Drawing.Size(360, 20);
            this.textRecognizePattern.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Recognize by folder/file:";
            // 
            // textMediaRoot
            // 
            this.textMediaRoot.Enabled = false;
            this.textMediaRoot.Location = new System.Drawing.Point(134, 67);
            this.textMediaRoot.Name = "textMediaRoot";
            this.textMediaRoot.Size = new System.Drawing.Size(314, 20);
            this.textMediaRoot.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Music folder:";
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
            this.textDeviceName.Location = new System.Drawing.Point(134, 16);
            this.textDeviceName.Name = "textDeviceName";
            this.textDeviceName.Size = new System.Drawing.Size(360, 20);
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
            this.listDevices.Location = new System.Drawing.Point(9, 21);
            this.listDevices.MultiSelect = false;
            this.listDevices.Name = "listDevices";
            this.listDevices.Size = new System.Drawing.Size(497, 177);
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
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(439, 465);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "&Close";
            // 
            // buttonOK
            // 
            this.buttonOK.Enabled = false;
            this.buttonOK.Location = new System.Drawing.Point(2, 465);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "&Save";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(518, 492);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iTunes Agent Preferences";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigurationForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupDeviceInformation.ResumeLayout(false);
            this.groupDeviceInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkNotifications;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ListView listDevices;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.GroupBox groupDeviceInformation;
        private System.Windows.Forms.ComboBox comboSyncPatterns;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textDeviceName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textRecognizePattern;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonBrowseMediaRoot;
        private System.Windows.Forms.TextBox textMediaRoot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.HelpProvider helpProvider;
        private System.Windows.Forms.CheckBox checkUseListFolder;
        private System.Windows.Forms.ComboBox comboAssociatePlaylist;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkAutocloseSyncWindow;
    }
}