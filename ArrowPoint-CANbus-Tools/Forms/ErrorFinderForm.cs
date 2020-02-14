using ArrowPointCANBusTool.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrowPointCANBusTool.Forms
{
    public partial class ErrorFinderForm : Form
    {

        OpenFileDialog openFileDialog;
        Stream ioStream;
        Timer timer;

        public ErrorFinderForm()
        {
            InitializeComponent();
            UpdateStatus();
        }
       
        private void ErrorFinderForm_Load(object sender, EventArgs e)
        {
            timer = new Timer
            {
                Interval = (100)
            };
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();
        }

        private void ErrorFinderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            toolStripStatusText.Text = CanRecordReplayDebugService.Instance.ReplayStatus;
        }

        private async void btnStart_ClickAsync(object sender, EventArgs e)
        {
            this.openFileDialog = new OpenFileDialog
            {
                RestoreDirectory = true,
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 2
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((ioStream = openFileDialog.OpenFile()) != null)
                    {
                        await CanRecordReplayDebugService.Instance.StartErrorTrace(ioStream);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

            UpdateStatus();
        }

   
    }
}
