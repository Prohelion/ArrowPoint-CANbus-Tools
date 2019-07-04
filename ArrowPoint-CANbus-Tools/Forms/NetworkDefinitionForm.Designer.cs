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
            this.NetworkDefinitionView = new System.Windows.Forms.TreeView();
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
            this.NodeMenuStrip.SuspendLayout();
            this.MessageMenuStrip.SuspendLayout();
            this.SignalMenuStrip.SuspendLayout();
            this.BusMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // NetworkDefinitionView
            // 
            this.NetworkDefinitionView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NetworkDefinitionView.ImageIndex = 0;
            this.NetworkDefinitionView.ImageList = this.ImageList;
            this.NetworkDefinitionView.Location = new System.Drawing.Point(0, 0);
            this.NetworkDefinitionView.Name = "NetworkDefinitionView";
            this.NetworkDefinitionView.SelectedImageIndex = 0;
            this.NetworkDefinitionView.ShowNodeToolTips = true;
            this.NetworkDefinitionView.Size = new System.Drawing.Size(183, 451);
            this.NetworkDefinitionView.TabIndex = 0;
            this.NetworkDefinitionView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.NetworkDefinitionView_NodeMouseDoubleClick);
            this.NetworkDefinitionView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NetworkDefinitionView_MouseUp);
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
            this.SignalMenuStrip.Size = new System.Drawing.Size(153, 70);
            // 
            // EditSignalMenuItem
            // 
            this.EditSignalMenuItem.Name = "EditSignalMenuItem";
            this.EditSignalMenuItem.Size = new System.Drawing.Size(152, 22);
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
            // NetworkDefinitionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 450);
            this.Controls.Add(this.NetworkDefinitionView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NetworkDefinitionForm";
            this.Text = "Network Definition";
            this.NodeMenuStrip.ResumeLayout(false);
            this.MessageMenuStrip.ResumeLayout(false);
            this.SignalMenuStrip.ResumeLayout(false);
            this.BusMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView NetworkDefinitionView;
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
    }
}