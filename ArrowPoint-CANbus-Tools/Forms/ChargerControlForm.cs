using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Charger;
using ArrowPointCANBusTool.Model;
using ArrowPointCANBusTool.Services;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ArrowPointCANBusTool.Forms
{
    public partial class ChargerControlForm : Form
    {

        private CanService canService;
        private BatteryChargeService chargeService;
        private BatteryDischargeService dischargeService;
        private BatteryMonitoringService monitoringService;

        private Timer timer;

        public ChargerControlForm(CanService canService)
        {
            InitializeComponent();
            this.canService = canService;

            chargeService = new BatteryChargeService(canService);
            dischargeService = new BatteryDischargeService(canService);
            monitoringService = new BatteryMonitoringService(chargeService, dischargeService, 5000);
            monitoringService.BatteryMonitorUpdateEventHandler += new BatteryMonitorUpdateEventHandler(MonitoringDataReceived);

            RequestedChargeCurrent.Maximum = decimal.Parse(maxSocketCurrent.SelectedItem.ToString());
        }

        private void StartCharge_Click(object sender, EventArgs e)
        {
            if (chargeService.IsCharging)
                chargeService.StopCharge();
            else
            {
                if ((chargeService.BatteryState == CanReceivingComponent.STATE_WARNING || chargeService.BatteryState == CanReceivingComponent.STATE_ON || chargeService.BatteryState == CanReceivingComponent.STATE_IDLE) &&
                    (chargeService.ChargerState == CanReceivingComponent.STATE_WARNING || chargeService.ChargerState == CanReceivingComponent.STATE_ON || chargeService.ChargerState == CanReceivingComponent.STATE_IDLE))
                { 
                    chargeService.RequestedCurrent = float.Parse(RequestedChargeCurrent.Value.ToString());
                    chargeService.RequestedVoltage = float.Parse(RequestedChargeVoltage.Value.ToString());
                    chargeService.SupplyCurrentLimit = float.Parse(maxSocketCurrent.SelectedItem.ToString());
                    chargeService.ChargeToPercentage = float.Parse(chargeToPercentage.Value.ToString());
                    chargeService.StartCharge();
                }
                else
                    MessageBox.Show("Charger of battery is currently in an invalid state to start charging",
                     "Check Battery and Charger",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);

            }
                
            UpdateStartStopButton();
        }

        private void ChargerControlForm_Load(object sender, EventArgs e)
        {
            ChargeChart.DataSource = monitoringService.ChargeDataSet;
            ChargeChart.DataBind();
            
            timer = new Timer
            {
                Interval = (100)
            };
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();
        }

        private void ChargerControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            chargeService.ShutdownCharge();
        }

        private void UpdateStartStopButton()
        {
            if (chargeService.IsCharging)
            {                
                startCharge.Text = "Stop Charge";
                maxSocketCurrent.Enabled = false;
            }
            else
            {            
                startCharge.Text = "Start Charge";
                maxSocketCurrent.Enabled = true;
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {

            Battery battery = chargeService.BatteryService.BatteryData;

            SOCText.Text = (battery.SOCPercentage * 100).ToString() + "%";
            BatteryPackMaTxt.Text = battery.BatteryCurrent.ToString();
            BatteryPackMvTxt.Text = battery.BatteryVoltage.ToString();
            BatteryCellMinMvTxt.Text = battery.MinCellVoltage.ToString();
            BatteryCellMaxMvTxt.Text = battery.MaxCellVoltage.ToString();
            BatteryMinCTxt.Text = (battery.MinCellTemp / 10).ToString();
            BatteryMaxCTxt.Text = (battery.MaxCellTemp / 10).ToString();
            BatteryBalancePositiveTxt.Text = battery.BalanceVoltageThresholdRising.ToString();
            BatteryBalanceNegativeTxt.Text = battery.BalanceVoltageThresholdFalling.ToString();

            ActualVoltageTxt.Text = String.Format(string.Format("{0:0.00}", chargeService.ChargerVoltage));
            ActualCurrentTxt.Text = String.Format(string.Format("{0:0.00}", chargeService.ChargerCurrent)); 

            if (!chargeService.IsCommsOk) Comms_Ok.ForeColor = Color.Red; else Comms_Ok.ForeColor = Color.Green;
            if (!chargeService.IsACOk) AC_Ok.ForeColor = Color.Red; else AC_Ok.ForeColor = Color.Green;
            if (!chargeService.IsDCOk) DC_Ok.ForeColor = Color.Red; else DC_Ok.ForeColor = Color.Green;
            if (!chargeService.IsTempOk) Temp_Ok.ForeColor = Color.Red; else Temp_Ok.ForeColor = Color.Green;
            if (!chargeService.IsHardwareOk) HW_Ok.ForeColor = Color.Red; else HW_Ok.ForeColor = Color.Green;

            batteryStatusLabel.Text = "Battery - " + CanReceivingComponent.GetStatusText(chargeService.BatteryState);
            batteryStatusLabel.ToolTipText = chargeService.BatteryStateMessage;
            batteryStatusLabel.BackColor = CanReceivingComponent.GetStatusColour(chargeService.BatteryState);
            chargerStatusLabel.Text = "Charger - " + CanReceivingComponent.GetStatusText(chargeService.ChargerState);
            chargerStatusLabel.ToolTipText = chargeService.ChargerStateMessage;
            chargerStatusLabel.BackColor = CanReceivingComponent.GetStatusColour(chargeService.ChargerState);
            dischargerStripStatusLabel.Text = "Discharger - " + CanReceivingComponent.STATE_NA_TEXT;
            dischargerStripStatusLabel.BackColor = CanReceivingComponent.GetStatusColour(CanReceivingComponent.STATE_NA);
            chargerStatusLabel.ToolTipText = CanReceivingComponent.STATE_NA_TEXT;

            UpdateStartStopButton();
        }

        private void MonitoringDataReceived(ChargeDataReceivedEventArgs e)
        {

            ChargeData chargeData = e.Message;

            if (ChargeChart.InvokeRequired)
            {
                ChargeChart.Invoke(new Action(() =>
                {
                    ChargeChart.DataSource = monitoringService.ChargeDataSet;
                    ChargeChart.DataBind();
                }
                ));
            }
        }

        private void StartDischarge_Click(object sender, EventArgs e)
        {
            if (dischargeService.IsDischarging) { 
                dischargeService.StopDischarge();
                startDischarge.Text = "Start Discharge";                
            }
            else
            {

                DialogResult result = MessageBox.Show("Please disconnect all load from the battery and press ok when ready",
                     "Disconnect Load",
                     MessageBoxButtons.OKCancel,
                     MessageBoxIcon.Hand);

                if (result == DialogResult.OK)
                {
                    dischargeService.StartDischarge();
                }
                else
                {
                    return;
                }
   
                result = MessageBox.Show("Please connect the discharge unit and press ok when ready",
                     "Connect the Discharger",
                     MessageBoxButtons.OKCancel,
                     MessageBoxIcon.Hand);

                if (result == DialogResult.OK)
                {
                    startDischarge.Text = "Stop Discharge";                   
                } else
                {
                    dischargeService.StopDischarge();
                }

            }
        }

        private void RequestedChargeCurrent_ValueChanged(object sender, EventArgs e)
        {
            chargeService.RequestedCurrent = float.Parse(RequestedChargeCurrent.Value.ToString());
        }

        private void MaxSocketCurrent_SelectedIndexChanged(object sender, EventArgs e)
        {
            RequestedChargeCurrent.Maximum = decimal.Parse(maxSocketCurrent.SelectedItem.ToString());
        }

        private void ChargeToPercentage_ValueChanged(object sender, EventArgs e)
        {
            chargeService.ChargeToPercentage = float.Parse(chargeToPercentage.Value.ToString());
        }

        private void RequestedChargeVoltage_ValueChanged(object sender, EventArgs e)
        {
            chargeService.RequestedVoltage = float.Parse(RequestedChargeVoltage.Value.ToString());
        }

        private void ClearData_Click(object sender, EventArgs e)
        {
            monitoringService.ClearChargeData();            
        }

        private void SaveData_Click(object sender, EventArgs e)
        {
            Stream ioStream;
            StreamWriter ioWriterStream;

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                RestoreDirectory = true,
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 2,
                FileName = "BatteryLog-" + DateTime.Now.ToString("yyyyMMdd-HHmm") + ".txt"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((ioStream = saveFileDialog.OpenFile()) != null)
                {
                    ioWriterStream = new StreamWriter(ioStream);
                    monitoringService.SaveChargeData(ioWriterStream);                    
                }
            }            
        }


    }
}
