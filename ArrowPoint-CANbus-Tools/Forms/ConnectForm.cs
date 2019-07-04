using ArrowPointCANBusTool.Services;
using System;
using System.Net;
using System.Windows.Forms;

namespace ArrowPointCANBusTool.Forms
{
    public partial class ConnectForm : Form
    {           
        private String ipAddress = "239.255.60.60";
        private int port = 4876;

        public ConnectForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            this.ipAddressTb.Text = this.ipAddress;
            this.portTb.Text = this.port.ToString();

            this.ipAddressTb.Enabled = false;
            this.portTb.Enabled = false;

            Boolean isConnected = CanService.Instance.IsConnected();

            this.connectBtn.Enabled = !isConnected;
            this.disconnectBtn.Enabled = isConnected;
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked) {
                this.ipAddressTb.Enabled = true;
                this.portTb.Enabled = true;
            }
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.ipAddressTb.Enabled = false;
            this.portTb.Enabled = false;
        }

        private void DisconnectBtn_Click(object sender, EventArgs e)
        {
            CanService.Instance.Disconnect();            

            this.connectBtn.Enabled = true;
            this.disconnectBtn.Enabled = false;

            this.ipAddressTb.Enabled = false;
            this.portTb.Enabled = false;
            this.radioButton1.Checked = false;
            this.radioButton2.Checked = false;
            this.radioButton1.Enabled = true;
            this.radioButton2.Enabled = true;

            this.Close();
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            Boolean ipAddressParsed = IPAddress.TryParse(this.ipAddressTb.Text, out IPAddress notUsedIpAddress);
            Boolean portParsed = Int32.TryParse(this.portTb.Text, out this.port);
            Boolean canServiceConnected = CanService.Instance.Connect(this.ipAddress, this.port);            

            if (ipAddressParsed && portParsed && canServiceConnected)
            {
                this.connectBtn.Enabled = false;
                this.disconnectBtn.Enabled = true;

                this.ipAddressTb.Enabled = false;
                this.portTb.Enabled = false;
                this.radioButton1.Checked = false;
                this.radioButton2.Checked = false;
                this.radioButton1.Enabled = false;
                this.radioButton2.Enabled = false;

                this.Close();
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

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
