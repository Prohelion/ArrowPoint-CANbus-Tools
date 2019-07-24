using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Model;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ArrowPointCANBusTool.Services.CanService;

namespace ArrowPointCANBusTool.Services
{
    public class BatteryService
    {
        private static readonly BatteryService instance = new BatteryService();

        private bool timeOutApplies = true;

        public bool TimeoutApplies {
            get
            {
                return timeOutApplies;
            }
            set
            {
                timeOutApplies = value;
                BatteryData = new Battery(TimeoutApplies);
            }
        }        

        public Battery BatteryData { get; private set; }

        static BatteryService()
        {
        }

        public static BatteryService Instance
        {
            get
            {
                return instance;
            }
        }

        public static BatteryService NewInstance
        {
            get
            {
                return new BatteryService();
            }
        }

        private BatteryService()
        {           
            
            BatteryData = new Battery(TimeoutApplies);

            // Set up the heartbeat for the battery so that we are ready to go
            CanPacket ControlPacket500 = new CanPacket(0x500); // 0x500
            ControlPacket500.SetInt16(0, 4098);
            ControlPacket500.SetInt16(2, 1);
            CanService.Instance.SetCanToSendAt10Hertz(ControlPacket500);

            // If we are not currently sending x505s then lets start as the battery likes them
            if (!CanService.Instance.IsPacketCurrent(0x505, 1000))
            {
                CanPacket ControlPacket505 = new CanPacket(0x505); // 0x505
                ControlPacket505.SetInt8(0, 0);
                CanService.Instance.SetCanToSendAt10Hertz(ControlPacket505);
            }
        }

        public async void EngageContactors()
        {
            CanPacket ControlPacket505 = new CanPacket(0x505); // 0x505
            ControlPacket505.SetInt8(0, 0);
            CanService.Instance.SetCanToSendAt10Hertz(ControlPacket505);
            
            ControlPacket505.SetInt8(0, 112);
            CanService.Instance.SetCanToSendAt10Hertz(ControlPacket505);

            // Set up the heartbeat for the battery so that we are ready to go
            CanPacket ControlPacket500 = new CanPacket(0x500); // 0x500
            CanService.Instance.SetCanToSendAt10Hertz(ControlPacket500);

            await WaitUntilContactorsEngage(5000);
        }

        public async void DisengageContactors()
        {         
            CanPacket ControlPacket505 = new CanPacket(0x505); // 0x505
            CanPacket ControlPacket500 = new CanPacket(0x500); // 0x500

            ControlPacket505.SetInt8(0, 2);
            CanService.Instance.SetCanToSendAt10Hertz(ControlPacket505);

            await WaitUntilContactorsDisengage(5000);
        }

        public async Task<bool> WaitUntilContactorsEngage(int timeoutMilli)
        {
            int timer = 0;

            while (timer < timeoutMilli)
            {
                if (IsContactorsEngaged) return (true);
                await Task.Delay(100);
                timer += 100;
            }

            return false;
        }

        public async Task<bool> WaitUntilContactorsDisengage(int timeoutMilli)
        {
            int timer = 0;

            while (timer < timeoutMilli)
            {
                if (!IsContactorsEngaged) return (true);
                await Task.Delay(100);
                timer += 100;
            }

            return false;
        }

        public void ShutdownService()
        {
            CanPacket ControlPacket505 = new CanPacket(0x505); // 0x505
            CanPacket ControlPacket500 = new CanPacket(0x500); // 0x500

            // Set up the heartbeat for the battery so that we are ready to go
            CanService.Instance.StopSendingCanAt10Hertz(ControlPacket505);
            CanService.Instance.StopSendingCanAt10Hertz(ControlPacket500);
        }

        public uint State { get { return BatteryData.State; } }
        public string StateMessage { get { return BatteryData.StateMessage; } }
        public Boolean IsContactorsEngaged { get { return BatteryData.IsPackReady; } }
    }
}
