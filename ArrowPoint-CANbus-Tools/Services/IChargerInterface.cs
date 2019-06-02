using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Services
{
    interface IChargerInterface
    {

        float VoltageRequested { get; set; }
        float CurrentRequested { get; set; }
        float ChargerVoltage { get; set; }
        float ChargerCurrent { get; set; }
        int ChargerStatus { get; set; }
        float SupplyVoltageLimit { get; set; }
        float SupplyCurrentLimit { get; set; }

        float ChargerVoltageLimit { get; }
        float ChargerCurrentLimit { get; set; }
        float ChargerPowerLimit { get; set; }
        float ChargerEfficiency { get; }

        void StartCharge();

        void StopCharge();

        Boolean IsOutputOn();
    }
}
