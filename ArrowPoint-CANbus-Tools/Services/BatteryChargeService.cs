
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
        private static readonly BatteryChargeService instance = new BatteryChargeService();

        private const float GRID_VOLTAGE = 230.0f;      // Assuming RMS grid voltage is at 230V
        private const float BMS_CHARGE_KI = 2048.0f;
        
        public IChargerInterface ChargerService { get; set; }

        private float latestChargeCurrent = 0;
        private float maxAvailableCurrent = 0;
        private float requestedCurrent = 5.0f;
        private float requestedVoltage = 160.0f;

        private int batteryIntegrator = 0;

        private Timer chargerUpdateTimer;

        public bool UseTimerUpdateLoop { get; set; } = true;

        public BatteryService BatteryService { get; private set; }        
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
                if (requestedCurrent > 0.0 && requestedCurrent <= ChargerService.ChargerCurrentLimit)
                    maxAvailableCurrent = requestedCurrent;
                else
                    maxAvailableCurrent = ChargerService.ChargerCurrentLimit;
            }
        }
        public float SupplyCurrentLimit { get; set; } = 10.0f;

        public float ChargerVoltage
        {
            get
            {
                return ChargerService.ChargerVoltage;
            }
        }

        public float ChargerCurrent
        {
            get
            {
                return ChargerService.ChargerCurrent;
            } 
        }


        static BatteryChargeService()
        {
        }

        public static BatteryChargeService Instance
        {
            get
            {
                return instance;
            }
        }

        public static BatteryChargeService NewInstance
        {
            get
            {
                BatteryChargeService batteryChargeService = new BatteryChargeService
                {
                    BatteryService = BatteryService.NewInstance
                };
                return batteryChargeService;
            }
        }

        private BatteryChargeService() {
            this.BatteryService = BatteryService.Instance;
            ChargerService = ElconService.Instance;
            ChargerService.SupplyVoltageLimit = GRID_VOLTAGE;
            ChargerService.SupplyCurrentLimit = this.SupplyCurrentLimit;            

            latestChargeCurrent = 0;
            maxAvailableCurrent = 0;            
        }

        private void StartTimer()
        {
            if (!UseTimerUpdateLoop) return;

            chargerUpdateTimer = new System.Timers.Timer
            {
                Interval = 100,
                AutoReset = true,
                Enabled = true
            };
            chargerUpdateTimer.Elapsed += ChargerUpdate;
        }

        private void StopTimer()
        {
            chargerUpdateTimer?.Stop();
        }

        public void ChargerUpdateInner() 
        {
            if (IsCharging)
            {

                // Check to make sure we are still getting data from the battery and the charger
                // and that they are both in a good state
                if (BatteryService.State != CanReceivingNode.STATE_ON || ChargerService.State != CanReceivingNode.STATE_ON)
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
                    batteryIntegrator += (batteryCellError + 25);

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

                ChargerService.RequestedVoltage = this.RequestedVoltage;
                ChargerService.RequestedCurrent = this.latestChargeCurrent;
                ChargerService.SupplyCurrentLimit = this.SupplyCurrentLimit;
            }
        }

        private void ChargerUpdate(object sender, EventArgs e)
        {
            ChargerUpdateInner();
        }

        public Boolean IsHardwareOk { get { return ChargerService.IsHardwareOk; } }
        public Boolean IsTempOk { get { return ChargerService.IsTempOk; } }
        public Boolean IsCommsOk { get { return ChargerService.IsCommsOk; } }
        public Boolean IsACOk { get { return ChargerService.IsACOk; } }
        public Boolean IsDCOk { get { return ChargerService.IsDCOk; } }
        public Boolean IsCharging {
            get
            {
                return BatteryService.IsContactorsEngaged && ChargerService.IsCharging;
            }
        }

        public uint ChargerState { get { return ChargerService.State; } }
        public string ChargerStateMessage { get { return ChargerService.StateMessage; } }
        public uint BatteryState { get { return BatteryService.State; } }
        public string BatteryStateMessage { get { return BatteryService.StateMessage; } }
        
        public void StartCharge()
        {

            latestChargeCurrent = 0;                      
            ChargerService.RequestedVoltage = 0;
            ChargerService.RequestedCurrent = latestChargeCurrent;
            ChargerService.SupplyCurrentLimit = SupplyCurrentLimit;
            batteryIntegrator = 0;

            StartTimer();

            BatteryService.EngageContactors();
            ChargerService.StartCharge();
        }        

        public void StopCharge()
        {
            ChargerService.StopCharge();       
            BatteryService.DisengageContactors();

            StopTimer();
        } 
        
        public void ShutdownCharge()
        {
            StopCharge();
        }

    }
}
