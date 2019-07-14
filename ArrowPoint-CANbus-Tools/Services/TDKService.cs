using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrowPointCANBusTool.Canbus;

namespace ArrowPointCANBusTool.Services
{
    class TDKService : ChargerServiceBase
    {
        public override string ComponentID => "TDK";

        private const float TDK_VOLTAGE_LIMIT = 300.0f;
        private const float TDK_CURRENT_LIMIT = 5.0f;
        private const float TDK_POWER_LIMIT = 1500.0f;

        public override float ChargerVoltageLimit { get; protected set; } = TDK_VOLTAGE_LIMIT;
        public override float ChargerCurrentLimit { get; protected set; } = TDK_CURRENT_LIMIT;
        public override float ChargerPowerLimit { get; protected set; } = TDK_POWER_LIMIT;
        public override float ChargerEfficiency => 0.9f;

        public override bool IsHardwareOk => true;
        public override bool IsTempOk => true;
        public override bool IsCommsOk => true;
        public override bool IsACOk => true;
        public override bool IsDCOk => true;

        public override bool IsCharging => throw new NotImplementedException();        

        public TDKService() : base(0,0)
        {

        }

        // Artifact of our structure that this exists, but it should never be used as the TDK is not can enabled
        public override void CanPacketReceived(CanPacket canPacket)
        {
            throw new NotImplementedException();
        }

        public override void StartCharge()
        {
            throw new NotImplementedException();
        }

        public override void StopCharge()
        {
            throw new NotImplementedException();
        }
    }
}
