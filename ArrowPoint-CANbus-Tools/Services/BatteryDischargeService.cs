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
        bool isDischarging = false;

        public BatteryDischargeService(CanService canService)
        {
            batteryService = new BatteryService(canService);
        }

        public void StartDischarge()
        {
            isDischarging = true;
            batteryService.EngageContactors();
        }

        public void StopDischarge()
        {
            isDischarging = false;
            batteryService.DisengageContactors();
        }

        public Boolean IsDischarging
        {
            get
            {
                return (isDischarging && batteryService.IsContactorEngaged());
            }
        }

    }
}
