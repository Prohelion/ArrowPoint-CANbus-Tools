using ArrowPointCANBusTool.Canbus;
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

        public DataLoggerForm()
        {
            InitializeComponent();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            btnStart.Enabled = !CanRecordReplayDebugService.Instance.IsRecording && isFormValid;
            btnStop.Enabled = CanRecordReplayDebugService.Instance.IsRecording;
            btnSaveConfig.Enabled = isFormValid;
            btnTestConnection.Visible = (logViaFTP.Checked || logViaSFTP.Checked);
            btnTestConnection.Enabled = (logViaFTP.Checked || logViaSFTP.Checked) && isFormValid;
        }

        private void UpdatePanels()
        {            

            toolStripStatusText.Text = CanRecordReplayDebugService.Instance.RecordStatus;

            localDirTextBox.Visible = false;
            remoteHostTextBox.Visible = false; 
            remotePortTextBox.Visible = false;
            remoteDirTextBox.Visible = false;
            usernameTextBox.Visible = false;
            passwordTextBox.Visible = false;

            localDirTextBox.Enabled = false;
            remoteHostTextBox.Enabled = false;
            remotePortTextBox.Enabled = false;
            remoteDirTextBox.Enabled = false;
            usernameTextBox.Enabled = false;
            passwordTextBox.Enabled = false;

            localDirLabel.Visible = false;
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
                minutesTextBox.Enabled = true;
                MBtextBox.Enabled = false;
                MBtextBox.BackColor = default;

                if (String.IsNullOrEmpty(minutesTextBox.Text))
                    minutesTextBox.Text = "10";
            }

            if (sizeRotate.Checked)
            {
                minutesTextBox.Enabled = false;
                minutesTextBox.BackColor = default;
                MBtextBox.Enabled = true;
                
                if (String.IsNullOrEmpty(MBtextBox.Text))
                    MBtextBox.Text = "10";
            }

            IsFormValid();
            
        }

        private void BtnStartStop_Click(object sender, EventArgs e)
        {            
            Stream ioStream;
            StreamWriter ioWriterStream;

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                RestoreDirectory = true,
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 2,
                FileName = "RawDataLog-" + DateTime.Now.ToString("yyyyMMdd-HHmm") + ".txt"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((ioStream = saveFileDialog.OpenFile()) != null)
                {
                    ioWriterStream = new StreamWriter(ioStream);
                    CanRecordReplayDebugService.Instance.StartRecording(ioWriterStream);
                }
            }

            UpdateButtons();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            CanRecordReplayDebugService.Instance.StopRecording();
            UpdateButtons();
        }

        private void DataLoggerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CanRecordReplayDebugService.Instance.StopRecording();
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

            UpdatePanels();
        }

        private async void StartLogger_Click(object sender, EventArgs e)
        {
            await TransferScheduler.RunTransfer(10);
        }

        private void StopLogger_Click(object sender, EventArgs e)
        {
            TransferScheduler.StopTransfer();
        }

        private void SaveConfigButton_Click(object sender, EventArgs e)
        {
            DataLogger dataLoggerConfig = new DataLogger();

            if (logLocally.Checked) dataLoggerConfig.LogTo = DataLogger.LOG_TO_DISK;
            else if (logViaFTP.Checked) dataLoggerConfig.LogTo = DataLogger.LOG_TO_FTP;
            else if (logViaSFTP.Checked) dataLoggerConfig.LogTo = DataLogger.LOG_TO_SFTP;

            if (timeRotate.Checked) dataLoggerConfig.RotateBy = DataLogger.ROTATE_BY_MIN;
            else if (sizeRotate.Checked) dataLoggerConfig.RotateBy = DataLogger.ROTATE_BY_MB;

            if (minutesTextBox.Enabled) dataLoggerConfig.RotateMinutes = minutesTextBox.Text;
            if (MBtextBox.Enabled) dataLoggerConfig.RotateMB = MBtextBox.Text;

            if (localDirTextBox.Enabled) dataLoggerConfig.LocalDirectory = localDirTextBox.Text;
            if (remoteHostTextBox.Enabled) dataLoggerConfig.RemoteHost = remoteHostTextBox.Text;
            if (remoteHostTextBox.Enabled) dataLoggerConfig.RemotePort = Int32.Parse(remotePortTextBox.Text);
            if (remoteDirTextBox.Enabled) dataLoggerConfig.RemoteDirectory = remoteDirTextBox.Text;
            if (usernameTextBox.Enabled) dataLoggerConfig.Username = usernameTextBox.Text;
            if (passwordTextBox.Enabled) dataLoggerConfig.Password = passwordTextBox.Text;
            
            saveFileDialog.Title = "Save DataLogger configuration file";
            saveFileDialog.CheckFileExists = false;
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.DefaultExt = "dlconf";
            saveFileDialog.Filter = "DataLogger config files (*.dlconf)|*.dlconf|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                CanRecordReplayDebugService canRecordReplayDebugService = CanRecordReplayDebugService.NewInstance;
                canRecordReplayDebugService.SaveConfig(saveFileDialog.FileName, dataLoggerConfig);                
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
                    // Not using the instance here
                    CanRecordReplayDebugService canRecordReplayDebugService = CanRecordReplayDebugService.NewInstance;
                    DataLogger dataLoggerConfig = canRecordReplayDebugService.LoadConfig(ioStream);

                    if (dataLoggerConfig.LogTo.Equals(DataLogger.LOG_TO_DISK)) logLocally.Checked = true;
                    else if (dataLoggerConfig.LogTo.Equals(DataLogger.LOG_TO_FTP)) logViaFTP.Checked = true;
                    else if (dataLoggerConfig.LogTo.Equals(DataLogger.LOG_TO_SFTP)) logViaSFTP.Checked = true;

                    if (dataLoggerConfig.RotateBy.Equals(DataLogger.ROTATE_BY_MIN)) timeRotate.Checked = true;
                    else if (dataLoggerConfig.RotateBy.Equals(DataLogger.ROTATE_BY_MB)) sizeRotate.Checked = true;

                    minutesTextBox.Text = dataLoggerConfig.RotateMinutes;
                    MBtextBox.Text = dataLoggerConfig.RotateMB;

                    localDirTextBox.Text = dataLoggerConfig.LocalDirectory;
                    remoteHostTextBox.Text = dataLoggerConfig.RemoteHost;
                    remotePortTextBox.Text = dataLoggerConfig.RemotePort.ToString();
                    remoteDirTextBox.Text = dataLoggerConfig.RemoteDirectory;
                    usernameTextBox.Text = dataLoggerConfig.Username;
                    passwordTextBox.Text = dataLoggerConfig.Password;
                }
            }

            UpdatePanels();
        }

        private void localDirSelect_Click(object sender, EventArgs e)
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

        private void IsFormValid()
        {
            bool validationResult = true;

            if (!TextValidator.IsValidDirectory(localDirTextBox, toolTip, "Please provide a valid local directory")) validationResult = false;

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

            isFormValid = validationResult;

            UpdateButtons();
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
            transferUtil.SourceDirectory = "D:\\";
            transferUtil.DestinationDirectory = remoteDirTextBox.Text;

            if (transferUtil.TestConnection())
                MessageBox.Show("Connection is successful","Connection Test",MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Unable to connect, please check settings", "Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
