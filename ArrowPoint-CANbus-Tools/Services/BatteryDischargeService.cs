using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Services
{
    public class BatteryDischargeService
    {
        private BatteryService batteryService;
        private CanControl canControl;
        bool isDischarging = false;

        public BatteryDischargeService(CanService canService)
        {
            batteryService = new BatteryService(canService);
            canControl = new CanControl(canService, 0x508);
        }

        public async void StartDischarge()         
        {
            batteryService.EngageContactors();

            await Task.Delay(1000);

            CanPacket canPacket = new CanPacket(0x508);
            canPacket.SetUInt8(0, 1);
            canPacket.SetUInt8(1, 1);

            canControl.ComponentCanService.SetCanToSendAt10Hertz(canPacket);

            isDischarging = true;
        }

        public async void StopDischarge()
        {
            batteryService.DisengageContactors();

            await Task.Delay(1000);

            CanPacket canPacket = new CanPacket(0x508);
            canPacket.SetUInt8(0, 0);
            canPacket.SetUInt8(1, 0);

            canControl.ComponentCanService.SetCanToSendAt10Hertz(canPacket);

            await Task.Delay(1000);

            canControl.ComponentCanService.StopSendingCanAt10Hertz(canPacket);

            isDischarging = false;
        }

        public Boolean IsDischarging
        {
            get
            {
                return (isDischarging && batteryService.IsContactorsEngaged);
            }
        }
        
    }
}
