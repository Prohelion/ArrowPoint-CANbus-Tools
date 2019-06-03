using ArrowPointCANBusTool.Charger;
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
    public partial class ChargerControlForm : Form
    {

        private CanService canService;
        private BatteryChargeService chargeService;


        public ChargerControlForm(CanService canService)
        {
            InitializeComponent();
            this.canService = canService;

            this.chargeService = new BatteryChargeService(canService);

        }

        private void StartCharge_Click(object sender, EventArgs e)
        {
            if (chargeService.IsCharging())
            {
                chargeService.StopCharge();
                startCharge.Text = "Start Charge";
                chargeBar.Visible = false;
            }
            else
            {
                chargeService.RequestedCurrent = float.Parse(RequestedChargeCurrent.Value.ToString());
                chargeService.RequestedVoltage = float.Parse(RequestedChargeVoltage.Value.ToString());
                chargeService.SupplyCurrentLimit = float.Parse(maxSocketCurrent.SelectedItem.ToString());
                chargeService.ChargeToPercentage = float.Parse(chargeToPercentage.Value.ToString());
                chargeService.StartCharge();
                startCharge.Text = "Stop Charge";
                chargeBar.Visible = true;
            }
        }

        private void ChargerControlForm_Load(object sender, EventArgs e)
        {
            // Move this logic to the receiver
            Timer timer = new Timer
            {
                Interval = (100)
            };
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();
        }

        
        private void TimerTick(object sender, EventArgs e)
        {       
            BatterySOC.Value = (int)(chargeService.Battery.GetBMU(0).SOCPercentage * 100);
            BatteryPackMaTxt.Text = chargeService.Battery.GetBMU(0).BatteryCurrent.ToString();
            BatteryPackMvTxt.Text = chargeService.Battery.GetBMU(0).BatteryVoltage.ToString();
            BatteryCellMinMvTxt.Text = chargeService.Battery.GetBMU(0).MinCellVoltage.ToString();
            BatteryCellMaxMvTxt.Text = chargeService.Battery.GetBMU(0).MaxCellVoltage.ToString();
            BatteryMinCTxt.Text = chargeService.Battery.GetBMU(0).MinCellTemp.ToString();
            BatteryMaxCTxt.Text = chargeService.Battery.GetBMU(0).MaxCellTemp.ToString();
            BatteryBalancePositiveTxt.Text = chargeService.Battery.GetBMU(0).BalanceVoltageThresholdRising.ToString();
            BatteryBalanceNegativeTxt.Text = chargeService.Battery.GetBMU(0).BalanceVoltageThresholdFalling.ToString();

            ActualVoltageTxt.Text = chargeService.ChargerVoltage.ToString();
            ActualCurrentTxt.Text = chargeService.ChargerCurrent.ToString();

            if (!chargeService.IsCommsOk) Comms_Ok.ForeColor = Color.Red; else Comms_Ok.ForeColor = Color.Green;
            if (!chargeService.IsACOk) AC_Ok.ForeColor = Color.Red; else AC_Ok.ForeColor = Color.Green;
            if (!chargeService.IsDCOk) DC_Ok.ForeColor = Color.Red; else DC_Ok.ForeColor = Color.Green;
            if (!chargeService.IsTempOk) Temp_Ok.ForeColor = Color.Red; else Temp_Ok.ForeColor = Color.Green;
            if (!chargeService.IsHardwareOk) HW_Ok.ForeColor = Color.Red; else HW_Ok.ForeColor = Color.Green;
        }

        private void StartDischarge_Click(object sender, EventArgs e)
        {

        }

        private void RequestedChargeCurrent_ValueChanged(object sender, EventArgs e)
        {
            chargeService.RequestedCurrent = float.Parse(RequestedChargeCurrent.Value.ToString());
        }
    }
}
