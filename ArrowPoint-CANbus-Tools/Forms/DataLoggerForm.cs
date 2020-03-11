using ArrowPointCANBusTool.CanLibrary;
using ArrowPointCANBusTool.Model;
using ArrowPointCANBusTool.Services;
using ArrowPointCANBusTool.Transfer;
using ArrowPointCANBusTool.Utilities.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ArrowPointCANBusTool.Services.CanService;

namespace ArrowPointCANBusTool.Forms
{
    public partial class DataLoggerForm : Form
    {

        private Timer timer;
        private bool isFormValid = false;
        private DataLogger dataLoggerConfig;
        private readonly CanRecordReplayDebugService recordReplayService;


        public DataLoggerForm()
        {
            InitializeComponent();
            recordReplayService = CanRecordReplayDebugService.NewInstance;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            recordReplayService.StartRecording(dataLoggerConfig);
            UpdatePanels();
            UpdateButtons();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            recordReplayService.StopRecording();
            UpdatePanels();
            UpdateButtons();
        }

        private void DataLoggerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            recordReplayService.StopRecording();
        }

        private void DataLoggerForm_Load(object sender, EventArgs e)
        {
            timer = new Timer
            {
                Interval = (100)
            };
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();

            localDirTextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            archiveDirTextBox.Text = localDirTextBox.Text + @"\archive";

            UpdatePanels();
        }

