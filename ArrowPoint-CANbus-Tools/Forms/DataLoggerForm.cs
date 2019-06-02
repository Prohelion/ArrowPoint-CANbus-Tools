using ArrowPointCANBusTool.Canbus;
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
using static ArrowPointCANBusTool.Services.CanService;

namespace ArrowPointCANBusTool.Forms
{
    public partial class DataLoggerForm : Form
    {
        CanService canService;
        SaveFileDialog saveFileDialog;
        Stream ioStream;
        StreamWriter ioStreamWriter;
        Timer timer;        
        DateTime epochTime;
        DateTime currentTime;
        TimeSpan timeSpan;

        bool isLogging;
        bool isLogRawData;
        bool isLogParsedData;

        private List<CanPacket> canPacketList;
        private Boolean isNewPacket;

        public DataLoggerForm(CanService canService)
        {
            InitializeComponent();

            this.canService = canService;
            this.canPacketList = new List<CanPacket>();

            timer = new Timer
            {
                Interval = (100)
            };
            timer.Tick += new EventHandler(TimerTick);

            epochTime = new DateTime(1970, 1, 1);

            this.isLogRawData = true;
            this.isLogParsedData = false;
            this.rbDataRaw.Checked = this.isLogRawData;
            this.rbDataParsed.Checked = this.isLogParsedData;
            this.rbDataParsed.Enabled = false;

            //this.btnStartStop.Enabled = false;
            this.btnStop.Enabled = false;
        }

        private void DataLoggerForm_Load(object sender, EventArgs e)
        {
            canService.CanUpdateEventHandler += new CanUpdateEventHandler(PacketReceived);
        }

        private void RbDataRaw_CheckedChanged(object sender, EventArgs e)
        {
            this.isLogRawData = this.rbDataRaw.Checked;
            this.isLogParsedData = !this.rbDataRaw.Checked;
            this.rbDataRaw.Checked = this.isLogRawData;
            this.rbDataParsed.Checked = this.isLogParsedData;

            //this.btnStartStop.Enabled = true;
        }

        private void RbDataParsed_CheckedChanged(object sender, EventArgs e)
        {
            this.isLogParsedData = this.rbDataParsed.Checked;
            this.isLogRawData = !this.rbDataParsed.Checked;
            this.rbDataRaw.Checked = this.isLogRawData;
            this.rbDataParsed.Checked = this.isLogParsedData;

            //this.btnStartStop.Enabled = true;
        }

        private void BtnStartStop_Click(object sender, EventArgs e)
        {
            this.isLogParsedData = this.rbDataParsed.Checked;
            saveFileDialog = new SaveFileDialog
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
                    this.btnStartStop.Enabled = false;
                    this.btnStop.Enabled = true;
                    this.isLogging = true;

                    ioStreamWriter = new StreamWriter(ioStream);
                    timer.Start();

                    // Code to write the stream goes here.
                    //ioStream.Close();
                }
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (!this.isLogging) {
                canService.CanUpdateEventHandler -= new CanUpdateEventHandler(PacketReceived);
                timer.Stop();
                ioStreamWriter.Close();
                ioStream.Close();                
                return;
            }

            if (!this.isNewPacket) return;

            try
            {
                CanPacket[] canPacketListCopy = new CanPacket[canPacketList.Count];
                String logEntry;
                this.canPacketList.CopyTo(canPacketListCopy, 0);
                canPacketList.Clear();

                currentTime = DateTime.Now;
                timeSpan = currentTime - epochTime;
                logEntry = "DateTime:" + Convert.ToInt64(timeSpan.TotalMilliseconds).ToString() +
                        " Data:";

                foreach (CanPacket cp in canPacketListCopy)
                {
                    ioStreamWriter.WriteLine(logEntry + cp.RawBytesString);
                }

                this.isNewPacket = false;
            }
            catch
            {
                // Welcome to how to deal with concurrent threads 101
            }
        }

        private void PacketReceived(CanReceivedEventArgs e)
        {
            CanPacket cp = e.Message;

            this.canPacketList.Add(e.Message);

            this.isNewPacket = true;
        }

        public void Detach()
        {
            this.isLogging = false;
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            this.Detach();
            this.Close();
        }
    }
}
