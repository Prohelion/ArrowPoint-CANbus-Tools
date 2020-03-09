using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Tritium.CanLibrary
{
    ///<summary>This class represents a CAN packet including the additional information used for sending it via UDP.</summary>
    public class UdpPacket: CanPacket
    {
        ///<summary>Identifies if this is a bridge heartbeat packet.</summary>
        protected Boolean bridgeHb;

        ///<summary>The identifier of the bus this packet is considered to be on.</summary>
        protected UInt64 busId;

        ///<summary>The identifier of the sender of this packet. This is not the original sender, but the last one.</summary>
        protected UInt64 senderId;

        ///<summary>The IP address of the sender of this packet.</summary>
        protected IPAddress senderAddr;

        ///<summary>The port of the sender of this packet.</summary>
        protected int senderPort;

        ///<summary>The local IP address that this packet was received on.</summary>
        protected IPAddress localAddr;

        ///<summary>Creates a new UDP packet using the data given. See <see cref="CanPacket"/> for information about the CAN specific parameters used and exceptions thrown by this function.</summary>
        ///<param name="id">See the parameter id of <see cref="CanPacket(UInt32, Boolean, Boolean, Byte, UInt64)"/>.</param>
        ///<param name="extended">See the parameter extended of <see cref="CanPacket(UInt32, Boolean, Boolean, Byte, UInt64)"/>.</param>
        ///<param name="rtr">See the parameter rtr of <see cref="CanPacket(UInt32, Boolean, Boolean, Byte, UInt64)"/>.</param>
        ///<param name="length">See the parameter length of <see cref="CanPacket(UInt32, Boolean, Boolean, Byte, UInt64)"/>.</param>
        ///<param name="data">See the parameter data of <see cref="CanPacket(UInt32, Boolean, Boolean, Byte, UInt64)"/>.</param>
        ///<param name="bridgeHb">True if the packet is a bridge heartbeat packet, false otherwise.</param>
        ///<param name="busId">The identifier of the bus this packet is considered to be on.</param>
        ///<param name="senderId">The identifier of the sender of this packet. This should not be the original sender, but the last one.</param>
        ///<seealso cref="CanPacket(UInt32, Boolean, Boolean, Byte, UInt64)"/>
        public UdpPacket(UInt32 id, Boolean extended, Boolean rtr, Byte length, UInt64 data, Boolean bridgeHb, UInt64 busId, UInt64 senderId) :
            base(id, extended, rtr, length, data)
        {
            this.busId = busId;
            this.senderId = senderId;
        }

        ///<summary>Creates a new UDP packet using the data given. See <see cref="CanPacket"/> for information about the CAN specific parameters used and exceptions thrown by this function.</summary>
        ///<param name="id">See the parameter id of <see cref="CanPacket(UInt32, Boolean, Boolean, Byte, byte[])"/>.</param>
        ///<param name="extended">See the parameter extended of <see cref="CanPacket(UInt32, Boolean, Boolean, Byte, byte[])"/>.</param>
        ///<param name="rtr">See the parameter rtr of <see cref="CanPacket(UInt32, Boolean, Boolean, Byte, byte[])"/>.</param>
        ///<param name="length">See the parameter length of <see cref="CanPacket(UInt32, Boolean, Boolean, Byte, byte[])"/>.</param>
        ///<param name="data">See the parameter data of <see cref="CanPacket(UInt32, Boolean, Boolean, Byte, byte[])"/>.</param>
        ///<param name="bridgeHb">True if the packet is a bridge heartbeat packet, false otherwise.</param>
        ///<param name="busId">The identifier of the bus this packet is considered to be on.</param>
        ///<param name="senderId">The identifier of the sender of this packet. This should not be the original sender, but the last one.</param>
        ///<seealso cref="CanPacket(UInt32, Boolean, Boolean, Byte, byte[])"/>
        public UdpPacket(UInt32 id, Boolean extended, Boolean rtr, Byte length, byte[] data, Boolean bridgeHb, UInt64 busId, UInt64 senderId) :
            base(id, extended, rtr, length, data)
        {
            this.busId = busId;
            this.senderId = senderId;
        }

        ///<summary>Returns whether this is a bridge heartbeat packet.</summary>
        ///<returns>True if this is a bridge heartbeat packet.</returns>
        public Boolean isBridgeHb()
        {
            return bridgeHb;
        }

        ///<summary>Returns the identifier of the bus this packet is considered to be on.</summary>
        ///<returns>The identifier of the bus this packet is considered to be on.</returns>
        public UInt64 getBusId()
        {
            return busId;
        }

        ///<summary>Returns the identifier of the sender of this packet. This is not the original sender, but the last one.</summary>
        ///<returns>The identifier of the sender of this packet.</returns>
        public UInt64 getSenderId()
        {
            return senderId;
        }

        ///<summary>Returns the IP address of the sender of this packet.</summary>
        ///<returns>The IP address of the sender of this packet.</returns>
        public IPAddress getSenderAddr()
        {
            return senderAddr;
        }

        ///<summary>Returns the port of the sender of this packet.</summary>
        ///<returns>The port of the sender of this packet.</returns>
        public int getSenderPort()
        {
            return senderPort;
        }

        ///<summary>Returns the local IP address this packet was received on.</summary>
        ///<returns>The local IP address this packet was received on.</returns>
        public IPAddress getLocalAddr()
        {
            return localAddr;
        }

        ///<summary>Sets the IP address of the sender of this packet.</summary>
        ///<param name="addr">The IP address of the sender of this packet.</param>
        public void setSenderAddr( IPAddress addr )
        {
            senderAddr = addr;
        }

        ///<summary>Sets the UDP port of this packet.</summary>
        ///<param name="port">The UDP port of this packet.</param>
        public void setSenderPort(int port)
        {
            senderPort = port;
        }

        ///<summary>Sets the local IP address this packet was received on.</summary>
        ///<param name="addr">The local IP address this packet was received on.</param>
        public void setLocalAddr(IPAddress addr)
        {
            localAddr = addr;
        }
    }
}
