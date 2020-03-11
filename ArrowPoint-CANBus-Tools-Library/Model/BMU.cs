using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrowPointCANBusTool.CanLibrary;
using ArrowPointCANBusTool.Services;
using Prohelion.CanLibrary;

namespace ArrowPointCANBusTool.Model
{
    public class BMU : CanReceivingNode
    {
        public const uint STATUS_CELL_OVER_VOLTAGE = 0x00000001;
        public const uint STATUS_CELL_UNDER_VOLTAGE = 0x00000002;
        public const uint STATUS_CELL_OVER_TEMPERATURE = 0x00000004;
        public const uint STATUS_MEASUREMENT_UNTRUSTTED = 0x00000008;
        public const uint STATUS_CMU_COMMUNICATIONS_TIMEOUT = 0x00000010;
        public const uint STATUS_VEHICLE_COMMUNICATIONS_TIMEOUT = 0x00000020;
        public const uint STATUS_BMU_IN_SETUP_MODE = 0x00000040;
        public const uint STATUS_CMU_CAN_BUS_POWER_STATUS = 0x00000080;
        public const uint STATUS_PACK_ISOLATION_TEST_FAILURE = 0x00000100;
        public const uint STATUS_SOC_MEASUREMENT_IS_NOT_VALID = 0x00000200;
        public const uint STATUS_CAN_12V_SUPPLY_LOW = 0x00000400;
        public const uint STATUS_CONTACTOR_STUCK = 0x00000800;
        public const uint STATUS_CMU_HAS_DETECTED_EXTRA_CELL = 0x00001000;

        public const uint PRECHARGE_STATUS_ERROR = 0;
        public const uint PRECHARGE_STATUS_IDLE = 1;
        public const uint PRECHARGE_STATUS_MEASURE = 2;
        public const uint PRECHARGE_STATUS_PRECHARGE = 3;
        public const uint PRECHARGE_STATUS_RUN = 4;
        public const uint PRECHARGE_STATUS_ENABLE_PACK = 5;

        public const uint CONTACTOR1_DRIVER_ERROR = 0x01; // Error status of contactor 1 driver(0 = OK, 1 = error ) 
        public const uint CONTACTOR2_DRIVER_ERROR = 0x02; // Error status of contactor 2 driver 
        public const uint CONTACTOR1_DRIVER_OUTPUT = 0x04; // Output status of contactor 1 driver(0 = Off, 1 = On) 
        public const uint CONTACTOR2_DRIVER_OUTPUT = 0x08; // Output status of contactor 2 driver 
        public const uint CONTACTOR_12V_SUPPLY_VOLTAGE = 0x10; // 12V contactor supply voltage OK(0 = Fault, 1 = OK) 
        public const uint CONTACTOR3_DRIVER_ERROR = 0x20; // Error status of contactor 3 driver
        public const uint CONTACTOR3_DRIVER_OUTPUT = 0x40; // Output status of contactor 3 driver

        private const uint BMU_CAN_WAIT_TIME = 5000;
        private const uint ADDRESS_RANGE = 255;
        private const uint CMU_OFFSET = 3;
        private const uint MAX_CMUS = 16;

        private uint state = CanReceivingNode.STATE_NA;
        private string stateMessage = CanReceivingNode.STATE_NA_TEXT;
        public const string BMU_ID = "BMU";

        private const uint VALID_MILLI = 1000;
        private readonly bool timeoutApplies = true;

        private CMU[] cmus;

