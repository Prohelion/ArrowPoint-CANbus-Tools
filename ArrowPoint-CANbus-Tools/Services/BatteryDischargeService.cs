using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ArrowPointCANBusTool.Services
{
    public class BatteryDischargeService
    {
        private static readonly BatteryDischargeService instance = new BatteryDischargeService();

        private static readonly uint TIME_VALID = 5000;

        private BatteryService batteryService;        
        private CanControl canControl;
        bool isDischarging = false;
        private Timer chargerUpdateTimer;

        static BatteryDischargeService()
        {
        }

        public static BatteryDischargeService Instance
        {
            get
            {
                return instance;
            }
        }

        private BatteryDischargeService()
        {
            batteryService = BatteryService.Instance;
            canControl = new CanControl(0x508);
        }

        public async void StartDischarge()         
        {

            CanPacket canPacket = new CanPacket(0x508);
            canPacket.SetByte(7, 0x0);
            canControl.ComponentCanService.SetCanToSendAt10Hertz(canPacket);

            await Task.Delay(1000);

            batteryService.EngageContactors();

            if (!await batteryService.WaitUntilContactorsEngage(5000)) return;

            // Not really necessary but a double check
            if (!batteryService.IsContactorsEngaged) return;

            canPacket.SetByte(7, 0x30);
            canControl.ComponentCanService.SetCanToSendAt10Hertz(canPacket);

            isDischarging = true;

            chargerUpdateTimer = new System.Timers.Timer
            {
                Interval = 100,
                AutoReset = true,
                Enabled = true
            };
            chargerUpdateTimer.Elapsed += DischargerUpdate;
        }

        private void DischargerUpdate(object sender, EventArgs e)
        {

           if (batteryService.State != CanReceivingNode.STATE_ON ||
                !batteryService.IsContactorsEngaged ||
                !IsDischargeContactorsEngaged())
                StopDischarge();
        }

        public async void StopDischarge()
        {
            chargerUpdateTimer.Stop();

            batteryService.DisengageContactors();

            if (!await batteryService.WaitUntilContactorsDisengage(2000)) return;

            CanPacket canPacket = new CanPacket(0x508);
            canPacket.SetByte(7,0x0);            
            canControl.ComponentCanService.SetCanToSendAt10Hertz(canPacket);

            isDischarging = false;
        }

        public Boolean IsDischargeContactorsEngaged()
        {
            CanPacket contactorStatus = canControl.ComponentCanService.LastestCanPacketById(0x302);
            if (contactorStatus == null) return (false);
            return contactorStatus.Byte1 == 0x30 && contactorStatus.MilisecondsSinceReceived < TIME_VALID;
        }

        public Boolean IsDischarging
        {
            get
            {
                CanPacket contactorStatus = canControl.ComponentCanService.LastestCanPacketById(0x302);
                if (contactorStatus == null) return false;              
                return (isDischarging && contactorStatus.Byte1 == 0x30 && batteryService.IsContactorsEngaged);
            }
        }

        public uint DischargerState {
            get {

                CanPacket contactorStatus = canControl.ComponentCanService.LastestCanPacketById(0x302);

                uint result = CanReceivingNode.STATE_NA;

                if (contactorStatus == null || contactorStatus.MilisecondsSinceReceived > TIME_VALID) result = CanReceivingNode.STATE_NA;
                else
                { 
                    if (contactorStatus.Byte1 == 0x30) result = CanReceivingNode.STATE_ON;
                    if (contactorStatus.Byte1 != 0x30) result = CanReceivingNode.STATE_IDLE;
                }

                return result;
            }
        }
        public string DischargerStateMessage { get { return CanReceivingNode.GetStatusText(DischargerState); } }


    }
}
