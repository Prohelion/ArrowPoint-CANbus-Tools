using ArrowPointCANBusTool.CanBus;
using ArrowPointCANBusTool.Model;
using ArrowPointCANBusTool.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrowPointCANBusTool.Services
{
    class BatteryService
    {

        private UdpService udpService;
        private Battery battery;

        private Timer timer;

        private Boolean contactorsEngaged = false;

        public BatteryService(UdpService udpService)
        {
            this.udpService = udpService;
            this.udpService.UdpReceiver().UdpReceiverEventHandler += new UdpReceivedEventHandler(PacketReceived);
            this.battery = new Battery();

            timer = new Timer();
            timer.Interval = 50;
            timer.Tick += new EventHandler(timerTick);
            timer.Start();
        }


        private void timerTick(object sender, EventArgs e)
        {
            CanPacket ControlPacket500 = new CanPacket(1280); // 0x500
            CanPacket ControlPacket505 = new CanPacket(1285); // 0x505

            if (this.contactorsEngaged)
            {
                ControlPacket505.setInt8(0, 114);
            } else
            {
                ControlPacket505.setInt8(0, 2);
            }
            ControlPacket500.setInt16(0, 4098);
            ControlPacket500.setInt16(2, 1);

            udpService.SendMessage(ControlPacket500);
            udpService.SendMessage(ControlPacket505);
        }


        public BMU GetBMU(int index)
        {
            return battery.GetBMU(index);
        }

        public void EngageContactors()
        {
            this.contactorsEngaged = true;
        }

        public void DisengageContactors()
        {
            this.contactorsEngaged = false;
        }        

        public bool IsContactorEngaged()
        {
            return contactorsEngaged;
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
