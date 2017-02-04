using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrowWareDiagnosticTool.Forms
{
    public partial class MotorControllerSimulatorForm : Form
    {
        private UdpSender udpSender;

        public MotorControllerSimulatorForm(UdpSender udpSender)
        {
            InitializeComponent();

            this.udpSender = udpSender;
        }

        private void MotorControllerSimulatorForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSendVelocity_Click(object sender, EventArgs e)
        {
            CanPacket cp = new CanPacket();
            cp.float0 = (float)(0.98);

            udpSender.SendMessage(cp);
        }
    }
}
