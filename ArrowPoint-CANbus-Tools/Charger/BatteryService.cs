using ArrowPointCANBusTool.CanBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrowWareDiagnosticTool.Charger
{
    public class BatteryService
    {
        private UdpService udpService;        

        public BatteryService(UdpService udpService) {
            
            this.udpService = udpService;
            this.udpService.UdpReceiver().CarDataEventHandler += new UdpReceivedEventHandler(packetReceived);
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


    }
}
