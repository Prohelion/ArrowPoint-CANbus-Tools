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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataLoggerForm));
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.logLocally = new System.Windows.Forms.RadioButton();
            this.logViaFTP = new System.Windows.Forms.RadioButton();
            this.destinationGroupBox = new System.Windows.Forms.GroupBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.logViaSFTP = new System.Windows.Forms.RadioButton();
            this.RotationGroupBox = new System.Windows.Forms.GroupBox();
            this.MBlabel = new System.Windows.Forms.Label();
            this.MBtextBox = new System.Windows.Forms.TextBox();
            this.minutesTextBox = new System.Windows.Forms.TextBox();
            this.minutesLabel = new System.Windows.Forms.Label();
            this.sizeRotate = new System.Windows.Forms.RadioButton();
            this.timeRotate = new System.Windows.Forms.RadioButton();
            this.destGroupBox = new System.Windows.Forms.GroupBox();
            this.remoteDirLabel = new System.Windows.Forms.Label();
            this.remoteDirTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.remoteHostLabel = new System.Windows.Forms.Label();
            this.remoteHostTextBox = new System.Windows.Forms.TextBox();
            this.localDirLabel = new System.Windows.Forms.Label();
            this.localDirSelect = new System.Windows.Forms.Button();
            this.localDirTextBox = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.btnLoadConfig = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.remotePortLabel = new System.Windows.Forms.Label();
            this.remotePortTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip.SuspendLayout();
            this.destinationGroupBox.SuspendLayout();
            this.RotationGroupBox.SuspendLayout();
            this.destGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(217, 392);
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
            this.btnStop.Location = new System.Drawing.Point(308, 392);
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
            this.statusStrip.Location = new System.Drawing.Point(0, 434);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(401, 22);
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
            this.logLocally.CheckedChanged += new System.EventHandler(this.LogLocally_CheckedChanged);
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
            this.logViaFTP.CheckedChanged += new System.EventHandler(this.LogViaFTP_CheckedChanged);
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
            this.destinationGroupBox.Size = new System.Drawing.Size(378, 92);
            this.destinationGroupBox.TabIndex = 9;
            this.destinationGroupBox.TabStop = false;
            this.destinationGroupBox.Text = "Specify your Log Destination";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestConnection.Location = new System.Drawing.Point(227, 175);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(99, 32);
            this.btnTestConnection.TabIndex = 4;
            this.btnTestConnection.Text = "Test Connection\r\n";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.TestConnectionButton_Click);
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
            this.logViaSFTP.CheckedChanged += new System.EventHandler(this.LogViaSFTP_CheckedChanged);
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
            this.RotationGroupBox.Size = new System.Drawing.Size(377, 45);
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
            this.MBtextBox.Validated += new System.EventHandler(this.MBtextBox_Validated);
            // 
            // minutesTextBox
            // 
            this.minutesTextBox.Location = new System.Drawing.Point(103, 18);
            this.minutesTextBox.Name = "minutesTextBox";
            this.minutesTextBox.Size = new System.Drawing.Size(28, 20);
            this.minutesTextBox.TabIndex = 12;
            this.minutesTextBox.Text = "10";
            this.minutesTextBox.Validated += new System.EventHandler(this.MinutesTextBox_Validated);
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
            this.sizeRotate.CheckedChanged += new System.EventHandler(this.SizeRotate_CheckedChanged);
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
            this.timeRotate.CheckedChanged += new System.EventHandler(this.TimeRotate_CheckedChanged);
            // 
            // destGroupBox
            // 
            this.destGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.destGroupBox.Controls.Add(this.remotePortLabel);
            this.destGroupBox.Controls.Add(this.remotePortTextBox);
            this.destGroupBox.Controls.Add(this.btnSaveConfig);
            this.destGroupBox.Controls.Add(this.btnLoadConfig);
            this.destGroupBox.Controls.Add(this.btnTestConnection);
            this.destGroupBox.Controls.Add(this.remoteDirLabel);
            this.destGroupBox.Controls.Add(this.remoteDirTextBox);
            this.destGroupBox.Controls.Add(this.passwordLabel);
            this.destGroupBox.Controls.Add(this.passwordTextBox);
            this.destGroupBox.Controls.Add(this.usernameLabel);
            this.destGroupBox.Controls.Add(this.usernameTextBox);
            this.destGroupBox.Controls.Add(this.remoteHostLabel);
            this.destGroupBox.Controls.Add(this.remoteHostTextBox);
            this.destGroupBox.Controls.Add(this.localDirLabel);
            this.destGroupBox.Controls.Add(this.localDirSelect);
            this.destGroupBox.Controls.Add(this.localDirTextBox);
            this.destGroupBox.Location = new System.Drawing.Point(14, 161);
            this.destGroupBox.Name = "destGroupBox";
            this.destGroupBox.Size = new System.Drawing.Size(375, 221);
            this.destGroupBox.TabIndex = 11;
            this.destGroupBox.TabStop = false;
            this.destGroupBox.Text = "Destination";
            // 
            // remoteDirLabel
            // 
            this.remoteDirLabel.AutoSize = true;
            this.remoteDirLabel.Location = new System.Drawing.Point(3, 102);
            this.remoteDirLabel.Name = "remoteDirLabel";
            this.remoteDirLabel.Size = new System.Drawing.Size(92, 13);
            this.remoteDirLabel.TabIndex = 10;
            this.remoteDirLabel.Text = "Remote Directory:";
            // 
            // remoteDirTextBox
            // 
            this.remoteDirTextBox.Location = new System.Drawing.Point(101, 98);
            this.remoteDirTextBox.Name = "remoteDirTextBox";
            this.remoteDirTextBox.Size = new System.Drawing.Size(225, 20);
            this.remoteDirTextBox.TabIndex = 24;
            this.remoteDirTextBox.Validated += new System.EventHandler(this.RemoteDirTextBox_Validated);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(39, 152);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 8;
            this.passwordLabel.Text = "Password:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(101, 148);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(225, 20);
            this.passwordTextBox.TabIndex = 26;
            this.passwordTextBox.UseSystemPasswordChar = true;
            this.passwordTextBox.Validated += new System.EventHandler(this.PasswordTextBox_Validated);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(37, 127);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(58, 13);
            this.usernameLabel.TabIndex = 6;
            this.usernameLabel.Text = "Username:";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(101, 123);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(225, 20);
            this.usernameTextBox.TabIndex = 25;
            this.usernameTextBox.Validated += new System.EventHandler(this.UsernameTextBox_Validated);
            // 
            // remoteHostLabel
            // 
            this.remoteHostLabel.AutoSize = true;
            this.remoteHostLabel.Location = new System.Drawing.Point(23, 52);
            this.remoteHostLabel.Name = "remoteHostLabel";
            this.remoteHostLabel.Size = new System.Drawing.Size(72, 13);
            this.remoteHostLabel.TabIndex = 4;
            this.remoteHostLabel.Text = "Remote Host:";
            // 
            // remoteHostTextBox
            // 
            this.remoteHostTextBox.Location = new System.Drawing.Point(101, 48);
            this.remoteHostTextBox.Name = "remoteHostTextBox";
            this.remoteHostTextBox.Size = new System.Drawing.Size(225, 20);
            this.remoteHostTextBox.TabIndex = 23;
            this.remoteHostTextBox.Validated += new System.EventHandler(this.RemoteHostTextBox_Validated);
            // 
            // localDirLabel
            // 
            this.localDirLabel.AutoSize = true;
            this.localDirLabel.Location = new System.Drawing.Point(14, 27);
            this.localDirLabel.Name = "localDirLabel";
            this.localDirLabel.Size = new System.Drawing.Size(81, 13);
            this.localDirLabel.TabIndex = 2;
            this.localDirLabel.Text = "Local Directory:";
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
            this.localDirTextBox.Validated += new System.EventHandler(this.LocalDirTextBox_Validated);
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveConfig.Location = new System.Drawing.Point(101, 176);
            this.btnSaveConfig.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(84, 31);
            this.btnSaveConfig.TabIndex = 31;
            this.btnSaveConfig.Text = "Save Config";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.SaveConfigButton_Click);
            // 
            // btnLoadConfig
            // 
            this.btnLoadConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadConfig.Location = new System.Drawing.Point(11, 176);
            this.btnLoadConfig.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadConfig.Name = "btnLoadConfig";
            this.btnLoadConfig.Size = new System.Drawing.Size(84, 31);
            this.btnLoadConfig.TabIndex = 32;
            this.btnLoadConfig.Text = "Load Config";
            this.btnLoadConfig.UseVisualStyleBackColor = true;
            this.btnLoadConfig.Click += new System.EventHandler(this.LoadConfigButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // remotePortLabel
            // 
            this.remotePortLabel.AutoSize = true;
            this.remotePortLabel.Location = new System.Drawing.Point(23, 78);
            this.remotePortLabel.Name = "remotePortLabel";
            this.remotePortLabel.Size = new System.Drawing.Size(69, 13);
            this.remotePortLabel.TabIndex = 33;
            this.remotePortLabel.Text = "Remote Port:";
            // 
            // remotePortTextBox
            // 
            this.remotePortTextBox.Location = new System.Drawing.Point(101, 74);
            this.remotePortTextBox.Name = "remotePortTextBox";
            this.remotePortTextBox.Size = new System.Drawing.Size(52, 20);
            this.remotePortTextBox.TabIndex = 34;
            // 
            // DataLoggerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 456);
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
        private System.Windows.Forms.Label remoteDirLabel;
        private System.Windows.Forms.TextBox remoteDirTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label remoteHostLabel;
        private System.Windows.Forms.TextBox remoteHostTextBox;
        private System.Windows.Forms.Label localDirLabel;
        private System.Windows.Forms.Button localDirSelect;
        private System.Windows.Forms.TextBox localDirTextBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.Button btnLoadConfig;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Label remotePortLabel;
        private System.Windows.Forms.TextBox remotePortTextBox;
    }
}