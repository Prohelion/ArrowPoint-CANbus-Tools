using ArrowPointCANBusTool.Canbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Canbus
{
    public interface ICanReceivingComponent
    {
        uint State { get; }
        string StateMessage { get; }
        string ComponentID { get; }

        void CanPacketReceived(CanPacket canPacket);
    }
}
