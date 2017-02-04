using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace ArrowWareDiagnosticTool
{
    public partial class ReceivePacketForm : Form
    {
        private UdpReciever udpReciever;
        private UdpSender udpSender;
        private BindingList<CanPacket> canPacketBindingList;
        private List<CanPacket> canPacketList;
        private Boolean isNewPacket;
        private int idCounter;
        private Boolean isPaused;

        private int fromFilter = 0;
        private int toFilter = 1000;

        public ReceivePacketForm(UdpReciever udpReciever, UdpSender udpSender)
        {
            InitializeComponent();

            this.udpReciever = udpReciever;
            this.udpSender = udpSender;

            this.isPaused = false;
            this.btnPause.Text = "Stop";
            this.isNewPacket = false;
            this.idCounter = 0;
        }

        private void ReceivePacketForm_Load(object sender, EventArgs e)
        {
            udpReciever.recieverFormEventHandler += new UdpRecievedEventHandler(packetRecieved);

            this.canPacketBindingList = new BindingList<CanPacket>(new List<CanPacket>());
            this.canPacketBindingSource.DataSource = canPacketBindingList;

            this.canPacketList = new List<CanPacket>();

            // Move this logic to the reciever
            Timer timer = new Timer();
            timer.Interval = (100);
            timer.Tick += new EventHandler(timerTick);
            timer.Start();

            this.fromTb.Text = fromFilter.ToString();
            this.toTb.Text = toFilter.ToString();
        }

        private void packetRecieved(UdpRecievedEventArgs e)
        {
            if (this.isPaused) return;

            CanPacket cp = e.Message;

            if (this.filterCheckBox.Checked
                && (cp.idBase10 < this.fromFilter
                || cp.idBase10 > this.toFilter))
            {
                return;
            }

            cp.packet = idCounter;
            this.canPacketList.Add(e.Message);

            this.isNewPacket = true;
            idCounter++;
        }

        private void timerTick(object sender, EventArgs e)
        {
            if (!this.isNewPacket) return;

            CanPacket[] canPacketListCopy = new CanPacket[canPacketList.Count];
            this.canPacketList.CopyTo(canPacketListCopy, 0);
            canPacketList.Clear();

            foreach (CanPacket cp in canPacketListCopy)
            {
                canPacketBindingList.Add(cp);
            }
            
            this.isNewPacket = false;
        }

        public void Detach()
        {
            // Detach the event and delete the list
            udpReciever.recieverFormEventHandler -= new UdpRecievedEventHandler(packetRecieved);
            udpReciever = null;
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            canPacketBindingList.Clear();
            idCounter = 0;
        }

        private void filterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            checkFromFilter();
            checkToFilter();

        }

        private Boolean checkFromFilter()
        {
            if (this.fromTb.Text != null)
            {
                /*if (this.fromTb.Text.Length % 2 == 1)
                {
                    this.fromTb.Text = "0" + this.fromTb.Text;
                }

                if (this.fromTb.Text.Length < 4)
                {
                    for (int i = 0; i <= (4 - this.fromTb.Text.Length); i++)
                    {
                        this.fromTb.Text = "0" + this.fromTb.Text;
                    }
                }*/

                try
                {
                    this.fromFilter = int.Parse(this.fromTb.Text, System.Globalization.NumberStyles.HexNumber);
                }
                catch
                {
                    MessageBox.Show("Failed to parse Lower Limit Filter value");
                    return false;
                }
            }
            return true;
        }

        private Boolean checkToFilter()
        {
            if (this.toTb.Text != null)
            {
                /*if (this.toTb.Text.Length % 2 == 1)
                {
                    this.toTb.Text = "0" + this.toTb.Text;
                }

                if (this.toTb.Text.Length <= 4) {
                    for (int i = 0; i < (4 - this.toTb.Text.Length); i++) {
                        this.toTb.Text = "0" + this.toTb.Text;
                    }
                }*/

                try
                {
                    this.toFilter = int.Parse(this.toTb.Text, System.Globalization.NumberStyles.HexNumber);
                }
                catch
                {
                    MessageBox.Show("Failed to parse Upper Limit Filter value");
                    return false;
                }
            }
            else
            {
                this.toFilter = this.fromFilter;
            }

            if (this.fromFilter > this.toFilter)
            {
                int temp = this.fromFilter;
                this.fromFilter = this.toFilter;
                this.toFilter = temp;
            }

            return true;
        }

        private void fromTb_Leave(object sender, EventArgs e)
        {
            checkFromFilter();
        }

        private void toTb_Leave(object sender, EventArgs e)
        {
            checkToFilter();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CanPacket currentPacket = (CanPacket)dataGridView1.CurrentRow.DataBoundItem;

            if (currentPacket == null)
            {
                MessageBox.Show("Please select a CanPacket");
            }
            else {
                SendPacketForm sendPacketForm = new SendPacketForm(this.udpReciever, this.udpSender, currentPacket.rawBytesStr);
                sendPacketForm.MdiParent = this.MdiParent;
                sendPacketForm.Show();
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (this.isPaused)
            {
                this.isPaused = false;
                this.btnPause.Text = "Stop";
            }
            else {
                this.isPaused = true;
                this.btnPause.Text = "Start";
            }
        }
    }
}
