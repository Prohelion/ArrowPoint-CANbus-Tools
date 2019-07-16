
using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Services;
using ArrowPointCANBusTool.Model;
using System;
using System.Collections;
using System.IO;
using System.Timers;

namespace ArrowPointCANBusTool.Services
{
    public class BatteryChargeService
    {
        private const float GRID_VOLTAGE = 230.0f;      // Assuming RMS grid voltage is at 230V
        private const float BMS_CHARGE_KI = 2048.0f;
        
        private readonly IChargerInterface chargerService;

        private float latestChargeCurrent = 0;
        private float maxAvailableCurrent = 0;
        private float requestedCurrent = 5.0f;
        private float requestedVoltage = 160.0f;

        private int batteryIntegrator = 0;

        public BatteryService BatteryService { get; }        
        public float ChargeToPercentage { get; set; } = 100.0f;
        public float ChargeToVoltage { get; set; } = GRID_VOLTAGE;        

        public float RequestedVoltage
        {
            get
            {
                return requestedVoltage;
            }
            set
            {
                requestedVoltage = value;
                if (requestedVoltage > GRID_VOLTAGE) requestedVoltage = GRID_VOLTAGE;
                if (requestedVoltage < 0) requestedVoltage = 0;
            }
        }
        public float RequestedCurrent
        {
            get
            {
                return requestedCurrent;
            }
            set
            {
                requestedCurrent = value;
                if (requestedCurrent > 0.0 && requestedCurrent <= chargerService.ChargerCurrentLimit)
                    maxAvailableCurrent = requestedCurrent;
                else
                    maxAvailableCurrent = chargerService.ChargerCurrentLimit;
            }
        }
        public float SupplyCurrentLimit { get; set; } = 10.0f;

        public float ChargerVoltage
        {
            get
            {
                return chargerService.ChargerVoltage;
            }
        }

        public float ChargerCurrent
        {
            get
            {
                return chargerService.ChargerCurrent;
            } 
        }


        public BatteryChargeService() {
            this.BatteryService = BatteryService.Instance;
            this.chargerService = new ElconService(GRID_VOLTAGE, SupplyCurrentLimit);

            latestChargeCurrent = 0;
            maxAvailableCurrent = 0;
            
            Timer chargerUpdateTimer = new System.Timers.Timer
            {
                Interval = 100,
                AutoReset = true,
                Enabled = true
            };
            chargerUpdateTimer.Elapsed += ChargerUpdate;            
        }


        private void ChargerUpdate(object sender, EventArgs e)
        {
            if (IsCharging)
            {

                // Check to make sure we are still getting data from the battery and the charger
                // and that they are both in a good state
                if (BatteryService.State != CanReceivingNode.STATE_ON || chargerService.State != CanReceivingNode.STATE_ON)
                {
                    StopCharge();
                    return;
                }

                // Check if we have reached either of our two charge to thresholds
                // if so, stop the charge
                // If charge to percentage is set to 100, we don't stop here as we want to balance the pack
                // and at the top of the pack tge percentage is not accurate until the pack is fully balanced
                if ((BatteryService.BatteryData.SOCPercentage * 100 >= ChargeToPercentage && ChargeToPercentage < 100) ||
                    BatteryService.BatteryData.BatteryVoltage / 1000 >= ChargeToVoltage)
                {
                    StopCharge();
                    return;
                }

                // Find the cell error
                int batteryCellError = BatteryService.BatteryData.MinChargeCellVoltageError;

                // Find the temp error with 5 degress less for the integrator
                // Unless we have a temp issue we set this to 0
                int batteryTempError = (BatteryService.BatteryData.MinCellTempMargin * -1) - 50;

                // BatteryTempError gets priority if we are reaching a temp threshold otherwise use batteryCellError
                if (batteryTempError < 0)
                    batteryIntegrator += batteryTempError;
                else
                    batteryIntegrator += (batteryCellError +  25);

                //Console.WriteLine("BMSCellError:" + batteryCellError + ", BatteryTempError: " + batteryTempError + ", BMSIntegrator:" + batteryIntegrator.ToString());

                // Scale and limit command
                latestChargeCurrent = ((float)batteryIntegrator) / BMS_CHARGE_KI;        // I-term scaling

                // Check for negative saturation
                if (latestChargeCurrent < 0.0)
                {
                    //Console.WriteLine("Setting Integrator to Zero");
                    latestChargeCurrent = 0;
                    batteryIntegrator = 0;
                }

                // Check for positive saturation
                if (latestChargeCurrent > maxAvailableCurrent)
                {
                    //Console.WriteLine("BMS Greater than MaxCurrent, BatteryIntegrator:" + batteryIntegrator);
                    latestChargeCurrent = maxAvailableCurrent;
                    batteryIntegrator = (int)(maxAvailableCurrent * BMS_CHARGE_KI);
                    //Console.WriteLine("BMS Greater than MaxCurrent, new BatteryIntegrator:" + batteryIntegrator);
                }

                chargerService.VoltageRequested = this.RequestedVoltage;
                chargerService.CurrentRequested = this.latestChargeCurrent;
                chargerService.SupplyCurrentLimit = this.SupplyCurrentLimit;                
            }
        }

        public Boolean IsHardwareOk { get { return chargerService.IsHardwareOk; } }
        public Boolean IsTempOk { get { return chargerService.IsTempOk; } }
        public Boolean IsCommsOk { get { return chargerService.IsCommsOk; } }
        public Boolean IsACOk { get { return chargerService.IsACOk; } }
        public Boolean IsDCOk { get { return chargerService.IsDCOk; } }
        public Boolean IsCharging {
            get
            {
                return BatteryService.IsContactorsEngaged && chargerService.IsCharging;
            }
        }

        public uint ChargerState { get { return chargerService.State; } }
        public string ChargerStateMessage { get { return chargerService.StateMessage; } }
        public uint BatteryState { get { return BatteryService.State; } }
        public string BatteryStateMessage { get { return BatteryService.StateMessage; } }
        
        public void StartCharge()
        {

            latestChargeCurrent = 0;                      
            chargerService.VoltageRequested = 0;
            chargerService.CurrentRequested = latestChargeCurrent;
            chargerService.SupplyCurrentLimit = SupplyCurrentLimit;
            batteryIntegrator = 0;

            BatteryService.EngageContactors();
            chargerService.StartCharge();
        }        


        public void StopCharge()
        {
            chargerService.StopCharge();       
            BatteryService.DisengageContactors();
        } 
        

        public void ShutdownCharge()
        {
            StopCharge();
        }

    }
}
