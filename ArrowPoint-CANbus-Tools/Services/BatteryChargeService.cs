﻿
using ArrowPointCANBusTool.Services;
using System;
using System.Timers;

namespace ArrowPointCANBusTool.Charger
{
    public class BatteryChargeService
    {
        private readonly CanService canService;
        private readonly ElconService elconService;
        
        private const float GRID_VOLTAGE = 230.0f;      // Assuming RMS grid voltage is at 230V

        public BatteryService Battery { get; set; }

        float BmsCurrentSetpoint = 0;
        float BmsMaxCurrent = 0;
        private int BmsIntegrator = 0;
        private int BMSCellError = 0;
        private const float BmsChargeKI = 2048.0f;

        public float RequestedVoltage { get; set; } = 160.0f;
        public float RequestedCurrent { get; set; } = 1.0f;
        public float SupplyCurrentLimit { get; set; } = 8.0f;

        public float ChargerVoltage
        {
            get
            {
                return elconService.ChargerVoltage;
            }
        }

        public float ChargerCurrent
        {
            get
            {
                return elconService.ChargerCurrent;
            } 
        }


        public BatteryChargeService(CanService canService) {
            this.canService = canService;            
            this.Battery = new BatteryService(canService);
            this.elconService = new ElconService(canService, GRID_VOLTAGE, SupplyCurrentLimit);

            BMSCellError = 0;
            BmsCurrentSetpoint = 0;
            BmsIntegrator = 0;
            BmsMaxCurrent = 0;

            // Move this logic to the receiver
            Timer aTimer = new System.Timers.Timer
            {
                Interval = 100,
                AutoReset = true,
                Enabled = true
            };
            aTimer.Elapsed += TimerTick;
        }

        private void TimerTick(object sender, EventArgs e)
        {            
            if (Battery.IsContactorEngaged() && elconService.IsOutputOn())
            {
                // Integrate the error
                // Check for positive saturation
                //if( BMS_curr_setpoint >= BMS_max_curr ){
                //	// If already positively saturated, only allow a reduction in the integral
                //	if( BMS_cellErr < 0 ) BMS_integrator += BMS_cellErr;
                //}
                //// Check for negative saturation
                //else if( BMS_curr_setpoint <= 0.0 ){
                //	// If already negatively saturated, only allow an increase in the integral
                //	if( BMS_cellErr > 0 ) BMS_integrator += BMS_cellErr;
                //}
                //// We're in the middle operating region, with the output command not saturated
                //else{

                BMSCellError = Battery.MinChargeCellError();
                BmsIntegrator += (BMSCellError + 25);
                //}
                // Scale and limit command
                BmsCurrentSetpoint = ((float)BmsIntegrator) / BmsChargeKI;        // I-term scaling

                Console.WriteLine("BMSCellError:" + BMSCellError + ", BMSIntegrator:" + BmsIntegrator.ToString());

                // Check for negative saturation
                if (BmsCurrentSetpoint < 0.0)
                {
                    Console.WriteLine("Setting Integrator to Zero");
                    BmsCurrentSetpoint = 0;
                    BmsIntegrator = 0;
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
                if (BmsCurrentSetpoint > BmsMaxCurrent)
                {
                    Console.WriteLine("BMS Greater than MaxCurrent, BmsIntegrator:" + BmsIntegrator);
                    BmsCurrentSetpoint = BmsMaxCurrent;
                    BmsIntegrator = (int)(BmsMaxCurrent * BmsChargeKI);
                    Console.WriteLine("BMS Greater than MaxCurrent, new BmsIntegrator:" + BmsIntegrator);
                }

                // This is messy improve this code
                RequestedCurrent = BmsCurrentSetpoint;
                elconService.CurrentRequested = RequestedCurrent;
            }
        }        

        public Boolean IsCharging()
        {
            return Battery.IsContactorEngaged() && elconService.IsOutputOn();
        }

        public Boolean StartCharge()
        {

            BMSCellError = 0;
            BmsCurrentSetpoint = 0;
            BmsIntegrator = 0;

            if (RequestedCurrent > 0.0 && RequestedCurrent <= elconService.ChargerCurrentLimit)
                BmsMaxCurrent = RequestedCurrent;
            else
                BmsMaxCurrent = elconService.ChargerCurrentLimit;
            
            elconService.VoltageRequested = this.RequestedVoltage;
            elconService.CurrentRequested = this.RequestedCurrent;
            elconService.SupplyCurrentLimit = this.SupplyCurrentLimit;

            Battery.EngageContactors();
            elconService.StartCharge();

            return true;
        }        


        public Boolean StopCharge()
        {
            elconService.StopCharge();       
            Battery.DisengageContactors();

            return true;
        }

        public void Detach()
        {
            Battery.Detach();
            elconService.Detach();
        }

    }
}