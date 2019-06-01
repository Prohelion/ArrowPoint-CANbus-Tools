using ArrowPointCANBusTool.CanBus;
using ArrowPointCANBusTool.Services;
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
    public partial class MotorControllerSimulatorForm : Form
    {
        private CanService udpService;
        private Timer timer;
        private int loopRate = 100;
        private Boolean looping;
        
        private CanPacket cpLimits = new CanPacket(0x401); // 0x401
        private CanPacket cpBus = new CanPacket(0x402); // 0x402
        private CanPacket cpVelocity = new CanPacket(0x403); // 0x403
        private CanPacket cpIVector = new CanPacket(0x406); // 0x406
        private CanPacket cpTemp1 = new CanPacket(0x40B); // 0x40B

        public MotorControllerSimulatorForm(CanService udpService)
        {
            InitializeComponent();

            this.udpService = udpService;
            this.looping = false;

            this.tbNeutral.Text = "1";
            this.tbBatteryCurrent.Text = "1.00";
            this.tbBatteryVoltage.Text = "1.00";
            this.tbMotorVelocity.Text = "1.00";
            this.tbRegen.Text = "1.00";
            this.tbMotorTemp.Text = "1.00";
            this.tbControllerTemp.Text = "1.00";

            this.TbNeutral_Leave(null, null);
            this.TbBatteryCurrent_Leave(null, null);
            this.TbBatteryVoltage_Leave(null, null);
            this.TbMotorVelocity_Leave(null, null);
            this.TbRegen_Leave(null, null);
            this.TbMotorTemp_Leave(null, null);
            this.TbControllerTemp_Leave(null, null);

        }

        private void MotorControllerSimulatorForm_Load(object sender, EventArgs e)
        {

        }

        private void BtnStartStopSim_Click(object sender, EventArgs e)
        {           
            if (looping)
            {
                this.timer.Stop();
                this.timer = null;

                this.looping = false;
                this.btnStartStopSim.Text = "Start";
            }
            else if (!looping) {
                this.timer = new Timer
                {
                    Interval = (this.loopRate)
                };
                this.timer.Tick += new EventHandler(TimerTick);
                this.timer.Start();

                this.looping = true;
                this.btnStartStopSim.Text = "Stop";
            }
            
        }

        private void TimerTick(object sender, EventArgs e)
        {
            udpService.SendMessage(this.cpLimits);
            udpService.SendMessage(this.cpBus);
            udpService.SendMessage(this.cpVelocity);
            udpService.SendMessage(this.cpIVector);
            udpService.SendMessage(this.cpTemp1);
        }

        private void TbNeutral_Leave(object sender, EventArgs e)
        {
            if (!int.TryParse(this.tbNeutral.Text, out int intVal))
            {
                MessageBox.Show("Neutral is not an int");
                this.tbNeutral.Text = this.cpLimits.GetInt8(0).ToString();
            }
            else
            {
                this.cpLimits.SetInt8(0, intVal);
            }
        }

        private void TbMotorVelocity_Leave(object sender, EventArgs e)
        {
            if (!float.TryParse(this.tbMotorVelocity.Text, out float floatVal))
            {
                MessageBox.Show("MotorVelocity is not a Float");
                this.tbMotorVelocity.Text = this.cpVelocity.GetFloat(0).ToString();
            }
            else
            {
                this.cpVelocity.SetFloat(0, floatVal);
            }
        }

        private void TbRegen_Leave(object sender, EventArgs e)
        {
            if (!float.TryParse(this.tbRegen.Text, out float floatVal))
            {
                MessageBox.Show("Regen is not a Float");
                this.tbRegen.Text = this.cpIVector.GetFloat(0).ToString();
            }
            else
            {
                this.cpIVector.SetFloat(0, floatVal);
            }
        }

        private void TbBatteryVoltage_Leave(object sender, EventArgs e)
        {
            if (!float.TryParse(this.tbBatteryVoltage.Text, out float floatVal))
            {
                MessageBox.Show("Battery Voltage is not a Float");
                this.tbBatteryVoltage.Text = this.cpBus.GetFloat(0).ToString();
            }
            else
            {
                this.cpBus.SetFloat(0, floatVal);
            }
        }

        private void TbBatteryCurrent_Leave(object sender, EventArgs e)
        {
            if (!float.TryParse(this.tbBatteryCurrent.Text, out float floatVal))
            {
                MessageBox.Show("Battery Current is not a Float");
                this.tbBatteryCurrent.Text = this.cpBus.GetFloat(1).ToString();
            }
            else
            {
                this.cpBus.SetFloat(1, floatVal);
            }
        }

        private void TbControllerTemp_Leave(object sender, EventArgs e)
        {
            if (!float.TryParse(this.tbControllerTemp.Text, out float floatVal))
            {
                MessageBox.Show("Controller Temp is not a Float");
                this.tbControllerTemp.Text = this.cpTemp1.GetFloat(1).ToString();
            }
            else
            {
                this.cpTemp1.SetFloat(1, floatVal);
            }
        }

        private void TbMotorTemp_Leave(object sender, EventArgs e)
        {
            if (!float.TryParse(this.tbMotorTemp.Text, out float floatVal))
            {
                MessageBox.Show("Motor Temp is not a Float");
                this.tbMotorTemp.Text = this.cpTemp1.GetFloat(0).ToString();
            }
            else
            {
                this.cpTemp1.SetFloat(0, floatVal);
            }
        }
    }
}
