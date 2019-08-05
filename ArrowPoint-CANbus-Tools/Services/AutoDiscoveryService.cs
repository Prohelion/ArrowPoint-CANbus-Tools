using ArrowPointCANBusTool.Canbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Services
{
    class AutoDiscoveryService : CanReceivingNode
    {

        public override string ComponentID => "AUTO-DISCOVERY";

        public override uint State => base.State;

        public override string StateMessage => base.StateMessage;

        public AutoDiscoveryService() : base(uint.MinValue, uint.MaxValue, 5000, true)
        {
            // The AutoDiscoveryService is used to detect and register standard can components such as BMU's
        }

        public override void CanPacketReceived(CanPacket canPacket)
        {

        }
    }
}
