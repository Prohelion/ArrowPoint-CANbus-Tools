using ArrowPointCANBusTool.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ArrowPointCANBusTool.Forms
{
    public partial class ConnectForm : Form
    {           
        private String ipAddress = "239.255.60.60";
        private int port = 4876;

        private class IpDetails
        {
            public string IpAddress { get; set; }
            public string IpDescription { get; set; }
            public override string ToString()
            {
                return IpDescription;
            }
        }

        public ConnectForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            ipAddressTb.Text = this.ipAddress;
            portTb.Text = this.port.ToString();

            ipAddressTb.Enabled = false;
            portTb.Enabled = false;
            InterfaceCheckedListBox.Enabled = false;

            Boolean isConnected = CanService.Instance.IsConnected();

            this.connectBtn.Enabled = !isConnected;
            this.disconnectBtn.Enabled = isConnected;
            this.radioButton1.Enabled = !isConnected;
            this.radioButton2.Enabled = !isConnected;

            foreach (KeyValuePair<string, string> entry in CanService.Instance.AvailableInterfaces)
            {
                IpDetails ipDetails = new IpDetails()
                {
                    IpAddress = entry.Key,
                    IpDescription = entry.Value
                };

                if (CanService.Instance.SelectedInterfaces != null && !CanService.Instance.SelectedInterfaces.Contains(ipDetails.IpAddress))
                    InterfaceCheckedListBox.Items.Add(ipDetails, false);             
                else
                    InterfaceCheckedListBox.Items.Add(ipDetails, true);
            }
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) {
                ipAddressTb.Enabled = true;
                portTb.Enabled = true;
                InterfaceCheckedListBox.Enabled = true;
            }
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ipAddressTb.Enabled = false;
            portTb.Enabled = false;
            InterfaceCheckedListBox.Enabled = false;
        }

        private void DisconnectBtn_Click(object sender, EventArgs e)
        {
            CanService.Instance.Disconnect();            

            this.connectBtn.Enabled = true;
            this.disconnectBtn.Enabled = false;

            this.ipAddressTb.Enabled = false;
            this.portTb.Enabled = false;
            this.radioButton1.Checked = false;
            this.radioButton2.Checked = true;
            this.radioButton1.Enabled = true;
            this.radioButton2.Enabled = true;         
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            Boolean ipAddressParsed = IPAddress.TryParse(this.ipAddressTb.Text, out IPAddress notUsedIpAddress);
            Boolean portParsed = Int32.TryParse(this.portTb.Text, out this.port);

            List<string> selectedInterfaces = new List<String>();

            foreach (IpDetails ipDetails in InterfaceCheckedListBox.CheckedItems)            
            {                
                selectedInterfaces.Add(ipDetails.IpAddress);
            }

            CanService.Instance.SelectedInterfaces = selectedInterfaces;

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
