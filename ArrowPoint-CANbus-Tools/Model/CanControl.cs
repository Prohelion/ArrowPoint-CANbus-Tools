using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Model
{
    class CanControl : CanReceivingComponent
    {
        public const string CANCONTROL_ID = "CANCONTROL_ID";
        private const uint ADDRESS_RANGE = 1;

        public override uint State => CanReceivingComponent.STATE_ON;

        public override string StateMessage => CanReceivingComponent.STATE_ON_TEXT;

        public override string ComponentID => CANCONTROL_ID;

        public CanControl(CanService canService, uint intBaseAddress) : base(canService, intBaseAddress, intBaseAddress + ADDRESS_RANGE - 1, true)
        {      
        }

        public override void CanPacketReceived(CanPacket canPacket)
        {            
        }

    }
}
