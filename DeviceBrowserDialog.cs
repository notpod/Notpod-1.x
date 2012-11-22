using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsPortableDevicesLib.Domain;
using Common.Logging;
using System.Collections.Generic;

namespace Notpod
{
    public partial class DeviceBrowserDialog : Form
    {
        private ILog l = LogManager.GetLogger(typeof(DeviceBrowserDialog));

        private WindowsPortableDevice device;

        private PortableDeviceFolder selectedFolder;

        public DeviceBrowserDialog()
        {
            InitializeComponent();
        }

        public WindowsPortableDevice Device
        {
            get { return this.device; }
            set { this.device = value; }
        }

        private void DeviceBrowserDialog_Load(object sender, EventArgs e)
        {
            l.Debug("Loading dialog...");
            selectedFolder = null;
            TreeNode root = tvFolders.Nodes.Add("/", device.FriendlyName);

            AddChildFolders(null, root);
        }

        private void AddChildFolders(PortableDeviceFolder parentFolder, TreeNode parentTreeNode)
        {

            PortableDeviceFolder folderContent = device.GetContents(parentFolder);
            var folders = from f in folderContent.Files where f.GetType() == typeof(PortableDeviceFolder) select f;

            foreach (PortableDeviceFolder folder in folders)
            {
                if (String.IsNullOrEmpty(folder.Name))
                {
                    l.DebugFormat("Not adding {0} because it's hidden.", folder.Id);
                    continue;
                }

                l.DebugFormat("Adding folder {0} ({1}) to {1}", folder.Id, folder.Name, parentTreeNode.Text);
                TreeNode node = parentTreeNode.Nodes.Add("/" + folder.Id, folder.Name);
                node.Nodes.Add("Expand to load more...");
                node.Tag = folder;

            }
        }

        private void tvFolders_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node = e.Node;
            l.DebugFormat("Node {0} was expanded.", node.Text);

            if (node.Nodes.Count == 1 && node.FirstNode.Tag == null)
            {
                node.Nodes.RemoveAt(0);
                AddChildFolders((PortableDeviceFolder)node.Tag, node);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (tvFolders.SelectedNode == null || tvFolders.SelectedNode.Tag == null)
            {
                MessageBox.Show(this, "Please select a folder on your device before continuing.", "Select a folder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            selectedFolder = (PortableDeviceFolder)tvFolders.SelectedNode.Tag;
            this.DialogResult = DialogResult.OK;
            Close();
        }

        public PortableDeviceFolder SelectedFolder
        {
            get { return selectedFolder; }
        }
    }
}
