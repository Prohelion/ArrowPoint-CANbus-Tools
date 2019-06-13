﻿using ArrowPointCANBusTool.Canbus;
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

            // If we are not currently sending x505s then lets start as the battery likes them
            if (!canService.IsPacketCurrent(0x505, 1000))
            {
                CanPacket ControlPacket505 = new CanPacket(0x505); // 0x505
                ControlPacket505.SetInt8(0, 0);
                canService.SetCanToSendAt10Hertz(ControlPacket505);
            }
        }

        public async void EngageContactors()
        {
            CanPacket ControlPacket505 = new CanPacket(0x505); // 0x505
            ControlPacket505.SetInt8(0, 0);
            canService.SetCanToSendAt10Hertz(ControlPacket505);

            await Task.Delay(3000); 

            ControlPacket505.SetInt8(0, 112);
            canService.SetCanToSendAt10Hertz(ControlPacket505);

            // Set up the heartbeat for the battery so that we are ready to go
            CanPacket ControlPacket500 = new CanPacket(0x500); // 0x500
            canService.SetCanToSendAt10Hertz(ControlPacket500);
        }

        public async void DisengageContactors()
        {         
            CanPacket ControlPacket505 = new CanPacket(0x505); // 0x505
            CanPacket ControlPacket500 = new CanPacket(0x500); // 0x500

            ControlPacket505.SetInt8(0, 2);
            canService.SetCanToSendAt10Hertz(ControlPacket505);

            await Task.Delay(500);

        }        

        public void ShutdownService()
        {
            CanPacket ControlPacket505 = new CanPacket(0x505); // 0x505
            CanPacket ControlPacket500 = new CanPacket(0x500); // 0x500

            // Set up the heartbeat for the battery so that we are ready to go
            canService.StopSendingCanAt10Hertz(ControlPacket505);
            canService.StopSendingCanAt10Hertz(ControlPacket500);
        }

        public uint State { get { return BatteryData.State; } }
        public string StateMessage { get { return BatteryData.StateMessage; } }
        public Boolean IsContactorsEngaged { get { return BatteryData.IsPackReady; } }
    }
}
