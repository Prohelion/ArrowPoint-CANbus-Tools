using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Services
{
    public interface IChargerInterface
    {

        float RequestedVoltage { get; set; }
        float RequestedCurrent { get; set; }
        float ActualVoltage { get; }
        float ActualCurrent { get; }
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

        Task<bool> WaitUntilChargerStarted(int timeoutMilli);

        Task<bool> WaitUntilChargerStopped(int timeoutMilli);

        Task<bool> WaitUntilVoltageReached(float voltage, float voltageRange, int timeoutMilli);

    }
}
