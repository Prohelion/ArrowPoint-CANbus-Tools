using ArrowPointCANBusTool.Canbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Canbus
{
    interface ICanComponent
    {
        int State { get; }
        string StateMessage { get; }

        void CanPacketReceived(CanPacket canPacket);
    }
}
