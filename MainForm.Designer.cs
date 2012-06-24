namespace Notpod
{
    partial class MainForm
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
        	this.itaTray = new System.Windows.Forms.NotifyIcon(this.components);
        	this.contextTray = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.ctxTrayPreferences = new System.Windows.Forms.ToolStripMenuItem();
        	this.ctxTrayHelp = new System.Windows.Forms.ToolStripMenuItem();
        	this.ctxTrayAbout = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
        	this.ctxTrayExit = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        	this.ctxTraySynchronize = new System.Windows.Forms.ToolStripMenuItem();
        	this.timerDriveListUpdate = new System.Windows.Forms.Timer(this.components);
        	this.ctxTrayReportBug = new System.Windows.Forms.ToolStripMenuItem();
        	this.contextTray.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// itaTray
        	// 
        	this.itaTray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
        	this.itaTray.BalloonTipText = "You may now attach compatible devices to your system. They will appear in iTunes " +
        	"as playlists where you can manage their tracks.";
        	this.itaTray.BalloonTipTitle = "Notpod is now running";
        	this.itaTray.ContextMenuStrip = this.contextTray;
        	this.itaTray.Icon = global::Notpod.Properties.Resources.ita_new;
        	this.itaTray.Text = "Notpod";
        	this.itaTray.Visible = true;
        	// 
        	// contextTray
        	// 
        	this.contextTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.ctxTrayPreferences,
        	        	        	this.ctxTrayHelp,
        	        	        	this.ctxTrayReportBug,
        	        	        	this.ctxTrayAbout,
        	        	        	this.toolStripSeparator4,
        	        	        	this.ctxTrayExit,
        	        	        	this.toolStripSeparator2,
        	        	        	this.ctxTraySynchronize});
        	this.contextTray.Name = "contextTray";
        	this.contextTray.Size = new System.Drawing.Size(199, 148);
        	// 
        	// ctxTrayPreferences
        	// 
        	this.ctxTrayPreferences.Name = "ctxTrayPreferences";
        	this.ctxTrayPreferences.Size = new System.Drawing.Size(198, 22);
        	this.ctxTrayPreferences.Text = "&Preferences...";
        	this.ctxTrayPreferences.Click += new System.EventHandler(this.ctxTrayPreferences_Click);
        	// 
        	// ctxTrayHelp
        	// 
        	this.ctxTrayHelp.Image = global::Notpod.Properties.Resources.help;
        	this.ctxTrayHelp.Name = "ctxTrayHelp";
        	this.ctxTrayHelp.Size = new System.Drawing.Size(198, 22);
        	this.ctxTrayHelp.Text = "&Online help...";
        	this.ctxTrayHelp.Click += new System.EventHandler(this.ctxTrayHelp_Click);
        	// 
        	// ctxTrayAbout
        	// 
        	this.ctxTrayAbout.Name = "ctxTrayAbout";
        	this.ctxTrayAbout.Size = new System.Drawing.Size(198, 22);
        	this.ctxTrayAbout.Text = "&About Notpod";
        	this.ctxTrayAbout.Click += new System.EventHandler(this.ctxTrayAbout_Click);
        	// 
        	// toolStripSeparator4
        	// 
        	this.toolStripSeparator4.Name = "toolStripSeparator4";
        	this.toolStripSeparator4.Size = new System.Drawing.Size(195, 6);
        	// 
        	// ctxTrayExit
        	// 
        	this.ctxTrayExit.Image = global::Notpod.Properties.Resources.exit;
        	this.ctxTrayExit.Name = "ctxTrayExit";
        	this.ctxTrayExit.Size = new System.Drawing.Size(198, 22);
        	this.ctxTrayExit.Text = "E&xit";
        	this.ctxTrayExit.Click += new System.EventHandler(this.ctxTrayExit_Click);
        	// 
        	// toolStripSeparator2
        	// 
        	this.toolStripSeparator2.Name = "toolStripSeparator2";
        	this.toolStripSeparator2.Size = new System.Drawing.Size(195, 6);
        	// 
        	// ctxTraySynchronize
        	// 
        	this.ctxTraySynchronize.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
        	this.ctxTraySynchronize.Name = "ctxTraySynchronize";
        	this.ctxTraySynchronize.Size = new System.Drawing.Size(198, 22);
        	this.ctxTraySynchronize.Text = "&Synchronize devices...";
        	this.ctxTraySynchronize.Click += new System.EventHandler(this.ctxTraySynchronize_Click);
        	// 
        	// timerDriveListUpdate
        	// 
        	this.timerDriveListUpdate.Interval = 3000;
        	this.timerDriveListUpdate.Tick += new System.EventHandler(this.timerDriveListUpdate_Tick);
        	// 
        	// ctxTrayReportBug
        	// 
        	this.ctxTrayReportBug.Name = "ctxTrayReportBug";
        	this.ctxTrayReportBug.Size = new System.Drawing.Size(198, 22);
        	this.ctxTrayReportBug.Text = "Report bug...";
        	this.ctxTrayReportBug.Click += new System.EventHandler(this.ctxTrayReportBug_Click);
        	// 
        	// MainForm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(238, 15);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.Icon = global::Notpod.Properties.Resources.ita_new;
        	this.MaximizeBox = false;
        	this.Name = "MainForm";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Notpod";
        	this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        	this.Load += new System.EventHandler(this.MainForm_Load);
        	this.contextTray.ResumeLayout(false);
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.ToolStripMenuItem ctxTrayReportBug;

        #endregion

        private System.Windows.Forms.NotifyIcon itaTray;
        private System.Windows.Forms.ContextMenuStrip contextTray;
        private System.Windows.Forms.Timer timerDriveListUpdate;
        private System.Windows.Forms.ToolStripMenuItem ctxTraySynchronize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ctxTrayExit;
        private System.Windows.Forms.ToolStripMenuItem ctxTrayPreferences;
        private System.Windows.Forms.ToolStripMenuItem ctxTrayHelp;
        private System.Windows.Forms.ToolStripMenuItem ctxTrayAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}

