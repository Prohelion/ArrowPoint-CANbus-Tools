using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrowPointCANBusTool.Canbus;

namespace ArrowPointCANBusTool.Canbus
{
    public class CanLoopback : ICanTrafficInterface
    {
        public ReceivedCanPacketHandler ReceivedCanPacketCallBack { get; set; }

        private bool isConnected = false;

        public CanLoopback(ReceivedCanPacketHandler receivedCanPacketCallBack)
        {
            this.ReceivedCanPacketCallBack = receivedCanPacketCallBack;
            this.isConnected = false;
        }

        public bool Connect()
        {
            isConnected = true;
            return isConnected;
        }

        public bool Disconnect()
        {
            isConnected = false;
            return isConnected;
        }

        public bool IsConnected()
        {
            return isConnected;
        }

        public int SendMessage(CanPacket canPacket)
        {
            if (ReceivedCanPacketCallBack == null) return -1;

            ReceivedCanPacketCallBack?.Invoke(canPacket);
            return 1;
        }
    }
}
