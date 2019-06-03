
using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.CanBus;
using ArrowPointCANBusTool.Services;
using System;
using static ArrowPointCANBusTool.Services.CanService;

namespace ArrowPointCANBusTool.Charger
{
    public class ElconService : IChargerInterface
    {
        
        // ELCON charger CAN messages        
        public const uint ELCON_CAN_STATUS = (int)0x18FF50E5ul;
        public const uint ELCON_CAN_COMMAND = (int)0x1806E5F4ul;

        private const int ELCON_STAT_HWFAIL	= 0x01;
        private const int ELCON_STAT_OTERR = 0x02;
        private const int ELCON_STAT_ACFAIL = 0x04;
        private const int ELCON_STAT_NODCV = 0x08;
        private const int ELCON_STAT_TOUT = 0x10;
        private const int ELCON_STAT_ERROR_MASK = ( ELCON_STAT_HWFAIL | ELCON_STAT_OTERR | ELCON_STAT_ACFAIL | ELCON_STAT_NODCV | ELCON_STAT_TOUT );

        private const int ELCON_CTL_ENABLE = 0x00;
        private const int ELCON_CTL_DISABLE = 0x01;

        private const float ELCON_MAX_CURR = 46.0f;         // 46 amps        
        private const float ELCON_MAX_VTG = 198.0f;         // 198 volts
        private const float ELCON_EFFICIENCY = 0.9f;		// 90% efficient at 1kW, apparently higher at higher power
        private const float ELCON_MAX_PWR = 6600.0f;		// Charger max power (Assuming unity power factor)        
    
        private CanService canService;

        private Boolean chargeOutputOn = false;

        private float voltageRequested = 0;
        private float currentRequested = 0;
        private float chargerVoltage = 0;
        private float chargerCurrent = 0;
        private int chargerStatus = 0;
        private float supplyCurrentLimit = 0;
        private float supplyVoltageLimit = 0;
        private float chargerCurrentLimit = ELCON_MAX_CURR;
        private float chargerPowerLimit = ELCON_MAX_PWR;
        private float chargerVoltageLimit = ELCON_MAX_VTG;

        public float VoltageRequested
        {
            get { return voltageRequested; }
            set
            {
                voltageRequested = value;
                if (voltageRequested > ChargerVoltageLimit)
                    chargerVoltage = ChargerVoltageLimit;
                else
                    chargerVoltage = value;                
            }
        }
        public float CurrentRequested
        {
            get { return currentRequested;  }
            set
            {
                currentRequested = value;
                if (currentRequested > ChargerCurrentLimit)
                    chargerCurrent = ChargerCurrentLimit;
                else
                    chargerCurrent = value;
            }
        }
        public float ChargerVoltage { get { return chargerVoltage; } }
        public float ChargerCurrent { get { return chargerCurrent; } }

        public int ChargerStatus { get { return chargerStatus; } }
        public float SupplyVoltageLimit
        {
            get
            {
                return supplyVoltageLimit;
            }
            set
            {
                supplyVoltageLimit = value;
                if (supplyVoltageLimit < ChargerVoltageLimit) chargerVoltageLimit = supplyVoltageLimit;
                ChangeSupplyCurrentOrVoltageLimit(supplyCurrentLimit, SupplyVoltageLimit);
            }
        }
        public float SupplyCurrentLimit
        {
            get
            {
                return supplyCurrentLimit;
            }
            set
            {
                supplyCurrentLimit = value;
                if (supplyCurrentLimit < ChargerCurrentLimit) chargerCurrentLimit = supplyCurrentLimit;
                ChangeSupplyCurrentOrVoltageLimit(supplyCurrentLimit, SupplyVoltageLimit);
            }
        }
        public float ChargerVoltageLimit { get { return chargerVoltageLimit; } }
        public float ChargerCurrentLimit { get { return chargerCurrentLimit; } }
        public float ChargerPowerLimit { get { return chargerPowerLimit; } }
        public float ChargerEfficiency { get; } = ELCON_EFFICIENCY; // 90% efficient at 1kW, apparently higher at higher power   

        public bool IsCharging { get { return chargeOutputOn; } }
        public bool IsHardwareOk { get { return (ChargerStatus & ELCON_STAT_HWFAIL) == 0; } }
        public bool IsTempOk { get { return (ChargerStatus & ELCON_STAT_OTERR) == 0; } }
        public bool IsCommsOk { get { return (ChargerStatus & ELCON_STAT_TOUT) == 0; } }
        public bool IsACOk { get { return (ChargerStatus & ELCON_STAT_ACFAIL) == 0; } }    
        public bool IsDCOk { get { return (ChargerStatus & ELCON_STAT_NODCV) == 0; } }

        public ElconService(CanService canService, float supplyVoltageLimit, float supplyCurrentLimit)
        {            
            this.canService = canService;
            SupplyVoltageLimit = supplyVoltageLimit;
            SupplyCurrentLimit = supplyCurrentLimit;
        }

        private void PacketReceived(CanReceivedEventArgs e)
        {
            CanPacket cp = e.Message;
            ReceiveCan(cp);
        }

        private void ReceiveCan(CanPacket cp)
        {
            // Elcon uses big endian
            cp.IsLittleEndian = false;

            Boolean gotStatusMessage = false;

            try
            {
                switch (cp.CanIdBase10)
                {
                    case ELCON_CAN_STATUS: // 0x18FF50E5
                        chargerVoltage = (float)cp.GetUInt16(0) / 10.0f;
                        chargerCurrent = (float)cp.GetUInt16(1) / 10.0f;

                        // Calculate and send updated dynamic current limit based on pack voltage
                        if (chargerVoltage > 0.0f)
                        {
                            chargerCurrentLimit = ChargerPowerLimit / chargerVoltage;

                            if (chargerCurrentLimit > ELCON_MAX_CURR)
                            {
                                chargerCurrentLimit = ELCON_MAX_CURR;
                            }
                        }

                        // Get status flags
                        chargerStatus = cp.GetInt8(3);
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
                elconCommand.SetUInt16(0, (UInt16)(voltageRequested * 10));

                // Update current requested by the ChargeService
                elconCommand.SetUInt16(1, (UInt16)(currentRequested * 10));

                canService.SendMessage(elconCommand);
            }
        }

        public void ChangeSupplyCurrentOrVoltageLimit(float supplyCurrentLimit, float supplyVoltageLimit)
        {
            
            chargerPowerLimit = SupplyVoltageLimit * SupplyCurrentLimit;
            if (chargerPowerLimit > ELCON_MAX_PWR)
            {
                chargerPowerLimit = ELCON_MAX_PWR;
            }

            // Derate maximum power by the chargers efficiency
            chargerPowerLimit *= ELCON_EFFICIENCY;
        }
    
        public void StartCharge()
        {
            this.canService.CanUpdateEventHandler += new CanUpdateEventHandler(PacketReceived);
            this.chargeOutputOn = true;
        }

        public void StopCharge()
        {
            canService.CanUpdateEventHandler -= new CanUpdateEventHandler(PacketReceived);

            // We use the receipt of the status message to send the charger the latest power details
            CanPacket elconCommand = new CanPacket(ELCON_CAN_COMMAND)
            {
                IsLittleEndian = false
            };

            // Update voltage requested to 0
            elconCommand.SetUInt16(3, (UInt16)(0));

            // Update current requested to 0
            elconCommand.SetUInt16(2, (UInt16)(0));

            canService.SendMessage(elconCommand);

            this.chargeOutputOn = false;
        }

    }
}
