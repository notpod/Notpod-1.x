namespace Notpod
{
    partial class StandardSynchronizerForm
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
        	this.progressSynchronize = new System.Windows.Forms.ProgressBar();
        	this.labelDeviceName = new System.Windows.Forms.Label();
        	this.labelCurrentStatus = new System.Windows.Forms.Label();
        	this.linkToggle = new System.Windows.Forms.LinkLabel();
        	this.rtbLogView = new System.Windows.Forms.RichTextBox();
        	this.buttonCancel = new System.Windows.Forms.Button();
        	this.SuspendLayout();
        	// 
        	// progressSynchronize
        	// 
        	this.progressSynchronize.Location = new System.Drawing.Point(5, 76);
        	this.progressSynchronize.Name = "progressSynchronize";
        	this.progressSynchronize.Size = new System.Drawing.Size(448, 20);
        	this.progressSynchronize.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
        	this.progressSynchronize.TabIndex = 1;
        	// 
        	// labelDeviceName
        	// 
        	this.labelDeviceName.Location = new System.Drawing.Point(12, 9);
        	this.labelDeviceName.Name = "labelDeviceName";
        	this.labelDeviceName.Size = new System.Drawing.Size(440, 29);
        	this.labelDeviceName.TabIndex = 2;
        	this.labelDeviceName.Text = "Initializing...";
        	this.labelDeviceName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// labelCurrentStatus
        	// 
        	this.labelCurrentStatus.Location = new System.Drawing.Point(12, 38);
        	this.labelCurrentStatus.Name = "labelCurrentStatus";
        	this.labelCurrentStatus.Size = new System.Drawing.Size(441, 35);
        	this.labelCurrentStatus.TabIndex = 3;
        	this.labelCurrentStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// linkToggle
        	// 
        	this.linkToggle.AutoSize = true;
        	this.linkToggle.Location = new System.Drawing.Point(6, 104);
        	this.linkToggle.Name = "linkToggle";
        	this.linkToggle.Size = new System.Drawing.Size(82, 13);
        	this.linkToggle.TabIndex = 4;
        	this.linkToggle.TabStop = true;
        	this.linkToggle.Text = "Toggle log view";
        	this.linkToggle.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkToggle_LinkClicked);
        	// 
        	// rtbLogView
        	// 
        	this.rtbLogView.BackColor = System.Drawing.Color.White;
        	this.rtbLogView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.rtbLogView.Cursor = System.Windows.Forms.Cursors.Arrow;
        	this.rtbLogView.Location = new System.Drawing.Point(5, 137);
        	this.rtbLogView.Name = "rtbLogView";
        	this.rtbLogView.ReadOnly = true;
        	this.rtbLogView.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
        	this.rtbLogView.Size = new System.Drawing.Size(447, 152);
        	this.rtbLogView.TabIndex = 5;
        	this.rtbLogView.Text = "";
        	// 
        	// buttonCancel
        	// 
        	this.buttonCancel.Location = new System.Drawing.Point(305, 99);
        	this.buttonCancel.Name = "buttonCancel";
        	this.buttonCancel.Size = new System.Drawing.Size(147, 23);
        	this.buttonCancel.TabIndex = 6;
        	this.buttonCancel.Text = "Cancel synchronization";
        	this.buttonCancel.UseVisualStyleBackColor = true;
        	this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
        	// 
        	// StandardSynchronizerForm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(460, 295);
        	this.Controls.Add(this.buttonCancel);
        	this.Controls.Add(this.rtbLogView);
        	this.Controls.Add(this.linkToggle);
        	this.Controls.Add(this.labelCurrentStatus);
        	this.Controls.Add(this.labelDeviceName);
        	this.Controls.Add(this.progressSynchronize);
        	this.DoubleBuffered = true;
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        	this.Icon = global::Notpod.Properties.Resources.ita_new;
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "StandardSynchronizerForm";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Notpod is synchronizing...";
        	this.Activated += new System.EventHandler(this.StandardSynchronizerForm_Activated);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ProgressBar progressSynchronize;
        private System.Windows.Forms.Label labelDeviceName;
        private System.Windows.Forms.Label labelCurrentStatus;
        private System.Windows.Forms.LinkLabel linkToggle;
        private System.Windows.Forms.RichTextBox rtbLogView;
        private System.Windows.Forms.Button buttonCancel;
    }
}