namespace ArrowPointCANBusTool.Forms
{
    partial class NetworkDefinitionForm
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
                timer.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetworkDefinitionForm));
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.NodeMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewMessageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NodeToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.EditNodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteNodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MessageMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewSignalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MessageToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.EditMessageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteMessageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SignalMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EditSignalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteSignalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BusMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewNodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.CanNodesSplitContainer = new System.Windows.Forms.SplitContainer();
            this.NetworkDefinitionView = new System.Windows.Forms.TreeView();
            this.UnknownCanListView = new System.Windows.Forms.ListView();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.MessagesAndSignalsTabPage = new System.Windows.Forms.TabPage();
            this.MessageSplitContainer = new System.Windows.Forms.SplitContainer();
            this.MessageSplitContainerUpper = new System.Windows.Forms.SplitContainer();
            this.MessageDataGridView = new System.Windows.Forms.DataGridView();
            this.MessageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CanId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DLC = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SendingNode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CanPacketDataGridView = new System.Windows.Forms.DataGridView();
            this.Bye7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Byte6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Byte5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Byte4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Byte3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Byte2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Byte1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Byte0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SignalDataGridView = new System.Windows.Forms.DataGridView();
            this.SignalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Format = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Mode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.StartBit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Factor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Offset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Minimum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Maximum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SignalComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoteListTabPage = new System.Windows.Forms.TabPage();
            this.NodeDataGridView = new System.Windows.Forms.DataGridView();
            this.NodeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommsMatrixTabPage = new System.Windows.Forms.TabPage();
            this.CommunicationsDataGridView = new System.Windows.Forms.DataGridView();
            this.CommsDataGridView = new System.Windows.Forms.DataGridView();
            this.EnvVariablesTabPage = new System.Windows.Forms.TabPage();
            this.EnvironmentDataGridView = new System.Windows.Forms.DataGridView();
            this.EnvironmentVariable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnvType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnvUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnvMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnvMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnvComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Access = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Values = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnvionmentDataGridView = new System.Windows.Forms.DataGridView();
            this.AttributesTabPage = new System.Windows.Forms.TabPage();
            this.AttributeDataGridView = new System.Windows.Forms.DataGridView();
            this.Attribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttributeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttributeValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttributeTypeOfObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttributesDataGridView = new System.Windows.Forms.DataGridView();
            this.NodeMenuStrip.SuspendLayout();
            this.MessageMenuStrip.SuspendLayout();
            this.SignalMenuStrip.SuspendLayout();
            this.BusMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CanNodesSplitContainer)).BeginInit();
            this.CanNodesSplitContainer.Panel1.SuspendLayout();
            this.CanNodesSplitContainer.Panel2.SuspendLayout();
            this.CanNodesSplitContainer.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.MessagesAndSignalsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MessageSplitContainer)).BeginInit();
            this.MessageSplitContainer.Panel1.SuspendLayout();
            this.MessageSplitContainer.Panel2.SuspendLayout();
            this.MessageSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MessageSplitContainerUpper)).BeginInit();
            this.MessageSplitContainerUpper.Panel1.SuspendLayout();
            this.MessageSplitContainerUpper.Panel2.SuspendLayout();
            this.MessageSplitContainerUpper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MessageDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CanPacketDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SignalDataGridView)).BeginInit();
            this.NoteListTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NodeDataGridView)).BeginInit();
            this.CommsMatrixTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CommunicationsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommsDataGridView)).BeginInit();
            this.EnvVariablesTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EnvironmentDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnvionmentDataGridView)).BeginInit();
            this.AttributesTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AttributeDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttributesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "Prohelion");
            this.ImageList.Images.SetKeyName(1, "Node");
            this.ImageList.Images.SetKeyName(2, "Message");
            this.ImageList.Images.SetKeyName(3, "Signal");
            // 
            // NodeMenuStrip
            // 
            this.NodeMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewMessageMenuItem,
            this.NodeToolStripSeparator,
            this.EditNodeMenuItem,
            this.DeleteNodeMenuItem});
            this.NodeMenuStrip.Name = "NodeMenuStrip";
            this.NodeMenuStrip.Size = new System.Drawing.Size(148, 76);
            // 
            // NewMessageMenuItem
            // 
            this.NewMessageMenuItem.Name = "NewMessageMenuItem";
            this.NewMessageMenuItem.Size = new System.Drawing.Size(147, 22);
            this.NewMessageMenuItem.Text = "New Message";
            this.NewMessageMenuItem.Click += new System.EventHandler(this.NewMessageMenuItem_Click);
            // 
            // NodeToolStripSeparator
            // 
            this.NodeToolStripSeparator.Name = "NodeToolStripSeparator";
            this.NodeToolStripSeparator.Size = new System.Drawing.Size(144, 6);
            // 
            // EditNodeMenuItem
            // 
            this.EditNodeMenuItem.Name = "EditNodeMenuItem";
            this.EditNodeMenuItem.Size = new System.Drawing.Size(147, 22);
            this.EditNodeMenuItem.Text = "Edit Node";
            this.EditNodeMenuItem.Click += new System.EventHandler(this.EditNodeMenuItem_Click);
            // 
            // DeleteNodeMenuItem
            // 
            this.DeleteNodeMenuItem.Name = "DeleteNodeMenuItem";
            this.DeleteNodeMenuItem.Size = new System.Drawing.Size(147, 22);
            this.DeleteNodeMenuItem.Text = "Delete Node";
            this.DeleteNodeMenuItem.Click += new System.EventHandler(this.DeleteNodeMenuItem_Click);
            // 
            // MessageMenuStrip
            // 
            this.MessageMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewSignalMenuItem,
            this.MessageToolStripSeparator,
            this.EditMessageMenuItem,
            this.DeleteMessageMenuItem});
            this.MessageMenuStrip.Name = "MessageMenuStrip";
            this.MessageMenuStrip.Size = new System.Drawing.Size(157, 76);
            // 
            // NewSignalMenuItem
            // 
            this.NewSignalMenuItem.Name = "NewSignalMenuItem";
            this.NewSignalMenuItem.Size = new System.Drawing.Size(156, 22);
            this.NewSignalMenuItem.Text = "New Signal";
            this.NewSignalMenuItem.Click += new System.EventHandler(this.NewSignalMenuItem_Click);
            // 
            // MessageToolStripSeparator
            // 
            this.MessageToolStripSeparator.Name = "MessageToolStripSeparator";
            this.MessageToolStripSeparator.Size = new System.Drawing.Size(153, 6);
            // 
            // EditMessageMenuItem
            // 
            this.EditMessageMenuItem.Name = "EditMessageMenuItem";
            this.EditMessageMenuItem.Size = new System.Drawing.Size(156, 22);
            this.EditMessageMenuItem.Text = "Edit Message";
            this.EditMessageMenuItem.Click += new System.EventHandler(this.EditMessageMenuItem_Click);
            // 
            // DeleteMessageMenuItem
            // 
            this.DeleteMessageMenuItem.Name = "DeleteMessageMenuItem";
            this.DeleteMessageMenuItem.Size = new System.Drawing.Size(156, 22);
            this.DeleteMessageMenuItem.Text = "Delete Message";
            this.DeleteMessageMenuItem.Click += new System.EventHandler(this.DeleteMessageMenuItem_Click);
            // 
            // SignalMenuStrip
            // 
            this.SignalMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditSignalMenuItem,
            this.DeleteSignalMenuItem});
            this.SignalMenuStrip.Name = "SignalMenuStrip";
            this.SignalMenuStrip.Size = new System.Drawing.Size(143, 48);
            // 
            // EditSignalMenuItem
            // 
            this.EditSignalMenuItem.Name = "EditSignalMenuItem";
            this.EditSignalMenuItem.Size = new System.Drawing.Size(142, 22);
            this.EditSignalMenuItem.Text = "Edit Signal";
            this.EditSignalMenuItem.Click += new System.EventHandler(this.EditSignalMenuItem_Click);
            // 
            // DeleteSignalMenuItem
            // 
            this.DeleteSignalMenuItem.Name = "DeleteSignalMenuItem";
            this.DeleteSignalMenuItem.Size = new System.Drawing.Size(142, 22);
            this.DeleteSignalMenuItem.Text = "Delete Signal";
            this.DeleteSignalMenuItem.Click += new System.EventHandler(this.DeleteSignalMenuItem_Click);
            // 
            // BusMenuStrip
            // 
            this.BusMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewNodeMenuItem});
            this.BusMenuStrip.Name = "BusMenuStrip";
            this.BusMenuStrip.Size = new System.Drawing.Size(131, 26);
            // 
            // NewNodeMenuItem
            // 
            this.NewNodeMenuItem.Name = "NewNodeMenuItem";
            this.NewNodeMenuItem.Size = new System.Drawing.Size(130, 22);
            this.NewNodeMenuItem.Text = "New Node";
            this.NewNodeMenuItem.Click += new System.EventHandler(this.NewNodeMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1101, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 25);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.CanNodesSplitContainer);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.MainTabControl);
            this.MainSplitContainer.Size = new System.Drawing.Size(1101, 517);
            this.MainSplitContainer.SplitterDistance = 157;
            this.MainSplitContainer.TabIndex = 5;
            // 
            // CanNodesSplitContainer
            // 
            this.CanNodesSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CanNodesSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CanNodesSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.CanNodesSplitContainer.Name = "CanNodesSplitContainer";
            this.CanNodesSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // CanNodesSplitContainer.Panel1
            // 
            this.CanNodesSplitContainer.Panel1.Controls.Add(this.NetworkDefinitionView);
            // 
            // CanNodesSplitContainer.Panel2
            // 
            this.CanNodesSplitContainer.Panel2.Controls.Add(this.UnknownCanListView);
            this.CanNodesSplitContainer.Size = new System.Drawing.Size(157, 517);
            this.CanNodesSplitContainer.SplitterDistance = 137;
            this.CanNodesSplitContainer.TabIndex = 0;
            // 
            // NetworkDefinitionView
            // 
            this.NetworkDefinitionView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NetworkDefinitionView.Location = new System.Drawing.Point(0, 0);
            this.NetworkDefinitionView.Name = "NetworkDefinitionView";
            this.NetworkDefinitionView.Size = new System.Drawing.Size(155, 135);
            this.NetworkDefinitionView.TabIndex = 0;
            this.NetworkDefinitionView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NetworkDefinitionView_MouseUp);
            // 
            // UnknownCanListView
            // 
            this.UnknownCanListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UnknownCanListView.Location = new System.Drawing.Point(0, 0);
            this.UnknownCanListView.Name = "UnknownCanListView";
            this.UnknownCanListView.Size = new System.Drawing.Size(155, 374);
            this.UnknownCanListView.TabIndex = 0;
            this.UnknownCanListView.UseCompatibleStateImageBehavior = false;
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.MessagesAndSignalsTabPage);
            this.MainTabControl.Controls.Add(this.NoteListTabPage);
            this.MainTabControl.Controls.Add(this.CommsMatrixTabPage);
            this.MainTabControl.Controls.Add(this.EnvVariablesTabPage);
            this.MainTabControl.Controls.Add(this.AttributesTabPage);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(0, 0);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(938, 515);
            this.MainTabControl.TabIndex = 0;
            // 
            // MessagesAndSignalsTabPage
            // 
            this.MessagesAndSignalsTabPage.Controls.Add(this.MessageSplitContainer);
            this.MessagesAndSignalsTabPage.Location = new System.Drawing.Point(4, 22);
            this.MessagesAndSignalsTabPage.Name = "MessagesAndSignalsTabPage";
            this.MessagesAndSignalsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MessagesAndSignalsTabPage.Size = new System.Drawing.Size(930, 489);
            this.MessagesAndSignalsTabPage.TabIndex = 1;
            this.MessagesAndSignalsTabPage.Text = "Messages & Signals";
            this.MessagesAndSignalsTabPage.UseVisualStyleBackColor = true;
            // 
            // MessageSplitContainer
            // 
            this.MessageSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.MessageSplitContainer.Name = "MessageSplitContainer";
            this.MessageSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MessageSplitContainer.Panel1
            // 
            this.MessageSplitContainer.Panel1.Controls.Add(this.MessageSplitContainerUpper);
            // 
            // MessageSplitContainer.Panel2
            // 
            this.MessageSplitContainer.Panel2.Controls.Add(this.SignalDataGridView);
            this.MessageSplitContainer.Size = new System.Drawing.Size(924, 483);
            this.MessageSplitContainer.SplitterDistance = 311;
            this.MessageSplitContainer.TabIndex = 0;
            // 
            // MessageSplitContainerUpper
            // 
            this.MessageSplitContainerUpper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageSplitContainerUpper.Location = new System.Drawing.Point(0, 0);
            this.MessageSplitContainerUpper.Name = "MessageSplitContainerUpper";
            // 
            // MessageSplitContainerUpper.Panel1
            // 
            this.MessageSplitContainerUpper.Panel1.Controls.Add(this.MessageDataGridView);
            // 
            // MessageSplitContainerUpper.Panel2
            // 
            this.MessageSplitContainerUpper.Panel2.Controls.Add(this.CanPacketDataGridView);
            this.MessageSplitContainerUpper.Size = new System.Drawing.Size(924, 311);
            this.MessageSplitContainerUpper.SplitterDistance = 697;
            this.MessageSplitContainerUpper.TabIndex = 0;
            // 
            // MessageDataGridView
            // 
            this.MessageDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MessageDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MessageDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MessageName,
            this.CanId,
            this.IdType,
            this.DLC,
            this.SendingNode,
            this.Comment});
            this.MessageDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageDataGridView.Location = new System.Drawing.Point(0, 0);
            this.MessageDataGridView.Name = "MessageDataGridView";
            this.MessageDataGridView.Size = new System.Drawing.Size(697, 311);
            this.MessageDataGridView.TabIndex = 0;
            this.MessageDataGridView.VirtualMode = true;
            this.MessageDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.MessageDataGridView_CellValueNeeded);
            this.MessageDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.MessageDataGridView_CellValuePushed);
            // 
            // MessageName
            // 
            this.MessageName.HeaderText = "Message Name";
            this.MessageName.Name = "MessageName";
            // 
            // CanId
            // 
            this.CanId.HeaderText = "CanId (Hex)";
            this.CanId.Name = "CanId";
            // 
            // IdType
            // 
            this.IdType.HeaderText = "Id Type";
            this.IdType.Items.AddRange(new object[] {
            "standard",
            "extended"});
            this.IdType.Name = "IdType";
            this.IdType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IdType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DLC
            // 
            this.DLC.HeaderText = "DLC";
            this.DLC.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.DLC.Name = "DLC";
            this.DLC.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DLC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SendingNode
            // 
            this.SendingNode.HeaderText = "Sending Node";
            this.SendingNode.Name = "SendingNode";
            this.SendingNode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SendingNode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Comment
            // 
            this.Comment.HeaderText = "Comment";
            this.Comment.Name = "Comment";
            // 
            // CanPacketDataGridView
            // 
            this.CanPacketDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CanPacketDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CanPacketDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Bye7,
            this.Byte6,
            this.Byte5,
            this.Byte4,
            this.Byte3,
            this.Byte2,
            this.Byte1,
            this.Byte0});
            this.CanPacketDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CanPacketDataGridView.Location = new System.Drawing.Point(0, 0);
            this.CanPacketDataGridView.Name = "CanPacketDataGridView";
            this.CanPacketDataGridView.RowHeadersVisible = false;
            this.CanPacketDataGridView.Size = new System.Drawing.Size(223, 311);
            this.CanPacketDataGridView.TabIndex = 0;
            // 
            // Bye7
            // 
            this.Bye7.HeaderText = "7";
            this.Bye7.Name = "Bye7";
            // 
            // Byte6
            // 
            this.Byte6.HeaderText = "6";
            this.Byte6.Name = "Byte6";
            // 
            // Byte5
            // 
            this.Byte5.HeaderText = "5";
            this.Byte5.Name = "Byte5";
            // 
            // Byte4
            // 
            this.Byte4.HeaderText = "4";
            this.Byte4.Name = "Byte4";
            // 
            // Byte3
            // 
            this.Byte3.HeaderText = "3";
            this.Byte3.Name = "Byte3";
            // 
            // Byte2
            // 
            this.Byte2.HeaderText = "2";
            this.Byte2.Name = "Byte2";
            // 
            // Byte1
            // 
            this.Byte1.HeaderText = "1";
            this.Byte1.Name = "Byte1";
            // 
            // Byte0
            // 
            this.Byte0.HeaderText = "0";
            this.Byte0.Name = "Byte0";
            // 
            // SignalDataGridView
            // 
            this.SignalDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SignalDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SignalDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SignalName,
            this.Type,
            this.Format,
            this.Mode,
            this.StartBit,
            this.Length,
            this.Factor,
            this.Offset,
            this.Minimum,
            this.Maximum,
            this.Unit,
            this.SignalComment});
            this.SignalDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SignalDataGridView.Location = new System.Drawing.Point(0, 0);
            this.SignalDataGridView.Name = "SignalDataGridView";
            this.SignalDataGridView.Size = new System.Drawing.Size(924, 168);
            this.SignalDataGridView.TabIndex = 0;
            // 
            // SignalName
            // 
            this.SignalName.HeaderText = "Signal Name";
            this.SignalName.Name = "SignalName";
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Items.AddRange(new object[] {
            "signed",
            "unsigned",
            "float",
            "double"});
            this.Type.Name = "Type";
            this.Type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Format
            // 
            this.Format.HeaderText = "Endian Format";
            this.Format.Items.AddRange(new object[] {
            "little",
            "big"});
            this.Format.Name = "Format";
            this.Format.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Format.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Mode
            // 
            this.Mode.HeaderText = "Mode";
            this.Mode.Items.AddRange(new object[] {
            "normal",
            "signal"});
            this.Mode.Name = "Mode";
            this.Mode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Mode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // StartBit
            // 
            this.StartBit.HeaderText = "Start Bit";
            this.StartBit.Name = "StartBit";
            // 
            // Length
            // 
            this.Length.HeaderText = "Length";
            this.Length.Name = "Length";
            // 
            // Factor
            // 
            this.Factor.HeaderText = "Factor";
            this.Factor.Name = "Factor";
            // 
            // Offset
            // 
            this.Offset.HeaderText = "Offset";
            this.Offset.Name = "Offset";
            // 
            // Minimum
            // 
            this.Minimum.HeaderText = "Minimum";
            this.Minimum.Name = "Minimum";
            // 
            // Maximum
            // 
            this.Maximum.HeaderText = "Maximum";
            this.Maximum.Name = "Maximum";
            // 
            // Unit
            // 
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            // 
            // SignalComment
            // 
            this.SignalComment.HeaderText = "Comment";
            this.SignalComment.Name = "SignalComment";
            // 
            // NoteListTabPage
            // 
            this.NoteListTabPage.Controls.Add(this.NodeDataGridView);
            this.NoteListTabPage.Location = new System.Drawing.Point(4, 22);
            this.NoteListTabPage.Name = "NoteListTabPage";
            this.NoteListTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.NoteListTabPage.Size = new System.Drawing.Size(930, 489);
            this.NoteListTabPage.TabIndex = 2;
            this.NoteListTabPage.Text = "Node List";
            this.NoteListTabPage.UseVisualStyleBackColor = true;
            // 
            // NodeDataGridView
            // 
            this.NodeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.NodeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NodeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NodeName});
            this.NodeDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NodeDataGridView.Location = new System.Drawing.Point(3, 3);
            this.NodeDataGridView.Name = "NodeDataGridView";
            this.NodeDataGridView.Size = new System.Drawing.Size(924, 483);
            this.NodeDataGridView.TabIndex = 0;
            // 
            // NodeName
            // 
            this.NodeName.HeaderText = "Node Name";
            this.NodeName.Name = "NodeName";
            // 
            // CommsMatrixTabPage
            // 
            this.CommsMatrixTabPage.Controls.Add(this.CommunicationsDataGridView);
            this.CommsMatrixTabPage.Controls.Add(this.CommsDataGridView);
            this.CommsMatrixTabPage.Location = new System.Drawing.Point(4, 22);
            this.CommsMatrixTabPage.Name = "CommsMatrixTabPage";
            this.CommsMatrixTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.CommsMatrixTabPage.Size = new System.Drawing.Size(930, 489);
            this.CommsMatrixTabPage.TabIndex = 3;
            this.CommsMatrixTabPage.Text = "Communications Matrix";
            this.CommsMatrixTabPage.UseVisualStyleBackColor = true;
            // 
            // CommunicationsDataGridView
            // 
            this.CommunicationsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CommunicationsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommunicationsDataGridView.Location = new System.Drawing.Point(3, 3);
            this.CommunicationsDataGridView.Name = "CommunicationsDataGridView";
            this.CommunicationsDataGridView.Size = new System.Drawing.Size(924, 483);
            this.CommunicationsDataGridView.TabIndex = 1;
            // 
            // CommsDataGridView
            // 
            this.CommsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CommsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommsDataGridView.Location = new System.Drawing.Point(3, 3);
            this.CommsDataGridView.Name = "CommsDataGridView";
            this.CommsDataGridView.Size = new System.Drawing.Size(924, 483);
            this.CommsDataGridView.TabIndex = 0;
            // 
            // EnvVariablesTabPage
            // 
            this.EnvVariablesTabPage.Controls.Add(this.EnvironmentDataGridView);
            this.EnvVariablesTabPage.Controls.Add(this.EnvionmentDataGridView);
            this.EnvVariablesTabPage.Location = new System.Drawing.Point(4, 22);
            this.EnvVariablesTabPage.Name = "EnvVariablesTabPage";
            this.EnvVariablesTabPage.Size = new System.Drawing.Size(930, 489);
            this.EnvVariablesTabPage.TabIndex = 4;
            this.EnvVariablesTabPage.Text = "Environmental Variables";
            this.EnvVariablesTabPage.UseVisualStyleBackColor = true;
            // 
            // EnvironmentDataGridView
            // 
            this.EnvironmentDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.EnvironmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EnvironmentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EnvironmentVariable,
            this.EnvType,
            this.EnvUnit,
            this.EnvMin,
            this.EnvMax,
            this.StartValue,
            this.EnvComment,
            this.Access,
            this.Values});
            this.EnvironmentDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EnvironmentDataGridView.Location = new System.Drawing.Point(0, 0);
            this.EnvironmentDataGridView.Name = "EnvironmentDataGridView";
            this.EnvironmentDataGridView.Size = new System.Drawing.Size(930, 489);
            this.EnvironmentDataGridView.TabIndex = 1;
            // 
            // EnvironmentVariable
            // 
            this.EnvironmentVariable.HeaderText = "Environment Variable";
            this.EnvironmentVariable.Name = "EnvironmentVariable";
            // 
            // EnvType
            // 
            this.EnvType.HeaderText = "Type";
            this.EnvType.Name = "EnvType";
            // 
            // EnvUnit
            // 
            this.EnvUnit.HeaderText = "Unit";
            this.EnvUnit.Name = "EnvUnit";
            // 
            // EnvMin
            // 
            this.EnvMin.HeaderText = "Minimum";
            this.EnvMin.Name = "EnvMin";
            // 
            // EnvMax
            // 
            this.EnvMax.HeaderText = "Maximum";
            this.EnvMax.Name = "EnvMax";
            // 
            // StartValue
            // 
            this.StartValue.HeaderText = "Start Value";
            this.StartValue.Name = "StartValue";
            // 
            // EnvComment
            // 
            this.EnvComment.HeaderText = "Comment";
            this.EnvComment.Name = "EnvComment";
            // 
            // Access
            // 
            this.Access.HeaderText = "Access";
            this.Access.Name = "Access";
            // 
            // Values
            // 
            this.Values.HeaderText = "Values";
            this.Values.Name = "Values";
            // 
            // EnvionmentDataGridView
            // 
            this.EnvionmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EnvionmentDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EnvionmentDataGridView.Location = new System.Drawing.Point(0, 0);
            this.EnvionmentDataGridView.Name = "EnvionmentDataGridView";
            this.EnvionmentDataGridView.Size = new System.Drawing.Size(930, 489);
            this.EnvionmentDataGridView.TabIndex = 0;
            // 
            // AttributesTabPage
            // 
            this.AttributesTabPage.Controls.Add(this.AttributeDataGridView);
            this.AttributesTabPage.Controls.Add(this.AttributesDataGridView);
            this.AttributesTabPage.Location = new System.Drawing.Point(4, 22);
            this.AttributesTabPage.Name = "AttributesTabPage";
            this.AttributesTabPage.Size = new System.Drawing.Size(930, 489);
            this.AttributesTabPage.TabIndex = 5;
            this.AttributesTabPage.Text = "Attributes";
            this.AttributesTabPage.UseVisualStyleBackColor = true;
            // 
            // AttributeDataGridView
            // 
            this.AttributeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AttributeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AttributeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Attribute,
            this.AttributeType,
            this.AttributeValue,
            this.AttributeTypeOfObject});
            this.AttributeDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AttributeDataGridView.Location = new System.Drawing.Point(0, 0);
            this.AttributeDataGridView.Name = "AttributeDataGridView";
            this.AttributeDataGridView.Size = new System.Drawing.Size(930, 489);
            this.AttributeDataGridView.TabIndex = 1;
            // 
            // Attribute
            // 
            this.Attribute.HeaderText = "Attribute";
            this.Attribute.Name = "Attribute";
            // 
            // AttributeType
            // 
            this.AttributeType.HeaderText = "Type";
            this.AttributeType.Name = "AttributeType";
            // 
            // AttributeValue
            // 
            this.AttributeValue.HeaderText = "Value";
            this.AttributeValue.Name = "AttributeValue";
            // 
            // AttributeTypeOfObject
            // 
            this.AttributeTypeOfObject.HeaderText = "Type Of Object";
            this.AttributeTypeOfObject.Name = "AttributeTypeOfObject";
            // 
            // AttributesDataGridView
            // 
            this.AttributesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AttributesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AttributesDataGridView.Location = new System.Drawing.Point(0, 0);
            this.AttributesDataGridView.Name = "AttributesDataGridView";
            this.AttributesDataGridView.Size = new System.Drawing.Size(930, 489);
            this.AttributesDataGridView.TabIndex = 0;
            // 
            // NetworkDefinitionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 542);
            this.Controls.Add(this.MainSplitContainer);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NetworkDefinitionForm";
            this.Text = "Network Definition";
            this.Load += new System.EventHandler(this.NetworkDefinitionForm_Load);
            this.NodeMenuStrip.ResumeLayout(false);
            this.MessageMenuStrip.ResumeLayout(false);
            this.SignalMenuStrip.ResumeLayout(false);
            this.BusMenuStrip.ResumeLayout(false);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.CanNodesSplitContainer.Panel1.ResumeLayout(false);
            this.CanNodesSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CanNodesSplitContainer)).EndInit();
            this.CanNodesSplitContainer.ResumeLayout(false);
            this.MainTabControl.ResumeLayout(false);
            this.MessagesAndSignalsTabPage.ResumeLayout(false);
            this.MessageSplitContainer.Panel1.ResumeLayout(false);
            this.MessageSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MessageSplitContainer)).EndInit();
            this.MessageSplitContainer.ResumeLayout(false);
            this.MessageSplitContainerUpper.Panel1.ResumeLayout(false);
            this.MessageSplitContainerUpper.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MessageSplitContainerUpper)).EndInit();
            this.MessageSplitContainerUpper.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MessageDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CanPacketDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SignalDataGridView)).EndInit();
            this.NoteListTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NodeDataGridView)).EndInit();
            this.CommsMatrixTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CommunicationsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommsDataGridView)).EndInit();
            this.EnvVariablesTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EnvironmentDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnvionmentDataGridView)).EndInit();
            this.AttributesTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AttributeDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttributesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip NodeMenuStrip;
        private System.Windows.Forms.ContextMenuStrip MessageMenuStrip;
        private System.Windows.Forms.ContextMenuStrip SignalMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem DeleteNodeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteMessageMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteSignalMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewMessageMenuItem;
        private System.Windows.Forms.ToolStripSeparator NodeToolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem NewSignalMenuItem;
        private System.Windows.Forms.ToolStripSeparator MessageToolStripSeparator;
        private System.Windows.Forms.ContextMenuStrip BusMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem NewNodeMenuItem;
        private System.Windows.Forms.ImageList ImageList;
        private System.Windows.Forms.ToolStripMenuItem EditNodeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditMessageMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditSignalMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.SplitContainer CanNodesSplitContainer;
        private System.Windows.Forms.TreeView NetworkDefinitionView;
        private System.Windows.Forms.ListView UnknownCanListView;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage MessagesAndSignalsTabPage;
        private System.Windows.Forms.SplitContainer MessageSplitContainer;
        private System.Windows.Forms.SplitContainer MessageSplitContainerUpper;
        private System.Windows.Forms.TabPage NoteListTabPage;
        private System.Windows.Forms.TabPage CommsMatrixTabPage;
        private System.Windows.Forms.TabPage EnvVariablesTabPage;
        private System.Windows.Forms.TabPage AttributesTabPage;
        private System.Windows.Forms.DataGridView MessageDataGridView;
        private System.Windows.Forms.DataGridView SignalDataGridView;
        private System.Windows.Forms.DataGridView NodeDataGridView;
        private System.Windows.Forms.DataGridView CommunicationsDataGridView;
        private System.Windows.Forms.DataGridView CommsDataGridView;
        private System.Windows.Forms.DataGridView EnvironmentDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnvironmentVariable;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnvType;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnvUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnvMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnvMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnvComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Access;
        private System.Windows.Forms.DataGridViewTextBoxColumn Values;
        private System.Windows.Forms.DataGridView EnvionmentDataGridView;
        private System.Windows.Forms.DataGridView AttributeDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attribute;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttributeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttributeValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttributeTypeOfObject;
        private System.Windows.Forms.DataGridView AttributesDataGridView;
        private System.Windows.Forms.DataGridView CanPacketDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bye7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Byte6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Byte5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Byte4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Byte3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Byte2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Byte1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Byte0;
        private System.Windows.Forms.DataGridViewTextBoxColumn NodeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MessageName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CanId;
        private System.Windows.Forms.DataGridViewComboBoxColumn IdType;
        private System.Windows.Forms.DataGridViewComboBoxColumn DLC;
        private System.Windows.Forms.DataGridViewComboBoxColumn SendingNode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn SignalName;
        private System.Windows.Forms.DataGridViewComboBoxColumn Type;
        private System.Windows.Forms.DataGridViewComboBoxColumn Format;
        private System.Windows.Forms.DataGridViewComboBoxColumn Mode;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartBit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn Factor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Offset;
        private System.Windows.Forms.DataGridViewTextBoxColumn Minimum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Maximum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn SignalComment;
    }
}