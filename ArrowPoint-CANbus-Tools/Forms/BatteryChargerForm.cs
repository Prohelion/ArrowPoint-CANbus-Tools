﻿using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Services;
using ArrowPointCANBusTool.Model;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Forms
{
    public partial class BatteryChargerForm : Form
    {

        private const int MAX_GRAPH_ITEMS = 500;

        private Timer timer;

        public BatteryChargerForm()
        {
            InitializeComponent();            
            BatteryMonitoringService.Instance.BatteryMonitorUpdateEventHandler += new BatteryMonitorUpdateEventHandler(MonitoringDataReceived);            
            maxSocketCurrent.SelectedIndex = maxSocketCurrent.FindStringExact("10");
            ChargerComboBox.SelectedIndex = 0;
            RequestedChargeCurrent.Maximum = 10;
        }

        private async void StartCharge_ClickAsync(object sender, EventArgs e)
        {
            startCharge.Enabled = false;

            // This should never happen.  It is a safety just in case
            if (BatteryDischargeService.Instance.IsDischarging)
            {
                await BatteryChargeService.Instance.StopCharge().ConfigureAwait(false);
                return;
            }

            if (BatteryChargeService.Instance.IsCharging)
               await BatteryChargeService.Instance.StopCharge().ConfigureAwait(false);
            else
            {
                startDischarge.Enabled = false;
                

                if ((BatteryChargeService.Instance.BatteryState == CanReceivingNode.STATE_WARNING || BatteryChargeService.Instance.BatteryState == CanReceivingNode.STATE_ON || BatteryChargeService.Instance.BatteryState == CanReceivingNode.STATE_IDLE) &&
                    (BatteryChargeService.Instance.ChargerState == CanReceivingNode.STATE_WARNING || BatteryChargeService.Instance.ChargerState == CanReceivingNode.STATE_ON || BatteryChargeService.Instance.ChargerState == CanReceivingNode.STATE_IDLE))
                {                    
                    BatteryChargeService.Instance.RequestedCurrent = float.Parse(RequestedChargeCurrent.Value.ToString());
                    BatteryChargeService.Instance.RequestedVoltage = float.Parse(RequestedChargeVoltage.Value.ToString());
                    BatteryChargeService.Instance.SupplyCurrentLimit = float.Parse(maxSocketCurrent.SelectedItem.ToString());
                    BatteryChargeService.Instance.ChargeToPercentage = float.Parse(chargeToPercentage.Value.ToString());
                    await BatteryChargeService.Instance.StartCharge().ConfigureAwait(false);
                }
                else
                    MessageBox.Show("Charger of battery is currently in an invalid state to start charging",
                     "Check Battery and Charger",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);

            }
                
            UpdateStartStopDetails();
        }

        private async void StartDischarge_ClickAsync(object sender, EventArgs e)
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
                await BatteryDischargeService.Instance.StartDischarge().ConfigureAwait(false);
                startDischarge.Text = "Stop Discharge";
            }
        }


        private void ChargerControlForm_Load(object sender, EventArgs e)
        {
            BatteryChargeService.Instance.SetCharger(ElconService.Instance);

            ChargeChart.DataSource = BatteryMonitoringService.Instance.ChargeDataSet;
            ChargeChart.DataBind();
            
            timer = new Timer
            {
                Interval = (100)
            };
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();
        }

        private async void ChargerControlForm_FormClosingAsync(object sender, FormClosingEventArgs e)
        {            
            timer.Stop();
            timer.Dispose();            
            await BatteryChargeService.Instance.StopCharge().ConfigureAwait(false);
            BatteryChargeService.Instance.BatteryService.ShutdownService();
        }

        private void UpdateRecordingDetails()
        {

            if (BatteryMonitoringService.Instance.IsSavingCharge)            
                BtnSaveData.Text = "Stop Save";
            else
                BtnSaveData.Text = "Save Charge Data";        
        }

        private void UpdateStartStopDetails()
        {

            if (BatteryChargeService.Instance.IsPrecharging)
            {
                startDischarge.Enabled = false;
                startCharge.Enabled = false;
                startCharge.Text = "Precharging";
                maxSocketCurrent.Enabled = false;            
            } else if (BatteryChargeService.Instance.IsCharging)
            {
                startDischarge.Enabled = false;
                startCharge.Enabled = true;
                startCharge.Text = "Stop Charge";
                maxSocketCurrent.Enabled = false;
            }
            else
            {
                ActualVoltageTxt.Text = "";
                ActualCurrentTxt.Text = "";
                
                startCharge.Text = "Start Charge";
                maxSocketCurrent.Enabled = true;

                if (!BatteryDischargeService.Instance.IsDischarging) startDischarge.Enabled = true;
            }

            if (BatteryDischargeService.Instance.IsDischarging)
            {
                startCharge.Enabled = false;
                startDischarge.Text = "Stop Discharge";
            } else
            {
                if (!BatteryChargeService.Instance.IsCharging && !BatteryChargeService.Instance.IsPrecharging) startCharge.Enabled = true;
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

            // Ensures that the user does not select a value less than the voltage of the pack
            double estimatedBatteryVoltage = battery.EstimatePackVoltageFromCMUs / 1000;
            if (battery.BatteryVoltage / 1000 > estimatedBatteryVoltage)  estimatedBatteryVoltage = battery.BatteryVoltage / 1000;
            if (BatteryChargeService.Instance.ChargerActualVoltage > estimatedBatteryVoltage) estimatedBatteryVoltage = BatteryChargeService.Instance.ChargerActualVoltage;
    
            double roundedUpVoltage = Math.Ceiling(estimatedBatteryVoltage);

            if (roundedUpVoltage > 0 && float.Parse(RequestedChargeVoltage.Value.ToString()) < roundedUpVoltage)
                RequestedChargeVoltage.Value = (decimal)roundedUpVoltage;

            RequestedChargeVoltage.Minimum = (decimal)roundedUpVoltage;

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

            UpdateStartStopDetails();
        }

        private void MonitoringDataReceived(ChargeDataReceivedEventArgs e)
        {
            ChargeData chargeData = e.Message;

            if (ChargeChart.InvokeRequired)
            {
                try
                {
                    ChargeChart.Invoke(new Action(() =>
                    {                        

                        if (BatteryMonitoringService.Instance.ChargeDataSet.Count > MAX_GRAPH_ITEMS)
                            ChargeChart.DataSource = BatteryMonitoringService.Instance.ChargeDataSet.GetRange(BatteryMonitoringService.Instance.ChargeDataSet.Count - MAX_GRAPH_ITEMS, MAX_GRAPH_ITEMS);
                        else
                            ChargeChart.DataSource = BatteryMonitoringService.Instance.ChargeDataSet;
                        ChargeChart.DataBind();
                    }
                    ));
                } catch 
                {
                    // Catch and kill and exception that sometimes occurs on shotdown of the form.
                }
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

            if (BatteryMonitoringService.Instance.IsSavingCharge)
            {
                BatteryMonitoringService.Instance.StopSavingChargeData();
            } else
            {
                using SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    RestoreDirectory = true,
                    Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                    FilterIndex = 2,
                    FileName = "BatteryLog-" + DateTime.Now.ToString("yyyyMMdd-HHmm") + ".txt"
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Stream ioStream = saveFileDialog.OpenFile();
                    if (ioStream != null)
                    {
                        using StreamWriter ioWriterStream = new StreamWriter(ioStream);
                        BatteryMonitoringService.Instance.SaveChargeData(ioWriterStream);

                    }
                }
            }

            UpdateRecordingDetails();
        }

        private void ChargerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChargerComboBox.SelectedIndex == 0)
            {
                // Elcon
                BatteryChargeService.Instance.SetCharger(ElconService.Instance);
            }
            else
            if (ChargerComboBox.SelectedIndex == 1)
            {
                // TDK                
                BatteryChargeService.Instance.SetCharger(TDKService.Instance);
                TDKService.Instance.Connect("192.168.20.35", 100);
            }
        }
    }
}
