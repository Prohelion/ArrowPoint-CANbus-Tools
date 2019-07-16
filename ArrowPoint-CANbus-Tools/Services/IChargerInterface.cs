using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Services
{
    public interface IChargerInterface
    {

        float VoltageRequested { get; set; }
        float CurrentRequested { get; set; }
        float ChargerVoltage { get; }
        float ChargerCurrent { get; }
        uint ChargerStatus { get; }
        float SupplyVoltageLimit { get; set; }
        float SupplyCurrentLimit { get; set; }

        float ChargerVoltageLimit { get; }
        float ChargerCurrentLimit { get; }
        float ChargerPowerLimit { get; }
        float ChargerEfficiency { get; }

        bool IsHardwareOk { get; }
        bool IsTempOk { get; }
        bool IsCommsOk { get; }
        bool IsACOk { get; }
        bool IsDCOk { get; }
        bool IsCharging { get; }

        uint State { get; }
        string StateMessage { get; }
        string ComponentID { get; }

        void StartCharge();

        void StopCharge();

    }
}