        public int SerialNumber { get; private set; }
        public Int32 DeviceId { get; private set; }
        public float SOCPercentage { get; private set; }
        public float SOCAh { get; private set; }
        public float BalancePercentage { get; private set; }
        public float BalanceAh { get; private set; }
        public int ChargeCellVoltageError { get; private set; }
        public int CellTempMargin { get; private set; }
        public int DischargeCellVoltageError { get; private set; }
        public uint TotalPackCapacity { get; private set; }
        public uint PrechargeTimer { get; private set; }
        public uint TimerFlag { get; private set; }
        public uint PrechargeState { get; private set; }
        public uint ContactorStatus { get; private set; }
        public int CellNumberMaxCell { get; private set; }
        public int CMUNumberMaxCell { get; private set; }
        public int CellNumberMinCell { get; private set; }
        public int CMUNumberMinCell { get; private set; }
        public uint MaxCellVoltage { get; private set; }
        public uint MinCellVoltage { get; private set; }
        public int CMUNumberMaxTemp { get; private set; }
        public int CMUNumberMinTemp { get; private set; }
        public uint MaxCellTemp { get; private set; }
        public uint MinCellTemp { get; private set; }
        public uint BatteryVoltage { get; private set; }
        public int BatteryCurrent { get; private set; }
        public uint BMUFirmwareBuildNumber { get; private set; }
        public uint CMUCount { get; private set; }
        public uint StatusFlags { get; private set; }
        public uint BalanceVoltageThresholdFalling { get; private set; }
        public uint BalanceVoltageThresholdRising { get; private set; }
        public uint TwelveVoltCurrentCMUs { get; private set; }
        public uint TwelveVoltCurrentFansContactors { get; private set; }
        public uint FanSpeed1RPM { get; private set; }
        public uint FanSpeed0RPM { get; private set; }
        public int BMUModelId { get; private set; }
        public int BMUHardwareVersion { get; private set; }
        public uint ExtendedStausFlag { get; private set; }

        public Boolean Contactor1DriverError { get { return (ContactorStatus & CONTACTOR1_DRIVER_ERROR) != 0; } }
        public Boolean Contactor2DriverError { get { return (ContactorStatus & CONTACTOR2_DRIVER_ERROR) != 0; } }
        public Boolean Contactor3DriverError { get { return (ContactorStatus & CONTACTOR3_DRIVER_ERROR) != 0; } }
        public Boolean Contactor1DriverOutput { get { return (ContactorStatus & CONTACTOR1_DRIVER_OUTPUT) != 0; } }
        public Boolean Contactor2DriverOutput { get { return (ContactorStatus & CONTACTOR2_DRIVER_OUTPUT) != 0; } }
        public Boolean Contactor3DriverOutput { get { return (ContactorStatus & CONTACTOR3_DRIVER_OUTPUT) != 0; } }
        public Boolean Contactor12vSupplyVoltage { get { return (ContactorStatus & CONTACTOR_12V_SUPPLY_VOLTAGE) != 0; } }

        public BMU(uint intBaseAddress, bool timeoutApplies) : base(intBaseAddress, intBaseAddress + ADDRESS_RANGE - 1, timeoutApplies ? VALID_MILLI : 0, true)
        {
            this.timeoutApplies = timeoutApplies;
            Initialise();
        }

        private void Initialise()
        {
            cmus = new CMU[MAX_CMUS];

            for (int i = 0; i <= MAX_CMUS - 1; i++)
            {
                cmus[i] = new CMU((uint)(i * CMU_OFFSET) + BaseAddress + 1, timeoutApplies);
            }
        }

        public override string ComponentID => BMU_ID;

        public override uint State
        {
            get
            {
                UpdateState();
                return state;
            }
        }

        public override string StateMessage
        {
            get
            {
                UpdateState();
                return stateMessage;
            }
        }

        public string PrechargeStateText
        {
            get
            {
                switch (PrechargeState)
                {
                    case (PRECHARGE_STATUS_ERROR): return "ERROR";
                    case (PRECHARGE_STATUS_IDLE): return "IDLE";
                    case (PRECHARGE_STATUS_MEASURE): return "MEASURE";
                    case (PRECHARGE_STATUS_PRECHARGE): return "PRECHARGE";
                    case (PRECHARGE_STATUS_RUN): return "RUN";
                    case (PRECHARGE_STATUS_ENABLE_PACK): return "ENABLE";
                    default: return "N/A";
                }
            }
        }

