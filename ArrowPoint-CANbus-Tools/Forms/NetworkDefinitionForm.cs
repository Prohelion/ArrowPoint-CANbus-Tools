using ArrowPointCANBusTool.Configuration;
using ArrowPointCANBusTool.Controls;
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
            NetworkDefinitionView.NodeMouseClick += (sender, args) => NetworkDefinitionView.SelectedNode = args.Node;
            NodeMenuStrip.Hide();
            MessageMenuStrip.Hide();
            SignalMenuStrip.Hide();
        }

        public void LoadConfig(string configFile)
        {
            ConfigManager configManager = ConfigManager.Instance;

            configManager.LoadConfig(configFile);

            NetworkDefinitionView.Nodes.Clear();

            foreach (Node node in configManager.Configuration.Node)
            {
                TreeNode nodeTreeNode = NetworkDefinitionView.Nodes.Add(node.name);

                CanTreeTag nodeTreeTag = new CanTreeTag
                {
                    NodeType = CanTreeTag.NODE,
                    Node = node
                };

                nodeTreeNode.Tag = nodeTreeTag;

                foreach (Configuration.Message message in configManager.MessagesFromNode(node))
                {
                    TreeNode messageTreeNode = nodeTreeNode.Nodes.Add(message.name);
                    CanTreeTag messageTreeTag = new CanTreeTag
                    {
                        NodeType = CanTreeTag.MESSAGE,
                        Node = node,
                        Message = message                        
                    };

                    messageTreeNode.Tag = messageTreeTag;
                    messageTreeNode.ToolTipText = "(" + message.id + ")";

                    foreach (Signal signal in message.Signal)
                    {
                        TreeNode signalTreeNode = messageTreeNode.Nodes.Add(signal.name);
                        CanTreeTag signalTreeTag = new CanTreeTag
                        {
                            NodeType = CanTreeTag.SIGNAL,
                            Node = node,
                            Message = message,
                            Signal = signal
                        };

                        signalTreeNode.Tag = signalTreeTag;
                        signalTreeNode.ToolTipText = "(" + message.id + "): Offset:" + signal.offset + " Length: " + signal.length;
                    }
                }
            }

        }

        private void NetworkDefinitionView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            ConfigManager configManager = ConfigManager.Instance;

            CanTreeTag tag = (CanTreeTag)e.Node.Tag;

            bool clickedNode = false;

            if (tag.NodeType == CanTreeTag.NODE)
            {
                clickedNode = true;
            }

            Form form = null;

            if (clickedNode) form = configManager.FormForNode(tag.Node);
            if (form != null)
            {
                form.MdiParent = this.ParentForm;
                form.Show();
            } else
            {
                // If we have clicked on an individual message then filter on that message
                if (tag.Message != null)
                {
                    ReceivePacketForm ReceivePacketForm = new ReceivePacketForm(new CanService())
                    {
                        MdiParent = this.ParentForm
                    };

                    char[] _trim_hex = new char[] { '0', 'x' };

                    bool success = Int32.TryParse(tag.Message.id.TrimStart(_trim_hex), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int messageId);

                    ReceivePacketForm.SetFilter(messageId, messageId);
                    ReceivePacketForm.Show();
                }
            }
        }

        private void NetworkDefinitionView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                CanTreeTag canTreeTag = (CanTreeTag)NetworkDefinitionView.SelectedNode.Tag;
                
                switch (canTreeTag.NodeType)
                {
                    case CanTreeTag.NODE: NodeMenuStrip.Show(NetworkDefinitionView, e.Location); break;
                    case CanTreeTag.MESSAGE: MessageMenuStrip.Show(NetworkDefinitionView, e.Location); break;
                    case CanTreeTag.SIGNAL: SignalMenuStrip.Show(NetworkDefinitionView, e.Location); break;
                    default: break;
                }
                
            }
        }

        private void NewNodeMenuItem_Click(object sender, EventArgs e)
        {
            NetworkNodeForm networkNodeForm = new NetworkNodeForm();
            networkNodeForm.ShowDialog();

            if (networkNodeForm.IsOk)
            {
                Node node = new Node
                {
                    name = networkNodeForm.NodeName,
                    id = ConfigManager.Instance.NextAvailableNodeId().ToString()
                };

                ConfigManager.Instance.Configuration.Node.Add(node);

                TreeNode nodeTreeNode = NetworkDefinitionView.Nodes.Add(node.name);

                CanTreeTag nodeTreeTag = new CanTreeTag
                {
                    NodeType = CanTreeTag.NODE,
                    Node = node
                };
            }
        }

    }
}
