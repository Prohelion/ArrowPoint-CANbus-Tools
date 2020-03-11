
using ArrowPointCANBusTool.CanLibrary;
using ArrowPointCANBusTool.Services;
using Prohelion.CanLibrary;
using System;
using System.Diagnostics;
using static ArrowPointCANBusTool.Services.CanService;

namespace ArrowPointCANBusTool.Services
{
    public class ElconService : ChargerServiceBase
    {
        private static readonly ElconService instance = new ElconService();

        // ELCON charger CAN messages        
        public const uint ELCON_CAN_STATUS = (uint)0x18FF50E5ul;
        public const uint ELCON_CAN_COMMAND = (uint)0x1806E5F4ul;
        public const uint ELCON_CAN_WAIT_TIME = 1000;

        private const uint ELCON_STAT_HWFAIL = 0x01;
        private const uint ELCON_STAT_OTERR = 0x02;
        private const uint ELCON_STAT_ACFAIL = 0x04;
        private const uint ELCON_STAT_NODCV = 0x08;
        private const uint ELCON_STAT_TOUT = 0x10;

        private const float ELCON_VOLTAGE_LIMIT = 198.0f;
        private const float ELCON_CURRENT_LIMIT = 46.0f;
        private const float ELCON_POWER_LIMIT = 6600.0f;        

        public override float ChargerVoltageLimit { get; protected set; } = ELCON_VOLTAGE_LIMIT;
        public override float ChargerCurrentLimit { get; protected set; } = ELCON_CURRENT_LIMIT;
        public override float ChargerPowerLimit { get; protected set; } = ELCON_POWER_LIMIT;
        public override float ChargerEfficiency => 0.9f;

        public override string ComponentID => "ELCON";

        private Boolean chargeOutputOn = false;

        private uint state = CanReceivingNode.STATE_NA;
        private string stateMessage = CanReceivingNode.STATE_NA_TEXT;

        static ElconService()
        {
        }

        public static ElconService Instance
        {
            get
            {
                return instance;
            }
        }

        private ElconService() : base(ELCON_CAN_STATUS, ELCON_CAN_STATUS)
        {            
        }

        public override bool IsCharging {
            get {
                if (!chargeOutputOn)
                {
                    return false;
                }
                
                if (ComponentCanService.LastestCanPacketById(ELCON_CAN_STATUS) == null)
                {
                    return false;
                }

                if (!ComponentCanService.IsPacketCurrent(ELCON_CAN_STATUS, ELCON_CAN_WAIT_TIME))
                {
                    return false;
                }

                return true;
            }
        }

        public override bool IsHardwareOk { get { return (ChargerStatus & ELCON_STAT_HWFAIL) == 0; } }
        public override bool IsTempOk { get { return (ChargerStatus & ELCON_STAT_OTERR) == 0; } }
        public override bool IsCommsOk { get { return (ChargerStatus & ELCON_STAT_TOUT) == 0; } }
        public override bool IsACOk { get { return (ChargerStatus & ELCON_STAT_ACFAIL) == 0; } }    
        public override bool IsDCOk { get { return (ChargerStatus & ELCON_STAT_NODCV) == 0; } }


        private void UpdateStatus()
        {
            state = CanReceivingNode.STATE_NA;
            stateMessage = "";

            if (!ComponentCanService.IsPacketCurrent(ELCON_CAN_STATUS, ELCON_CAN_WAIT_TIME))
            {
                state = CanReceivingNode.STATE_NA;
                stateMessage = "N/A - No CanBus data";
                return;
            }

            if (ChargerStatus != 0)
            {
                state = CanReceivingNode.STATE_FAILURE;
                if (!IsHardwareOk) stateMessage += "(Hardware Issue) ";
                if (!IsTempOk) stateMessage += "(Temp Issue) ";
                if (!IsCommsOk) stateMessage += "(Comms Issue) ";
                if (!IsACOk) stateMessage += "(AC Issue) ";
                if (!IsDCOk) stateMessage += "(DC Issue) ";
            }
    
            if (IsCharging)
            {
                state = CanReceivingNode.STATE_ON;
                stateMessage = CanReceivingNode.STATE_ON_TEXT;
            } else
            {
                state = CanReceivingNode.STATE_IDLE;
                stateMessage = CanReceivingNode.STATE_IDLE_TEXT;
            }
        }

        public override uint State
        {
            get
            {
                UpdateStatus();
                return state;
            }
        }
        
        public override string StateMessage
        {
            get
            {
                UpdateStatus();
                return stateMessage;
            }
        }

        public override void CanPacketReceived(CanPacket cp)
        {
            if (cp == null) throw new ArgumentNullException(nameof(cp));

            // Elcon uses big endian
            cp.IsLittleEndian = false;

            Boolean gotStatusMessage = false;            

            try
            {
                switch (cp.CanIdBase10)
                {
                    case ELCON_CAN_STATUS: // 0x18FF50E5
                        ActualVoltage = (float)cp.UShort16Pos0 / 10.0f;
                        ActualCurrent = (float)cp.UShort16Pos1 / 10.0f;

                        // Calculate and send updated dynamic current limit based on pack voltage
                        if (ActualVoltage > 0.0f)
                        {
                            ChargerCurrentLimit = ChargerPowerLimit / ActualVoltage;

                            if (ChargerCurrentLimit > ELCON_CURRENT_LIMIT)
                            {
                                ChargerCurrentLimit = ELCON_CURRENT_LIMIT;
                            }
                        }

                        // Get status flags
                        ChargerStatus = cp.UInt8Pos4;
                        gotStatusMessage = true;
                        break;
                }
            }
            catch
            {
                //Let it go, let it go. Can't hold it back anymore...
            }

            if (chargeOutputOn && gotStatusMessage) {
                // We use the receipt of the status message to send the charger the latest power details
                CanPacket elconCommand = new CanPacket(ELCON_CAN_COMMAND)
                {
                    IsLittleEndian = false
                };

                // Update voltage requested by the ChargeService
                elconCommand.UShort16Pos0 = (ushort)(RequestedVoltage * 10);

                // Update current requested by the ChargeService
                elconCommand.UShort16Pos1 = (ushort)(RequestedCurrent * 10);

                ComponentCanService.SendMessage(elconCommand);
            }

            UpdateStatus();
        }
    
        public override void StartCharge()
        {
            StartReceivingCan();
            chargeOutputOn = true;
        }

        public override void StopCharge()
        {
            StopReceivingCan();

            // We use the receipt of the status message to send the charger the latest power details
            CanPacket elconCommand = new CanPacket(ELCON_CAN_COMMAND)
            {
                IsLittleEndian = false
            };

            // Update voltage requested to 0
            elconCommand.UShort16Pos3 = (ushort)(0);

            // Update current requested to 0
            elconCommand.UShort16Pos2 = (ushort)(0);

            ComponentCanService.SendMessage(elconCommand);

            chargeOutputOn = false;
        }

    }
}
