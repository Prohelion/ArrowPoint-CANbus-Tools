﻿using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Services;
using ArrowPointCANBusTool.Model;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

namespace ArrowPointCANBusTool.Services
{

    public delegate void BatteryMonitorUpdateEventHandler(ChargeDataReceivedEventArgs e);

    public class BatteryMonitoringService
    {

        private static readonly BatteryMonitoringService instance = new BatteryMonitoringService();

        private readonly List<ChargeData> chargeDataSet = new List<ChargeData>();
        public event BatteryMonitorUpdateEventHandler BatteryMonitorUpdateEventHandler;
        public List<ChargeData> ChargeDataSet { get { return chargeDataSet; } }
        private StreamWriter fileStream;

        static BatteryMonitoringService()
        {
        }

        public static BatteryMonitoringService Instance
        {
            get
            {
                return instance;
            }
        }

        private BatteryMonitoringService()
        {
            using Timer updateChargeDataTimer = new System.Timers.Timer
            {
                Interval = 5000,
                AutoReset = true,
                Enabled = true
            };
            updateChargeDataTimer.Elapsed += UpdateChargeData;
        }


        private void UpdateChargeData(object sender, EventArgs e)
        {
            Battery battery = BatteryChargeService.Instance.BatteryService.BatteryData;

            ChargeData chargeData = new ChargeData
            {
                DateTime = DateTime.Now,
                SOC = battery.SOCPercentage,
                ChargeCurrentA = BatteryChargeService.Instance.ChargerActualCurrent,
                ChargeVoltagemV = BatteryChargeService.Instance.ChargerActualVoltage,
                PackmA = battery.BatteryCurrent,
                PackmV = battery.BatteryVoltage,
                MinCellmV = battery.MinCellVoltage,
                MaxCellmV = battery.MaxCellVoltage,
                MinCellTemp = battery.MinCellTemp,
                MaxCellTemp = battery.MaxCellTemp,
                BalanceVoltageThresholdFalling = battery.BalanceVoltageThresholdFalling,
                BalanceVoltageThresholdRising = battery.BalanceVoltageThresholdRising,
                ChargeCellVoltageError = battery.MinChargeCellVoltageError,
                DischargeCellVoltageError = battery.MinDischargeCellVoltageError
            };

            if (BatteryChargeService.Instance.IsCharging && BatteryDischargeService.Instance.IsDischarging) chargeData.State = ChargeData.STATE_ERROR;
            else if (BatteryChargeService.Instance.IsCharging) chargeData.State = ChargeData.STATE_CHARGE;
            else if (BatteryDischargeService.Instance.IsDischarging) chargeData.State = ChargeData.STATE_DISCHARGE;
            else chargeData.State = ChargeData.STATE_IDLE;

            // Add all of the CMU voltages
            foreach (BMU bmu in battery.GetActiveBMUs())
            {
                foreach (CMU cmu in bmu.GetActiveCMUs())
                {
                    if (cmu.State == CanReceivingNode.STATE_ON)
                    {
                        uint?[] voltages = new uint?[9];
                        voltages[0] = cmu.Cell0mV;
                        voltages[1] = cmu.Cell1mV;
                        voltages[2] = cmu.Cell2mV;
                        voltages[3] = cmu.Cell3mV;
                        voltages[4] = cmu.Cell4mV;
                        voltages[5] = cmu.Cell5mV;
                        voltages[6] = cmu.Cell6mV;
                        voltages[7] = cmu.Cell7mV;
                        voltages[8] = (uint?)cmu.SerialNumber;


                        if (chargeData.CellVoltages == null)
                            chargeData.CellVoltages = new List<uint?[]>();
                        chargeData.CellVoltages.Add(voltages);
                    }
                }
            }

            chargeDataSet.Add(chargeData);

            if (IsSavingCharge) SaveChargeData(chargeData);

            BatteryMonitorUpdateEventHandler?.Invoke(new ChargeDataReceivedEventArgs(chargeData));
        }

        public void ClearChargeData()
        {
            chargeDataSet.Clear();
        }

        public bool IsSavingCharge {
            get            
            {
                return (fileStream != null);
            }
        }

