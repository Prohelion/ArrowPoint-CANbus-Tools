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
        float ChargerVoltage { get; }
        float ChargerCurrent { get; }
        int ChargerStatus { get; }
        float SupplyVoltageLimit { get; set; }
        float SupplyCurrentLimit { get; set; }

        float ChargerVoltageLimit { get; }
        float ChargerCurrentLimit { get; }
        float ChargerPowerLimit { get; }
        float ChargerEfficiency { get; }

        Boolean IsHardwareOk { get; }
        Boolean IsTempOk { get; }
        Boolean IsCommsOk { get; }
        Boolean IsACOk { get; }
        Boolean IsDCOk { get; }
        Boolean IsCharging { get; }

        void StartCharge();

        void StopCharge();

    }
}
