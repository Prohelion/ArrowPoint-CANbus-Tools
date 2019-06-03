
using ArrowPointCANBusTool.Services;
using System;
using System.Timers;

namespace ArrowPointCANBusTool.Charger
{
    public class BatteryChargeService
    {
        private const float GRID_VOLTAGE = 230.0f;      // Assuming RMS grid voltage is at 230V
        private const float BMS_CHARGE_KI = 2048.0f;

        private readonly CanService canService;
        private readonly IChargerInterface chargerService;
                
        private float latestChargeCurrent = 0;
        private float maxAvailableCurrent = 0;
        private int batteryIntegrator = 0;
        private int batteryCellError = 0;
        private float requestedCurrent = 5.0f;
        private float requestedVoltage = 160.0f;

        public BatteryService Battery { get; }
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


        public BatteryChargeService(CanService canService) {
            this.canService = canService;            
            this.Battery = new BatteryService(canService);
            this.chargerService = new ElconService(canService, GRID_VOLTAGE, SupplyCurrentLimit);

            batteryCellError = 0;
            latestChargeCurrent = 0;
            batteryIntegrator = 0;
            maxAvailableCurrent = 0;

            // Move this logic to the receiver
            Timer aTimer = new System.Timers.Timer
            {
                Interval = 100,
                AutoReset = true,
                Enabled = true
            };
            aTimer.Elapsed += ChargerUpdate;
        }

        private void ChargerUpdate(object sender, EventArgs e)
        {            
            if (Battery.IsContactorEngaged() && chargerService.IsCharging)
            {

                // Check if we have reached either of our two charge to thresholds
                // if so, stop the charge
                if (Battery.GetBMU(0).SOCPercentage >= ChargeToPercentage ||
                    Battery.GetBMU(0).BatteryVoltage * 1000 >= ChargeToVoltage)
                {
                    StopCharge();
                    return;
                }

                batteryCellError = Battery.MinChargeCellError();
                batteryIntegrator += (batteryCellError + 25);

                // Scale and limit command
                latestChargeCurrent = ((float)batteryIntegrator) / BMS_CHARGE_KI;        // I-term scaling

                //Console.WriteLine("BMSCellError:" + bmsCellError + ", BMSIntegrator:" + bmsIntegrator.ToString());

                // Check for negative saturation
                if (latestChargeCurrent < 0.0)
                {
                    //Console.WriteLine("Setting Integrator to Zero");
                    latestChargeCurrent = 0;
                    batteryIntegrator = 0;
                }

                // Update maximum current
                /*if ((elconService.ChargerCurrent > 0) && (elconService.ChargerCurrent < BmsMaxCurrent))
                {
                    // WHy
                    maxCurrent = elconService.ChargerCurrentLimit;
                }
                else
                {
                    maxCurrent = BmsMaxCurrent;
                }*/

                // Check for positive saturation
                if (latestChargeCurrent > maxAvailableCurrent)
                {
                    //Console.WriteLine("BMS Greater than MaxCurrent, BmsIntegrator:" + bmsIntegrator);
                    latestChargeCurrent = maxAvailableCurrent;
                    batteryIntegrator = (int)(maxAvailableCurrent * BMS_CHARGE_KI);
                    //Console.WriteLine("BMS Greater than MaxCurrent, new BmsIntegrator:" + bmsIntegrator);
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

        public Boolean IsCharging()
        {
            return Battery.IsContactorEngaged() && chargerService.IsCharging;
        }

        
        public void StartCharge()
        {

            batteryCellError = 0;
            latestChargeCurrent = 0;
            batteryIntegrator = 0;
                       
            chargerService.VoltageRequested = 0;
            chargerService.CurrentRequested = latestChargeCurrent;
            chargerService.SupplyCurrentLimit = SupplyCurrentLimit;

            Battery.EngageContactors();
            chargerService.StartCharge();
        }        


        public void StopCharge()
        {
            chargerService.StopCharge();       
            Battery.DisengageContactors();

            if (!Battery.IsContactorEngaged())
            {
                Battery.ShutdownService();
            }           
        }        

    }
}
