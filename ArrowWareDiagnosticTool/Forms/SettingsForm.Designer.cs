namespace ArrowWareDiagnosticTool.Forms
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.connectBtn = new System.Windows.Forms.Button();
            this.disconnectBtn = new System.Windows.Forms.Button();
            this.applyBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.portTb = new System.Windows.Forms.TextBox();
            this.ipAddressTb = new System.Windows.Forms.TextBox();
            this.portLbl = new System.Windows.Forms.Label();
            this.ipAddressLbl = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(12, 278);
            this.connectBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(198, 58);
            this.connectBtn.TabIndex = 0;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // disconnectBtn
            // 
            this.disconnectBtn.Location = new System.Drawing.Point(252, 278);
            this.disconnectBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.disconnectBtn.Name = "disconnectBtn";
            this.disconnectBtn.Size = new System.Drawing.Size(198, 58);
            this.disconnectBtn.TabIndex = 1;
            this.disconnectBtn.Text = "Disconnect";
            this.disconnectBtn.UseVisualStyleBackColor = true;
            this.disconnectBtn.Click += new System.EventHandler(this.disconnectBtn_Click);
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(491, 278);
            this.applyBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(198, 58);
            this.applyBtn.TabIndex = 2;
            this.applyBtn.Text = "Close";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.portTb);
            this.groupBox1.Controls.Add(this.ipAddressTb);
            this.groupBox1.Controls.Add(this.portLbl);
            this.groupBox1.Controls.Add(this.ipAddressLbl);
            this.groupBox1.Location = new System.Drawing.Point(15, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(675, 245);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection Settings";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(237, 185);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(180, 29);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "My name is Matt";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(237, 142);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(234, 29);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "I know what I am doing";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // portTb
            // 
            this.portTb.Location = new System.Drawing.Point(237, 96);
            this.portTb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.portTb.Name = "portTb";
            this.portTb.Size = new System.Drawing.Size(259, 29);
            this.portTb.TabIndex = 3;
            // 
            // ipAddressTb
            // 
            this.ipAddressTb.Location = new System.Drawing.Point(237, 50);
            this.ipAddressTb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ipAddressTb.Name = "ipAddressTb";
            this.ipAddressTb.Size = new System.Drawing.Size(259, 29);
            this.ipAddressTb.TabIndex = 2;
            // 
            // portLbl
            // 
            this.portLbl.Location = new System.Drawing.Point(110, 102);
            this.portLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.portLbl.Name = "portLbl";
            this.portLbl.Size = new System.Drawing.Size(106, 24);
            this.portLbl.TabIndex = 1;
            this.portLbl.Text = "Port";
            // 
            // ipAddressLbl
            // 
            this.ipAddressLbl.Location = new System.Drawing.Point(110, 53);
            this.ipAddressLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ipAddressLbl.Name = "ipAddressLbl";
            this.ipAddressLbl.Size = new System.Drawing.Size(106, 28);
            this.ipAddressLbl.TabIndex = 0;
            this.ipAddressLbl.Text = "IP Address";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 352);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.disconnectBtn);
            this.Controls.Add(this.connectBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Button disconnectBtn;
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox portTb;
        private System.Windows.Forms.TextBox ipAddressTb;
        private System.Windows.Forms.Label portLbl;
        private System.Windows.Forms.Label ipAddressLbl;
    }
}