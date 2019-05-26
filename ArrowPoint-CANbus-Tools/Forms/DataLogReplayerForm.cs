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

            Stopwatch stopwatch = new Stopwatch();
            double startTime = 0;
            double timeStamp;
            int timeDiff;

            stopwatch.Start();

            while (this.isReplaying && (line = ioStreamReader.ReadLine()) != null) 
            {

                string[] components = line.Split(',');

                if (!components[0].StartsWith("Recv time"))
                {                                        
                    timeStamp = (Convert.ToDateTime(components[0].Trim()) -  DateTime.MinValue).TotalMilliseconds;

                    if (startTime == 0)
                    {
                        startTime = timeStamp;
                    }

                    timeDiff = (int)(timeStamp - startTime - stopwatch.ElapsedMilliseconds);
                    if (timeDiff < 0) timeDiff = 0;
                    await Task.Delay(timeDiff);

                    CanPacket cp = new CanPacket
                    {
                        CanId = Convert.ToUInt32(components[2].Trim(), 16)
                    };

                    string rawBytesStr = components[4].Trim().Substring(2);
                    byte[] rawBytes = MyExtentions.StringToByteArray(rawBytesStr);
                    Array.Reverse(rawBytes, 0, rawBytes.Length);

                    for (int i = 0; i<=7; i++)                    
                        cp.SetByte(i,rawBytes[i]);                    

                    udpService.SendMessage(cp);
                }
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
