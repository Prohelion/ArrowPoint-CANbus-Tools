using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Model;
using ArrowPointCANBusTool.Services;
using ArrowPointCANBusTool.Transfer;
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
        Timer timer;

        public DataLoggerForm()
        {
            InitializeComponent();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            btnStart.Enabled = !CanRecordReplayDebugService.Instance.IsRecording;
            btnStop.Enabled = CanRecordReplayDebugService.Instance.IsRecording;
            toolStripStatusText.Text = CanRecordReplayDebugService.Instance.RecordStatus;
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

            UpdateStatus();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            CanRecordReplayDebugService.Instance.StopRecording();
            UpdateStatus();
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

            dataLoggerConfig.LocalDirectory = localDirTextBox.Text;
            dataLoggerConfig.RemoteHost = remoteHostTextBox.Text;
            dataLoggerConfig.RemoteDirectory = remoteDirTextBox.Text;
            dataLoggerConfig.Username = usernameTextBox.Text;
            dataLoggerConfig.Password = passwordTextBox.Text;
            
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

                    localDirTextBox.Text = dataLoggerConfig.LocalDirectory;
                    remoteHostTextBox.Text = dataLoggerConfig.RemoteHost;
                    remoteDirTextBox.Text = dataLoggerConfig.RemoteDirectory;
                    usernameTextBox.Text = dataLoggerConfig.Username;
                    passwordTextBox.Text = dataLoggerConfig.Password;
                }
            }
        }

        private void localDirSelect_Click(object sender, EventArgs e)
        {            
            folderBrowserDialog.ShowNewFolderButton = true;            
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                localDirTextBox.Text = folderBrowserDialog.SelectedPath;                
            }
        }
    }
}
