﻿using Prohelion.CanLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prohelion.CanLibrary
{
    public class CanReceivedEventArgs : EventArgs
    {
        public CanPacket Message { get; set; }

        public CanReceivedEventArgs(CanPacket Message)
        {
            this.Message = Message;
        }
    }
}
