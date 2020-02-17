namespace ArrowPointCANBusTool.Forms
{
    partial class DataLoggerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataLoggerForm));
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.logLocally = new System.Windows.Forms.RadioButton();
            this.logViaFTP = new System.Windows.Forms.RadioButton();
            this.destinationGroupBox = new System.Windows.Forms.GroupBox();
            this.logViaSFTP = new System.Windows.Forms.RadioButton();
            this.RotationGroupBox = new System.Windows.Forms.GroupBox();
            this.MBlabel = new System.Windows.Forms.Label();
            this.MBtextBox = new System.Windows.Forms.TextBox();
            this.minutesTextBox = new System.Windows.Forms.TextBox();
            this.minutesLabel = new System.Windows.Forms.Label();
            this.sizeRotate = new System.Windows.Forms.RadioButton();
            this.timeRotate = new System.Windows.Forms.RadioButton();
            this.destGroupBox = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.remoteDirTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.remoteHostTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.localDirSelect = new System.Windows.Forms.Button();
            this.localDirTextBox = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SaveConfigButton = new System.Windows.Forms.Button();
            this.LoadConfigButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip.SuspendLayout();
            this.destinationGroupBox.SuspendLayout();
            this.RotationGroupBox.SuspendLayout();
            this.destGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(216, 331);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(84, 31);
            this.btnStart.TabIndex = 33;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStartStop_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Location = new System.Drawing.Point(304, 331);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(84, 31);
            this.btnStop.TabIndex = 34;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusText});
            this.statusStrip.Location = new System.Drawing.Point(0, 374);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(399, 22);
            this.statusStrip.TabIndex = 6;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusText
            // 
            this.toolStripStatusText.Name = "toolStripStatusText";
            this.toolStripStatusText.Size = new System.Drawing.Size(26, 17);
            this.toolStripStatusText.Text = "Idle";
            // 
            // logLocally
            // 
            this.logLocally.AutoSize = true;
            this.logLocally.Checked = true;
            this.logLocally.Location = new System.Drawing.Point(18, 19);
            this.logLocally.Name = "logLocally";
            this.logLocally.Size = new System.Drawing.Size(115, 17);
            this.logLocally.TabIndex = 1;
            this.logLocally.TabStop = true;
            this.logLocally.Text = "Log Locally to Disk";
            this.logLocally.UseVisualStyleBackColor = true;
            // 
            // logViaFTP
            // 
            this.logViaFTP.AutoSize = true;
            this.logViaFTP.Location = new System.Drawing.Point(18, 42);
            this.logViaFTP.Name = "logViaFTP";
            this.logViaFTP.Size = new System.Drawing.Size(130, 17);
            this.logViaFTP.TabIndex = 2;
            this.logViaFTP.TabStop = true;
            this.logViaFTP.Text = "Log Remotely via FTP";
            this.logViaFTP.UseVisualStyleBackColor = true;
            // 
            // destinationGroupBox
            // 
            this.destinationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.destinationGroupBox.Controls.Add(this.logViaSFTP);
            this.destinationGroupBox.Controls.Add(this.logLocally);
            this.destinationGroupBox.Controls.Add(this.logViaFTP);
            this.destinationGroupBox.Location = new System.Drawing.Point(12, 12);
            this.destinationGroupBox.Name = "destinationGroupBox";
            this.destinationGroupBox.Size = new System.Drawing.Size(376, 92);
            this.destinationGroupBox.TabIndex = 9;
            this.destinationGroupBox.TabStop = false;
            this.destinationGroupBox.Text = "Specify your Log Destination";
            // 
            // logViaSFTP
            // 
            this.logViaSFTP.AutoSize = true;
            this.logViaSFTP.Location = new System.Drawing.Point(18, 65);
            this.logViaSFTP.Name = "logViaSFTP";
            this.logViaSFTP.Size = new System.Drawing.Size(137, 17);
            this.logViaSFTP.TabIndex = 3;
            this.logViaSFTP.TabStop = true;
            this.logViaSFTP.Text = "Log Remotely via SFTP";
            this.logViaSFTP.UseVisualStyleBackColor = true;
            // 
            // RotationGroupBox
            // 
            this.RotationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RotationGroupBox.Controls.Add(this.MBlabel);
            this.RotationGroupBox.Controls.Add(this.MBtextBox);
            this.RotationGroupBox.Controls.Add(this.minutesTextBox);
            this.RotationGroupBox.Controls.Add(this.minutesLabel);
            this.RotationGroupBox.Controls.Add(this.sizeRotate);
            this.RotationGroupBox.Controls.Add(this.timeRotate);
            this.RotationGroupBox.Location = new System.Drawing.Point(12, 110);
            this.RotationGroupBox.Name = "RotationGroupBox";
            this.RotationGroupBox.Size = new System.Drawing.Size(375, 45);
            this.RotationGroupBox.TabIndex = 10;
            this.RotationGroupBox.TabStop = false;
            this.RotationGroupBox.Text = "Specify your Rotation Fequency";
            // 
            // MBlabel
            // 
            this.MBlabel.AutoSize = true;
            this.MBlabel.Location = new System.Drawing.Point(330, 21);
            this.MBlabel.Name = "MBlabel";
            this.MBlabel.Size = new System.Drawing.Size(23, 13);
            this.MBlabel.TabIndex = 5;
            this.MBlabel.Text = "MB";
            // 
            // MBtextBox
            // 
            this.MBtextBox.Location = new System.Drawing.Point(296, 18);
            this.MBtextBox.Name = "MBtextBox";
            this.MBtextBox.Size = new System.Drawing.Size(32, 20);
            this.MBtextBox.TabIndex = 14;
            this.MBtextBox.Text = "10";
            // 
            // minutesTextBox
            // 
            this.minutesTextBox.Location = new System.Drawing.Point(103, 18);
            this.minutesTextBox.Name = "minutesTextBox";
            this.minutesTextBox.Size = new System.Drawing.Size(28, 20);
            this.minutesTextBox.TabIndex = 12;
            this.minutesTextBox.Text = "10";
            // 
            // minutesLabel
            // 
            this.minutesLabel.AutoSize = true;
            this.minutesLabel.Location = new System.Drawing.Point(137, 21);
            this.minutesLabel.Name = "minutesLabel";
            this.minutesLabel.Size = new System.Drawing.Size(43, 13);
            this.minutesLabel.TabIndex = 2;
            this.minutesLabel.Text = "minutes";
            // 
            // sizeRotate
            // 
            this.sizeRotate.AutoSize = true;
            this.sizeRotate.Location = new System.Drawing.Point(213, 19);
            this.sizeRotate.Name = "sizeRotate";
            this.sizeRotate.Size = new System.Drawing.Size(86, 17);
            this.sizeRotate.TabIndex = 13;
            this.sizeRotate.TabStop = true;
            this.sizeRotate.Text = "Rotate every";
            this.sizeRotate.UseVisualStyleBackColor = true;
            // 
            // timeRotate
            // 
            this.timeRotate.AutoSize = true;
            this.timeRotate.Checked = true;
            this.timeRotate.Location = new System.Drawing.Point(18, 19);
            this.timeRotate.Name = "timeRotate";
            this.timeRotate.Size = new System.Drawing.Size(86, 17);
            this.timeRotate.TabIndex = 11;
            this.timeRotate.TabStop = true;
            this.timeRotate.Text = "Rotate every";
            this.timeRotate.UseVisualStyleBackColor = true;
            // 
            // destGroupBox
            // 
            this.destGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.destGroupBox.Controls.Add(this.label5);
            this.destGroupBox.Controls.Add(this.remoteDirTextBox);
            this.destGroupBox.Controls.Add(this.label4);
            this.destGroupBox.Controls.Add(this.passwordTextBox);
            this.destGroupBox.Controls.Add(this.label3);
            this.destGroupBox.Controls.Add(this.usernameTextBox);
            this.destGroupBox.Controls.Add(this.label2);
            this.destGroupBox.Controls.Add(this.remoteHostTextBox);
            this.destGroupBox.Controls.Add(this.label1);
            this.destGroupBox.Controls.Add(this.localDirSelect);
            this.destGroupBox.Controls.Add(this.localDirTextBox);
            this.destGroupBox.Location = new System.Drawing.Point(14, 161);
            this.destGroupBox.Name = "destGroupBox";
            this.destGroupBox.Size = new System.Drawing.Size(373, 159);
            this.destGroupBox.TabIndex = 11;
            this.destGroupBox.TabStop = false;
            this.destGroupBox.Text = "Destination";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Remote Directory:";
            // 
            // remoteDirTextBox
            // 
            this.remoteDirTextBox.Location = new System.Drawing.Point(101, 73);
            this.remoteDirTextBox.Name = "remoteDirTextBox";
            this.remoteDirTextBox.Size = new System.Drawing.Size(225, 20);
            this.remoteDirTextBox.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(101, 123);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(225, 20);
            this.passwordTextBox.TabIndex = 26;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Username:";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(101, 98);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(225, 20);
            this.usernameTextBox.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Remote Host:";
            // 
            // remoteHostTextBox
            // 
            this.remoteHostTextBox.Location = new System.Drawing.Point(101, 48);
            this.remoteHostTextBox.Name = "remoteHostTextBox";
            this.remoteHostTextBox.Size = new System.Drawing.Size(225, 20);
            this.remoteHostTextBox.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Local Directory:";
            // 
            // localDirSelect
            // 
            this.localDirSelect.Location = new System.Drawing.Point(332, 23);
            this.localDirSelect.Name = "localDirSelect";
            this.localDirSelect.Size = new System.Drawing.Size(33, 20);
            this.localDirSelect.TabIndex = 22;
            this.localDirSelect.Text = "...";
            this.localDirSelect.UseVisualStyleBackColor = true;
            this.localDirSelect.Click += new System.EventHandler(this.localDirSelect_Click);
            // 
            // localDirTextBox
            // 
            this.localDirTextBox.Location = new System.Drawing.Point(101, 23);
            this.localDirTextBox.Name = "localDirTextBox";
            this.localDirTextBox.Size = new System.Drawing.Size(225, 20);
            this.localDirTextBox.TabIndex = 21;
            // 
            // SaveConfigButton
            // 
            this.SaveConfigButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveConfigButton.Location = new System.Drawing.Point(11, 331);
            this.SaveConfigButton.Margin = new System.Windows.Forms.Padding(2);
            this.SaveConfigButton.Name = "SaveConfigButton";
            this.SaveConfigButton.Size = new System.Drawing.Size(84, 31);
            this.SaveConfigButton.TabIndex = 31;
            this.SaveConfigButton.Text = "Save Config";
            this.SaveConfigButton.UseVisualStyleBackColor = true;
            this.SaveConfigButton.Click += new System.EventHandler(this.SaveConfigButton_Click);
            // 
            // LoadConfigButton
            // 
            this.LoadConfigButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LoadConfigButton.Location = new System.Drawing.Point(99, 331);
            this.LoadConfigButton.Margin = new System.Windows.Forms.Padding(2);
            this.LoadConfigButton.Name = "LoadConfigButton";
            this.LoadConfigButton.Size = new System.Drawing.Size(84, 31);
            this.LoadConfigButton.TabIndex = 32;
            this.LoadConfigButton.Text = "Load Config";
            this.LoadConfigButton.UseVisualStyleBackColor = true;
            this.LoadConfigButton.Click += new System.EventHandler(this.LoadConfigButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // DataLoggerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 396);
            this.Controls.Add(this.LoadConfigButton);
            this.Controls.Add(this.SaveConfigButton);
            this.Controls.Add(this.destGroupBox);
            this.Controls.Add(this.RotationGroupBox);
            this.Controls.Add(this.destinationGroupBox);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataLoggerForm";
            this.Text = "Data Logger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataLoggerForm_FormClosing);
            this.Load += new System.EventHandler(this.DataLoggerForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.destinationGroupBox.ResumeLayout(false);
            this.destinationGroupBox.PerformLayout();
            this.RotationGroupBox.ResumeLayout(false);
            this.RotationGroupBox.PerformLayout();
            this.destGroupBox.ResumeLayout(false);
            this.destGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusText;
        private System.Windows.Forms.RadioButton logLocally;
        private System.Windows.Forms.RadioButton logViaFTP;
        private System.Windows.Forms.GroupBox destinationGroupBox;
        private System.Windows.Forms.RadioButton logViaSFTP;
        private System.Windows.Forms.GroupBox RotationGroupBox;
        private System.Windows.Forms.RadioButton sizeRotate;
        private System.Windows.Forms.RadioButton timeRotate;
        private System.Windows.Forms.Label MBlabel;
        private System.Windows.Forms.TextBox MBtextBox;
        private System.Windows.Forms.TextBox minutesTextBox;
        private System.Windows.Forms.Label minutesLabel;
        private System.Windows.Forms.GroupBox destGroupBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox remoteDirTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox remoteHostTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button localDirSelect;
        private System.Windows.Forms.TextBox localDirTextBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button SaveConfigButton;
        private System.Windows.Forms.Button LoadConfigButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}