        private void UpdateState()
        {

            state = CanReceivingNode.STATE_NA;
            stateMessage = CanReceivingNode.STATE_NA_TEXT;

            if (!ComponentCanService.IsPacketCurrent(BaseAddress, BMU_CAN_WAIT_TIME))
            {
                state = CanReceivingNode.STATE_NA;
                stateMessage = "N/A - No CanBus data";
                return;
            }

            stateMessage = "";

            if ((ExtendedStausFlag & BMU.STATUS_CELL_OVER_VOLTAGE) != 0)
            {
                state = CanReceivingNode.STATE_FAILURE;
                stateMessage += "(Cell over voltage) ";
            }

            if ((ExtendedStausFlag & BMU.STATUS_CELL_UNDER_VOLTAGE) != 0)
            {
                state = CanReceivingNode.STATE_FAILURE;
                stateMessage += "(Cell under voltage) ";
            }

            if ((ExtendedStausFlag & BMU.STATUS_CELL_OVER_TEMPERATURE) != 0)
            {
                state = CanReceivingNode.STATE_FAILURE;
                stateMessage += "(Cell over temp) ";
            }

            if ((ExtendedStausFlag & BMU.STATUS_MEASUREMENT_UNTRUSTTED) != 0)
            {
                state = CanReceivingNode.STATE_WARNING;
                stateMessage += "(Measurement Untrusted) ";
            }

            if ((ExtendedStausFlag & BMU.STATUS_CMU_COMMUNICATIONS_TIMEOUT) != 0)
            {
                state = CanReceivingNode.STATE_FAILURE;
                stateMessage += "(CMU Comms Timeout) ";
            }

            if ((ExtendedStausFlag & BMU.STATUS_VEHICLE_COMMUNICATIONS_TIMEOUT) != 0)
            {
                state = CanReceivingNode.STATE_FAILURE;
                stateMessage += "(Vehicle Comms Timeout) ";
            }

            if ((ExtendedStausFlag & BMU.STATUS_BMU_IN_SETUP_MODE) != 0)
            {
                state = CanReceivingNode.STATE_WARNING;
                stateMessage += "(BMU in setup mode) ";
            }

            if ((ExtendedStausFlag & BMU.STATUS_CMU_CAN_BUS_POWER_STATUS) == 0)
            {
                state = CanReceivingNode.STATE_WARNING;
                stateMessage += "(CMU CanBus Power Status) ";
            }

            if ((ExtendedStausFlag & BMU.STATUS_PACK_ISOLATION_TEST_FAILURE) != 0)
            {
                state = CanReceivingNode.STATE_FAILURE;
                stateMessage += "(Pack Isolation Failure) ";
            }

            if ((ExtendedStausFlag & BMU.STATUS_SOC_MEASUREMENT_IS_NOT_VALID) != 0)
            {
                state = CanReceivingNode.STATE_WARNING;
                stateMessage += "(SOC Measurement not valid) ";
            }

            if ((ExtendedStausFlag & BMU.STATUS_CAN_12V_SUPPLY_LOW) != 0)
            {
                state = CanReceivingNode.STATE_WARNING;
                stateMessage += "(CanBus 12v Supply Low) ";
            }

            if ((ExtendedStausFlag & BMU.STATUS_CONTACTOR_STUCK) != 0)
            {
                state = CanReceivingNode.STATE_FAILURE;
                stateMessage += "(Contactor Stuck) ";
            }

            if ((ExtendedStausFlag & BMU.STATUS_CMU_HAS_DETECTED_EXTRA_CELL) != 0)
            {
                state = CanReceivingNode.STATE_FAILURE;
                stateMessage += "(Detected extra cell) ";
            }


            if (state != CanReceivingNode.STATE_NA)
                return;

            if (PrechargeState == PRECHARGE_STATUS_ERROR)
            {
                state = CanReceivingNode.STATE_FAILURE;
                stateMessage = "(Precharge Error)";
                return;
            }

            if (PrechargeState == PRECHARGE_STATUS_IDLE || PrechargeState == PRECHARGE_STATUS_MEASURE || PrechargeState == PRECHARGE_STATUS_PRECHARGE)
            {
                state = CanReceivingNode.STATE_IDLE;
                stateMessage = "(Precharge Idle)";
                return;
            }

            if (PrechargeState == PRECHARGE_STATUS_RUN && !Contactor1DriverOutput)
            {
                state = CanReceivingNode.STATE_OFF;
                stateMessage = "(Contactors Closed)";
                return;
            }

            if (PrechargeState == PRECHARGE_STATUS_RUN && Contactor1DriverOutput)
            {
                state = CanReceivingNode.STATE_ON;
                stateMessage = "(On and Ready)";
                return;
            }
        }

