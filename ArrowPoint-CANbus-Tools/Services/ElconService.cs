
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
        private const int ELCON_CAN_STATUS = (int)0x18FF50E5ul;
        private const int ELCON_CAN_COMMAND = (int)0x1806E5F4ul;

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
        private const float GRID_VOLTAGE = 230.0f;	
    
        private CanService canService;

        private Boolean chargeOutputOn = false;                

        public float VoltageRequested { get; set; } = 0;
        public float CurrentRequested { get; set; } = 0;
        public float ChargerVoltage { get; set; } = 0;
        public float ChargerCurrent { get; set; } = 0;
        public int ChargerStatus { get; set; } = 0;
        public float SupplyVoltageLimit { get; set; } = 0;
        public float SupplyCurrentLimit { get; set; } = 0;

        public float ChargerVoltageLimit { get; } = ELCON_MAX_VTG;  
        public float ChargerCurrentLimit { get; set; } = ELCON_MAX_CURR; 
        public float ChargerPowerLimit { get; set; } = ELCON_MAX_PWR;	// Charger max power (Assuming unity power factor)
        public float ChargerEfficiency { get; } = ELCON_EFFICIENCY; // 90% efficient at 1kW, apparently higher at higher power                

        public ElconService(CanService canService, float supplyVoltageLimit, float supplyCurrentLimit)
        {            
            this.canService = canService;
            SupplyVoltageLimit = supplyVoltageLimit;
            SupplyCurrentLimit = supplyCurrentLimit;

            // TO do, this should not be able to be missing, setting the supply current affects the supply power
            ChangeSupplyCurrentLimit(supplyCurrentLimit);         
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
                        ChargerVoltage = (float)cp.GetUInt16(0) / 10.0f;
                        ChargerCurrent = (float)cp.GetUInt16(1) / 10.0f;

                        // Calculate and send updated dynamic current limit based on pack voltage
                        if (ChargerVoltage > 0.0f)
                        {
                            ChargerCurrentLimit = ChargerPowerLimit / ChargerVoltage;

                            if (ChargerCurrentLimit > ELCON_MAX_CURR)
                            {
                                ChargerCurrentLimit = ELCON_MAX_CURR;
                            }
                        }

                        // Get status flags
                        ChargerStatus = cp.GetInt8(3);
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
                float chargeVoltage = VoltageRequested;
                if (chargeVoltage > ChargerVoltageLimit) chargeVoltage = ChargerVoltageLimit;

                elconCommand.SetUInt16(0, (UInt16)(VoltageRequested * 10));

                // Update current requested by the ChargeService
                // Check we are not exceeding maximum allowable charge
                float chargeCurrent = CurrentRequested;
                if (chargeCurrent > ChargerCurrentLimit) chargeCurrent = ChargerCurrentLimit;
                elconCommand.SetUInt16(1, (UInt16)(chargeCurrent * 10));

                canService.SendMessage(elconCommand);
            }
        }

        public void ChangeSupplyCurrentLimit(float supplyCurrentLimit)
        {
            ChargerPowerLimit = GRID_VOLTAGE * supplyCurrentLimit;
            if (ChargerPowerLimit > ELCON_MAX_PWR)
            {
                ChargerPowerLimit = ELCON_MAX_PWR;
            }

            // Derate maximum power by the chargers efficiency
            ChargerPowerLimit *= ELCON_EFFICIENCY;
        }
    
        public void Detach()
        {
            StopCharge();
        }

        public Boolean IsOutputOn()
        {
            return chargeOutputOn;
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
