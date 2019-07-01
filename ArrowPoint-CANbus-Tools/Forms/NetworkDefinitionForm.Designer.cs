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
            this.NewNodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MessageMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewMessageStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SignalMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewSignalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NodeMenuStrip.SuspendLayout();
            this.MessageMenuStrip.SuspendLayout();
            this.SignalMenuStrip.SuspendLayout();
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
            this.NewNodeMenuItem});
            this.NodeMenuStrip.Name = "NodeMenuStrip";
            this.NodeMenuStrip.Size = new System.Drawing.Size(131, 26);
            // 
            // NewNodeMenuItem
            // 
            this.NewNodeMenuItem.Name = "NewNodeMenuItem";
            this.NewNodeMenuItem.Size = new System.Drawing.Size(130, 22);
            this.NewNodeMenuItem.Text = "New Node";
            this.NewNodeMenuItem.Click += new System.EventHandler(this.NewNodeMenuItem_Click);
            // 
            // MessageMenuStrip
            // 
            this.MessageMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewMessageStripMenuItem});
            this.MessageMenuStrip.Name = "MessageMenuStrip";
            this.MessageMenuStrip.Size = new System.Drawing.Size(148, 26);
            // 
            // NewMessageStripMenuItem
            // 
            this.NewMessageStripMenuItem.Name = "NewMessageStripMenuItem";
            this.NewMessageStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.NewMessageStripMenuItem.Text = "New Message";
            
            // 
            // SignalMenuStrip
            // 
            this.SignalMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewSignalToolStripMenuItem});
            this.SignalMenuStrip.Name = "SignalMenuStrip";
            this.SignalMenuStrip.Size = new System.Drawing.Size(181, 48);
            // 
            // NewSignalToolStripMenuItem
            // 
            this.NewSignalToolStripMenuItem.Name = "NewSignalToolStripMenuItem";
            this.NewSignalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.NewSignalToolStripMenuItem.Text = "New Signal";
            
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
            this.NodeMenuStrip.ResumeLayout(false);
            this.MessageMenuStrip.ResumeLayout(false);
            this.SignalMenuStrip.ResumeLayout(false);
            this.Text = "Network Definition";            
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TreeView NetworkDefinitionView;
        private System.Windows.Forms.ContextMenuStrip NodeMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem NewNodeMenuItem;
        private System.Windows.Forms.ContextMenuStrip MessageMenuStrip;
        private System.Windows.Forms.ContextMenuStrip SignalMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem NewMessageStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewSignalToolStripMenuItem;
    }
}