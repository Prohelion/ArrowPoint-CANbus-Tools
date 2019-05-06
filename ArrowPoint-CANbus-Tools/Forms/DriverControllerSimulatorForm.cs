using ArrowPointCANBusTool.CanBus;
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
    public partial class DriverControllerSimulatorForm : Form
    {
        private UdpService udpService;

        private CanPacket cpSwitches = new CanPacket(769); // 0x301
        private CanPacket cpThrottle = new CanPacket(770); // 0x302

        bool isCruiseActive = false;
        int cruiseMode = 0;

        bool isLeftOn = false;
        bool isRightOn = false;

        public DriverControllerSimulatorForm(UdpService udpService)
        {
            this.udpService = udpService;

            InitializeComponent();
        }

        private void btnNeutral_Click(object sender, EventArgs e)
        {
            updateDriveMode(1);
        }

        private void btnDrive_Click(object sender, EventArgs e)
        {
            updateDriveMode(2);
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            updateDriveMode(3);
        }

        private void btnSpeedCruise_Click(object sender, EventArgs e)
        {
            updateCruiseMode(1);
        }

        private void btnSetpointCruise_Click(object sender, EventArgs e)
        {
            updateCruiseMode(2);
        }

        private void btnSolarCruise_Click(object sender, EventArgs e)
        {
            updateCruiseMode(3);
        }

        private void btnCruiseActivate_Click(object sender, EventArgs e)
        {
            updateCruiseActive(true);
        }

        private void btnCruiseDeactivate_Click(object sender, EventArgs e)
        {
            updateCruiseActive(false);
        }

        private void btnLeftIndicator_Click(object sender, EventArgs e)
        {
            updateIndicators(!this.isLeftOn, this.isRightOn);
        }

        private void btnRightIndicator_Click(object sender, EventArgs e)
        {
            updateIndicators(this.isLeftOn, !this.isRightOn);
        }

        private void btnCruiseIncrease_Click(object sender, EventArgs e)
        {
            this.cpSwitches.setInt16(1, 1);
            sendSwitches();
            this.cpSwitches.setInt16(2, 0);
        }

        private void btnCruiseDecrease_Click(object sender, EventArgs e)
        {
            this.cpSwitches.setInt16(1, -1);
            sendSwitches();
            this.cpSwitches.setInt16(1, 0);
        }

        private void updateDriveMode(int driveMode)
        {
            this.btnNeutral.UseVisualStyleBackColor = true;
            this.btnDrive.UseVisualStyleBackColor = true;
            this.btnReverse.UseVisualStyleBackColor = true;

            switch (driveMode)
            {
                case 1:
                    this.btnNeutral.UseVisualStyleBackColor = false;
                    break;
                case 2:
                    this.btnDrive.UseVisualStyleBackColor = false;
                    break;
                case 3:
                    this.btnReverse.UseVisualStyleBackColor = false;
                    break;
            }

            this.cpSwitches.setInt8(0, driveMode);
            sendSwitches();
        }

        private void updateCruiseMode(int cruiseMode)
        {
            this.cruiseMode = cruiseMode;
            this.btnSpeedCruise.UseVisualStyleBackColor = true;
            this.btnSetpointCruise.UseVisualStyleBackColor = true;
            this.btnSolarCruise.UseVisualStyleBackColor = true;

            switch (cruiseMode)
            {
                case 1:
                    this.btnSpeedCruise.UseVisualStyleBackColor = false;
                    break;
                case 2:
                    this.btnSetpointCruise.UseVisualStyleBackColor = false;
                    break;
                case 3:
                    this.btnSolarCruise.UseVisualStyleBackColor = false;
                    break;
            }
            

            if (this.isCruiseActive)
            {
                this.cpSwitches.setInt8(1, this.cruiseMode);
            }
            else
            {
                this.cpSwitches.setInt8(1, 0);
            }

            sendSwitches();
        }

        private void updateCruiseActive(bool isCruiseActive) {
            this.isCruiseActive = isCruiseActive;

            this.btnCruiseActivate.UseVisualStyleBackColor = !isCruiseActive;
            this.btnCruiseDeactivate.UseVisualStyleBackColor = isCruiseActive;

            updateCruiseMode(this.cruiseMode);
        }

        private void updateIndicators(bool isLeftOn, bool isRightOn) {
            this.isLeftOn = isLeftOn;
            this.isRightOn = isRightOn;

            this.btnLeftIndicator.UseVisualStyleBackColor = !isLeftOn;
            this.btnRightIndicator.UseVisualStyleBackColor = !isRightOn;
            
            this.cpSwitches.setInt8(4, Convert.ToInt32(isLeftOn));
            this.cpSwitches.setInt8(5, Convert.ToInt32(isRightOn));
            sendSwitches();
        }

        private void sendThrottle()
        {
            this.udpService.SendMessage(this.cpThrottle);
        }

        private void sendSwitches()
        {
            this.udpService.SendMessage(this.cpSwitches);
        }

        private void trackBarRegen_MouseUp(object sender, MouseEventArgs e)
        {
            float newRegen = ((float)this.trackBarRegen.Value) / 100;
            this.cpThrottle.setFloat(1, newRegen);
            this.sendThrottle();
        }

        private void trackBarThrottle_MouseUp(object sender, MouseEventArgs e)
        {
            float newThrottle = ((float)this.trackBarThrottle.Value) / 100;
            this.cpThrottle.setFloat(0, newThrottle);
            this.sendThrottle();
        }
    }
}
