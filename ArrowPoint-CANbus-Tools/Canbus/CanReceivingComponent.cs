using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Services;

namespace ArrowPointCANBusTool.Canbus
{
    abstract public class CanReceivingComponent : ICanComponent
    {

        public const int STATE_NA = -1;
        public const int STATE_OFF = 0;
        public const int STATE_IDLE = 1;
        public const int STATE_ON = 2;
        public const int STATE_WARNING = 3;
        public const int STATE_FAILURE = 4;

        private int state = STATE_OFF;
        private readonly uint lowAddress = 0;
        private readonly uint highAddress = 0;
        private readonly CanService canService;

        public int State {
            get
            {
                return state;
            }
            private set
            {
                this.state = value;
            }
        }

        public CanService CurrentCanService { get { return canService; } }

        public abstract string StateMessage { get; }        

        public CanReceivingComponent(CanService canService, uint lowAddress, uint highAddress, bool startReceiver)
        {
            this.lowAddress = lowAddress;
            this.highAddress = highAddress;
            this.canService = canService;
            if (startReceiver) StartReceivingCan();
        }    

        public void StartReceivingCan()
        {
            this.canService.CanUpdateEventHandler += new CanUpdateEventHandler(CanPacketReceivedInternal);
        }

        public void StopReceivingCan()
        {
            canService.CanUpdateEventHandler -= new CanUpdateEventHandler(CanPacketReceivedInternal);
        }

        private void CanPacketReceivedInternal(CanReceivedEventArgs e)
        {
            CanPacket canPacket = e.Message;

            if (canPacket.CanId >= lowAddress && canPacket.CanId <= highAddress)
                CanPacketReceived(canPacket);
        }

        public abstract void CanPacketReceived(CanPacket canPacket);
    }
}
