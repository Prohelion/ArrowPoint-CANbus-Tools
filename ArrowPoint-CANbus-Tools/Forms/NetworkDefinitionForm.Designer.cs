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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetworkDefinitionForm));
            this.NetworkDefinitionView = new System.Windows.Forms.TreeView();
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView NetworkDefinitionView;
    }
}