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

        private Boolean chargeEngaged = false;

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

        public void EngageContactors()
        {

        }

        public void DisengageContactors()
        {



        }        

        public bool IsChargeEngaged()
        {
            return chargeEngaged;
        }

        public int MinChargeCellError()
        {
            int minCellError = int.MaxValue;

            foreach (BMU bmu in battery.GetBMUs())
            {
                if (bmu.ChargeCellVoltageError < minCellError)
                    minCellError = bmu.ChargeCellVoltageError;
            }

            return minCellError;
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
                Console.Write(ex.StackTrace);
            }
        }        
    }
}
