using System;
using System.Net;
using System.Windows.Forms;

namespace ArrowWareDiagnosticTool.Forms
{
    public partial class SettingsForm : Form
    {
        private UdpReciever udpReciever;
        private UdpSender udpSender;

        private String ipAddress = "239.255.60.60";
        private int port = 4876;

        public SettingsForm(UdpReciever udpReciever, UdpSender udpSender)
        {
            InitializeComponent();

            this.udpReciever = udpReciever;
            this.udpSender = udpSender;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            this.ipAddressTb.Text = this.ipAddress;
            this.portTb.Text = this.port.ToString();

            this.ipAddressTb.Enabled = false;
            this.portTb.Enabled = false;

            Boolean isConnected = this.udpReciever.isConnected && this.udpReciever.isConnected;

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
            this.udpReciever.disconnect();
            this.udpSender.disconnect();

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
            Boolean recieverConnected = this.udpReciever.connect(this.ipAddress, this.port);
            Boolean senderConnected = this.udpSender.connect(this.ipAddress, this.port);

            if (ipAddressParsed && portParsed && recieverConnected && senderConnected)
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
                MessageBox.Show("Failed to connect");
            }
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
