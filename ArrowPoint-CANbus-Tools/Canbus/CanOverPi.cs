using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Canbus
{
    class CanOverPi : ICanTrafficInterface
    {
        public Dictionary<string, string> AvailableInterfaces => throw new NotImplementedException();

        public List<string> SelectedInterfaces { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ReceivedCanPacketHandler ReceivedCanPacketCallBack { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Connect()
        {
            throw new NotImplementedException();
        }

        public bool Disconnect()
        {
            throw new NotImplementedException();
        }

        public bool IsConnected()
        {
            throw new NotImplementedException();
        }

        public int SendMessage(CanPacket canPacket)
        {
            throw new NotImplementedException();
        }
    }
}
