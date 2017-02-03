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
        private UdpReciever udpReciever;
        private UdpSender udpSender;
        private CanPacket canPacket;
        private Timer timer;
        private Boolean looping;

        private string samplePacket = "005472697469756d006508a8c0007f5d0000012300080000000000000000";

        public SendPacketForm(UdpReciever udpReciever, UdpSender udpSender)
        {
            InitializeComponent();

            this.udpReciever = udpReciever;
            this.udpSender = udpSender;
            this.looping = false;

            this.btnReset.Enabled = !looping;
            this.btnLoop.Enabled = !looping;
            this.btnSend.Enabled = !looping;
            this.btnStop.Enabled = looping;
            this.tbLoopRate.Enabled = !looping;

            this.canPacket = new CanPacket(samplePacket);

            updateInputFields();
        }

        public SendPacketForm(UdpReciever udpReciever, UdpSender udpSender, String samplePacket)
        {
            InitializeComponent();

            this.udpReciever = udpReciever;
            this.udpSender = udpSender;
            this.samplePacket = samplePacket;

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

        private void timerTick(object sender, EventArgs e) {
            bool sent = udpSender.SendMessage(this.canPacket);
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            this.tbRawData.Text = samplePacket;
        }

        private void updateInputFields() {
            this.tbId.Text = this.canPacket.id;
            this.tbIdBase10.Text = this.canPacket.idBase10.ToString();
            this.cbExtended.Checked = this.canPacket.extended;
            this.cbRtr.Checked = this.canPacket.rtr;

            this.tbByte0.Text = this.canPacket.byte0;
            this.tbByte1.Text = this.canPacket.byte1;
            this.tbByte2.Text = this.canPacket.byte2;
            this.tbByte3.Text = this.canPacket.byte3;
            this.tbByte4.Text = this.canPacket.byte4;
            this.tbByte5.Text = this.canPacket.byte5;
            this.tbByte6.Text = this.canPacket.byte6;
            this.tbByte7.Text = this.canPacket.byte7;
            this.tbByte0.Text = this.canPacket.byte0;

            this.tbInt0.Text = this.canPacket.int0.ToString();
            this.tbInt1.Text = this.canPacket.int1.ToString();
            this.tbInt2.Text = this.canPacket.int2.ToString();
            this.tbInt3.Text = this.canPacket.int3.ToString();

            this.tbFloat0.Text = this.canPacket.float0.ToString();
            this.tbFloat1.Text = this.canPacket.float1.ToString();

            this.tbRawData.Text = this.canPacket.rawBytesStr;

        }

        private Boolean isHexString(String text) {
            return System.Text.RegularExpressions.Regex.IsMatch(text, @"\A\b[0-9a-fA-F]+\b\Z");
        }

        private void tbId_Leave(object sender, EventArgs e)
        {
            if (!isHexString(this.tbId.Text))
            {
                MessageBox.Show("ID is not hex");
            }
            else if (this.tbId.Text.Length == 4)
            {
                this.canPacket.id = this.tbId.Text;

                this.canPacket.updateRawBytes();
                updateInputFields();
            }
        }

        private void tbIdBase10_Leave(object sender, EventArgs e)
        {

        }

        private void tbByte0_Leave(object sender, EventArgs e)
        {
            if (!isHexString(this.tbByte0.Text))
            {
                MessageBox.Show("Byte0 is not hex");
            }
            else if (this.tbByte0.Text.Length == 2)
            {
                this.canPacket.byte0 = this.tbByte0.Text;

                this.canPacket.updateRawBytes();
                updateInputFields();
            }
        }

        private void tbByte1_Leave(object sender, EventArgs e)
        {
            if (!isHexString(this.tbByte1.Text))
            {
                MessageBox.Show("Byte1 is not hex");
            }
            else if (this.tbByte1.Text.Length == 2)
            {
                this.canPacket.byte1 = this.tbByte1.Text;

                this.canPacket.updateRawBytes();
                updateInputFields();
            }
        }

        private void tbByte2_Leave(object sender, EventArgs e)
        {
            if (!isHexString(this.tbByte2.Text))
            {
                MessageBox.Show("Byte2 is not hex");
            }
            else if (this.tbByte2.Text.Length == 2)
            {
                this.canPacket.byte2 = this.tbByte2.Text;

                this.canPacket.updateRawBytes();
                updateInputFields();
            }
        }

        private void tbByte3_Leave(object sender, EventArgs e)
        {
            if (!isHexString(this.tbByte3.Text))
            {
                MessageBox.Show("Byte3 is not hex");
            }
            else if (this.tbByte3.Text.Length == 2)
            {
                this.canPacket.byte3 = this.tbByte3.Text;

                this.canPacket.updateRawBytes();
                updateInputFields();
            }
        }

        private void tbByte4_Leave(object sender, EventArgs e)
        {
            if (!isHexString(this.tbByte4.Text))
            {
                MessageBox.Show("Byte4 is not hex");
            }
            else if (this.tbByte4.Text.Length == 2)
            {
                this.canPacket.byte4 = this.tbByte4.Text;

                this.canPacket.updateRawBytes();
                updateInputFields();
            }
        }

        private void tbByte5_Leave(object sender, EventArgs e)
        {
            if (!isHexString(this.tbByte5.Text))
            {
                MessageBox.Show("Byte5 is not hex");
            }
            else if (this.tbByte5.Text.Length == 2)
            {
                this.canPacket.byte5 = this.tbByte5.Text;

                this.canPacket.updateRawBytes();
                updateInputFields();
            }
        }

        private void tbByte6_Leave(object sender, EventArgs e)
        {
            if (!isHexString(this.tbByte6.Text))
            {
                MessageBox.Show("Byte6 is not hex");
            }
            else if (this.tbByte6.Text.Length == 2)
            {
                this.canPacket.byte6 = this.tbByte6.Text;

                this.canPacket.updateRawBytes();
                updateInputFields();
            }
        }

        private void tbByte7_Leave(object sender, EventArgs e)
        {
            if (!isHexString(this.tbByte7.Text))
            {
                MessageBox.Show("Byte7 is not hex");
            }
            else if (this.tbByte7.Text.Length == 2)
            {
                this.canPacket.byte7 = this.tbByte7.Text;

                this.canPacket.updateRawBytes();
                updateInputFields();
            }
        }

        private void tbInt0_Leave(object sender, EventArgs e)
        {
            int int0;

            if (!int.TryParse(this.tbInt0.Text, out int0))
            {
                MessageBox.Show("Int0 is not an Integer");
            }
            else
            {
                this.canPacket.int0 = int0;

                this.canPacket.updateRawBytes();
                updateInputFields();
            }
        }

        private void tbInt1_Leave(object sender, EventArgs e)
        {
            int int1;

            if (!int.TryParse(this.tbInt1.Text, out int1))
            {
                MessageBox.Show("Int1 is not an Integer");
            }
            else
            {
                this.canPacket.int1 = int1;

                this.canPacket.updateRawBytes();
                updateInputFields();
            }
        }

        private void tbInt2_Leave(object sender, EventArgs e)
        {
            int int2;

            if (!int.TryParse(this.tbInt2.Text, out int2))
            {
                MessageBox.Show("Int2 is not an Integer");
            }
            else
            {
                this.canPacket.int2 = int2;

                this.canPacket.updateRawBytes();
                updateInputFields();
            }
        }

        private void tbInt3_Leave(object sender, EventArgs e)
        {
            int int3;

            if (!int.TryParse(this.tbInt3.Text, out int3))
            {
                MessageBox.Show("Int3 is not an Integer");
            }
            else
            {
                this.canPacket.int3 = int3;

                this.canPacket.updateRawBytes();
                updateInputFields();
            }
        }

        private void tbFloat0_Leave(object sender, EventArgs e)
        {
            float float0;

            if (!float.TryParse(this.tbFloat0.Text, out float0))
            {
                MessageBox.Show("Float0 is not a Float");
            }
            else
            {
                this.canPacket.float0 = float0;

                this.canPacket.updateRawBytes();
                updateInputFields();
            }
        }

        private void tbFloat1_Leave(object sender, EventArgs e)
        {
            float float1;

            if (!float.TryParse(this.tbFloat1.Text, out float1))
            {
                MessageBox.Show("Float1 is not a Float");
            }
            else
            {
                this.canPacket.float1 = float1;

                this.canPacket.updateRawBytes();
                updateInputFields();
            }
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

            if (int.TryParse(tbLoopRate.Text, out loopRate))
            {
                timer = new Timer();
                timer.Interval = (loopRate);
                timer.Tick += new EventHandler(timerTick);
                timer.Start();

                looping = true;

                this.btnReset.Enabled = !looping;
                this.btnLoop.Enabled = !looping;
                this.btnSend.Enabled = !looping;
                this.btnStop.Enabled = looping;
                this.tbLoopRate.Enabled = !looping;
            }
            else
            {
                MessageBox.Show("Unable to parse Loop Rate");
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.timer.Stop();
            this.timer = null;

            looping = false;

            this.btnReset.Enabled = !looping;
            this.btnLoop.Enabled = !looping;
            this.btnSend.Enabled = !looping;
            this.btnStop.Enabled = looping;
            this.tbLoopRate.Enabled = !looping;
        }
    }
}
