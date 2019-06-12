using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Forms;
using ArrowPointCANBusTool.Services;
using System;
using System.Collections.Concurrent;
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
        private List<CanPacket> canPacketList;
        private Boolean isPaused;
        private Timer timer;

        private int fromFilter = 1;
        private int toFilter = 1024;

        public ReceivePacketForm(CanService canService)
        {
            InitializeComponent();

            this.canService = canService;            

            isPaused = false;
            btnPause.Text = "Stop";
            
            fromTb.Text = fromFilter.ToString();
            toTb.Text = toFilter.ToString();
            filterCheckBox.Checked = true;
            cbAutoScroll.Checked = true;
        }

        private void ReceivePacketForm_Load(object sender, EventArgs e)
        {
            canService.CanUpdateEventHandler += new CanUpdateEventHandler(PacketReceived);
            canPacketList = new List<CanPacket>();

            canPacketGridView.VirtualMode = true;
            canPacketGridView.DoubleBuffered(true);

            timer = new Timer
            {
                Interval = (100)
            };
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();
        }

        private void ReceivePacketForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            // Detach the event and delete the list
            canService.CanUpdateEventHandler -= new CanUpdateEventHandler(PacketReceived);
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

            canPacketList.Add(e.Message);
        }


        private void TimerTick(object sender, EventArgs e)
        {
            // Try catch just to handle thread related issues where we close the form mid update
            try
            {
                canPacketGridView.RowCount = canPacketList.Count;

                if (this.cbAutoScroll.Checked)
                {
                    if (canPacketGridView.RowCount > 0)
                        canPacketGridView.FirstDisplayedScrollingRowIndex = canPacketGridView.RowCount - 1;
                }
            } catch { };
        }


        private void ClearBtn_Click(object sender, EventArgs e)
        {
            canPacketList.Clear();            
            canPacketGridView.Rows.Clear();            
            canPacketGridView.Refresh();            
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

            CanPacket currentPacket = null;

            if (canPacketGridView.CurrentRow != null)            
                currentPacket = (CanPacket)canPacketList[canPacketGridView.CurrentRow.Index];            

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

        private void DataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            // Try catch just to deal with thread issues when we clear the packetList in the middle
            // of a refresh
            try
            {
                int rowIndex = e.RowIndex;
                switch (canPacketGridView.Columns[e.ColumnIndex].Name)
                {
                    /* Not actual names, example */
                    case "packet": e.Value = canPacketList[rowIndex].PacketIndex; break;
                    case "canId": e.Value = canPacketList[rowIndex].CanIdAsHex; break;
                    case "CanIdBase10": e.Value = canPacketList[rowIndex].CanIdBase10; break;
                    case "flags": e.Value = canPacketList[rowIndex].Flags; break;
                    case "byte7": e.Value = canPacketList[rowIndex].Byte7AsHex; break;
                    case "byte6": e.Value = canPacketList[rowIndex].Byte6AsHex; break;
                    case "byte5": e.Value = canPacketList[rowIndex].Byte5AsHex; break;
                    case "byte4": e.Value = canPacketList[rowIndex].Byte4AsHex; break;
                    case "byte3": e.Value = canPacketList[rowIndex].Byte3AsHex; break;
                    case "byte2": e.Value = canPacketList[rowIndex].Byte2AsHex; break;
                    case "byte1": e.Value = canPacketList[rowIndex].Byte1AsHex; break;
                    case "byte0": e.Value = canPacketList[rowIndex].Byte0AsHex; break;
                    case "int3": e.Value = canPacketList[rowIndex].Int3; break;
                    case "int2": e.Value = canPacketList[rowIndex].Int2; break;
                    case "int1": e.Value = canPacketList[rowIndex].Int1; break;
                    case "int0": e.Value = canPacketList[rowIndex].Int0; break;
                    case "float1": e.Value = canPacketList[rowIndex].Float1; break;
                    case "float0": e.Value = canPacketList[rowIndex].Float0; break;
                    case "rawBytesStr": e.Value = canPacketList[rowIndex].RawBytesString; break;
                }
            } catch { }
        }

    }
}
