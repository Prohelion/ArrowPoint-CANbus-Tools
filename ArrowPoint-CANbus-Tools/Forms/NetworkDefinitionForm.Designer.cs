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
            this.NodeMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteNodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MessageMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteMessageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SignalMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteSignalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BusMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewNodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewSignalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MessageToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.NewMessageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NodeToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
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
            this.NetworkDefinitionView.Location = new System.Drawing.Point(0, 0);
            this.NetworkDefinitionView.Name = "NetworkDefinitionView";
            this.NetworkDefinitionView.ShowNodeToolTips = true;
            this.NetworkDefinitionView.Size = new System.Drawing.Size(183, 451);
            this.NetworkDefinitionView.TabIndex = 0;
            this.NetworkDefinitionView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.NetworkDefinitionView_NodeMouseDoubleClick);
            this.NetworkDefinitionView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NetworkDefinitionView_MouseUp);
            // 
            // NodeMenuStrip
            // 
            this.NodeMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewMessageMenuItem,
            this.NodeToolStripSeparator,
            this.DeleteNodeMenuItem});
            this.NodeMenuStrip.Name = "NodeMenuStrip";
            this.NodeMenuStrip.Size = new System.Drawing.Size(148, 54);
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
            this.DeleteMessageMenuItem});
            this.MessageMenuStrip.Name = "MessageMenuStrip";
            this.MessageMenuStrip.Size = new System.Drawing.Size(157, 54);
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
            this.DeleteSignalMenuItem});
            this.SignalMenuStrip.Name = "SignalMenuStrip";
            this.SignalMenuStrip.Size = new System.Drawing.Size(143, 26);
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
            this.BusMenuStrip.Size = new System.Drawing.Size(181, 48);
            // 
            // NewNodeMenuItem
            // 
            this.NewNodeMenuItem.Name = "NewNodeMenuItem";
            this.NewNodeMenuItem.Size = new System.Drawing.Size(180, 22);
            this.NewNodeMenuItem.Text = "New Node";
            this.NewNodeMenuItem.Click += new System.EventHandler(this.NewNodeMenuItem_Click);
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
    }
}