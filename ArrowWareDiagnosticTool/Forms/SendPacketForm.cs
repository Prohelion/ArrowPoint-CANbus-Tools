using ArrowWareDiagnosticTool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrowWareDiagnosticTool
{
    public partial class SendPacketForm : Form
    {
        private UdpSender udpSender;
        private CanPacket canPacket;
        private Timer timer;
        private Boolean looping;

        private string samplePacket = "005472697469756d006508a8c0007f5d0000012300080000000000000000";

        public SendPacketForm(UdpSender udpSender)
        {
            InitializeComponent();

            this.udpSender = udpSender;
            this.looping = false;

            this.btnReset.Enabled = !looping;
            this.btnLoop.Enabled = !looping;
            this.btnSend.Enabled = !looping;
            this.tbLoopRate.Enabled = !looping;

            this.canPacket = new CanPacket(samplePacket);

            updateInputFields();
        }

        public SendPacketForm(UdpSender udpSender, String newPacket)
        {
            InitializeComponent();

            this.udpSender = udpSender;
            this.looping = false;

            this.btnReset.Enabled = !looping;
            this.btnLoop.Enabled = !looping;
            this.btnSend.Enabled = !looping;
            this.tbLoopRate.Enabled = !looping;

            this.samplePacket = newPacket;
            this.canPacket = new CanPacket(samplePacket);

            updateInputFields();
        }

        private void SendPacketForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            bool sent = udpSender.SendMessage(this.canPacket);
          
        }

        private void cbLoop_CheckedChanged(object sender, EventArgs e)
        {
            if (this.timer != null)
            {
                this.timer.Stop();
                this.btnReset.Enabled = true;
                this.tbLoopRate.Enabled = true;
            }
        }

        private void btnLoop_Click(object sender, EventArgs e)
        {
            int loopRate;

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
            else if (!looping && int.TryParse(tbLoopRate.Text, out loopRate))
            {
                timer = new Timer();
                timer.Interval = (loopRate);
                timer.Tick += new EventHandler(timerTick);
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.canPacket = new CanPacket(samplePacket);

            updateInputFields();
        }

        private void tbId_Leave(object sender, EventArgs e)
        {
            if (!isHexString(this.tbId.Text))
            {
                MessageBox.Show("ID is not hex");
            }
            else if (this.tbId.Text.Length == 4)
            {
                this.canPacket.setCanId(this.tbId.Text);

                updateInputFields();
            }
        }

        private void tbIdBase10_Leave(object sender, EventArgs e)
        {
            int canIdBase10;

            if (!int.TryParse(this.tbIdBase10.Text, out canIdBase10))
            {
                MessageBox.Show("IdBase10 is not an Integer");
            }
            else
            {
                this.canPacket.setCanIdBase10(canIdBase10);
                updateInputFields();
            }
        }

        private void cbExtended_MouseClick(object sender, MouseEventArgs e)
        {
            this.canPacket.setExtended(!this.canPacket.getExtended());
            updateInputFields();
        }

        private void cbRtr_MouseClick(object sender, MouseEventArgs e)
        {
            this.canPacket.setRtr(!this.canPacket.getRtr());
            updateInputFields();
        }

        private void tbByte0_Leave(object sender, EventArgs e)
        {
            updateByte(0, this.tbByte0.Text);
        }

        private void tbByte1_Leave(object sender, EventArgs e)
        {
            updateByte(1, this.tbByte1.Text);
        }

        private void tbByte2_Leave(object sender, EventArgs e)
        {
            updateByte(2, this.tbByte2.Text);
        }

        private void tbByte3_Leave(object sender, EventArgs e)
        {
            updateByte(3, this.tbByte3.Text);
        }

        private void tbByte4_Leave(object sender, EventArgs e)
        {
            updateByte(4, this.tbByte4.Text);
        }

        private void tbByte5_Leave(object sender, EventArgs e)
        {
            updateByte(5, this.tbByte5.Text);
        }

        private void tbByte6_Leave(object sender, EventArgs e)
        {
            updateByte(6, this.tbByte6.Text);
        }

        private void tbByte7_Leave(object sender, EventArgs e)
        {
            updateByte(7, this.tbByte7.Text);
        }

        private void tbInt0_Leave(object sender, EventArgs e)
        {
            this.updateInt(0, this.tbInt0.Text);
        }

        private void tbInt1_Leave(object sender, EventArgs e)
        {
            this.updateInt(1, this.tbInt1.Text);
        }

        private void tbInt2_Leave(object sender, EventArgs e)
        {
            this.updateInt(2, this.tbInt2.Text);
        }

        private void tbInt3_Leave(object sender, EventArgs e)
        {
            this.updateInt(3, this.tbInt3.Text);
        }

        private void tbFloat0_Leave(object sender, EventArgs e)
        {
            this.updateFloat(0, this.tbFloat0.Text);
        }

        private void tbFloat1_Leave(object sender, EventArgs e)
        {
            this.updateFloat(1, this.tbFloat1.Text);
        }

        private void timerTick(object sender, EventArgs e)
        {
            bool sent = udpSender.SendMessage(this.canPacket);
        }

        private Boolean isHexString(String text)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(text, @"\A\b[0-9a-fA-F]+\b\Z");
        }

        private bool updateByte(int index, string byteString)
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

            if (!isHexString(byteString))
            {
                MessageBox.Show("Byte" + index.ToString() + " is not hex");
                return false;
            }

            this.canPacket.setByteString(index, byteString);
            updateInputFields();

            return true;
        }

        private bool updateInt(int index, string intString)
        {
            int intVal;

            if (intString.Length == 0)
            {
                intString = "0";
            }

            if (!int.TryParse(intString, out intVal))
            {
                MessageBox.Show("Int" + index.ToString() + " is not an Integer");
                return false;
            }

            this.canPacket.setInt16(index, intVal);
            updateInputFields();
            return true;
        }

        private bool updateFloat(int index, string floatString)
        {
            float floatVal;

            if (floatString.Length == 0)
            {
                floatString = "0.00";
            }

            if (!float.TryParse(floatString, out floatVal))
            {
                MessageBox.Show("Float" + index.ToString() + " is not a Float");
                return false;
            }

            this.canPacket.setFloat(index, floatVal);
            updateInputFields();
            return true;
        }

        private void tbRawData_Leave(object sender, EventArgs e)
        {
            double dataLength = this.tbRawData.Text.Length / 2; ;
            if ((dataLength - 16) % 14 != 0)
            {
                MessageBox.Show("Raw Bytes must have a length of 30");
                return;
            }

            if (!isHexString(this.tbRawData.Text))
            {
                MessageBox.Show("Raw Bytes is not hex");
                return;
            }

            this.canPacket.setRawBytesString(this.tbRawData.Text);
            updateInputFields();
        }

        private void updateInputFields()
        {

            this.tbId.Text = this.canPacket.getCanId();
            this.tbIdBase10.Text = this.canPacket.getCanIdBase10().ToString();
            this.cbExtended.Checked = this.canPacket.getExtended();
            this.cbRtr.Checked = this.canPacket.getRtr();

            this.tbByte0.Text = this.canPacket.getByteString(0);
            this.tbByte1.Text = this.canPacket.getByteString(1);
            this.tbByte2.Text = this.canPacket.getByteString(2);
            this.tbByte3.Text = this.canPacket.getByteString(3);
            this.tbByte4.Text = this.canPacket.getByteString(4);
            this.tbByte5.Text = this.canPacket.getByteString(5);
            this.tbByte6.Text = this.canPacket.getByteString(6);
            this.tbByte7.Text = this.canPacket.getByteString(7);

            this.tbInt0.Text = this.canPacket.getInt16(0).ToString();
            this.tbInt1.Text = this.canPacket.getInt16(1).ToString();
            this.tbInt2.Text = this.canPacket.getInt16(2).ToString();
            this.tbInt3.Text = this.canPacket.getInt16(3).ToString();

            this.tbFloat0.Text = this.canPacket.getFloat(0).ToString();
            this.tbFloat1.Text = this.canPacket.getFloat(1).ToString();

            this.tbRawData.Text = this.canPacket.getRawBytesString();

        }

        
    }
}
