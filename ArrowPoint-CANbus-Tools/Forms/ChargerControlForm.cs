using ArrowPointCANBusTool.Charger;
using ArrowPointCANBusTool.Model;
using ArrowPointCANBusTool.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ArrowPointCANBusTool.Forms
{
    public partial class ChargerControlForm : Form
    {

        private CanService canService;
        private BatteryChargeService chargeService;
        private BatteryDischargeService dischargeService;
        private BatteryMonitoringService monitoringService;        

        public ChargerControlForm(CanService canService)
        {
            InitializeComponent();
            this.canService = canService;

            this.chargeService = new BatteryChargeService(canService);
            this.dischargeService = new BatteryDischargeService(canService);
            this.monitoringService = new BatteryMonitoringService(chargeService, dischargeService, 5000);
            monitoringService.BatteryMonitorUpdateEventHandler += new BatteryMonitorUpdateEventHandler(MonitoringDataReceived);

            RequestedChargeCurrent.Maximum = decimal.Parse(maxSocketCurrent.SelectedItem.ToString());
        }

        private void StartCharge_Click(object sender, EventArgs e)
        {
            if (chargeService.IsCharging)
            {
                chargeService.StopCharge();
                startCharge.Text = "Start Charge";
                ChargeBar.Visible = false;
                maxSocketCurrent.Enabled = true;
            }
            else
            {
                chargeService.RequestedCurrent = float.Parse(RequestedChargeCurrent.Value.ToString());
                chargeService.RequestedVoltage = float.Parse(RequestedChargeVoltage.Value.ToString());
                chargeService.SupplyCurrentLimit = float.Parse(maxSocketCurrent.SelectedItem.ToString());
                chargeService.ChargeToPercentage = float.Parse(chargeToPercentage.Value.ToString());
                chargeService.StartCharge();
                startCharge.Text = "Stop Charge";
                ChargeBar.Visible = true;
                maxSocketCurrent.Enabled = false;
            }
        }

        private void ChargerControlForm_Load(object sender, EventArgs e)
        {
            ChargeChart.DataSource = monitoringService.ChargeDataSet;
            ChargeChart.DataBind();

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

            SOCText.Text = (chargeService.Battery.SOCPercentage * 100).ToString() + "%";
            BatteryPackMaTxt.Text = chargeService.Battery.BatteryCurrent.ToString();
            BatteryPackMvTxt.Text = chargeService.Battery.BatteryVoltage.ToString();
            BatteryCellMinMvTxt.Text = chargeService.Battery.MinCellVoltage.ToString();
            BatteryCellMaxMvTxt.Text = chargeService.Battery.MaxCellVoltage.ToString();
            BatteryMinCTxt.Text = (chargeService.Battery.MinCellTemp / 10).ToString();
            BatteryMaxCTxt.Text = (chargeService.Battery.MaxCellTemp / 10).ToString();
            BatteryBalancePositiveTxt.Text = chargeService.Battery.BalanceVoltageThresholdRising.ToString();
            BatteryBalanceNegativeTxt.Text = chargeService.Battery.BalanceVoltageThresholdFalling.ToString();

            ActualVoltageTxt.Text = String.Format(string.Format("{0:0.00}", chargeService.ChargerVoltage));
            ActualCurrentTxt.Text = String.Format(string.Format("{0:0.00}", chargeService.ChargerCurrent)); 

            if (!chargeService.IsCommsOk) Comms_Ok.ForeColor = Color.Red; else Comms_Ok.ForeColor = Color.Green;
            if (!chargeService.IsACOk) AC_Ok.ForeColor = Color.Red; else AC_Ok.ForeColor = Color.Green;
            if (!chargeService.IsDCOk) DC_Ok.ForeColor = Color.Red; else DC_Ok.ForeColor = Color.Green;
            if (!chargeService.IsTempOk) Temp_Ok.ForeColor = Color.Red; else Temp_Ok.ForeColor = Color.Green;
            if (!chargeService.IsHardwareOk) HW_Ok.ForeColor = Color.Red; else HW_Ok.ForeColor = Color.Green;
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
            else
            {
                
            }

            //chargeDataBindingList.Add(e.Message);
            //chargeDataBindingSource.DataSource = chargeDataBindingList;

            //ChargeChart.Series["SOC"].XValueMember = "DateTime";
            //ChargeChart.Series["SOC"].YValueMembers = "SOCAsInt";

//         
        }

        private void StartDischarge_Click(object sender, EventArgs e)
        {
            if (dischargeService.IsDischarging) { 
                dischargeService.StopDischarge();
                startDischarge.Text = "Start Discharge";
                DischargeBar.Visible = false;
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
                    DischargeBar.Visible = true;
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

        private void ChargerControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            chargeService.ShutdownCharge();
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
