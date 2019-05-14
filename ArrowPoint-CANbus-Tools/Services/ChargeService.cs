
using ArrowPointCANBusTool.Services;
using System;
using System.Timers;

namespace ArrowPointCANBusTool.Charger
{
    public class ChargeService
    {
        private UdpService udpService;        
        private BatteryService batteryService;
        private ElconService elconService;
        
        float BMS_curr_setpoint;
        float BMS_max_curr;
        int BMS_integrator;
        int BMS_cellErr;
        int[] BMS_cellErrors = new int[4];
        float BMS_CHARGE_KI = 2048.0f;

        public ChargeService(UdpService udpService) {
            this.udpService = udpService;            
            this.batteryService = new BatteryService(udpService);
            this.elconService = new ElconService(udpService);

            BMS_cellErr = 0;
            BMS_curr_setpoint = 0;
            BMS_integrator = 0;
            BMS_max_curr = 0;

            // Move this logic to the receiver
            Timer aTimer = new System.Timers.Timer();
            aTimer.Interval = 100;
            aTimer.Elapsed += timerTick;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void timerTick(object sender, EventArgs e)
        {
            float maxCurrent = 0;

            if (batteryService.IsContactorEngaged() && elconService.IsOutputOn())
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

                BMS_cellErr = batteryService.MinChargeCellError();
                BMS_integrator += (BMS_cellErr + 25);
                //}
                // Scale and limit command
                BMS_curr_setpoint = ((float)BMS_integrator) / BMS_CHARGE_KI;        // I-term scaling

                // Check for negative saturation
                if (BMS_curr_setpoint < 0.0)
                {
                    BMS_curr_setpoint = 0;
                    BMS_integrator = 0;
                }

                // Update maximum current
                if ((elconService.GetDynamicCurrent() > 0) && (elconService.GetDynamicCurrent() < BMS_max_curr))
                {
                    maxCurrent = elconService.GetDynamicCurrent();
                }
                else
                {
                    maxCurrent = BMS_max_curr;
                }

                // Check for positive saturation
                if (BMS_curr_setpoint > maxCurrent)
                {
                    BMS_curr_setpoint = maxCurrent;
                    BMS_integrator = (int)(maxCurrent * BMS_CHARGE_KI);
                }

                // Transmit to charger
                /*str.Format("%0.2f", BMS_curr_setpoint);
                m_curSpCtl.SetWindowText(str);
                OnBnClickedPsuset();*/
            }

        }

        public Boolean IsCharging()
        {
            return batteryService.IsContactorEngaged() && elconService.IsOutputOn();
        }

        public Boolean StartCharge()
        {

            BMS_cellErr = 0;
            BMS_curr_setpoint = 0;
            BMS_integrator = 0;            

            // Just stubs at this point
            batteryService.EngageContactors();
            
            elconService.StartCharge();

            return true;
        }

        public Boolean StopCharge()
        {
            elconService.StopCharge();
       
            batteryService.DisengageContactors();

            return true;
        }


        public void Detach()
        {
            batteryService.Detach();
            elconService.Detach();
        }

    }
}