        public List<CMU> GetCMUs()
        {
            return new List<CMU>(cmus); ;
        }

        public List<CMU> GetActiveCMUs()
        {
            List<CMU> activeCmus = new List<CMU>();

            foreach (CMU cmu in cmus)
            {
                if (cmu.State != CanReceivingNode.STATE_NA) activeCmus.Add(cmu);
            }

            return activeCmus;
        }

        public CMU GetCMU(int index)
        {
            if (cmus == null) return null;
            if (cmus.Length - 1 < index) return null;

            return ((CMU)cmus[index]);
        }

        public override void CanPacketReceived(CanPacket canPacket)
        {
            if (canPacket == null) throw new ArgumentNullException(nameof(canPacket));

            int canOffset = (int)canPacket.CanIdBase10 - (int)BaseAddress;

            if (IdMatch("0", canOffset))
            {
                SerialNumber = canPacket.Int32Pos1;
                DeviceId = canPacket.Int32Pos0;
            }
            else

            if (IdMatch("F4", canOffset))
            {
                SOCPercentage = canPacket.FloatPos1;
                SOCAh = canPacket.FloatPos0;
            }

            if (IdMatch("F5", canOffset))
            {
                BalancePercentage = canPacket.FloatPos1;
                BalanceAh = canPacket.FloatPos0;
            }

            if (IdMatch("F6", canOffset))
            {
                TotalPackCapacity = canPacket.UShort16Pos3;
                DischargeCellVoltageError = canPacket.Short16Pos2;
                CellTempMargin = canPacket.Short16Pos1;
                ChargeCellVoltageError = canPacket.Short16Pos0;
            }

            if (IdMatch("F7", canOffset))
            {
                PrechargeTimer = canPacket.UInt8Pos7;
                TimerFlag = canPacket.UInt8Pos6;
                PrechargeState = canPacket.UInt8Pos1;
                ContactorStatus = canPacket.UInt8Pos0;
            }

            if (IdMatch("F8", canOffset))
            {
                CellNumberMaxCell = canPacket.Int8Pos7;
                CMUNumberMaxCell = canPacket.Int8Pos6;
                CellNumberMinCell = canPacket.Int8Pos5;
                CMUNumberMinCell = canPacket.Int8Pos4;
                MaxCellVoltage = canPacket.UShort16Pos1;
                MinCellVoltage = canPacket.UShort16Pos0;
            }

            if (IdMatch("F9", canOffset))
            {
                CMUNumberMaxTemp = canPacket.Int8Pos6;
                CMUNumberMinTemp = canPacket.Int8Pos4;
                MaxCellTemp = canPacket.UShort16Pos1;
                MinCellTemp = canPacket.UShort16Pos0;
            }

            if (IdMatch("FA", canOffset))
            {
                BatteryCurrent = canPacket.Int32Pos1;
                BatteryVoltage = canPacket.UInt32Pos0;
            }


            if (IdMatch("FB", canOffset))
            {
                BMUFirmwareBuildNumber = canPacket.UShort16Pos3;
                CMUCount = canPacket.UInt8Pos5;
                StatusFlags = canPacket.UInt8Pos4;
                BalanceVoltageThresholdFalling = canPacket.UShort16Pos1;
                BalanceVoltageThresholdRising = canPacket.UShort16Pos0;
            }


            if (IdMatch("FC", canOffset))
            {
                TwelveVoltCurrentCMUs = canPacket.UShort16Pos3;
                TwelveVoltCurrentFansContactors = canPacket.UShort16Pos2;
                FanSpeed1RPM = canPacket.UShort16Pos1;
                FanSpeed0RPM = canPacket.UShort16Pos0;
            }

            if (IdMatch("FD", canOffset))
            {
                BMUModelId = canPacket.Int8Pos5;
                BMUHardwareVersion = canPacket.Short16Pos3;
                ExtendedStausFlag = canPacket.UInt32Pos0;
            }

        }

    }
}

