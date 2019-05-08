using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrowPointCANBusTool.CanBus;

namespace ArrowPointCANBusTool.Model
{
    class BMU : CanModel
    {

        private int baseAddress = 0;
        private int addressRange = 255;
        private int topAddress = 0;
        private int cmuOffset = 3;

        ArrayList cmus = new ArrayList();

        public int SerialNumber { get; set; }
        public Int32 DeviceId { get; set;}
        public float SOCPercentage { get; set; }
        public float SOCAh { get; set;  }
        public float BalancePercentage { get; set; }
        public float BalanceAh { get; set; }
        public int ChargeCellVoltageError { get; set; }
        public int CellTempMargin { get; set; }
        public int DischargeCellVoltageError { get; set; }
        public uint TotalPackCapacity { get; set; }
        public uint PrechargeTimer { get; set; }
        public uint TimerFlag { get; set; }
        public uint PrechargeState { get; set; }
        public uint ContactorStatus { get; set; }
        public int CellNumberMaxCell { get; set; }
        public int CMUNumberMaxCell { get; set; }
        public int CellNumberMinCell { get; set; }
        public int CMUNumberMinCell { get; set; }
        public uint MaxCellVoltage { get; set; }
        public uint MinCellVoltage { get; set; }
        public int CMUNumberMaxTemp { get; set; }
        public int CMUNumberMinTemp { get; set; }
        public uint MaxCellTemp { get; set; }
        public uint MinCellTemp { get; set; }
        public uint BatteryVoltage { get; set; }
        public int BatteryCurrent { get; set; }
        public uint BMUFirmwareBuildNumber { get; set; }
        public uint CMUCount { get; set; }
        public uint StatusFlags { get; set; }
        public uint BalanceVoltageThresholdFalling { get; set; }
        public uint BalanceVoltageThresholdRising { get; set; }
        public uint TwelveVoltCurrentCMUs { get; set; }
        public uint TwelveVoltCurrentFansContactors { get; set; }
        public uint FanSpeed1RPM { get; set; }
        public uint FanSpeed0RPM { get; set; }
        public int BMUModelId { get; set; }
        public int BMUHardwareVersion { get; set; }
        public uint ExtendedStausFlag { get; set; }


        public BMU(int intBaseAddress)
        {
            this.baseAddress = intBaseAddress;
            this.topAddress = baseAddress + addressRange - 1;
        }

        public BMU(string hexBaseAddress)
        {
            int hexIdAsInt = int.Parse(hexBaseAddress, System.Globalization.NumberStyles.HexNumber);
            this.baseAddress = hexIdAsInt;
            this.topAddress = baseAddress + addressRange;
        }

        public ArrayList GetCMUs()
        {
            return cmus;
        }

        public bool InRange(CanPacket packet)
        {
            if (packet.canIdBase10 >= baseAddress && packet.canIdBase10 <= topAddress)
                return (true);
            else
                return (false);
        }

        public Boolean IdMatch(string HexId, int canOffset)
        {
            int hexIdAsInt = int.Parse(HexId, System.Globalization.NumberStyles.HexNumber);
            return (hexIdAsInt == canOffset);
        }

        public void Update(CanPacket packet)
        {
            try
            {

                // Only try and update if it is in range of this device
                if (!InRange(packet)) return;

                int canIdOffset = packet.getCanIdBase10() - baseAddress;

                // Check if it is actually CMU data
                if (canIdOffset >= 1 && canIdOffset <= cmuOffset * 8)
                {
                    int cmuId = (int)Math.Floor((double)canIdOffset / cmuOffset);
                    if (cmus.Count < cmuId)
                    {
                        int numberMissing = cmuId - (cmus.Count - 1);
                        for (int i = 0; i < numberMissing; i++)
                        {
                            cmus.Add(new CMU((i * cmuOffset) + this.baseAddress + 1));
                        }
                    }
                }

                // Check to see if it is actually CMU data
                foreach (CMU cmu in cmus)
                {
                    if (cmu.InRange(packet))
                    {
                        // If it is update the CMU and then return as it will not be a BMU packet and doesn
                        // require any futher processing
                        cmu.Update(packet);
                        return;
                    }
                }

                int canOffset = packet.getCanIdBase10() - baseAddress;

                if (IdMatch("0", canOffset))
                {
                    SerialNumber = packet.getInt32(1);
                    DeviceId = packet.getInt32(0);
                }
                else

                if (IdMatch("F4", canOffset))
                {
                    SOCPercentage = packet.getFloat(1);
                    SOCAh = packet.getFloat(0);
                }

                if (IdMatch("F5", canOffset))
                {
                    BalancePercentage = packet.getFloat(1);
                    BalanceAh = packet.getFloat(0);
                }

                if (IdMatch("F6", canOffset))
                {
                    ChargeCellVoltageError = packet.getInt16(3);
                    CellTempMargin = packet.getInt16(2);
                    DischargeCellVoltageError = packet.getInt16(1);
                    TotalPackCapacity = packet.getUInt16(0);
                }

                if (IdMatch("F7", canOffset))
                {
                    PrechargeTimer = packet.getUInt16(3);
                    TimerFlag = packet.getUInt8(6);
                    PrechargeState = packet.getUInt8(1);
                    ContactorStatus = packet.getUInt8(0);
                }


                if (IdMatch("F8", canOffset))
                {
                    CellNumberMaxCell = packet.getInt8(7);
                    CellNumberMaxCell = packet.getInt8(6);
                    CellNumberMinCell = packet.getInt8(5);
                    CMUNumberMinCell = packet.getInt8(4);
                    MaxCellVoltage = packet.getUInt16(2);
                    MinCellVoltage = packet.getUInt16(0);
                }

                if (IdMatch("F9", canOffset))
                {
                    CMUNumberMaxTemp = packet.getInt8(6);
                    CMUNumberMinTemp = packet.getInt8(4);
                    MaxCellTemp = packet.getUInt16(2);
                    MinCellTemp = packet.getUInt16(0);
                }

                if (IdMatch("FA", canOffset))
                {
                    BatteryVoltage = packet.getUInt32(1);
                    BatteryCurrent = packet.getInt32(0);
                }


                if (IdMatch("FB", canOffset))
                {
                    BMUFirmwareBuildNumber = packet.getUInt16(3);
                    CMUCount = packet.getUInt8(5);
                    StatusFlags = packet.getUInt8(4);
                    BalanceVoltageThresholdFalling = packet.getUInt16(1);
                    BalanceVoltageThresholdRising = packet.getUInt16(0);
                }


                if (IdMatch("FC", canOffset))
                {
                    TwelveVoltCurrentCMUs = packet.getUInt16(3);
                    TwelveVoltCurrentFansContactors = packet.getUInt16(2);
                    FanSpeed1RPM = packet.getUInt16(1);
                    FanSpeed0RPM = packet.getUInt16(0);
                }

                if (IdMatch("FD", canOffset))
                {
                    BMUModelId = packet.getInt8(5);
                    BMUHardwareVersion = packet.getInt16(3);
                    ExtendedStausFlag = packet.getUInt32(0);
                }

            } catch (Exception ex)
            {
                int hellp = 1;
            }
        }
    }
}

