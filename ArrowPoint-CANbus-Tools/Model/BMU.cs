using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrowPointCANBusTool.CanBus;

namespace ArrowPointCANBusTool.Model
{
    public class BMU : CanModel
    {    
        public const int STATUS_CELL_OVER_VOLTAGE = 0x00000001;
        public const int STATUS_CELL_UNDER_VOLTAGE = 0x00000002;
        public const int STATUS_CELL_OVER_TEMPERATURE = 0x00000004;
        public const int STATUS_MEASUREMENT_UNTRUSTTED = 0x00000008;
        public const int STATUS_CMU_COMMUNICATIONS_TIMEOUT = 0x00000010;
        public const int STATUS_VEHICLE_COMMUNICATIONS_TIMEOUT= 0x00000020;
        public const int STATUS_BMU_IN_SETUP_MODE = 0x00000040;
        public const int STATUS_CMU_CAN_BUS_POWER_STATUS = 0x00000080;
        public const int STATUS_PACK_ISOLATION_TEST_FAILURE =0x00000100;
        public const int STATUS_SOC_MEASUREMENT_IS_NOT_VALID = 0x00000200;
        public const int STATUS_CAN_12V_SUPPLY_LOW = 0x00000400;
        public const int STATUS_CONTACTOR_STUCK = 0x00000800;
        public const int STATUS_CMU_HAS_DETECTED_EXTRA_CELL = 0x00001000;

        public const int PRECHARGE_STATUS_ERROR = 0;
        public const int PRECHARGE_STATUS_IDLE = 1;
        public const int PRECHARGE_STATUS_MEASURE = 2;
        public const int PRECHARGE_STATUS_PRECHARGE = 3;
        public const int PRECHARGE_STATUS_RUN = 4;
        public const int PRECHARGE_STATUS_ENABLE_PACK = 5;

        private const int ADDRESS_RANGE = 255;
        private const int CMU_OFFSET = 3;

        private readonly int baseAddress = 0;
        private int topAddress = 0;
        
        public CMU[] cmus;

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
            Initialise();
        }

        public BMU(string hexBaseAddress)
        {
            int hexIdAsInt = int.Parse(hexBaseAddress, System.Globalization.NumberStyles.HexNumber);
            this.baseAddress = hexIdAsInt;
            Initialise();
        }

        private void Initialise()
        {
            this.topAddress = baseAddress + ADDRESS_RANGE - 1;

            cmus = new CMU[8];

            for (int i = 0; i <= 7; i++)
            {
                cmus[i] = new CMU((i * CMU_OFFSET) + this.baseAddress + 1);
            }
        }

        public CMU[] GetCMUs()
        {
            return cmus;
        }

        public bool InRange(CanPacket packet)
        {
            if (packet.CanIdBase10 >= baseAddress && packet.CanIdBase10 <= topAddress)
                return (true);
            else
                return (false);
        }

        private Boolean IdMatch(string HexId, int canOffset)
        {
            int hexIdAsInt = int.Parse(HexId, System.Globalization.NumberStyles.HexNumber);
            return (hexIdAsInt == canOffset);
        }

        public void Update(CanPacket packet)
        {

                // Only try and update if it is in range of this device
                if (!InRange(packet)) return;

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

                int canOffset = (int)packet.CanIdBase10 - baseAddress;

                if (IdMatch("0", canOffset))
                {
                    SerialNumber = packet.GetInt32(1);
                    DeviceId = packet.GetInt32(0);
                }
                else

                if (IdMatch("F4", canOffset))
                {
                    SOCPercentage = packet.GetFloat(1);
                    SOCAh = packet.GetFloat(0);
                }

                if (IdMatch("F5", canOffset))
                {
                    BalancePercentage = packet.GetFloat(1);
                    BalanceAh = packet.GetFloat(0);
                }

                if (IdMatch("F6", canOffset))
                {
                    ChargeCellVoltageError = packet.GetInt16(3);
                    CellTempMargin = packet.GetInt16(2);
                    DischargeCellVoltageError = packet.GetInt16(1);
                    TotalPackCapacity = packet.GetUInt16(0);
                }

                if (IdMatch("F7", canOffset))
                {
                    PrechargeTimer = packet.GetUInt16(3);
                    TimerFlag = packet.GetUInt8(6);
                    PrechargeState = packet.GetUInt8(1);
                    ContactorStatus = packet.GetUInt8(0);
                }


                if (IdMatch("F8", canOffset))
                {
                    CellNumberMaxCell = packet.GetInt8(7);
                    CMUNumberMaxCell = packet.GetInt8(6);
                    CellNumberMinCell = packet.GetInt8(5);
                    CMUNumberMinCell = packet.GetInt8(4);
                    MaxCellVoltage = packet.GetUInt16(1);
                    MinCellVoltage = packet.GetUInt16(0);
                }

                if (IdMatch("F9", canOffset))
                {
                    CMUNumberMaxTemp = packet.GetInt8(6);
                    CMUNumberMinTemp = packet.GetInt8(4);
                    MaxCellTemp = packet.GetUInt16(1);
                    MinCellTemp = packet.GetUInt16(0);
                }

                if (IdMatch("FA", canOffset))
                {
                    BatteryCurrent = packet.GetInt32(1);
                    BatteryVoltage = packet.GetUInt32(0);                    
                }


                if (IdMatch("FB", canOffset))
                {
                    BMUFirmwareBuildNumber = packet.GetUInt16(3);
                    CMUCount = packet.GetUInt8(5);
                    StatusFlags = packet.GetUInt8(4);
                    BalanceVoltageThresholdFalling = packet.GetUInt16(1);
                    BalanceVoltageThresholdRising = packet.GetUInt16(0);
                }


                if (IdMatch("FC", canOffset))
                {
                    TwelveVoltCurrentCMUs = packet.GetUInt16(3);
                    TwelveVoltCurrentFansContactors = packet.GetUInt16(2);
                    FanSpeed1RPM = packet.GetUInt16(1);
                    FanSpeed0RPM = packet.GetUInt16(0);
                }

                if (IdMatch("FD", canOffset))
                {
                    BMUModelId = packet.GetInt8(5);
                    BMUHardwareVersion = packet.GetInt16(3);
                    ExtendedStausFlag = packet.GetUInt32(0);
                }

        }
    }
}

