using ArrowPointCANBusTool.CanBus;
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

namespace ArrowPointCANBusTool.Forms
{
    public partial class DataLogReplayerForm : Form
    {
        UdpService udpService;
        OpenFileDialog openFileDialog;
        Stream ioStream;
        StreamReader ioStreamReader;

        bool isReplaying;
        bool isIncludeFilter;

        public DataLogReplayerForm(UdpService udpService)
        {
            InitializeComponent();

            this.udpService = udpService;
            this.isReplaying = false;
            this.isIncludeFilter = true;
            this.rbIdInclude.Checked = this.isIncludeFilter;
            this.rbIdExclude.Checked = !this.isIncludeFilter;

            this.rbIdInclude.Enabled = false;
            this.rbIdExclude.Enabled = false;

            this.tbFilterFrom.Text = "1";
            this.tbFilterFrom.Enabled = false;
            this.tbFilterTo.Text = "1000";
            this.tbFilterTo.Enabled = false;

            this.btnStop.Enabled = false;
        }

        private void BtnStartStop_Click(object sender, EventArgs e)
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
                        this.btnStartStop.Enabled = false;
                        this.btnStop.Enabled = true;
                        this.isReplaying = true;

                        ioStreamReader = new StreamReader(ioStream);
                        StartReplaying();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private async void StartReplaying() {
            string line;

            string timeStampIdentifier = "DateTime:";
            int timeStampIndex;
            Stopwatch stopwatch = new Stopwatch();
            long startTime = 0;
            long timeStamp;
            int timeDiff;
            string rawDataIdentifier = "Data:";
            int rawDataStrIndex;
            string rawDataStr;

            stopwatch.Start();

            while (this.isReplaying && (line = ioStreamReader.ReadLine()) != null) {

                timeStampIndex = line.IndexOf(timeStampIdentifier) + timeStampIdentifier.Length;
                timeStamp = Convert.ToInt64(line.Substring(timeStampIndex, 13));

                if (startTime == 0) {
                    startTime = timeStamp;
                }

                timeDiff = (int)(timeStamp - startTime - stopwatch.ElapsedMilliseconds);
                await Task.Delay(timeDiff);

                rawDataStrIndex = line.IndexOf(rawDataIdentifier) + rawDataIdentifier.Length;
                rawDataStr = line.Substring(rawDataStrIndex, 60);
                udpService.SendMessage(new CanPacket(rawDataStr));
            }

            this.ioStreamReader.Close();
            this.ioStream.Close();

            this.btnStartStop.Enabled = true;
            this.btnStop.Enabled = false;
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            this.isReplaying = false;
        }
    }
}
