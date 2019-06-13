﻿using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.CanBus;
using ArrowPointCANBusTool.Model;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ArrowPointCANBusTool.Services.CanService;

namespace ArrowPointCANBusTool.Services
{
    public class BatteryService
    {

        private CanService canService;
        private Battery battery;

        private Boolean contactorsEngaged = false;

        public BatteryService(CanService canService)
        {
            this.canService = canService;
            this.canService.CanUpdateEventHandler += new CanUpdateEventHandler(PacketReceived);
            this.battery = new Battery();
        }

        public void ShutdownService()
        {
            canService.CanUpdateEventHandler -= new CanUpdateEventHandler(PacketReceived);
        }

        public BMU GetBMU(int index)
        {
            return battery.GetBMU(index);
        }

        public async void EngageContactors()
        {
            CanPacket ControlPacket505 = new CanPacket(0x505); // 0x505
            ControlPacket505.SetInt8(0, 0);
            canService.SetCanToSendAt10Hertz(ControlPacket505);

            await Task.Delay(3000); 

            ControlPacket505.SetInt8(0, 112);
            canService.SetCanToSendAt10Hertz(ControlPacket505);

            // Set up the heartbeat for the battery so that we are ready to go
            CanPacket ControlPacket500 = new CanPacket(0x500); // 0x500
            canService.SetCanToSendAt10Hertz(ControlPacket500);
        }

        public async void DisengageContactors()
        {         
            CanPacket ControlPacket505 = new CanPacket(0x505); // 0x505
            CanPacket ControlPacket500 = new CanPacket(0x500); // 0x500

            ControlPacket505.SetInt8(0, 2);
            canService.SetCanToSendAt10Hertz(ControlPacket505);

            await Task.Delay(500);

            // Set up the heartbeat for the battery so that we are ready to go
            canService.StopSendingCanAt10Hertz(ControlPacket505);
            canService.StopSendingCanAt10Hertz(ControlPacket500);
        }        

        public bool IsContactorEngaged()
        {
            return contactorsEngaged;
        }

        public int ChargeCellVoltageError
        {
            get
            {
                int chargeCellError = int.MaxValue;

                foreach (BMU bmu in battery.GetBMUs())
                {
                    if (bmu.ChargeCellVoltageError < chargeCellError)
                        chargeCellError = bmu.ChargeCellVoltageError;
                }

                return chargeCellError;
            }
        }

        public int DischargeCellVoltageError
        {
            get
            {
                int dischargeCellError = int.MaxValue;

                foreach (BMU bmu in battery.GetBMUs())
                {
                    if (bmu.DischargeCellVoltageError < dischargeCellError)
                        dischargeCellError = bmu.DischargeCellVoltageError;
                }

                return dischargeCellError;
            }
        }


        public int BatteryCurrent
        {
            get
            {
                int batteryCurrent = 0;

                foreach (BMU bmu in battery.GetBMUs())
                {
                    batteryCurrent = batteryCurrent + bmu.BatteryCurrent;
                }

                return batteryCurrent;
            }
        }

        public uint BatteryVoltage
        {
            get
            {
                if (battery.GetBMUs().Count == 0)
                    return 0;

                return battery.GetBMU(0).BatteryVoltage;
            }
        }


        public uint MinCellVoltage
        {
            get
            {
                if (battery.GetBMUs().Count == 0)
                    return 0;

                uint minCellVoltage = int.MaxValue;

                foreach (BMU bmu in battery.GetBMUs())
                {
                    if (bmu.MinCellVoltage < minCellVoltage)
                        minCellVoltage = bmu.MinCellVoltage;
                }

                return minCellVoltage;
            }
        }


        public uint MaxCellVoltage
        {
            get
            {
                if (battery.GetBMUs().Count == 0)
                    return 0;

                uint maxCellVoltage = 0;

                foreach (BMU bmu in battery.GetBMUs())
                {
                    if (bmu.MaxCellVoltage > maxCellVoltage)
                        maxCellVoltage = bmu.MaxCellVoltage;
                }

                return maxCellVoltage;
            }
        }


        public uint MinCellTemp
        {
            get
            {
                if (battery.GetBMUs().Count == 0)
                    return 0;

                uint minCellTemp = int.MaxValue;

                foreach (BMU bmu in battery.GetBMUs())
                {
                    if (bmu.MinCellTemp < minCellTemp)
                        minCellTemp = bmu.MinCellTemp;
                }

                return minCellTemp;
            }
        }


        public uint MaxCellTemp
        {
            get
            {
                if (battery.GetBMUs().Count == 0)
                    return 0;

                uint maxCellTemp = 0;

                foreach (BMU bmu in battery.GetBMUs())
                {
                    if (bmu.MaxCellTemp > maxCellTemp)
                        maxCellTemp = bmu.MaxCellTemp;
                }

                return maxCellTemp;
            }
        }


        public uint BalanceVoltageThresholdFalling
        {
            get
            {
                if (battery.GetBMUs().Count == 0)
                    return 0;

                uint balanceVoltageThresholdFalling = int.MaxValue;

                foreach (BMU bmu in battery.GetBMUs())
                {
                    if (bmu.BalanceVoltageThresholdFalling < balanceVoltageThresholdFalling)
                        balanceVoltageThresholdFalling = bmu.BalanceVoltageThresholdFalling;
                }

                return balanceVoltageThresholdFalling;
            }
        }


        public uint BalanceVoltageThresholdRising
        {
            get
            {
                if (battery.GetBMUs().Count == 0)
                    return 0;

                uint balanceVoltageThresholdRising = 0;

                foreach (BMU bmu in battery.GetBMUs())
                {
                    if (bmu.BalanceVoltageThresholdRising > balanceVoltageThresholdRising)
                        balanceVoltageThresholdRising = bmu.BalanceVoltageThresholdRising;
                }

                return balanceVoltageThresholdRising;
            }
        }


        public float SOCPercentage
        {
            get
            {
                if (battery.GetBMUs().Count == 0)
                    return 0;

                float socPercentage = 1;

                foreach (BMU bmu in battery.GetBMUs())
                {
                    if (bmu.SOCPercentage > socPercentage)
                        socPercentage = bmu.SOCPercentage;
                }

                return socPercentage;
            }
        }

        private void PacketReceived(CanReceivedEventArgs e)
        {
            CanPacket canPacket = e.Message;
            try
            {
                battery.Update(canPacket);
                contactorsEngaged = battery.IsPackInRunState;
            } catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }
        }        
    }
}
