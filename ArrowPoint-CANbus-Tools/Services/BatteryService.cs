using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.CanBus;
using ArrowPointCANBusTool.Model;
using System;
using System.Windows.Forms;
using static ArrowPointCANBusTool.Services.CanService;

namespace ArrowPointCANBusTool.Services
{
    public class BatteryService
    {

        private CanService udpService;
        private Battery battery;

        private Boolean contactorsEngaged = false;

        public BatteryService(CanService udpService)
        {
            this.udpService = udpService;
            this.udpService.CanUpdateEventHandler += new CanUpdateEventHandler(PacketReceived);
            this.battery = new Battery();
        }

        public BMU GetBMU(int index)
        {
            return battery.GetBMU(index);
        }

        public void EngageContactors()
        {
            CanPacket ControlPacket500 = new CanPacket(0x500); // 0x500
            CanPacket ControlPacket505 = new CanPacket(0x505); // 0x505

            ControlPacket505.SetInt8(0, 114);
            ControlPacket500.SetInt16(0, 4098);
            ControlPacket500.SetInt16(2, 1);

            udpService.SetCanToSendAt10Hertz(ControlPacket500);
            udpService.SetCanToSendAt10Hertz(ControlPacket505);

            this.contactorsEngaged = true;
        }

        public void DisengageContactors()
        {
            CanPacket ControlPacket500 = new CanPacket(0x500); // 0x500
            CanPacket ControlPacket505 = new CanPacket(0x505); // 0x505

            ControlPacket505.SetInt8(0, 2);
            ControlPacket500.SetInt16(0, 4098);
            ControlPacket500.SetInt16(2, 1);

            udpService.SetCanToSendAt10Hertz(ControlPacket500);
            udpService.SetCanToSendAt10Hertz(ControlPacket505);

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
            CanPacket ControlPacket500 = new CanPacket(0x500); // 0x500
            CanPacket ControlPacket505 = new CanPacket(0x505); // 0x505
            
            udpService.StopSendingCanAt10Hertz(ControlPacket500);
            udpService.StopSendingCanAt10Hertz(ControlPacket505);

            udpService.CanUpdateEventHandler -= new CanUpdateEventHandler(PacketReceived);
        }

        private void PacketReceived(CanReceivedEventArgs e)
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
