using ArrowPointCANBusTool;
using ArrowPointCANBusTool.CanLibrary;
using ArrowPointCANBusTool.Services;
using Prohelion.CanLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrowPointCANBusTool.Forms
{
    public partial class SendPacketForm : Form
    {        
        private CanPacket canPacket;
        private Timer timer;
        private Boolean looping;

        private string samplePacket = "005472697469756d00be61fea90031010000050800080000000000000000";

        public SendPacketForm()
        {
            InitializeComponent();
            
            this.looping = false;

            this.btnReset.Enabled = !looping;
            this.btnLoop.Enabled = !looping;
            this.btnSend.Enabled = !looping;
            this.tbLoopRate.Enabled = !looping;

            this.canPacket = new CanPacket(samplePacket);

            UpdateInputFields();
        }

        public SendPacketForm(String newPacket)
        {
            InitializeComponent();
            
            this.looping = false;

            this.btnReset.Enabled = !looping;
            this.btnLoop.Enabled = !looping;
            this.btnSend.Enabled = !looping;
            this.tbLoopRate.Enabled = !looping;

            this.samplePacket = newPacket;
            this.canPacket = new CanPacket(samplePacket);

            UpdateInputFields();
        }

        private void SendPacketForm_Load(object sender, EventArgs e)
        {

        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            int sent = CanService.Instance.SendMessage(this.canPacket);          
        }

        private void CbLoop_CheckedChanged(object sender, EventArgs e)
        {
            if (this.timer != null)
            {
                this.timer.Stop();
                this.btnReset.Enabled = true;
                this.tbLoopRate.Enabled = true;
            }
        }

        private void BtnLoop_Click(object sender, EventArgs e)
        {
            if (looping)
            {
                this.timer.Stop();
                this.timer = null;

                looping = false;

                this.btnReset.Enabled = !looping;
                this.btnSend.Enabled = !looping;
                this.tbLoopRate.Enabled = !looping;

                this.btnLoop.Text = "Loop";

            }
            else if (!looping && int.TryParse(tbLoopRate.Text, out int loopRate))
            {
                timer = new Timer
                {
                    Interval = (loopRate)
                };
                timer.Tick += new EventHandler(TimerTick);
                timer.Start();

                looping = true;

                this.btnReset.Enabled = !looping;
                this.btnSend.Enabled = !looping;
                this.tbLoopRate.Enabled = !looping;

                this.btnLoop.Text = "Stop";
            }
            else
            {
                MessageBox.Show("Unable to parse Loop Rate");
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            this.canPacket = new CanPacket(samplePacket);

            UpdateInputFields();
        }

        private void TbId_Leave(object sender, EventArgs e)
        {
            if (!IsHexString(this.tbId.Text))
            {
                MessageBox.Show("ID is not hex");
            }

            this.canPacket.CanIdBase10 = uint.Parse(CanUtilities.Trim0x(this.tbId.Text), System.Globalization.NumberStyles.HexNumber);
            UpdateInputFields();
        }

        private void TbIdBase10_Leave(object sender, EventArgs e)
        {
            if (!int.TryParse(this.tbIdBase10.Text, out int CanIdBase10))
            {
                MessageBox.Show("IdBase10 is not an Integer");
            }
            else
            {
                this.canPacket.CanIdBase10 = (uint)CanIdBase10;
                UpdateInputFields();
            }
        }

        private void CbExtended_MouseClick(object sender, MouseEventArgs e)
        {
            this.canPacket.Extended = !this.canPacket.Extended;
            UpdateInputFields();
        }

        private void CbRtr_MouseClick(object sender, MouseEventArgs e)
        {
            this.canPacket.Rtr = !this.canPacket.Rtr;
            UpdateInputFields();
        }

        private void TbByte0_Leave(object sender, EventArgs e)
        {
            UpdateByte(0, this.tbByte0.Text);
        }

        private void TbByte1_Leave(object sender, EventArgs e)
        {
            UpdateByte(1, this.tbByte1.Text);
        }

        private void TbByte2_Leave(object sender, EventArgs e)
        {
            UpdateByte(2, this.tbByte2.Text);
        }

        private void TbByte3_Leave(object sender, EventArgs e)
        {
            UpdateByte(3, this.tbByte3.Text);
        }

        private void TbByte4_Leave(object sender, EventArgs e)
        {
            UpdateByte(4, this.tbByte4.Text);
        }

        private void TbByte5_Leave(object sender, EventArgs e)
        {
            UpdateByte(5, this.tbByte5.Text);
        }

        private void TbByte6_Leave(object sender, EventArgs e)
        {
            UpdateByte(6, this.tbByte6.Text);
        }

        private void TbByte7_Leave(object sender, EventArgs e)
        {
            UpdateByte(7, this.tbByte7.Text);
        }

        private void TbInt0_Leave(object sender, EventArgs e)
        {
            this.UpdateInt(0, this.tbInt0.Text);
        }

        private void TbInt1_Leave(object sender, EventArgs e)
        {
            this.UpdateInt(1, this.tbInt1.Text);
        }

        private void TbInt2_Leave(object sender, EventArgs e)
        {
            this.UpdateInt(2, this.tbInt2.Text);
        }

        private void TbInt3_Leave(object sender, EventArgs e)
        {
            this.UpdateInt(3, this.tbInt3.Text);
        }

        private void TbInt320_Leave(object sender, EventArgs e)
        {
            this.UpdateInt32(0, this.tbInt320.Text);
        }

        private void TbInt321_Leave(object sender, EventArgs e)
        {
            this.UpdateInt32(1, this.tbInt321.Text);
        }

        private void TbFloat0_Leave(object sender, EventArgs e)
        {
            this.UpdateFloat(0, this.tbFloat0.Text);
        }

        private void TbFloat1_Leave(object sender, EventArgs e)
        {
            this.UpdateFloat(1, this.tbFloat1.Text);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            int sent = CanService.Instance.SendMessage(this.canPacket);
        }

        private static Boolean IsHexString(String text)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(CanUtilities.Trim0x(text), @"\A\b[0-9a-fA-F]+\b\Z");
        }

        private bool UpdateByte(int index, string byteString)
        {

            if (byteString.Length == 1)
            {
                byteString = "0" + byteString;
            }
            else if (byteString.Length != 2)
            {
                MessageBox.Show("Byte" + index.ToString() + " must have a length of 2");
                return false;
            }

            if (!IsHexString(byteString))
            {
                MessageBox.Show("Byte" + index.ToString() + " is not hex");
                return false;
            }

            byte byteVal = Convert.ToByte(byteString);

            switch (index)
            {
                case 0: this.canPacket.UBytePos0 = byteVal; break;
                case 1: this.canPacket.UBytePos1 = byteVal; break;
                case 2: this.canPacket.UBytePos2 = byteVal; break;
                case 3: this.canPacket.UBytePos3 = byteVal; break;
                case 4: this.canPacket.UBytePos4 = byteVal; break;
                case 5: this.canPacket.UBytePos5 = byteVal; break;
                case 6: this.canPacket.UBytePos6 = byteVal; break;
                case 7: this.canPacket.UBytePos7 = byteVal; break;                
            }
            
            UpdateInputFields();

            return true;
        }

        private bool UpdateInt32(int index, string intString)
        {
            if (intString.Length == 0)
            {
                intString = "0";
            }

            if (!int.TryParse(intString, out int intVal))
            {
                MessageBox.Show("Int" + index.ToString() + " is not an Integer");
                return false;
            }

            switch (index)
            {
                case 0: this.canPacket.Int32Pos0 = intVal; break;
                case 1: this.canPacket.Int32Pos1 = intVal; break;
            }

            UpdateInputFields();
            return true;
        }

        private bool UpdateInt(int index, string intString)
        {
            if (intString.Length == 0)
            {
                intString = "0";
            }

            if (!short.TryParse(intString, out short shortVal))
            {
                MessageBox.Show("Int" + index.ToString() + " is not a Integer");
                return false;
            }

            switch (index)
            {
                case 0: this.canPacket.Short16Pos0 = shortVal; break;
                case 1: this.canPacket.Short16Pos1 = shortVal; break;
                case 2: this.canPacket.Short16Pos2 = shortVal; break;
                case 3: this.canPacket.Short16Pos3 = shortVal; break;
            }
            
            UpdateInputFields();
            return true;
        }

        private bool UpdateFloat(int index, string floatString)
        {
            if (floatString.Length == 0)
            {
                floatString = "0.00";
            }

            if (!float.TryParse(floatString, out float floatVal))
            {
                MessageBox.Show("Float" + index.ToString() + " is not a Float");
                return false;
            }

            switch (index)
            {
                case 0: this.canPacket.FloatPos0 = floatVal; break;
                case 1: this.canPacket.FloatPos1 = floatVal; break;
            }

            UpdateInputFields();
            return true;
        }

        private void TbRawData_Leave(object sender, EventArgs e)
        {
            double dataLength = this.tbRawData.Text.Length / 2; ;
            if ((dataLength - 16) % 14 != 0)
            {
                MessageBox.Show("Raw Bytes must have a length of 30");
                return;
            }

            if (!IsHexString(this.tbRawData.Text))
            {
                MessageBox.Show("Raw Bytes is not hex");
                return;
            }

            this.canPacket.RawBytesString = this.tbRawData.Text;
            UpdateInputFields();
        }

        private void UpdateInputFields()
        {

            this.tbId.Text = this.canPacket.CanIdAsHex.ToString();
            this.tbIdBase10.Text = this.canPacket.CanIdBase10.ToString();
            this.cbExtended.Checked = this.canPacket.Extended;
            this.cbRtr.Checked = this.canPacket.Rtr;

            this.tbByte7.Text = this.canPacket.Byte7AsHex;
            this.tbByte6.Text = this.canPacket.Byte6AsHex;
            this.tbByte5.Text = this.canPacket.Byte5AsHex;
            this.tbByte4.Text = this.canPacket.Byte4AsHex;
            this.tbByte3.Text = this.canPacket.Byte3AsHex;
            this.tbByte2.Text = this.canPacket.Byte2AsHex;
            this.tbByte1.Text = this.canPacket.Byte1AsHex;
            this.tbByte0.Text = this.canPacket.Byte0AsHex;

            this.tbInt3.Text = this.canPacket.Short16Pos3.ToString();
            this.tbInt2.Text = this.canPacket.Short16Pos2.ToString();
            this.tbInt1.Text = this.canPacket.Short16Pos1.ToString();
            this.tbInt0.Text = this.canPacket.Short16Pos0.ToString();

            this.tbInt321.Text = this.canPacket.Int32Pos1.ToString();
            this.tbInt320.Text = this.canPacket.Int32Pos0.ToString();

            this.tbFloat1.Text = this.canPacket.FloatPos1.ToString();
            this.tbFloat0.Text = this.canPacket.FloatPos0.ToString();

            this.tbRawData.Text = this.canPacket.RawBytesString;

        }
      

    }
}
