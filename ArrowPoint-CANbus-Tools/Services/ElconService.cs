
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
        private UdpService udpService;

        private Boolean ChargeOutputOn = false;

        private Timer timer;

        private int voltageRequested { get; set; } = 0;
        private int currentRequested { get; set; } = 0;

        private int chargerDynamicVoltage { get; set; } = 0;
        private int chargerDynamicCurrent { get; set; } = 0;
        private int chargerStatus { get; set; } = 0;

        private int chargerMaxVoltage { get; set; } = 0;
        private int chargerMaxCurrent { get; set; } = 0;
    
        private CanPacket elconControlPacket = new CanPacket(403105268); // 0x1806E5F4

        public ElconService(UdpService udpService)
        {            
            this.udpService = udpService;
            this.udpService.UdpReceiverEventHandler += new UdpReceivedEventHandler(packetReceived);
        }

        private void receiveCan(CanPacket cp)
        {
            try
            {
                switch (cp.canIdBase10)
                {
                    case 403105268: // 0x1806E5F4
                        this.chargerDynamicCurrent = cp.getInt8(1);
                        this.chargerDynamicVoltage = cp.getInt8(2);
                        this.chargerStatus = cp.getInt8(3);                        
                        break;
                }
            }
            catch
            {
                //Let it go, let it go. Can't hold it back anymore...
            }
        }

        private void packetReceived(UdpReceivedEventArgs e)
        {
            CanPacket cp = e.Message;

            receiveCan(cp);
        }

        public void Detach()
        {
            // Detach the event and delete the list
            udpService.UdpReceiverEventHandler -= new UdpReceivedEventHandler(packetReceived);
            
        }

        private void timerTick(object sender, EventArgs e)
        {
            if (!this.ChargeOutputOn) return;

            this.elconControlPacket.setInt8(3, this.currentRequested);
            this.elconControlPacket.setInt8(2, this.voltageRequested);
            udpService.SendMessage(this.elconControlPacket);
        }


        public int GetDynamicCurrent()
        {
            return chargerDynamicCurrent;
        }

        public Boolean IsOutputOn()
        {
            return ChargeOutputOn;
        }

        public void StartCharge()
        {
            // Timer to keep the Elcon charger alive
            if (timer != null) timer.Stop();
            timer = new Timer();
            timer.Interval = (100);
            timer.Tick += new EventHandler(timerTick);
            timer.Start();

            this.ChargeOutputOn = true;
        }

        public void StopCharge()
        {
            timer.Stop();
            timer = null;

            this.ChargeOutputOn = false;

        }


    }
}
