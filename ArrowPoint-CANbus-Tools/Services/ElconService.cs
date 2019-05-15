
using ArrowPointCANBusTool.CanBus;
using ArrowPointCANBusTool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ArrowPointCANBusTool.Services.UdpService;

namespace ArrowPointCANBusTool.Charger
{
    public class ElconService
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

        private const int ELCON_CTL_ENABLE= 0x00;
        private const int ELCON_CTL_DISABLE = 0x01;

        private const float ELCON_MAX_CURR = 46.0f;
        private const float ELCON_MAX_VTG = 198.0f;
        private const float ELCON_EFFICIENCY = 0.9f;		// 90% efficient at 1kW, apparently higher at higher power
        private const float ELCON_MAX_PWR = 6600.0f;	// Charger max power (Assuming unity power factor)
        private const float GRID_VOLTAGE = 230.0f;      // Assuming RMS grid voltage is at 230V

        private static readonly float[] currLims = { 8.0f, 9.0f, 10.0f, 11.0f, 12.0f, 13.0f, 14.0f, 15.0f, 16.0f, 17.0f, 18.0f, 19.0f, 20.0f, 21.0f, 22.0f, 30.0f, 31.0f, 32.0f, 33.0f, 34.0f };

        private UdpService udpService;

        private Boolean chargeOutputOn = false;

        private Timer timer;

        private float VoltageRequested { get; set; } = 0;
        private float CurrentRequested { get; set; } = 0;
        private float ChargerDynamicVoltage { get; set; } = 0;
        private float ChargerDynamicCurrent { get; set; } = 0;
        private float ChargerStatus { get; set; } = 0;
        private float ChargerVoltageLimit { get; set; } = 0;
        private float ChargerCurrentLimit { get; set; } = 0;
        private float ChargerPowerLimit { get; set; } = 0;
        private float VoltageLimit { get; set; } = 0;
        private float CurrentLimit { get; set; } = 0;
    
        private CanPacket ElconControlPacket { get; set; } = new CanPacket((int)ELCON_CAN_COMMAND); // 0x1806E5F4

        public ElconService(UdpService udpService)
        {            
            this.udpService = udpService;
            this.udpService.UdpReceiverEventHandler += new UdpReceivedEventHandler(PacketReceived);
        }

        private void ReceiveCan(CanPacket cp)
        {
            try
            {
                switch (cp.CanIdBase10)
                {
                    case ELCON_CAN_COMMAND: // 0x1806E5F4
                        ChargerDynamicCurrent = cp.GetInt8(1);
                        ChargerDynamicVoltage = cp.GetInt8(2);
                        ChargerStatus = cp.GetInt8(3);                        
                        break;
                }
            }
            catch
            {
                //Let it go, let it go. Can't hold it back anymore...
            }
        }

        private void PacketReceived(UdpReceivedEventArgs e)
        {
            CanPacket cp = e.Message;

            ReceiveCan(cp);
        }

        public void Detach()
        {
            // Detach the event and delete the list
            udpService.UdpReceiverEventHandler -= new UdpReceivedEventHandler(PacketReceived);
            
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (!this.chargeOutputOn) return;

//            ElconControlPacket.SetInt8(3, CurrentRequested);
//            ElconControlPacket.SetInt8(2, VoltageRequested);
            udpService.SendMessage(this.ElconControlPacket);
        }

        public float GetDynamicCurrent()
        {
            return ChargerDynamicCurrent;
        }

        public Boolean IsOutputOn()
        {
            return chargeOutputOn;
        }

        public void StartCharge()
        {
            // Timer to keep the Elcon charger alive
            if (timer != null) timer.Stop();
            timer = new Timer
            {
                Interval = (100)
            };
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();

            this.chargeOutputOn = true;
        }

        public void StopCharge()
        {
            timer.Stop();
            timer = null;

            this.chargeOutputOn = false;
        }


    }
}
