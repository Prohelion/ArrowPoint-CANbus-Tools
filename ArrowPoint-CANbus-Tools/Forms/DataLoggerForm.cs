using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Services;
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
            btnStart.Enabled = !CanRecordReplayService.Instance.IsRecording;
            btnStop.Enabled = CanRecordReplayService.Instance.IsRecording;
            toolStripStatusText.Text = CanRecordReplayService.Instance.RecordStatus;
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
                    CanRecordReplayService.Instance.StartRecording(ioWriterStream);
                }
            }

            UpdateStatus();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            CanRecordReplayService.Instance.StopRecording();
            UpdateStatus();
        }

        private void DataLoggerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CanRecordReplayService.Instance.StopRecording();
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
    }
}
