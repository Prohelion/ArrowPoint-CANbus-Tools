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
        
        private TreeNode AddNode(TreeNodeCollection nodes, string nodeName, int nodeType, Configuration.Node node, Configuration.Bus bus, Configuration.Message message, Configuration.Signal signal)
        {
            TreeNode newTreeNode = nodes.Add(nodeName);
            CanTreeTag newTreeTag = new CanTreeTag
            {
                NodeType = nodeType,
                Bus = bus,
                Node = node,
                Message = message,
                Signal = signal
            };

            newTreeNode.Tag = newTreeTag;

            int imageIndex = 0;

            switch (nodeType)
            {
                case CanTreeTag.BUS: imageIndex = 0; break;
                case CanTreeTag.NODE: imageIndex = 1; break;
                case CanTreeTag.MESSAGE: imageIndex = 2; newTreeNode.ToolTipText = "(" + message.id + ")"; break;
                case CanTreeTag.SIGNAL: imageIndex = 3; newTreeNode.ToolTipText = "(" + message.id + "): Offset:" + signal.offset + " Length: " + signal.length; break;
            }

            newTreeNode.ImageIndex = imageIndex;
            newTreeNode.SelectedImageIndex = imageIndex;

            return newTreeNode;
        }


        public void LoadConfig(string configFile)
        {            

            ConfigService configManager = ConfigService.Instance;            

            configManager.LoadConfig(configFile);

            NetworkDefinitionView.Nodes.Clear();

            // Right now we are only supporting one bus
            Bus bus = configManager.Configuration.Bus[0];

            TreeNode busNode = AddNode(NetworkDefinitionView.Nodes, "CanBus Network", CanTreeTag.BUS, null, bus, null, null);

            foreach (Node node in configManager.Configuration.Node)
            {
                TreeNode nodeTreeNode = AddNode(busNode.Nodes, node.name, CanTreeTag.NODE, node, bus, null, null);

                foreach (Configuration.Message message in configManager.MessagesFromNodeOnBus(node, bus))
                {
                    TreeNode messageTreeNode = AddNode(nodeTreeNode.Nodes, message.name, CanTreeTag.MESSAGE, node, bus, message, null);

                    foreach (Signal signal in message.Signal)
                    {
                        TreeNode signalTreeNode = AddNode(messageTreeNode.Nodes, signal.name, CanTreeTag.SIGNAL, node, bus, message, signal);
                    }
                }
            }
        }

        private void NetworkDefinitionView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            ConfigService configManager = ConfigService.Instance;

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
                    case CanTreeTag.BUS: BusMenuStrip.Show(NetworkDefinitionView, e.Location); break;
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
                CanTreeTag canTreeTag = (CanTreeTag)NetworkDefinitionView.SelectedNode.Tag;
                Node node = ConfigService.Instance.AddNode(networkNodeForm.NodeName);
                TreeNode nodeTreeNode = AddNode(NetworkDefinitionView.Nodes[0].Nodes, node.name, CanTreeTag.NODE, node, canTreeTag.Bus, null, null);
                NetworkDefinitionView.SelectedNode = nodeTreeNode;
            }
        }

        private void EditNodeMenuItem_Click(object sender, EventArgs e)
        {
            CanTreeTag canTreeTag = (CanTreeTag)NetworkDefinitionView.SelectedNode.Tag;

            NetworkNodeForm networkNodeForm = new NetworkNodeForm
            {
                NodeName = canTreeTag.Node.name
            };
            networkNodeForm.ShowDialog();

            if (networkNodeForm.IsOk)
            {
                canTreeTag.Node.name = networkNodeForm.NodeName;
                NetworkDefinitionView.SelectedNode.Text = networkNodeForm.NodeName;
            }
        }


        private void DeleteNodeMenuItem_Click(object sender, EventArgs e)
        {
            CanTreeTag canTreeTag = (CanTreeTag)NetworkDefinitionView.SelectedNode.Tag;
            ConfigService.Instance.DeleteNode(canTreeTag.Node);
            NetworkDefinitionView.SelectedNode.Parent.Nodes.Remove(NetworkDefinitionView.SelectedNode);
        }

        private void NewSignalMenuItem_Click(object sender, EventArgs e)
        {
            NetworkSignalForm networkSignalForm = new NetworkSignalForm();
            networkSignalForm.ShowDialog();

            if (networkSignalForm.IsOk)
            {
                CanTreeTag canTreeTag = (CanTreeTag)NetworkDefinitionView.SelectedNode.Tag;
                ConfigService.Instance.AddSignal(networkSignalForm.Signal, canTreeTag.Message);
                TreeNode nodeTreeNode = AddNode(NetworkDefinitionView.SelectedNode.Nodes, networkSignalForm.Signal.name, CanTreeTag.SIGNAL, canTreeTag.Node, canTreeTag.Bus, canTreeTag.Message, networkSignalForm.Signal);
                NetworkDefinitionView.SelectedNode = nodeTreeNode;
            }
        }

        private void EditSignalMenuItem_Click(object sender, EventArgs e)
        {
            CanTreeTag canTreeTag = (CanTreeTag)NetworkDefinitionView.SelectedNode.Tag;

            NetworkSignalForm networkSignalForm = new NetworkSignalForm(canTreeTag.Signal);
            networkSignalForm.ShowDialog();

            if (networkSignalForm.IsOk)
            {
                canTreeTag.Node.name = networkSignalForm.Signal.name;
                NetworkDefinitionView.SelectedNode.Text = networkSignalForm.Signal.name;
                NetworkDefinitionView.SelectedNode.ToolTipText = "(" + canTreeTag.Message.id + "): Offset:" + networkSignalForm.Signal.offset + " Length: " + networkSignalForm.Signal.length;
            }
        }

        private void DeleteSignalMenuItem_Click(object sender, EventArgs e)
        {
            CanTreeTag canTreeTag = (CanTreeTag)NetworkDefinitionView.SelectedNode.Tag;
            ConfigService.Instance.DeleteSignal(canTreeTag.Signal, canTreeTag.Message);
            NetworkDefinitionView.SelectedNode.Parent.Nodes.Remove(NetworkDefinitionView.SelectedNode);
        }

        private void NewMessageMenuItem_Click(object sender, EventArgs e)
        {
            NetworkMessageForm networkMessageForm = new NetworkMessageForm();
            networkMessageForm.ShowDialog();
            
            if (networkMessageForm.IsOk)
            {
                CanTreeTag canTreeTag = (CanTreeTag)NetworkDefinitionView.SelectedNode.Tag;
                Configuration.Message message = ConfigService.Instance.AddMessage(networkMessageForm.Message.name, networkMessageForm.Message.id, canTreeTag.Node, canTreeTag.Bus);
                TreeNode nodeTreeNode = AddNode(NetworkDefinitionView.SelectedNode.Nodes, message.name, CanTreeTag.MESSAGE, canTreeTag.Node, canTreeTag.Bus, message, null);
                NetworkDefinitionView.SelectedNode = nodeTreeNode;
            }
        }

        private void EditMessageMenuItem_Click(object sender, EventArgs e)
        {
            CanTreeTag canTreeTag = (CanTreeTag)NetworkDefinitionView.SelectedNode.Tag;

            NetworkMessageForm networkMessageForm = new NetworkMessageForm(canTreeTag.Message);
            networkMessageForm.ShowDialog();

            if (networkMessageForm.IsOk)
            {
                canTreeTag.Node.name = networkMessageForm.Message.name;
                NetworkDefinitionView.SelectedNode.Text = networkMessageForm.Message.name;
                NetworkDefinitionView.SelectedNode.ToolTipText =  "(" + networkMessageForm.Message.id + ")";
            }
        }


        private void DeleteMessageMenuItem_Click(object sender, EventArgs e)
        {
            CanTreeTag canTreeTag = (CanTreeTag)NetworkDefinitionView.SelectedNode.Tag;
            ConfigService.Instance.DeleteMessage(canTreeTag.Message);
            NetworkDefinitionView.SelectedNode.Parent.Nodes.Remove(NetworkDefinitionView.SelectedNode);
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            switch (m.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = m.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }
            base.WndProc(ref m);
        }


    }
}
