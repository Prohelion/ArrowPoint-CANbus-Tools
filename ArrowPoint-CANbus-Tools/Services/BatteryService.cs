using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Model;
using System;
using System.Threading;
using System.Windows.Forms;
using static ArrowPointCANBusTool.Services.CanService;

namespace ArrowPointCANBusTool.Services
{
    public class BatteryService
    {
                
        private CanService canService;

        public Battery BatteryData { get; private set; }

        public BatteryService(CanService canService)
        {
            BatteryData = new Battery(canService);
            this.canService = canService;

            // Set up the heartbeat for the battery so that we are ready to go
            CanPacket ControlPacket500 = new CanPacket(0x500); // 0x500
            ControlPacket500.SetInt16(0, 4098);
            ControlPacket500.SetInt16(2, 1);
            canService.SetCanToSendAt10Hertz(ControlPacket500);
        }

        public void ShutdownService()
        {
            // Detach the event and delete the list
            CanPacket ControlPacket500 = new CanPacket(0x500); // 0x500
            CanPacket ControlPacket505 = new CanPacket(0x505); // 0x505

            canService.StopSendingCanAt10Hertz(ControlPacket500);
            canService.StopSendingCanAt10Hertz(ControlPacket505);
        }

        public void EngageContactors()
        {

            CanPacket ControlPacket505 = new CanPacket(0x505); // 0x505

            ControlPacket505.SetInt8(0, 114);
            canService.SetCanToSendAt10Hertz(ControlPacket505);
        }

        public void DisengageContactors()
        {
            CanPacket ControlPacket505 = new CanPacket(0x505); // 0x505

            ControlPacket505.SetInt8(0, 2);
            canService.SetCanToSendAt10Hertz(ControlPacket505);
        }

        public uint State { get { return BatteryData.State; } }
        public string StateMessage { get { return BatteryData.StateMessage; } }
        public Boolean IsContactorsEngaged { get { return BatteryData.IsPackReady; } }
    }
}
