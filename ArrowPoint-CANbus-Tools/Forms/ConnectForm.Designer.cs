namespace ArrowPointCANBusTool.Forms
{
    partial class ConnectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectForm));
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
            this.connectBtn.Location = new System.Drawing.Point(7, 151);
            this.connectBtn.Margin = new System.Windows.Forms.Padding(2);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(108, 31);
            this.connectBtn.TabIndex = 0;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // disconnectBtn
            // 
            this.disconnectBtn.Location = new System.Drawing.Point(137, 151);
            this.disconnectBtn.Margin = new System.Windows.Forms.Padding(2);
            this.disconnectBtn.Name = "disconnectBtn";
            this.disconnectBtn.Size = new System.Drawing.Size(108, 31);
            this.disconnectBtn.TabIndex = 1;
            this.disconnectBtn.Text = "Disconnect";
            this.disconnectBtn.UseVisualStyleBackColor = true;
            this.disconnectBtn.Click += new System.EventHandler(this.DisconnectBtn_Click);
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(268, 151);
            this.applyBtn.Margin = new System.Windows.Forms.Padding(2);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(108, 31);
            this.applyBtn.TabIndex = 2;
            this.applyBtn.Text = "Close";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.portTb);
            this.groupBox1.Controls.Add(this.ipAddressTb);
            this.groupBox1.Controls.Add(this.portLbl);
            this.groupBox1.Controls.Add(this.ipAddressLbl);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(368, 133);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection Settings";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(129, 100);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(100, 17);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Default Settings";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.RadioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(129, 77);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(96, 17);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.Text = "Expert Settings";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
            // 
            // portTb
            // 
            this.portTb.Location = new System.Drawing.Point(129, 52);
            this.portTb.Margin = new System.Windows.Forms.Padding(2);
            this.portTb.Name = "portTb";
            this.portTb.Size = new System.Drawing.Size(143, 20);
            this.portTb.TabIndex = 3;
            // 
            // ipAddressTb
            // 
            this.ipAddressTb.Location = new System.Drawing.Point(129, 27);
            this.ipAddressTb.Margin = new System.Windows.Forms.Padding(2);
            this.ipAddressTb.Name = "ipAddressTb";
            this.ipAddressTb.Size = new System.Drawing.Size(143, 20);
            this.ipAddressTb.TabIndex = 2;
            // 
            // portLbl
            // 
            this.portLbl.Location = new System.Drawing.Point(60, 55);
            this.portLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.portLbl.Name = "portLbl";
            this.portLbl.Size = new System.Drawing.Size(58, 13);
            this.portLbl.TabIndex = 1;
            this.portLbl.Text = "Port";
            // 
            // ipAddressLbl
            // 
            this.ipAddressLbl.Location = new System.Drawing.Point(60, 29);
            this.ipAddressLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ipAddressLbl.Name = "ipAddressLbl";
            this.ipAddressLbl.Size = new System.Drawing.Size(58, 15);
            this.ipAddressLbl.TabIndex = 0;
            this.ipAddressLbl.Text = "IP Address";
            // 
            // ConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 191);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.disconnectBtn);
            this.Controls.Add(this.connectBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectForm";
            this.Text = "Connect / Disconnect";
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