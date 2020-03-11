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
    public partial class DriverControllerSimulatorForm : Form
    {        
        private CanPacket cpSwitches = new CanPacket(0x301); // 0x301
        private CanPacket cpThrottle = new CanPacket(0x302); // 0x302

        bool isCruiseActive = false;
        int cruiseMode = 0;

        bool isLeftOn = false;
        bool isRightOn = false;

        public DriverControllerSimulatorForm()
        {
            InitializeComponent();
        }

        private void BtnNeutral_Click(object sender, EventArgs e)
        {
            UpdateDriveMode(1);
        }

        private void BtnDrive_Click(object sender, EventArgs e)
        {
            UpdateDriveMode(2);
        }

        private void BtnReverse_Click(object sender, EventArgs e)
        {
            UpdateDriveMode(3);
        }

        private void BtnSpeedCruise_Click(object sender, EventArgs e)
        {
            UpdateCruiseMode(1);
        }

        private void BtnSetpointCruise_Click(object sender, EventArgs e)
        {
            UpdateCruiseMode(2);
        }

        private void BtnSolarCruise_Click(object sender, EventArgs e)
        {
            UpdateCruiseMode(3);
        }

        private void BtnCruiseActivate_Click(object sender, EventArgs e)
        {
            UpdateCruiseActive(true);
        }

        private void BtnCruiseDeactivate_Click(object sender, EventArgs e)
        {
            UpdateCruiseActive(false);
        }

        private void BtnLeftIndicator_Click(object sender, EventArgs e)
        {
            UpdateIndicators(!this.isLeftOn, this.isRightOn);
        }

        private void BtnRightIndicator_Click(object sender, EventArgs e)
        {
            UpdateIndicators(this.isLeftOn, !this.isRightOn);
        }

        private void BtnCruiseIncrease_Click(object sender, EventArgs e)
        {
            this.cpSwitches.Short16Pos1 = 1;
            SendSwitches();
            this.cpSwitches.Short16Pos2 = 0;
        }

        private void BtnCruiseDecrease_Click(object sender, EventArgs e)
        {
            this.cpSwitches.Short16Pos1 = -1;
            SendSwitches();
            this.cpSwitches.Short16Pos1 = 0;
        }

        private void UpdateDriveMode(int driveMode)
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

            this.cpSwitches.Int8Pos0 = driveMode;
            SendSwitches();
        }

        private void UpdateCruiseMode(int cruiseMode)
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
                this.cpSwitches.Int8Pos1 = this.cruiseMode;
            }
            else
            {
                this.cpSwitches.Int8Pos1 = 0;
            }

            SendSwitches();
        }

        private void UpdateCruiseActive(bool isCruiseActive) {
            this.isCruiseActive = isCruiseActive;

            this.btnCruiseActivate.UseVisualStyleBackColor = !isCruiseActive;
            this.btnCruiseDeactivate.UseVisualStyleBackColor = isCruiseActive;

            UpdateCruiseMode(this.cruiseMode);
        }

        private void UpdateIndicators(bool isLeftOn, bool isRightOn) {
            this.isLeftOn = isLeftOn;
            this.isRightOn = isRightOn;

            this.btnLeftIndicator.UseVisualStyleBackColor = !isLeftOn;
            this.btnRightIndicator.UseVisualStyleBackColor = !isRightOn;
            
            this.cpSwitches.Int8Pos4 = Convert.ToInt32(isLeftOn);
            this.cpSwitches.Int8Pos5 = Convert.ToInt32(isRightOn);
            SendSwitches();
        }

        private void SendThrottle()
        {
            CanService.Instance.SendMessage(this.cpThrottle);
        }

        private void SendSwitches()
        {
            CanService.Instance.SendMessage(this.cpSwitches);
        }

        private void TrackBarRegen_MouseUp(object sender, MouseEventArgs e)
        {
            float newRegen = ((float)this.trackBarRegen.Value) / 100;
            this.cpThrottle.FloatPos1 = newRegen;
            this.SendThrottle();
        }

        private void TrackBarThrottle_MouseUp(object sender, MouseEventArgs e)
        {
            float newThrottle = ((float)this.trackBarThrottle.Value) / 100;
            this.cpThrottle.FloatPos0 = newThrottle;
            this.SendThrottle();
        }
    }
}
