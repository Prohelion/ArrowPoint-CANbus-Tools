using ArrowPointCANBusTool.CanLibrary;
using ArrowPointCANBusTool.Services;
using Prohelion.CanLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Model
{
    class CanControl : CanReceivingNode
    {
        public const string CANCONTROL_ID = "CANCONTROL_ID";
        private const uint ADDRESS_RANGE = 1;

        public override string ComponentID => CANCONTROL_ID;

        public CanControl(uint intBaseAddress) : base(intBaseAddress, intBaseAddress + ADDRESS_RANGE - 1, 1000, true)
        {      
        }

        public override void CanPacketReceived(CanPacket canPacket)
        {            
        }

    }
}
