using ArrowPointCANBusTool.CanBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrowWareDiagnosticTool.Charger
{
    public class ChargeService
    {
        private UdpService udpService;        
        private BatteryService batteryService;
        private ElconService elconService;

        public ChargeService(UdpService udpService) {
            this.udpService = udpService;            
            this.udpService.UdpReceiver().CarDataEventHandler += new UdpReceivedEventHandler(packetReceived);

            this.batteryService = new BatteryService(udpService);
            this.elconService = new ElconService(udpService);
        }

        private void receiveCan(CanPacket cp)
        {
            /*try
            {
                switch (cp.canIdBase10)
                {
                }
            } catch {
                //Let it go, let it go. Can't hold it back anymore...
            }*/
        }

        private void packetReceived(UdpReceivedEventArgs e)
        {
            CanPacket cp = e.Message;
            receiveCan(cp);
        }

        public void Detach()
        {
            // Detach the event and delete the list
            udpService.UdpReceiver().ReceiverFormEventHandler -= new UdpReceivedEventHandler(packetReceived);            
        }

        public void startCharge()
        {
            elconService.start();
        }

        public void stopCharge()
        {
            elconService.stop();
        }


    }
}
