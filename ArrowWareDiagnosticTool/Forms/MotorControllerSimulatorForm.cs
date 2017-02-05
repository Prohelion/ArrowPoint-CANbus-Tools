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
        private Timer timer;
        private int loopRate = 100;
        private Boolean looping;
        
        private CanPacket cpLimits = new CanPacket(1025); // 0x401
        private CanPacket cpBus = new CanPacket(1026); // 0x402
        private CanPacket cpVelocity = new CanPacket(1027); // 0x403
        private CanPacket cpIVector = new CanPacket(1030); // 0x406
        private CanPacket cpTemp1 = new CanPacket(1035); // 0x40B

        public MotorControllerSimulatorForm(UdpSender udpSender)
        {
            InitializeComponent();

            this.udpSender = udpSender;
            this.looping = false;

            this.tbNeutral.Text = "1";
            this.tbBatteryCurrent.Text = "1.00";
            this.tbBatteryVoltage.Text = "1.00";
            this.tbMotorVelocity.Text = "1.00";
            this.tbRegen.Text = "1.00";
            this.tbMotorTemp.Text = "1.00";
            this.tbControllerTemp.Text = "1.00";

            this.tbNeutral_Leave(null, null);
            this.tbBatteryCurrent_Leave(null, null);
            this.tbBatteryVoltage_Leave(null, null);
            this.tbMotorVelocity_Leave(null, null);
            this.tbRegen_Leave(null, null);
            this.tbMotorTemp_Leave(null, null);
            this.tbControllerTemp_Leave(null, null);

        }

        private void MotorControllerSimulatorForm_Load(object sender, EventArgs e)
        {

        }

        private void btnStartStopSim_Click(object sender, EventArgs e)
        {
            

            if (looping)
            {
                this.timer.Stop();
                this.timer = null;

                this.looping = false;
                this.btnStartStopSim.Text = "Start";
            }
            else if (!looping) {
                this.timer = new Timer();
                this.timer.Interval = (this.loopRate);
                this.timer.Tick += new EventHandler(timerTick);
                this.timer.Start();

                this.looping = true;
                this.btnStartStopSim.Text = "Stop";
            }
            
        }

        private void timerTick(object sender, EventArgs e)
        {
            udpSender.SendMessage(this.cpLimits);
            udpSender.SendMessage(this.cpBus);
            udpSender.SendMessage(this.cpVelocity);
            udpSender.SendMessage(this.cpIVector);
            udpSender.SendMessage(this.cpTemp1);
        }

        private void tbNeutral_Leave(object sender, EventArgs e)
        {
            int intVal;

            if (!int.TryParse(this.tbNeutral.Text, out intVal))
            {
                MessageBox.Show("Neutral is not an int");
                this.tbNeutral.Text = this.cpLimits.getInt8(0).ToString();
            }
            else
            {
                this.cpLimits.setInt8(0, intVal);
            }
        }

        private void tbMotorVelocity_Leave(object sender, EventArgs e)
        {
            float floatVal;

            if (!float.TryParse(this.tbMotorVelocity.Text, out floatVal))
            {
                MessageBox.Show("MotorVelocity is not a Float");
                this.tbMotorVelocity.Text = this.cpVelocity.getFloat(0).ToString();
            }
            else
            {
                this.cpVelocity.setFloat(0, floatVal);
            }
        }

        private void tbRegen_Leave(object sender, EventArgs e)
        {
            float floatVal;

            if (!float.TryParse(this.tbRegen.Text, out floatVal))
            {
                MessageBox.Show("Regen is not a Float");
                this.tbRegen.Text = this.cpIVector.getFloat(0).ToString();
            }
            else
            {
                this.cpIVector.setFloat(0, floatVal);
            }
        }

        private void tbBatteryVoltage_Leave(object sender, EventArgs e)
        {
            float floatVal;

            if (!float.TryParse(this.tbBatteryVoltage.Text, out floatVal))
            {
                MessageBox.Show("Battery Voltage is not a Float");
                this.tbBatteryVoltage.Text = this.cpBus.getFloat(0).ToString();
            }
            else
            {
                this.cpBus.setFloat(0, floatVal);
            }
        }

        private void tbBatteryCurrent_Leave(object sender, EventArgs e)
        {
            float floatVal;

            if (!float.TryParse(this.tbBatteryCurrent.Text, out floatVal))
            {
                MessageBox.Show("Battery Current is not a Float");
                this.tbBatteryCurrent.Text = this.cpBus.getFloat(1).ToString();
            }
            else
            {
                this.cpBus.setFloat(1, floatVal);
            }
        }

        private void tbControllerTemp_Leave(object sender, EventArgs e)
        {
            float floatVal;

            if (!float.TryParse(this.tbControllerTemp.Text, out floatVal))
            {
                MessageBox.Show("Controller Temp is not a Float");
                this.tbControllerTemp.Text = this.cpTemp1.getFloat(1).ToString();
            }
            else
            {
                this.cpTemp1.setFloat(1, floatVal);
            }
        }

        private void tbMotorTemp_Leave(object sender, EventArgs e)
        {
            float floatVal;

            if (!float.TryParse(this.tbMotorTemp.Text, out floatVal))
            {
                MessageBox.Show("Motor Temp is not a Float");
                this.tbMotorTemp.Text = this.cpTemp1.getFloat(0).ToString();
            }
            else
            {
                this.cpTemp1.setFloat(0, floatVal);
            }
        }
    }
}