        public void SaveChargeData(StreamWriter newFileStream)
        {
            // If we are currenting saving a charge run, stop
            if (IsSavingCharge) StopSavingChargeData();

            fileStream = newFileStream;
            
            if (fileStream != null) SaveChargeDataHeader();
            else
                throw (new FileNotFoundException());
        }

        public void StopSavingChargeData()
        {
            if (fileStream != null)
            {
                fileStream.Close();
                fileStream = null;
            }
        }

        public void SaveChargeDataHeader()
        {
            fileStream.Write("Date time     , SOC %, Charge Current , Charge Voltage, Pack mA, Pack mV, Min Cell mV, Max Cell mV, Min Cell Temp, Max Cell Temp, Balance +, Balance -, Charge Voltage Error, Discharge Voltage Error");

            foreach (BMU bmu in BatteryChargeService.Instance.BatteryService.BatteryData.GetBMUs())
            {
                foreach (CMU cmu in bmu.GetCMUs())
                {
                    if (cmu.State == CanReceivingNode.STATE_ON)
                        fileStream.Write(", CMU" + CanUtilities.AlignLeft(cmu.SerialNumber.ToString(), 3, false) + ", Cell0mV, Cell1mV, Cell2mV, Cell3mV, Cell4mV, Cell5mV, Cell6mV, Cell7mV");
                }
            }

            fileStream.WriteLine();
        }

        public void SaveChargeData(ChargeData chargeData)
        {
            if (chargeData == null) throw new ArgumentNullException(nameof(chargeData));

            string newLine = "";

            newLine += CanUtilities.AlignLeft(chargeData.DateTime.ToString("HH:mm:ss"), 14, false);
            newLine += CanUtilities.AlignLeft(chargeData.SOCAsInt.ToString(), 7, true);
            newLine += CanUtilities.AlignLeft(chargeData.ChargeCurrentmA.ToString(), 17, true);
            newLine += CanUtilities.AlignLeft(chargeData.ChargeVoltagemV.ToString(), 16, true);
            newLine += CanUtilities.AlignLeft(chargeData.PackmA.ToString(), 9, true);
            newLine += CanUtilities.AlignLeft(chargeData.PackmV.ToString(), 9, true);
            newLine += CanUtilities.AlignLeft(chargeData.MinCellmV.ToString(), 13, true);
            newLine += CanUtilities.AlignLeft(chargeData.MaxCellmV.ToString(), 13, true);
            newLine += CanUtilities.AlignLeft(chargeData.MinCellTemp.ToString(), 15, true);
            newLine += CanUtilities.AlignLeft(chargeData.MaxCellTemp.ToString(), 15, true);
            newLine += CanUtilities.AlignLeft(chargeData.BalanceVoltageThresholdRising.ToString(), 11, true);
            newLine += CanUtilities.AlignLeft(chargeData.BalanceVoltageThresholdFalling.ToString(), 11, true);
            newLine += CanUtilities.AlignLeft(chargeData.ChargeCellVoltageError.ToString(), 22, true);
            newLine += CanUtilities.AlignLeft(chargeData.DischargeCellVoltageError.ToString(), 25, true);

            if (chargeData.CellVoltages != null)
            {
                foreach (uint?[] array in chargeData.CellVoltages)
                {
                    newLine += CanUtilities.AlignLeft(array[8].ToString(), 8, true);
                    newLine += CanUtilities.AlignLeft(array[0].ToString(), 9, true);
                    newLine += CanUtilities.AlignLeft(array[1].ToString(), 9, true);
                    newLine += CanUtilities.AlignLeft(array[2].ToString(), 9, true);
                    newLine += CanUtilities.AlignLeft(array[3].ToString(), 9, true);
                    newLine += CanUtilities.AlignLeft(array[4].ToString(), 9, true);
                    newLine += CanUtilities.AlignLeft(array[5].ToString(), 9, true);
                    newLine += CanUtilities.AlignLeft(array[6].ToString(), 9, true);
                    newLine += CanUtilities.AlignLeft(array[7].ToString(), 9, true);
                }
            }

            fileStream.WriteLine(newLine);

        }

    }
}
