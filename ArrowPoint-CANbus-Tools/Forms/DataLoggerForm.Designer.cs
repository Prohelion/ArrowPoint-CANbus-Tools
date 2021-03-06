﻿namespace ArrowPointCANBusTool.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataLoggerForm));
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.logLocally = new System.Windows.Forms.RadioButton();
            this.logViaFTP = new System.Windows.Forms.RadioButton();
            this.logGroupBox = new System.Windows.Forms.GroupBox();
            this.logViaSFTP = new System.Windows.Forms.RadioButton();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.rotationGroupBox = new System.Windows.Forms.GroupBox();
            this.MBlabel = new System.Windows.Forms.Label();
            this.MBtextBox = new System.Windows.Forms.TextBox();
            this.minutesTextBox = new System.Windows.Forms.TextBox();
            this.minutesLabel = new System.Windows.Forms.Label();
            this.sizeRotate = new System.Windows.Forms.RadioButton();
            this.timeRotate = new System.Windows.Forms.RadioButton();
            this.destGroupBox = new System.Windows.Forms.GroupBox();
            this.archiveDirLabel = new System.Windows.Forms.Label();
            this.archiveDirSelect = new System.Windows.Forms.Button();
            this.archiveDirTextBox = new System.Windows.Forms.TextBox();
            this.remotePortLabel = new System.Windows.Forms.Label();
            this.remotePortTextBox = new System.Windows.Forms.TextBox();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.btnLoadConfig = new System.Windows.Forms.Button();
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.archiveGroupBox = new System.Windows.Forms.GroupBox();
            this.ArchiveLimitTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.limitArchive = new System.Windows.Forms.CheckBox();
            this.archive = new System.Windows.Forms.CheckBox();
            this.compress = new System.Windows.Forms.CheckBox();
            this.statusStrip.SuspendLayout();
            this.logGroupBox.SuspendLayout();
            this.rotationGroupBox.SuspendLayout();
            this.destGroupBox.SuspendLayout();
            this.archiveGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(217, 422);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(84, 31);
            this.btnStart.TabIndex = 41;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Location = new System.Drawing.Point(308, 422);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(84, 31);
            this.btnStop.TabIndex = 42;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusText});
            this.statusStrip.Location = new System.Drawing.Point(0, 464);
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
            // logGroupBox
            // 
            this.logGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logGroupBox.Controls.Add(this.logLocally);
            this.logGroupBox.Controls.Add(this.logViaSFTP);
            this.logGroupBox.Controls.Add(this.logViaFTP);
            this.logGroupBox.Location = new System.Drawing.Point(12, 12);
            this.logGroupBox.Name = "logGroupBox";
            this.logGroupBox.Size = new System.Drawing.Size(165, 92);
            this.logGroupBox.TabIndex = 0;
            this.logGroupBox.TabStop = false;
            this.logGroupBox.Text = "Log Destination";
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
            // btnTestConnection
            // 
            this.btnTestConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestConnection.Location = new System.Drawing.Point(227, 205);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(99, 32);
            this.btnTestConnection.TabIndex = 32;
            this.btnTestConnection.Text = "Test Connection\r\n";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.TestConnectionButton_Click);
            // 
            // rotationGroupBox
            // 
            this.rotationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rotationGroupBox.Controls.Add(this.minutesTextBox);
            this.rotationGroupBox.Controls.Add(this.MBtextBox);
            this.rotationGroupBox.Controls.Add(this.timeRotate);
            this.rotationGroupBox.Controls.Add(this.minutesLabel);
            this.rotationGroupBox.Controls.Add(this.sizeRotate);
            this.rotationGroupBox.Controls.Add(this.MBlabel);
            this.rotationGroupBox.Location = new System.Drawing.Point(12, 110);
            this.rotationGroupBox.Name = "rotationGroupBox";
            this.rotationGroupBox.Size = new System.Drawing.Size(377, 45);
            this.rotationGroupBox.TabIndex = 10;
            this.rotationGroupBox.TabStop = false;
            this.rotationGroupBox.Text = "Specify your Rotation Fequency";
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
            this.destGroupBox.Controls.Add(this.archiveDirLabel);
            this.destGroupBox.Controls.Add(this.archiveDirSelect);
            this.destGroupBox.Controls.Add(this.archiveDirTextBox);
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
            this.destGroupBox.Size = new System.Drawing.Size(375, 251);
            this.destGroupBox.TabIndex = 20;
            this.destGroupBox.TabStop = false;
            this.destGroupBox.Text = "Destination";
            // 
            // archiveDirLabel
            // 
            this.archiveDirLabel.AutoSize = true;
            this.archiveDirLabel.Location = new System.Drawing.Point(4, 52);
            this.archiveDirLabel.Name = "archiveDirLabel";
            this.archiveDirLabel.Size = new System.Drawing.Size(91, 13);
            this.archiveDirLabel.TabIndex = 35;
            this.archiveDirLabel.Text = "Archive Directory:";
            // 
            // archiveDirSelect
            // 
            this.archiveDirSelect.Location = new System.Drawing.Point(332, 49);
            this.archiveDirSelect.Name = "archiveDirSelect";
            this.archiveDirSelect.Size = new System.Drawing.Size(33, 20);
            this.archiveDirSelect.TabIndex = 24;
            this.archiveDirSelect.Text = "...";
            this.archiveDirSelect.UseVisualStyleBackColor = true;
            this.archiveDirSelect.Click += new System.EventHandler(this.ArchiveDirSelect_Click);
            // 
            // archiveDirTextBox
            // 
            this.archiveDirTextBox.Location = new System.Drawing.Point(101, 49);
            this.archiveDirTextBox.Name = "archiveDirTextBox";
            this.archiveDirTextBox.Size = new System.Drawing.Size(225, 20);
            this.archiveDirTextBox.TabIndex = 23;
            this.archiveDirTextBox.Validated += new System.EventHandler(this.ArchiveDirTextBox_Validated);
            // 
            // remotePortLabel
            // 
            this.remotePortLabel.AutoSize = true;
            this.remotePortLabel.Location = new System.Drawing.Point(26, 106);
            this.remotePortLabel.Name = "remotePortLabel";
            this.remotePortLabel.Size = new System.Drawing.Size(69, 13);
            this.remotePortLabel.TabIndex = 33;
            this.remotePortLabel.Text = "Remote Port:";
            // 
            // remotePortTextBox
            // 
            this.remotePortTextBox.Location = new System.Drawing.Point(101, 102);
            this.remotePortTextBox.Name = "remotePortTextBox";
            this.remotePortTextBox.Size = new System.Drawing.Size(52, 20);
            this.remotePortTextBox.TabIndex = 26;
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveConfig.Location = new System.Drawing.Point(101, 206);
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
            this.btnLoadConfig.Location = new System.Drawing.Point(11, 206);
            this.btnLoadConfig.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadConfig.Name = "btnLoadConfig";
            this.btnLoadConfig.Size = new System.Drawing.Size(84, 31);
            this.btnLoadConfig.TabIndex = 30;
            this.btnLoadConfig.Text = "Load Config";
            this.btnLoadConfig.UseVisualStyleBackColor = true;
            this.btnLoadConfig.Click += new System.EventHandler(this.LoadConfigButton_Click);
            // 
            // remoteDirLabel
            // 
            this.remoteDirLabel.AutoSize = true;
            this.remoteDirLabel.Location = new System.Drawing.Point(3, 130);
            this.remoteDirLabel.Name = "remoteDirLabel";
            this.remoteDirLabel.Size = new System.Drawing.Size(92, 13);
            this.remoteDirLabel.TabIndex = 10;
            this.remoteDirLabel.Text = "Remote Directory:";
            // 
            // remoteDirTextBox
            // 
            this.remoteDirTextBox.Location = new System.Drawing.Point(101, 126);
            this.remoteDirTextBox.Name = "remoteDirTextBox";
            this.remoteDirTextBox.Size = new System.Drawing.Size(225, 20);
            this.remoteDirTextBox.TabIndex = 27;
            this.remoteDirTextBox.Validated += new System.EventHandler(this.RemoteDirTextBox_Validated);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(39, 180);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 8;
            this.passwordLabel.Text = "Password:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(101, 176);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(225, 20);
            this.passwordTextBox.TabIndex = 29;
            this.passwordTextBox.UseSystemPasswordChar = true;
            this.passwordTextBox.Validated += new System.EventHandler(this.PasswordTextBox_Validated);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(37, 155);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(58, 13);
            this.usernameLabel.TabIndex = 6;
            this.usernameLabel.Text = "Username:";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(101, 151);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(225, 20);
            this.usernameTextBox.TabIndex = 28;
            this.usernameTextBox.Validated += new System.EventHandler(this.UsernameTextBox_Validated);
            // 
            // remoteHostLabel
            // 
            this.remoteHostLabel.AutoSize = true;
            this.remoteHostLabel.Location = new System.Drawing.Point(23, 80);
            this.remoteHostLabel.Name = "remoteHostLabel";
            this.remoteHostLabel.Size = new System.Drawing.Size(72, 13);
            this.remoteHostLabel.TabIndex = 4;
            this.remoteHostLabel.Text = "Remote Host:";
            // 
            // remoteHostTextBox
            // 
            this.remoteHostTextBox.Location = new System.Drawing.Point(101, 76);
            this.remoteHostTextBox.Name = "remoteHostTextBox";
            this.remoteHostTextBox.Size = new System.Drawing.Size(225, 20);
            this.remoteHostTextBox.TabIndex = 25;
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
            this.localDirSelect.Click += new System.EventHandler(this.LocalDirSelect_Click);
            // 
            // localDirTextBox
            // 
            this.localDirTextBox.Location = new System.Drawing.Point(101, 23);
            this.localDirTextBox.Name = "localDirTextBox";
            this.localDirTextBox.Size = new System.Drawing.Size(225, 20);
            this.localDirTextBox.TabIndex = 21;
            this.localDirTextBox.Validated += new System.EventHandler(this.LocalDirTextBox_Validated);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // archiveGroupBox
            // 
            this.archiveGroupBox.Controls.Add(this.ArchiveLimitTextBox);
            this.archiveGroupBox.Controls.Add(this.compress);
            this.archiveGroupBox.Controls.Add(this.archive);
            this.archiveGroupBox.Controls.Add(this.limitArchive);
            this.archiveGroupBox.Controls.Add(this.label1);
            this.archiveGroupBox.Location = new System.Drawing.Point(183, 12);
            this.archiveGroupBox.Name = "archiveGroupBox";
            this.archiveGroupBox.Size = new System.Drawing.Size(205, 92);
            this.archiveGroupBox.TabIndex = 5;
            this.archiveGroupBox.TabStop = false;
            this.archiveGroupBox.Text = "Archive and Compression";
            // 
            // ArchiveLimitTextBox
            // 
            this.ArchiveLimitTextBox.Enabled = false;
            this.ArchiveLimitTextBox.Location = new System.Drawing.Point(134, 62);
            this.ArchiveLimitTextBox.Name = "ArchiveLimitTextBox";
            this.ArchiveLimitTextBox.Size = new System.Drawing.Size(36, 20);
            this.ArchiveLimitTextBox.TabIndex = 9;
            this.ArchiveLimitTextBox.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "logs";
            // 
            // limitArchive
            // 
            this.limitArchive.AutoSize = true;
            this.limitArchive.Enabled = false;
            this.limitArchive.Location = new System.Drawing.Point(12, 65);
            this.limitArchive.Name = "limitArchive";
            this.limitArchive.Size = new System.Drawing.Size(125, 17);
            this.limitArchive.TabIndex = 8;
            this.limitArchive.Text = "Limit Archive Size To";
            this.limitArchive.UseVisualStyleBackColor = true;
            this.limitArchive.CheckedChanged += new System.EventHandler(this.LimitArchiveCheckBox_CheckedChanged);
            // 
            // archive
            // 
            this.archive.AutoSize = true;
            this.archive.Location = new System.Drawing.Point(12, 42);
            this.archive.Name = "archive";
            this.archive.Size = new System.Drawing.Size(107, 17);
            this.archive.TabIndex = 7;
            this.archive.Text = "Archive Old Logs";
            this.archive.UseVisualStyleBackColor = true;
            this.archive.CheckedChanged += new System.EventHandler(this.Archive_CheckedChanged);
            // 
            // compress
            // 
            this.compress.AutoSize = true;
            this.compress.Location = new System.Drawing.Point(12, 19);
            this.compress.Name = "compress";
            this.compress.Size = new System.Drawing.Size(98, 17);
            this.compress.TabIndex = 6;
            this.compress.Text = "Compress Logs";
            this.compress.UseVisualStyleBackColor = true;
            this.compress.CheckedChanged += new System.EventHandler(this.Compress_CheckedChanged);
            // 
            // DataLoggerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 486);
            this.Controls.Add(this.logGroupBox);
            this.Controls.Add(this.archiveGroupBox);
            this.Controls.Add(this.rotationGroupBox);
            this.Controls.Add(this.destGroupBox);
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
            this.logGroupBox.ResumeLayout(false);
            this.logGroupBox.PerformLayout();
            this.rotationGroupBox.ResumeLayout(false);
            this.rotationGroupBox.PerformLayout();
            this.destGroupBox.ResumeLayout(false);
            this.destGroupBox.PerformLayout();
            this.archiveGroupBox.ResumeLayout(false);
            this.archiveGroupBox.PerformLayout();
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
        private System.Windows.Forms.GroupBox logGroupBox;
        private System.Windows.Forms.RadioButton logViaSFTP;
        private System.Windows.Forms.GroupBox rotationGroupBox;
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
        private System.Windows.Forms.GroupBox archiveGroupBox;
        private System.Windows.Forms.TextBox ArchiveLimitTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox limitArchive;
        private System.Windows.Forms.CheckBox archive;
        private System.Windows.Forms.CheckBox compress;
        private System.Windows.Forms.Label archiveDirLabel;
        private System.Windows.Forms.Button archiveDirSelect;
        private System.Windows.Forms.TextBox archiveDirTextBox;
    }
}