        private void SaveConfigButton_Click(object sender, EventArgs e)
        {
            UpdateDataLoggerConfig();

            saveFileDialog.Title = "Save DataLogger configuration file";
            saveFileDialog.CheckFileExists = false;
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.DefaultExt = "dlconf";
            saveFileDialog.Filter = "DataLogger config files (*.dlconf)|*.dlconf|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {                
                CanRecordReplayDebugService.SaveConfig(saveFileDialog.FileName, dataLoggerConfig);
            }
        }

        private void LoadConfigButton_Click(object sender, EventArgs e)
        {

            Stream ioStream;

            this.openFileDialog = new OpenFileDialog
            {
                RestoreDirectory = true,
                Filter = "DataLogger config files (*.dlconf)|*.dlconf|All files (*.*)|*.*",
                FilterIndex = 1
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                if ((ioStream = openFileDialog.OpenFile()) != null)
                {
                    recordReplayService.StopRecording();
                    UpdateButtons();

                    // Not using the instance here                    
                    DataLogger dataLoggerConfig = CanRecordReplayDebugService.LoadConfig(ioStream);

                    if (dataLoggerConfig.IsLogToLocalDisk()) logLocally.Checked = true;
                    else if (dataLoggerConfig.IsLogToFTP()) logViaFTP.Checked = true;
                    else if (dataLoggerConfig.IsLogToSFTP()) logViaSFTP.Checked = true;

                    if (dataLoggerConfig.ArchiveLogs) archive.Checked = true;
                    if (dataLoggerConfig.CompressLogs) compress.Checked = true;
                    if (dataLoggerConfig.LimitArchive)
                    {
                        limitArchive.Checked = true;
                        ArchiveLimitTextBox.Text = dataLoggerConfig.LimitArchiveFileNum.ToString();
                    }

                    if (dataLoggerConfig.IsRotateByMin()) timeRotate.Checked = true;
                    else if (dataLoggerConfig.IsRotateByMB()) sizeRotate.Checked = true;

                    minutesTextBox.Text = dataLoggerConfig.RotateMinutes.ToString();
                    MBtextBox.Text = dataLoggerConfig.RotateMB.ToString();

                    localDirTextBox.Text = dataLoggerConfig.LocalDirectory;
                    archiveDirTextBox.Text = dataLoggerConfig.ArchiveDirectory;
                    remoteHostTextBox.Text = dataLoggerConfig.RemoteHost;
                    remotePortTextBox.Text = dataLoggerConfig.RemotePort.ToString();
                    remoteDirTextBox.Text = dataLoggerConfig.RemoteDirectory;
                    usernameTextBox.Text = dataLoggerConfig.Username;
                    passwordTextBox.Text = dataLoggerConfig.Password;
                }
            }

            UpdatePanels();
        }

        private void TestConnectionButton_Click(object sender, EventArgs e)
        {
            TransferBase transferUtil = new FTPTransfer();

            if (logViaFTP.Checked) transferUtil = new FTPTransfer();
            if (logViaSFTP.Checked) transferUtil = new SFTPTransfer();

            transferUtil.Host = remoteHostTextBox.Text;
            transferUtil.Port = Int32.Parse(remotePortTextBox.Text);
            transferUtil.Username = usernameTextBox.Text;
            transferUtil.Password = passwordTextBox.Text;
            transferUtil.SourceDirectory = "C:\\";
            transferUtil.DestinationDirectory = remoteDirTextBox.Text;

            if (transferUtil.TestConnection())
                MessageBox.Show("Connection is successful", "Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Unable to connect, please check settings", "Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void LocalDirSelect_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowNewFolderButton = true;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                localDirTextBox.Text = folderBrowserDialog.SelectedPath;
                TextValidator.IsValidDirectory(localDirTextBox, toolTip, "Please provide a valid local directory");
            }
        }

        private void LogLocally_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePanels();
        }

        private void LogViaFTP_CheckedChanged(object sender, EventArgs e)
        {
            remotePortTextBox.Text = "21";
            UpdatePanels();
        }

        private void LogViaSFTP_CheckedChanged(object sender, EventArgs e)
        {
            remotePortTextBox.Text = "22";
            UpdatePanels();
        }

        private void TimeRotate_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePanels();
        }

        private void SizeRotate_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePanels();
        }

        private void LocalDirTextBox_Validated(object sender, EventArgs e)
        {
            IsFormValid();
        }

        private void ArchiveDirTextBox_Validated(object sender, EventArgs e)
        {
            IsFormValid();
        }

        private void RemoteDirTextBox_Validated(object sender, EventArgs e)
        {
            IsFormValid();
        }

        private void UsernameTextBox_Validated(object sender, EventArgs e)
        {
            IsFormValid();
        }

        private void PasswordTextBox_Validated(object sender, EventArgs e)
        {
            IsFormValid();
        }

        private void MinutesTextBox_Validated(object sender, EventArgs e)
        {
            IsFormValid();
        }

        private void MBtextBox_Validated(object sender, EventArgs e)
        {
            IsFormValid();
        }

        private void RemoteHostTextBox_Validated(object sender, EventArgs e)
        {
            IsFormValid();
        }

        private void UpdateButtons()
        {
            btnStart.Enabled = !recordReplayService.IsRecording && isFormValid;
            btnStop.Enabled = recordReplayService.IsRecording;
            btnSaveConfig.Enabled = isFormValid;
            btnTestConnection.Visible = (logViaFTP.Checked || logViaSFTP.Checked);
            btnTestConnection.Enabled = (logViaFTP.Checked || logViaSFTP.Checked) && isFormValid;
        }

        private void UpdatePanels()
        {

            toolStripStatusText.Text = recordReplayService.RecordStatus;

            localDirTextBox.Visible = false;
            archiveDirTextBox.Visible = false;
            archiveDirSelect.Visible = false;
            remoteHostTextBox.Visible = false;
            remotePortTextBox.Visible = false;
            remoteDirTextBox.Visible = false;
            usernameTextBox.Visible = false;
            passwordTextBox.Visible = false;

            localDirTextBox.Enabled = false;
            archiveDirTextBox.Enabled = false;
            archiveDirSelect.Enabled = false;
            remoteHostTextBox.Enabled = false;
            remotePortTextBox.Enabled = false;
            remoteDirTextBox.Enabled = false;
            usernameTextBox.Enabled = false;
            passwordTextBox.Enabled = false;

            localDirLabel.Visible = false;
            archiveDirLabel.Visible = false;
            remoteHostLabel.Visible = false;
            remotePortLabel.Visible = false;
            remoteDirLabel.Visible = false;
            usernameLabel.Visible = false;
            passwordLabel.Visible = false;

            if (logLocally.Checked)
            {
                localDirTextBox.Visible = true;
                localDirTextBox.Enabled = true;
                localDirLabel.Visible = true;
            }

            if (archive.Checked)
            {
                archiveDirTextBox.Visible = true;
                archiveDirTextBox.Enabled = true;
                archiveDirLabel.Visible = true;
                archiveDirSelect.Visible = true;
                archiveDirSelect.Enabled = true;
            }

            if (limitArchive.Checked)
            {
                ArchiveLimitTextBox.Enabled = true;
            }

            if (logViaFTP.Checked || logViaSFTP.Checked)
            {
                localDirTextBox.Visible = true;
                remoteHostTextBox.Visible = true;
                remotePortTextBox.Visible = true;
                remoteDirTextBox.Visible = true;
                usernameTextBox.Visible = true;
                passwordTextBox.Visible = true;

                localDirTextBox.Enabled = true;
                remoteHostTextBox.Enabled = true;
                remotePortTextBox.Enabled = true;
                remoteDirTextBox.Enabled = true;
                usernameTextBox.Enabled = true;
                passwordTextBox.Enabled = true;

                localDirLabel.Visible = true;
                remoteHostLabel.Visible = true;
                remotePortLabel.Visible = true;
                remoteDirLabel.Visible = true;
                usernameLabel.Visible = true;
                passwordLabel.Visible = true;
            }

            if (timeRotate.Checked)
            {
                minutesTextBox.Enabled = !recordReplayService.IsRecording;
                MBtextBox.Enabled = false;
                MBtextBox.BackColor = default;

                if (String.IsNullOrEmpty(minutesTextBox.Text))
                    minutesTextBox.Text = "10";
            }

            if (sizeRotate.Checked)
            {
                minutesTextBox.Enabled = false;
                minutesTextBox.BackColor = default;
                MBtextBox.Enabled = !recordReplayService.IsRecording;

                if (String.IsNullOrEmpty(MBtextBox.Text))
                    MBtextBox.Text = "10";
            }

            logGroupBox.Enabled = !recordReplayService.IsRecording;
            archiveGroupBox.Enabled = !recordReplayService.IsRecording;
            rotationGroupBox.Enabled = !recordReplayService.IsRecording;
            destGroupBox.Enabled = !recordReplayService.IsRecording;

            IsFormValid();
        }

        private void UpdateDataLoggerConfig()
        {
            if (dataLoggerConfig == null)
                dataLoggerConfig = new DataLogger();

            if (logLocally.Checked) dataLoggerConfig.LogToLocalDisk();
            else if (logViaFTP.Checked) dataLoggerConfig.LogToFTP();
            else if (logViaSFTP.Checked) dataLoggerConfig.LogToSFTP();

            if (compress.Checked) dataLoggerConfig.CompressLogs = true;
            if (archive.Checked) dataLoggerConfig.ArchiveLogs = true;
            if (limitArchive.Checked)
            {
                dataLoggerConfig.LimitArchive = true;
                if (Int32.TryParse(ArchiveLimitTextBox.Text, out int limitResult))
                    dataLoggerConfig.LimitArchiveFileNum = limitResult;
            }

            if (timeRotate.Checked) dataLoggerConfig.RotateByMin();
            else if (sizeRotate.Checked) dataLoggerConfig.RotateByMB();

            if (minutesTextBox.Enabled)
            {
                if (Int32.TryParse(minutesTextBox.Text, out int minuteResult))
                    dataLoggerConfig.RotateMinutes = minuteResult;
            }

            if (MBtextBox.Enabled)
            {
                if (Int32.TryParse(MBtextBox.Text, out int mBResult))
                    dataLoggerConfig.RotateMB = mBResult;
            }

            if (localDirTextBox.Enabled) dataLoggerConfig.LocalDirectory = localDirTextBox.Text;
            if (archiveDirTextBox.Enabled) dataLoggerConfig.ArchiveDirectory = archiveDirTextBox.Text;
            if (remoteHostTextBox.Enabled) dataLoggerConfig.RemoteHost = remoteHostTextBox.Text;

            if (remoteHostTextBox.Enabled)
            {
                if (Int32.TryParse(remotePortTextBox.Text, out int remotePortResult))
                    dataLoggerConfig.RemotePort = remotePortResult;
            }
            if (remoteDirTextBox.Enabled) dataLoggerConfig.RemoteDirectory = remoteDirTextBox.Text;
            if (usernameTextBox.Enabled) dataLoggerConfig.Username = usernameTextBox.Text;
            if (passwordTextBox.Enabled) dataLoggerConfig.Password = passwordTextBox.Text;
        }

        private void IsFormValid()
        {
            bool validationResult = true;

            if (!TextValidator.IsValidDirectory(localDirTextBox, toolTip, "Please provide a valid local directory")) validationResult = false;

            if (archive.Checked)
                if (!TextValidator.IsValidDirectory(archiveDirTextBox, toolTip, "Please provide a valid archive directory")) validationResult = false;

            if (timeRotate.Checked)
                if (!TextValidator.IsValidInteger(minutesTextBox, toolTip, "Please provide the number of minutes in whole digits")) validationResult = false;

            if (sizeRotate.Checked)
                if (!TextValidator.IsValidInteger(MBtextBox, toolTip, "Please provide a MB value in whole digits")) validationResult = false;

            // If we are logging locally we don't need any more than this
            if (!logLocally.Checked)
            {
                if (!TextValidator.IsValidHost(remoteHostTextBox, toolTip, "This does not appear to be a valid remote host (we cannot ping it)")) validationResult = false;
                if (!TextValidator.IsValidInteger(remotePortTextBox, toolTip, "This does not appear to be a valid remote port")) validationResult = false;
                if (!TextValidator.IsValidText(remoteDirTextBox, toolTip, "Please provide a valid remote directory")) validationResult = false;
                if (!TextValidator.IsValidText(usernameTextBox, toolTip, "Please provide a valid username")) validationResult = false;
                if (!TextValidator.IsValidText(passwordTextBox, toolTip, "Please provide a valid password")) validationResult = false;
            }

            if (!limitArchive.Checked)
                if (!TextValidator.IsValidInteger(ArchiveLimitTextBox, toolTip, "Please provide a number of files to retain in whole digits")) validationResult = false;

            isFormValid = validationResult;

            UpdateDataLoggerConfig();
            UpdateButtons();
        }

        private void LimitArchiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ArchiveLimitTextBox.Enabled = limitArchive.Checked;
            UpdatePanels();
        }

        private void ArchiveDirSelect_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowNewFolderButton = true;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                archiveDirTextBox.Text = folderBrowserDialog.SelectedPath;
                TextValidator.IsValidDirectory(archiveDirTextBox, toolTip, "Please provide a valid archive directory");
            }
        }

        private void Archive_CheckedChanged(object sender, EventArgs e)
        {
            if (archive.Checked)
                limitArchive.Enabled = true;
            else
            {
                limitArchive.Checked = false;
                limitArchive.Enabled = false;
            }

            UpdatePanels();
        }

        private void Compress_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePanels();
        }

    }
}
