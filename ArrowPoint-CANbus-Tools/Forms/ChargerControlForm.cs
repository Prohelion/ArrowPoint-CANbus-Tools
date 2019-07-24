using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Services;
using ArrowPointCANBusTool.Model;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ArrowPointCANBusTool.Forms
{
    public partial class ChargerControlForm : Form
    {                                
        private Timer timer;

        private bool preCharge = false;

        public ChargerControlForm()
        {
            InitializeComponent();            
            BatteryMonitoringService.Instance.BatteryMonitorUpdateEventHandler += new BatteryMonitorUpdateEventHandler(MonitoringDataReceived);
            RequestedChargeCurrent.Maximum = decimal.Parse(maxSocketCurrent.SelectedItem.ToString());
        }

        private async void StartCharge_ClickAsync(object sender, EventArgs e)
        {
            startCharge.Enabled = false;

            // This should never happen.  It is a safety just in case
            if (BatteryDischargeService.Instance.IsDischarging)
            {
                BatteryChargeService.Instance.StopCharge();
                preCharge = false;
                return;
            }

            if (BatteryChargeService.Instance.IsCharging)
                BatteryChargeService.Instance.StopCharge();
            else
            {
                startDischarge.Enabled = false;
                preCharge = true;

                if ((BatteryChargeService.Instance.BatteryState == CanReceivingNode.STATE_WARNING || BatteryChargeService.Instance.BatteryState == CanReceivingNode.STATE_ON || BatteryChargeService.Instance.BatteryState == CanReceivingNode.STATE_IDLE) &&
                    (BatteryChargeService.Instance.ChargerState == CanReceivingNode.STATE_WARNING || BatteryChargeService.Instance.ChargerState == CanReceivingNode.STATE_ON || BatteryChargeService.Instance.ChargerState == CanReceivingNode.STATE_IDLE))
                {
                    BatteryChargeService.Instance.RequestedCurrent = float.Parse(RequestedChargeCurrent.Value.ToString());
                    BatteryChargeService.Instance.RequestedVoltage = float.Parse(RequestedChargeVoltage.Value.ToString());
                    BatteryChargeService.Instance.SupplyCurrentLimit = float.Parse(maxSocketCurrent.SelectedItem.ToString());
                    BatteryChargeService.Instance.ChargeToPercentage = float.Parse(chargeToPercentage.Value.ToString());
                    await BatteryChargeService.Instance.StartCharge();
                }
                else
                    MessageBox.Show("Charger of battery is currently in an invalid state to start charging",
                     "Check Battery and Charger",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);

            }
                
            UpdateStartStopDetails();
        }

        private void StartDischarge_Click(object sender, EventArgs e)
        {

            startDischarge.Enabled = false;

            // This should never happen.  It is a safety just in case
            if (BatteryChargeService.Instance.IsCharging)
            {
                BatteryDischargeService.Instance.StopDischarge();
                return;
            }

            if (BatteryDischargeService.Instance.IsDischarging)
            {
                BatteryDischargeService.Instance.StopDischarge();
                startDischarge.Text = "Start Discharge";
            }
            else
            {
                startCharge.Enabled = false;
                BatteryDischargeService.Instance.StartDischarge();
                startDischarge.Text = "Stop Discharge";
            }
        }


        private void ChargerControlForm_Load(object sender, EventArgs e)
        {
            ChargeChart.DataSource = BatteryMonitoringService.Instance.ChargeDataSet;
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
            BatteryChargeService.Instance.ShutdownCharge();
            BatteryChargeService.Instance.BatteryService.ShutdownService();
        }

        private void UpdateStartStopDetails()
        {
            if (BatteryChargeService.Instance.IsCharging || preCharge)
            {
                startDischarge.Enabled = false;
                startCharge.Text = "Stop Charge";
                maxSocketCurrent.Enabled = false;
            }
            else
            {
                ActualVoltageTxt.Text = "";
                ActualCurrentTxt.Text = "";

                startDischarge.Enabled = true;
                startCharge.Text = "Start Charge";
                maxSocketCurrent.Enabled = true;
            }

            if (BatteryDischargeService.Instance.IsDischarging)
            {
                startCharge.Enabled = false;
                startDischarge.Text = "Stop Discharge";
            } else
            {
                startCharge.Enabled = true;
                startDischarge.Text = "Start Discharge";
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {

            Battery battery = BatteryChargeService.Instance.BatteryService.BatteryData;

            SOCText.Text = (battery.SOCPercentage * 100).ToString() + "%";
            BatteryPackMaTxt.Text = battery.BatteryCurrent.ToString();
            BatteryPackMvTxt.Text = battery.BatteryVoltage.ToString();
            BatteryCellMinMvTxt.Text = battery.MinCellVoltage.ToString();
            BatteryCellMaxMvTxt.Text = battery.MaxCellVoltage.ToString();
            BatteryMinCTxt.Text = (battery.MinCellTemp / 10).ToString();
            BatteryMaxCTxt.Text = (battery.MaxCellTemp / 10).ToString();
            BatteryBalancePositiveTxt.Text = battery.BalanceVoltageThresholdRising.ToString();
            BatteryBalanceNegativeTxt.Text = battery.BalanceVoltageThresholdFalling.ToString();

            ActualVoltageTxt.Text = String.Format(string.Format("{0:0.00}", BatteryChargeService.Instance.ChargerActualVoltage));
            ActualCurrentTxt.Text = String.Format(string.Format("{0:0.00}", BatteryChargeService.Instance.ChargerActualCurrent)); 

            if (!BatteryChargeService.Instance.IsCommsOk) Comms_Ok.ForeColor = Color.Red; else Comms_Ok.ForeColor = Color.Green;
            if (!BatteryChargeService.Instance.IsACOk) AC_Ok.ForeColor = Color.Red; else AC_Ok.ForeColor = Color.Green;
            if (!BatteryChargeService.Instance.IsDCOk) DC_Ok.ForeColor = Color.Red; else DC_Ok.ForeColor = Color.Green;
            if (!BatteryChargeService.Instance.IsTempOk) Temp_Ok.ForeColor = Color.Red; else Temp_Ok.ForeColor = Color.Green;
            if (!BatteryChargeService.Instance.IsHardwareOk) HW_Ok.ForeColor = Color.Red; else HW_Ok.ForeColor = Color.Green;

            batteryStatusLabel.Text = "Battery - " + CanReceivingNode.GetStatusText(BatteryChargeService.Instance.BatteryState);
            batteryStatusLabel.ToolTipText = BatteryChargeService.Instance.BatteryStateMessage;
            batteryStatusLabel.BackColor = CanReceivingNode.GetStatusColour(BatteryChargeService.Instance.BatteryState);
            chargerStatusLabel.Text = "Charger - " + CanReceivingNode.GetStatusText(BatteryChargeService.Instance.ChargerState);
            chargerStatusLabel.ToolTipText = BatteryChargeService.Instance.ChargerStateMessage;
            chargerStatusLabel.BackColor = CanReceivingNode.GetStatusColour(BatteryChargeService.Instance.ChargerState);
            dischargerStripStatusLabel.Text = "Discharger - " + CanReceivingNode.GetStatusText(BatteryDischargeService.Instance.DischargerState);
            dischargerStripStatusLabel.BackColor = CanReceivingNode.GetStatusColour(BatteryDischargeService.Instance.DischargerState);
            chargerStatusLabel.ToolTipText = BatteryDischargeService.Instance.DischargerStateMessage;

            if (BatteryChargeService.Instance.IsCharging) preCharge = false;

            UpdateStartStopDetails();
        }

        private void MonitoringDataReceived(ChargeDataReceivedEventArgs e)
        {

            ChargeData chargeData = e.Message;

            if (ChargeChart.InvokeRequired)
            {
                ChargeChart.Invoke(new Action(() =>
                {
                    ChargeChart.DataSource = BatteryMonitoringService.Instance.ChargeDataSet;
                    ChargeChart.DataBind();
                }
                ));
            }
        }


        private void RequestedChargeCurrent_ValueChanged(object sender, EventArgs e)
        {
            BatteryChargeService.Instance.RequestedCurrent = float.Parse(RequestedChargeCurrent.Value.ToString());
        }

        private void MaxSocketCurrent_SelectedIndexChanged(object sender, EventArgs e)
        {
            RequestedChargeCurrent.Maximum = decimal.Parse(maxSocketCurrent.SelectedItem.ToString());
        }

        private void ChargeToPercentage_ValueChanged(object sender, EventArgs e)
        {
            BatteryChargeService.Instance.ChargeToPercentage = float.Parse(chargeToPercentage.Value.ToString());
        }

        private void RequestedChargeVoltage_ValueChanged(object sender, EventArgs e)
        {
            BatteryChargeService.Instance.RequestedVoltage = float.Parse(RequestedChargeVoltage.Value.ToString());
        }

        private void ClearData_Click(object sender, EventArgs e)
        {
            BatteryMonitoringService.Instance.ClearChargeData();
            ChargeChart.DataBind();
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
                    BatteryMonitoringService.Instance.SaveChargeData(ioWriterStream);                    
                }
            }            
        }


    }
}
