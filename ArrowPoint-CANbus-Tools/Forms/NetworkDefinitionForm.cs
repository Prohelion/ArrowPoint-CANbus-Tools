using ArrowPointCANBusTool.Canbus;
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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrowPointCANBusTool.Forms
{
    public partial class NetworkDefinitionForm : Form
    {
        Timer timer;
        Bus bus;
        int unknownCanLength = 0;

        public NetworkDefinitionForm()
        {
            InitializeComponent();
            NetworkDefinitionView.NodeMouseClick += (sender, args) => NetworkDefinitionView.SelectedNode = args.Node;
            NodeMenuStrip.Hide();
            MessageMenuStrip.Hide();
            SignalMenuStrip.Hide();
        }

        private static BindingList<Configuration.Node> ConfigurationNodes
        {
            get
            {
                return new BindingList<Configuration.Node>(ConfigService.Instance.Configuration.Node);
            }
            set
            {
                ConfigService.Instance.Configuration.Node = value.ToList();
            }
        }

        private static BindingList<Configuration.Message> ConfigurationMessages
        {
            get
            {
                return new BindingList<Configuration.Message>(ConfigService.Instance.Configuration.Bus[0].Message);
            }
            set
            {
                ConfigService.Instance.Configuration.Bus[0].Message = value.ToList();
            }
        }


        private BindingList<Configuration.Signal> ConfigurationSignals
        {            
            get
            {
                int selectedRow = MessageDataGridView.CurrentCell.RowIndex;
                return new BindingList<Configuration.Signal>(ConfigService.Instance.Configuration.Bus[0].Message[selectedRow].Signal);
            }
            set
            {
                int selectedRow = MessageDataGridView.CurrentCell.RowIndex;
                ConfigService.Instance.Configuration.Bus[0].Message[selectedRow].Signal = value.ToList();
            }
        }



        private static TreeNode AddNode(TreeNodeCollection nodes, string nodeName, int nodeType, Configuration.Node node, Configuration.Bus bus, Configuration.Message message, Configuration.Signal signal)
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
            bus = configManager.Configuration.Bus[0];

            TreeNode busNode = AddNode(NetworkDefinitionView.Nodes, "CanBus Network", CanTreeTag.BUS, null, bus, null, null);

            foreach (Node node in configManager.Configuration.Node)
            {
                TreeNode nodeTreeNode = AddNode(busNode.Nodes, node.name, CanTreeTag.NODE, node, bus, null, null);

                foreach (Configuration.Message message in ConfigService.MessagesFromNodeOnBus(node, bus))
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

            CanTreeTag tag = (CanTreeTag)e.Node.Tag;

            bool clickedNode = false;

            if (tag.NodeType == CanTreeTag.NODE)
            {
                clickedNode = true;
            }

            if (clickedNode)
            {
               /* using Form form = ConfigService.FormForNode(tag.Node);
                if (form != null)
                {
                    form.MdiParent = this.ParentForm;
                    form.Show();
                }
                else */
                {
                    // If we have clicked on an individual message then filter on that message
                    if (tag.Message != null)
                    {
                        using ReceivePacketForm ReceivePacketForm = new ReceivePacketForm()
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
        }

        private void NetworkDefinitionView_MouseUp(object sender, MouseEventArgs e)
        {
            CanTreeTag canTreeTag = (CanTreeTag)NetworkDefinitionView.SelectedNode.Tag;

            if (e.Button == MouseButtons.Left)
            {             
                switch (canTreeTag.NodeType)
                {
                    case CanTreeTag.BUS: 
                    case CanTreeTag.NODE: MainTabControl.SelectTab(1); break;
                    case CanTreeTag.MESSAGE: MainTabControl.SelectTab(0); break;
                    case CanTreeTag.SIGNAL: MainTabControl.SelectTab(0); break;
                    default: break;
                }
            }

            if (e.Button == MouseButtons.Right)
            {                
                
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
            using NetworkNodeForm networkNodeForm = new NetworkNodeForm();
            networkNodeForm.ShowDialog();

            if (networkNodeForm.IsOk)
            {
                CanTreeTag canTreeTag = (CanTreeTag)NetworkDefinitionView.SelectedNode.Tag;
                Node node = ConfigService.AddNode(networkNodeForm.NodeName);
                TreeNode nodeTreeNode = AddNode(NetworkDefinitionView.Nodes[0].Nodes, node.name, CanTreeTag.NODE, node, canTreeTag.Bus, null, null);
                NetworkDefinitionView.SelectedNode = nodeTreeNode;
            }
        }

        private void EditNodeMenuItem_Click(object sender, EventArgs e)
        {
            CanTreeTag canTreeTag = (CanTreeTag)NetworkDefinitionView.SelectedNode.Tag;

            using NetworkNodeForm networkNodeForm = new NetworkNodeForm
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
            using NetworkSignalForm networkSignalForm = new NetworkSignalForm();
            networkSignalForm.ShowDialog();

            if (networkSignalForm.IsOk)
            {
                CanTreeTag canTreeTag = (CanTreeTag)NetworkDefinitionView.SelectedNode.Tag;
                ConfigService.AddSignal(networkSignalForm.Signal, canTreeTag.Message);
                TreeNode nodeTreeNode = AddNode(NetworkDefinitionView.SelectedNode.Nodes, networkSignalForm.Signal.name, CanTreeTag.SIGNAL, canTreeTag.Node, canTreeTag.Bus, canTreeTag.Message, networkSignalForm.Signal);
                NetworkDefinitionView.SelectedNode = nodeTreeNode;
            }
        }

        private void EditSignalMenuItem_Click(object sender, EventArgs e)
        {
            CanTreeTag canTreeTag = (CanTreeTag)NetworkDefinitionView.SelectedNode.Tag;

            using NetworkSignalForm networkSignalForm = new NetworkSignalForm(canTreeTag.Signal);
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
            ConfigService.DeleteSignal(canTreeTag.Signal, canTreeTag.Message);
            NetworkDefinitionView.SelectedNode.Parent.Nodes.Remove(NetworkDefinitionView.SelectedNode);
        }

        private void NewMessageMenuItem_Click(object sender, EventArgs e)
        {
            using NetworkMessageForm networkMessageForm = new NetworkMessageForm();
            networkMessageForm.ShowDialog();
            
            if (networkMessageForm.IsOk)
            {
                CanTreeTag canTreeTag = (CanTreeTag)NetworkDefinitionView.SelectedNode.Tag;
                Configuration.Message message = ConfigService.AddMessage(networkMessageForm.Message.name, networkMessageForm.Message.id, canTreeTag.Node, canTreeTag.Bus);
                TreeNode nodeTreeNode = AddNode(NetworkDefinitionView.SelectedNode.Nodes, message.name, CanTreeTag.MESSAGE, canTreeTag.Node, canTreeTag.Bus, message, null);
                NetworkDefinitionView.SelectedNode = nodeTreeNode;
                UpdateUnknownCan(true);
            }
        }

        private void EditMessageMenuItem_Click(object sender, EventArgs e)
        {
            CanTreeTag canTreeTag = (CanTreeTag)NetworkDefinitionView.SelectedNode.Tag;

            using NetworkMessageForm networkMessageForm = new NetworkMessageForm(canTreeTag.Message);
            networkMessageForm.ShowDialog();

            if (networkMessageForm.IsOk)
            {
                canTreeTag.Node.name = networkMessageForm.Message.name;
                NetworkDefinitionView.SelectedNode.Text = networkMessageForm.Message.name;
                NetworkDefinitionView.SelectedNode.ToolTipText =  "(" + networkMessageForm.Message.id + ")";
                UpdateUnknownCan(true);
            }
        }


        private void DeleteMessageMenuItem_Click(object sender, EventArgs e)
        {
            CanTreeTag canTreeTag = (CanTreeTag)NetworkDefinitionView.SelectedNode.Tag;
            ConfigService.Instance.DeleteMessage(canTreeTag.Message);
            NetworkDefinitionView.SelectedNode.Parent.Nodes.Remove(NetworkDefinitionView.SelectedNode);
        }

        /*protected override void WndProc(ref System.Windows.Forms.Message m)
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
        }*/

        private void MessageDataGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if ((MessageDataGridView.Rows[e.RowIndex].DataBoundItem != null) && (MessageDataGridView.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
                e.Value = BindProperty(MessageDataGridView.Rows[e.RowIndex].DataBoundItem, MessageDataGridView.Columns[e.ColumnIndex].DataPropertyName);
        }

        private void MessageDataGridView_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            if ((MessageDataGridView.Rows[e.RowIndex].DataBoundItem != null) && (MessageDataGridView.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
                SetProperty(MessageDataGridView.Rows[e.RowIndex].DataBoundItem, MessageDataGridView.Columns[e.ColumnIndex].DataPropertyName, e.Value);
        }

        private void SetProperty(object property, string propertyName, object value)
        {
            if (propertyName.Contains("."))
            {
                PropertyInfo[] arrayProperties;

                string leftPropertyName = propertyName.Substring(0, propertyName.IndexOf("."));

                int arrayIndex = -1;
                bool isArray = false;
                string trimmedLeftPropertyName;

                if (leftPropertyName.Contains("["))
                {
                    string leftPropertyArray = leftPropertyName.Substring(leftPropertyName.IndexOf("[") + 1, leftPropertyName.IndexOf("]") - (leftPropertyName.IndexOf("[") + 1));
                    trimmedLeftPropertyName = leftPropertyName.Substring(0, propertyName.IndexOf("["));
                    arrayIndex = Int32.Parse(leftPropertyArray);
                    isArray = true;
                }
                else
                    trimmedLeftPropertyName = leftPropertyName;

                arrayProperties = property.GetType().GetProperties();

                foreach (PropertyInfo propertyInfo in arrayProperties)
                {

                    if (propertyInfo.Name == trimmedLeftPropertyName)
                    {
                        if (isArray)
                        {
                            Object collection = propertyInfo.GetValue(property, null);                            

                            // note that there's no checking here that the object really
                            // is a collection and thus really has the attribute
                            String indexerName = ((DefaultMemberAttribute)collection.GetType().GetCustomAttributes(typeof(DefaultMemberAttribute), true)[0]).MemberName;
                            PropertyInfo pi2 = collection.GetType().GetProperty(indexerName);
                            MethodInfo addMethod = collection.GetType().GetMethod("Add");
                            
                            object indexedValue = null;

                            try
                            {
                                indexedValue = pi2.GetValue(collection, new Object[] { arrayIndex });
                            } catch
                            {
                                System.Type type = pi2.GetMethod.ReturnType;
                                object instance = Activator.CreateInstance(type);
                                addMethod.Invoke(collection, new Object[] { instance });
                                indexedValue = pi2.GetValue(collection, new Object[] { arrayIndex });
                            }
                                                        
                            SetProperty(indexedValue, propertyName.Substring(propertyName.IndexOf(".") + 1), value);
                        }
                        else
                            SetProperty(propertyInfo.GetValue(property, null), propertyName.Substring(propertyName.IndexOf(".") + 1), value);
                        break;
                    }
                }
            }
            else
            {
                Type propertyType;
                PropertyInfo propertyInfo;

                propertyType = property.GetType();
                propertyInfo = propertyType.GetProperty(propertyName);
                propertyInfo.SetValue(property, value);                
            }
        }

        private string BindProperty(object property, string propertyName)
        {
            string retValue;

            retValue = "";

            if (propertyName.Contains("."))
            {
                PropertyInfo[] arrayProperties;

                string leftPropertyName = propertyName.Substring(0, propertyName.IndexOf("."));

                int arrayIndex = -1;
                bool isArray = false;
                string trimmedLeftPropertyName;

                if (leftPropertyName.Contains("["))
                {
                    string leftPropertyArray = leftPropertyName.Substring(leftPropertyName.IndexOf("[") + 1, leftPropertyName.IndexOf("]") - (leftPropertyName.IndexOf("[") + 1));
                    trimmedLeftPropertyName = leftPropertyName.Substring(0, propertyName.IndexOf("["));
                    arrayIndex = Int32.Parse(leftPropertyArray);
                    isArray = true;
                }
                else
                    trimmedLeftPropertyName = leftPropertyName;

                arrayProperties = property.GetType().GetProperties();

                foreach (PropertyInfo propertyInfo in arrayProperties)
                {

                    if (propertyInfo.Name == trimmedLeftPropertyName)
                    {                        
                        if (isArray)
                        {
                            Object collection = propertyInfo.GetValue(property, null);

                            // note that there's no checking here that the object really
                            // is a collection and thus really has the attribute
                            String indexerName = ((DefaultMemberAttribute)collection.GetType().GetCustomAttributes(typeof(DefaultMemberAttribute),true)[0]).MemberName;
                            PropertyInfo pi2 = collection.GetType().GetProperty(indexerName);

                            try
                            {
                                // If this fails, it is likely because the array has not been initialised
                                Object indexedValue = pi2.GetValue(collection, new Object[] { arrayIndex });
                                retValue = BindProperty(indexedValue, propertyName.Substring(propertyName.IndexOf(".") + 1));
                            } catch
                            {
                                return null;
                            }                            
                        }
                        else
                            retValue = BindProperty(propertyInfo.GetValue(property, null), propertyName.Substring(propertyName.IndexOf(".") + 1));
                        break;
                    }
                }
            }
            else
            {
                Type propertyType;
                PropertyInfo propertyInfo;

                propertyType = property.GetType();
                propertyInfo = propertyType.GetProperty(propertyName);
                retValue = propertyInfo.GetValue(property, null).ToString();
            }

            return retValue;
        }
    

    private void NetworkDefinitionForm_Load(object sender, EventArgs e)
        {
            NodeDataGridView.AutoGenerateColumns = false;
            NodeDataGridView.DataSource = ConfigurationNodes;
            NodeDataGridView.Columns[0].DataPropertyName = "name";

            MessageDataGridView.AutoGenerateColumns = false;
            MessageDataGridView.VirtualMode = true;
            MessageDataGridView.DataSource = ConfigurationMessages;
            MessageDataGridView.Columns[0].DataPropertyName = "name";
            MessageDataGridView.Columns[1].DataPropertyName = "id";
            //MessageDataGridView.Columns[2].DataPropertyName = "format";
            DataGridViewComboBoxColumn publishingNode = (DataGridViewComboBoxColumn)MessageDataGridView.Columns[4];
            publishingNode.DataSource = ConfigurationNodes;
            publishingNode.DisplayMember = "name";
            publishingNode.ValueMember = "id";
            publishingNode.DataPropertyName = "Producer[0].id";
            MessageDataGridView.Columns[5].DataPropertyName = "Notes";
            

            SignalDataGridView.AutoGenerateColumns = false;
            SignalDataGridView.DataSource = ConfigurationSignals;
            SignalDataGridView.Columns[0].DataPropertyName = "name";
            SignalDataGridView.Columns[1].DataPropertyName = "id";
            SignalDataGridView.Columns[2].DataPropertyName = "format";
            SignalDataGridView.Columns[4].DataPropertyName = "Producer[0].id";
            SignalDataGridView.Columns[5].DataPropertyName = "Nodes";



            timer = new Timer
            {
                Interval = (1000)
            };
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            UpdateUnknownCan(false);
        }

        private void UpdateUnknownCan(Boolean force)
        {
            if (bus != null)
            {
                List<CanPacket> unknownCanIds = ConfigService.UnknownCanIds(bus);
                if (force) unknownCanLength = 0;

                if (unknownCanIds != null && unknownCanLength != unknownCanIds.Count)
                {
                    UnknownCanListView.Clear();

                    foreach (CanPacket canPacket in unknownCanIds)
                    {
                        ListViewItem listViewItem = new ListViewItem
                        {
                            Text = canPacket.CanIdAsHex
                        };
                        UnknownCanListView.Items.Add(listViewItem);
                    }

                    unknownCanLength = unknownCanIds.Count;
                }
            }
        }

    }
}
