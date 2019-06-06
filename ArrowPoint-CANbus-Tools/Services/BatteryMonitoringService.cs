using ArrowPointCANBusTool.CanBus;
using ArrowPointCANBusTool.Charger;
using ArrowPointCANBusTool.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ArrowPointCANBusTool.Services
{

    public delegate void BatteryMonitorUpdateEventHandler(ChargeDataReceivedEventArgs e);

    public class BatteryMonitoringService
    {
        private List<ChargeData> chargeDataSet = new List<ChargeData>();
        private readonly BatteryChargeService chargeService;
        private readonly BatteryDischargeService dischargeService;

        public event BatteryMonitorUpdateEventHandler BatteryMonitorUpdateEventHandler;
        public List<ChargeData> ChargeDataSet { get { return chargeDataSet; } }

        public BatteryMonitoringService(BatteryChargeService chargeService, BatteryDischargeService dischargeService, int refereshInterval)
        {
            this.chargeService = chargeService;
            this.dischargeService = dischargeService;

            Timer updateChargeDataTimer = new System.Timers.Timer
            {
                Interval = refereshInterval,
                AutoReset = true,
                Enabled = true
            };
            updateChargeDataTimer.Elapsed += UpdateChargeData;
        }


        private void UpdateChargeData(object sender, EventArgs e)
        {
            ChargeData chargeData = new ChargeData
            {
                    DateTime = DateTime.Now,
                    SOC = chargeService.Battery.SOCPercentage,
                    ChargeCurrentmA = chargeService.ChargerCurrent,
                    ChargeVoltagemV = chargeService.ChargerVoltage,
                    PackmA = chargeService.Battery.BatteryCurrent,
                    PackmV = chargeService.Battery.BatteryVoltage,
                    MinCellmV = chargeService.Battery.MinCellVoltage,
                    MaxCellmV = chargeService.Battery.MaxCellVoltage,
                    MinCellTemp = chargeService.Battery.MinCellTemp,
                    MaxCellTemp = chargeService.Battery.MaxCellTemp,
                    BalanceVoltageThresholdFalling = chargeService.Battery.BalanceVoltageThresholdFalling,
                    BalanceVoltageThresholdRising = chargeService.Battery.BalanceVoltageThresholdRising,
                    ChargeCellVoltageError = chargeService.Battery.MinChargeCellVoltageError,
                    DischargeCellVoltageError = chargeService.Battery.MinDischargeCellVoltageError
            };

            chargeDataSet.Add(chargeData);

            BatteryMonitorUpdateEventHandler?.Invoke(new ChargeDataReceivedEventArgs(chargeData));
        }

        public void ClearChargeData()
        {
            chargeDataSet.Clear();
        }

        public void SaveChargeData(string fileName)
        {
            StreamWriter fileStream = new System.IO.StreamWriter(fileName);
            if (fileStream != null)
                SaveChargeData(fileStream);
            else
                throw (new FileNotFoundException());
        }

        public void SaveChargeData(StreamWriter ioStream)
        {
            StreamWriter recordStream = ioStream;
            recordStream.WriteLine("Date time     , SOC %, Charge Current , Charge Voltage, Pack mA, Pack mV, Min Cell mV, Max Cell mV, Min Cell Temp, Max Cell Temp, Balance +, Balance -, Charge Voltage Error, Discharge Voltage Error");

            foreach (ChargeData chargeData in chargeDataSet)
            {
                string newLine = "";

                newLine = newLine + MyExtensions.AlignLeft(chargeData.DateTime.ToString("HH:mm:ss"), 14, false);
                newLine = newLine + MyExtensions.AlignLeft(chargeData.SOCAsInt.ToString(), 7, true);
                newLine = newLine + MyExtensions.AlignLeft(chargeData.ChargeCurrentmA.ToString(), 17, true);
                newLine = newLine + MyExtensions.AlignLeft(chargeData.ChargeVoltagemV.ToString(), 16, true);
                newLine = newLine + MyExtensions.AlignLeft(chargeData.PackmA.ToString(), 9, true);
                newLine = newLine + MyExtensions.AlignLeft(chargeData.PackmV.ToString(), 9, true);
                newLine = newLine + MyExtensions.AlignLeft(chargeData.MinCellmV.ToString(), 13, true);
                newLine = newLine + MyExtensions.AlignLeft(chargeData.MaxCellmV.ToString(), 13, true);
                newLine = newLine + MyExtensions.AlignLeft(chargeData.MinCellTemp.ToString(), 15, true);
                newLine = newLine + MyExtensions.AlignLeft(chargeData.MaxCellTemp.ToString(), 15, true);
                newLine = newLine + MyExtensions.AlignLeft(chargeData.BalanceVoltageThresholdRising.ToString(), 11, true);
                newLine = newLine + MyExtensions.AlignLeft(chargeData.BalanceVoltageThresholdFalling.ToString(), 11, true);
                newLine = newLine + MyExtensions.AlignLeft(chargeData.ChargeCellVoltageError.ToString(), 22, true);
                newLine = newLine + MyExtensions.AlignLeft(chargeData.DischargeCellVoltageError.ToString(), 12, true);

                recordStream.WriteLine(newLine);
            }

            ioStream.Close();
            recordStream.Close();
        }

    }
}
