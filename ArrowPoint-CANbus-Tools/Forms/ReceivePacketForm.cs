using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.CanBus;
using ArrowPointCANBusTool.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using static ArrowPointCANBusTool.Services.CanService;

namespace ArrowPointCANBusTool
{
    public partial class ReceivePacketForm : Form
    {
        private CanService canService;        
        private BindingList<CanPacket> canPacketBindingList;
        private List<CanPacket> canPacketList;
        private Boolean isNewPacket;
        private int idCounter;
        private Boolean isPaused;

        private int fromFilter = 1;
        private int toFilter = 1024;

        public ReceivePacketForm(CanService canService)
        {
            InitializeComponent();

            this.canService = canService;            

            this.isPaused = false;
            this.btnPause.Text = "Stop";
            
            this.fromTb.Text = fromFilter.ToString();
            this.toTb.Text = toFilter.ToString();
            this.filterCheckBox.Checked = true;
            this.cbAutoScroll.Checked = true;

            this.isNewPacket = false;
            this.idCounter = 0;
        }

        private void ReceivePacketForm_Load(object sender, EventArgs e)
        {
            canService.CanUpdateEventHandler += new CanUpdateEventHandler(PacketReceived);

            this.canPacketBindingList = new BindingList<CanPacket>(new List<CanPacket>());
            this.canPacketBindingSource.DataSource = canPacketBindingList;

            this.canPacketList = new List<CanPacket>();

            // Move this logic to the receiver
            Timer timer = new Timer
            {
                Interval = (100)
            };
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();
        }

        private void PacketReceived(CanReceivedEventArgs e)
        {
            if (this.isPaused) return;

            CanPacket cp = e.Message;

            if (this.filterCheckBox.Checked
                && (cp.CanIdBase10 < this.fromFilter
                || cp.CanIdBase10 > this.toFilter))
            {
                return;
            }

            cp.PacketIndex = idCounter;
            this.canPacketList.Add(e.Message);

            this.isNewPacket = true;
            idCounter++;
            if (idCounter > 5000) {
                idCounter = 0;
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (!this.isNewPacket) return;

            try
            {

                CanPacket[] canPacketListCopy = new CanPacket[canPacketList.Count];
                this.canPacketList.CopyTo(canPacketListCopy, 0);
                canPacketList.Clear();

                dataGridView1.Enabled = false;

                foreach (CanPacket cp in canPacketListCopy)
                {
                    if (dataGridView1.RowCount > 2000) {
                        canPacketBindingList.Clear();
                    }

                    cp.IsLittleEndian = !cbBigEndian.Checked;
                    canPacketBindingList.Add(cp);                    
                }

                dataGridView1.Enabled = true;

                if (this.cbAutoScroll.Checked)
                {
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                }

                this.isNewPacket = false;
            }
            catch
            {
                // Welcome to how to deal with concurrent threads 101
            }
        }

        public void Detach()
        {
            // Detach the event and delete the list
            canService.CanUpdateEventHandler -= new CanUpdateEventHandler(PacketReceived);            
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            idCounter = 0;
            canPacketBindingList.Clear();
        }

        private void FilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckFromFilter();
            CheckToFilter();

        }

        private Boolean CheckFromFilter()
        {

            if (this.fromTb.Text != null)
            {
                Boolean check = Int32.TryParse(this.fromTb.Text.Trim(), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out this.fromFilter);
                if (!check) { 
                    MessageBox.Show("Failed to parse Lower Limit Filter value");
                    return false;
                }
            }
            return true;
        }

        private bool CheckToFilter()
        {

            if (this.toTb.Text != null)
            {
                Boolean check = Int32.TryParse(this.toTb.Text.Trim(), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out this.toFilter);
                if (!check)
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

        private void FromTb_Leave(object sender, EventArgs e)
        {
            CheckFromFilter();
        }

        private void ToTb_Leave(object sender, EventArgs e)
        {
            CheckToFilter();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CanPacket currentPacket = (CanPacket)dataGridView1.CurrentRow.DataBoundItem;

            if (currentPacket == null)
            {
                MessageBox.Show("Please select a CanPacket");
            }
            else {
                SendPacketForm sendPacketForm = new SendPacketForm(this.canService, currentPacket.RawBytesString)
                {
                    MdiParent = this.MdiParent
                };
                sendPacketForm.Show();
            }
        }

        private void BtnPause_Click(object sender, EventArgs e)
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
