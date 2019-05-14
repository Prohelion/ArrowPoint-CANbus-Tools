using ArrowPointCANBusTool.Services;
using System;
using System.Net;
using System.Windows.Forms;

namespace ArrowPointCANBusTool.Forms
{
    public partial class SettingsForm : Form
    {
        private UdpService udpService;        

        private String ipAddress = "239.255.60.60";
        private int port = 4876;

        public SettingsForm(UdpService udpService)
        {
            InitializeComponent();

            this.udpService = udpService;            
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            this.ipAddressTb.Text = this.ipAddress;
            this.portTb.Text = this.port.ToString();

            this.ipAddressTb.Enabled = false;
            this.portTb.Enabled = false;

            Boolean isConnected = this.udpService.IsUdpConnected();

            this.connectBtn.Enabled = !isConnected;
            this.disconnectBtn.Enabled = isConnected;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked) {
                this.ipAddressTb.Enabled = true;
                this.portTb.Enabled = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.ipAddressTb.Enabled = false;
            this.portTb.Enabled = false;
        }

        private void disconnectBtn_Click(object sender, EventArgs e)
        {
            this.udpService.Disconnect();            

            this.connectBtn.Enabled = true;
            this.disconnectBtn.Enabled = false;

            this.ipAddressTb.Enabled = false;
            this.portTb.Enabled = false;
            this.radioButton1.Checked = false;
            this.radioButton2.Checked = false;
            this.radioButton1.Enabled = true;
            this.radioButton2.Enabled = true;
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            IPAddress notUsedIpAddress;

            Boolean ipAddressParsed = IPAddress.TryParse(this.ipAddressTb.Text, out notUsedIpAddress);
            Boolean portParsed = Int32.TryParse(this.portTb.Text, out this.port);
            Boolean udpServiceConnected = this.udpService.Connect(this.ipAddress, this.port);            

            if (ipAddressParsed && portParsed && udpServiceConnected)
            {
                this.connectBtn.Enabled = false;
                this.disconnectBtn.Enabled = true;

                this.ipAddressTb.Enabled = false;
                this.portTb.Enabled = false;
                this.radioButton1.Checked = false;
                this.radioButton2.Checked = false;
                this.radioButton1.Enabled = false;
                this.radioButton2.Enabled = false;

                
            }
            else if (!ipAddressParsed)
            {
                MessageBox.Show("Failed to parse IP address.");
            }
            else if (!portParsed) {
                MessageBox.Show("Failed to parse port value. Port must be an integer");
            }
            else
            {
                MessageBox.Show("Failed to connect, this is likely caused by another tool already listening on the CanBus Port.");
            }
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
