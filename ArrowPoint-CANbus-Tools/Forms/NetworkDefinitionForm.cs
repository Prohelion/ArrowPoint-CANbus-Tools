using ArrowPointCANBusTool.Configuration;
using ArrowPointCANBusTool.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrowPointCANBusTool.Forms
{
    public partial class NetworkDefinitionForm : Form
    {
        public NetworkDefinitionForm()
        {
            InitializeComponent();
        }

        public void LoadConfig(string configFile)
        {
            ConfigManager configManager = ConfigManager.Instance;

            configManager.LoadConfig(configFile);

            NetworkDefinitionView.Nodes.Clear();

            foreach (Node node in configManager.Configuration.Node)
            {
                TreeNode nodeTreeNode = NetworkDefinitionView.Nodes.Add(node.name);

                object[] tags = new object[1];
                tags[0] = node;

                nodeTreeNode.Tag = tags;

                foreach (Configuration.Message message in configManager.MessagesFromNode(node))
                {
                    foreach (Signal signal in message.Signal)
                    {
                        TreeNode signalTreeNode = nodeTreeNode.Nodes.Add(signal.name);

                        tags = new object[3];
                        tags[0] = node;
                        tags[1] = message;
                        tags[2] = signal;

                        signalTreeNode.Tag = tags;
                        signalTreeNode.ToolTipText = "(" + message.id + "): Offset:" + signal.offset + " Length: " + signal.length;
                    }
                }
            }

        }

        private void NetworkDefinitionView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            ConfigManager configManager = ConfigManager.Instance;

            object[] tags = (object[])e.Node.Tag;

            Configuration.Node node = null;
            Configuration.Message message = null;
            Configuration.Signal signal = null;
            bool clickedNode = false;

            if (tags.Length == 1)
            {
                node = (Configuration.Node)tags[0];
                clickedNode = true;
            } else
            {
                node = (Configuration.Node)tags[0];
                message = (Configuration.Message)tags[1];
                signal = (Configuration.Signal)tags[2];
            }

            Form form = null;

            if (clickedNode) form = configManager.FormForNode(node);
            if (form != null)
            {
                form.MdiParent = this.ParentForm;
                form.Show();
            } else
            {
                // If we have clicked on an individual message then filter on that message
                if (message != null)
                {
                    ReceivePacketForm ReceivePacketForm = new ReceivePacketForm(new CanService())
                    {
                        MdiParent = this.ParentForm
                    };

                    char[] _trim_hex = new char[] { '0', 'x' };

                    bool success = Int32.TryParse(message.id.TrimStart(_trim_hex), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int messageId);

                    ReceivePacketForm.SetFilter(messageId, messageId);
                    ReceivePacketForm.Show();
                }
            }
        }
    }
}
