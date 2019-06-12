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

        public BatteryDischargeService(CanService canService)
        {
            batteryService = new BatteryService(canService);
        }

        public void StartDischarge()
        {
            batteryService.EngageContactors();
        }

        public void StopDischarge()
        {
            batteryService.DisengageContactors();
        }

        public Boolean IsDischarging()
        {
            return batteryService.IsContactorsEngaged;
        }
        
    }
}
