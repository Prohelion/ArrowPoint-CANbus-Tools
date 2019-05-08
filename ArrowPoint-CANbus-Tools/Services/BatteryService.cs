using ArrowPointCANBusTool.CanBus;
using ArrowPointCANBusTool.Service;
using ArrowWareDiagnosticTool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowWareDiagnosticTool.Services
{
    class BatteryService
    {

        private UdpService udpService;
        private Battery battery;

        public BatteryService(UdpService udpService)
        {
            this.udpService = udpService;
            this.udpService.UdpReceiver().UdpReceiverEventHandler += new UdpReceivedEventHandler(PacketReceived);
            this.battery = new Battery();
        }

        public void Detach()
        {
            // Detach the event and delete the list
            udpService.UdpReceiver().UdpReceiverEventHandler -= new UdpReceivedEventHandler(PacketReceived);
        }

        private void PacketReceived(UdpReceivedEventArgs e)
        {
            CanPacket canPacket = e.Message;
            battery.Update(canPacket);         
        }        
    }
}
