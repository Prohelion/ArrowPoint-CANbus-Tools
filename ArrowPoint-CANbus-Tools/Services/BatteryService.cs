using ArrowPointCANBusTool.CanBus;
using ArrowPointCANBusTool.Model;
using ArrowPointCANBusTool.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Services
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

        public BMU GetBMU(int index)
        {
            return battery.GetBMU(index);
        }

        public void Detach()
        {
            // Detach the event and delete the list
            udpService.UdpReceiver().UdpReceiverEventHandler -= new UdpReceivedEventHandler(PacketReceived);
        }

        private void PacketReceived(UdpReceivedEventArgs e)
        {
            CanPacket canPacket = e.Message;
            try
            {
                battery.Update(canPacket);
            } catch (Exception ex)
            {
                int hello = 1;
            }
        }        
    }
}
