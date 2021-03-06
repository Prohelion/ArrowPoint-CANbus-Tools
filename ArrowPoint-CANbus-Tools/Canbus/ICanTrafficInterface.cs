﻿using ArrowPointCANBusTool.Canbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Canbus
{

    public delegate void ReceivedCanPacketHandler(CanPacket canPacket);

    public interface ICanTrafficInterface
    {
        Dictionary<string, string> AvailableInterfaces { get; }

        List<string> SelectedInterfaces { get; set; }

        ReceivedCanPacketHandler ReceivedCanPacketCallBack { get; set; }
        
        Boolean Connect();

        Boolean Disconnect();

        Boolean IsConnected();

        int SendMessage(CanPacket canPacket);

    }
}
