
using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Model;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Services
{
    public class BatteryChargeService
    {
        private static readonly BatteryChargeService instance = new BatteryChargeService();

        public const int STOP_REASON_UNKNOWN = 0;
        public const int STOP_REASON_ERROR = 1;
        public const int STOP_REASON_OVERHEAT = 2;
        public const int STOP_REASON_USER_REQUESTED = 3;
        public const int STOP_REASON_FULLY_CHARGED = 4;

        private const float GRID_VOLTAGE = 230.0f;      // Assuming RMS grid voltage is at 230V
        private const float BMS_CHARGE_KI = 2048.0f;
        
        public IChargerInterface ChargerService { get; private set; }

        private float latestChargeCurrent = 0;
        private float maxAvailableCurrent = 0;
        private float requestedCurrent = 5.0f;
        private float requestedVoltage = 160.0f;
        private int stopReason = STOP_REASON_UNKNOWN;

        private int batteryIntegrator = 0;

        private CancellationTokenSource listenerCts;

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

        public float ChargerActualVoltage
        {
            get
            {
                return ChargerService.ActualVoltage;
            }
        }

        public float ChargerActualCurrent
        {
            get
            {
                return ChargerService.ActualCurrent;
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

            latestChargeCurrent = 0;
            maxAvailableCurrent = 0;            
        }

        public void SetCharger(IChargerInterface charger)
        {
            ChargerService = charger;
            ChargerService.SupplyVoltageLimit = GRID_VOLTAGE;
            ChargerService.SupplyCurrentLimit = this.SupplyCurrentLimit;
        }

        private void StartTimer()
        {
            if (!UseTimerUpdateLoop) return;

            if (listenerCts == null || listenerCts.IsCancellationRequested)
            {
                listenerCts = new CancellationTokenSource();

                ThreadPool.QueueUserWorkItem(new WaitCallback(ChargerUpdate), listenerCts.Token);
            }
        }

        private void StopTimer()
        {
            listenerCts?.Cancel();
        }

        private async Task SafeStateAsync()
        {
            // Does the necessary checks to ensure that the system is in a safe state
            // If we are not charging then make sure everything is switched off
            //if (!IsCharging)
              //  StopCharge();

            if (BatteryService.State >= CanControl.STATE_FAILURE || ChargerService.State >= CanControl.STATE_FAILURE)
                await StopCharge();
        }

        public async void ChargerUpdateInner() 
        {

            await SafeStateAsync();

            if (IsCharging)
            {

                // Check to make sure we are still getting data from the battery and the charger
                // and that they are both in a good state
                if (!(BatteryService.State == CanReceivingNode.STATE_ON || BatteryService.State == CanReceivingNode.STATE_WARNING) || ChargerService.State != CanReceivingNode.STATE_ON)
                {
                    await StopCharge();
                    return;
                }

                // Check if we have reached either of our two charge to thresholds
                // if so, stop the charge
                // If charge to percentage is set to 100, we don't stop here as we want to balance the pack
                // and at the top of the pack tge percentage is not accurate until the pack is fully balanced
                if ((BatteryService.BatteryData.SOCPercentage * 100 >= ChargeToPercentage && ChargeToPercentage < 100) ||
                    BatteryService.BatteryData.BatteryVoltage / 1000 >= ChargeToVoltage)
                {
                    await StopCharge();
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

        private void ChargerUpdate(object obj)
        {
            CancellationToken token = (CancellationToken)obj;

            while (true)
            {
                if (token.IsCancellationRequested) break;
                ChargerUpdateInner();
                Thread.Sleep(1000);
            }
        }

        public Boolean IsHardwareOk { get { return ChargerService.IsHardwareOk; } }
        public Boolean IsTempOk { get { return ChargerService.IsTempOk; } }
        public Boolean IsCommsOk { get { return ChargerService.IsCommsOk; } }
        public Boolean IsACOk { get { return ChargerService.IsACOk; } }
        public Boolean IsDCOk { get { return ChargerService.IsDCOk; } }

        public Boolean IsCharging {
            get
            {
                bool isCharging = BatteryService.IsContactorsEngaged && ChargerService.IsCharging;

                // Just a safety to ensure that if we are charging, then we are not precharging, can't be in both states at once
                // Charging has priority
                if (isCharging) IsPrecharging = false;

                return isCharging;
            }
        }

        public Boolean IsPrecharging { get; private set; } = false;

        public int ChargeStopReason
        {
            get
            {
                return stopReason;
            }
        }

        public Boolean IsFullyCharged
        {
            get
            {
                return (IsCharging == false && ChargeStopReason == STOP_REASON_FULLY_CHARGED);
            }
        }

        public uint ChargerState { get { return ChargerService.State; } }
        public string ChargerStateMessage { get { return ChargerService.StateMessage; } }
        public uint BatteryState { get { return BatteryService.State; } }
        public string BatteryStateMessage { get { return BatteryService.StateMessage; } }
        
        public async Task<bool> StartCharge()
        {

            IsPrecharging = true;

            latestChargeCurrent = 0;

            // Send 50ma so that the voltage can be measured
            ChargerService.RequestedVoltage = RequestedVoltage;
            ChargerService.RequestedCurrent = 0.05f;

            ChargerService.SupplyCurrentLimit = SupplyCurrentLimit;
            batteryIntegrator = 0;

            ChargerService.StopCharge();

            if (await ChargerService.WaitUntilChargerStopped(1000) == false) return false;            

            ChargerService.RequestedVoltage = BatteryService.BatteryData.EstimatePackVoltageFromCMUs / 1000;
            ChargerService.StartCharge();

            if (await ChargerService.WaitUntilChargerStarted(3000) == false ||
                await ChargerService.WaitUntilVoltageReached(RequestedVoltage, 10, 10000) == false)
            {
                await StopCharge();
                return false;
            }
             
            await BatteryService.EngageContactors();

            if (await BatteryService.WaitUntilContactorsEngage(10000) == false)
            {
                await StopCharge();
                return false;
            }
    
            StartTimer();

            IsPrecharging = false;

            return true;
        }        

        public async Task<bool> StopCharge()
        {

            IsPrecharging = false;

            ChargerService.StopCharge();

            if (!await ChargerService.WaitUntilChargerStopped(3000)) return false;
            
            BatteryService.DisengageContactors();

            if (!await BatteryService.WaitUntilContactorsDisengage(3000)) return false;

            StopTimer();

            return true;
        }

        public async Task<bool> WaitUntilFullCharged(int timeoutSeconds)
        {
            int timer = 0;

            while (timer < timeoutSeconds * 1000)
            {
                if (IsFullyCharged) return (true);
                await Task.Delay(1000);
                timer += 1000;
            }

            return false;
        }

    }
}
