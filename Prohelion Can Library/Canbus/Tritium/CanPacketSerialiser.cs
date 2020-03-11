using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Prohelion.CanLibrary.Tritium;

namespace Prohelion.CanLibrary
{
    ///<summary>This class provides methods to serialise CAN packets to and from a binary format.</summary>
    class CanPacketSerialiser
    {
        private const int LENGTH_BUS = 8;
        private const int LENGTH_SENDER = 8;
        private const int LENGTH_IDENTIFIER = 4;
        private const int LENGTH_DATA = 8;

        private const int INDEX_BUS = 0;
        private const int INDEX_SENDER = INDEX_BUS + LENGTH_BUS; //8
        private const int INDEX_IDENTIFIER = INDEX_SENDER + LENGTH_SENDER; //16
        private const int INDEX_FLAGS = INDEX_IDENTIFIER + LENGTH_IDENTIFIER; //20
        private const int INDEX_LENGTH = INDEX_FLAGS + 1; //21
        private const int INDEX_DATA = INDEX_LENGTH + 1;  //22

        public const int PACKET_LENGTH = INDEX_DATA + LENGTH_DATA;    //30
        public const int PACKET_LENGTH_PRELIM = LENGTH_BUS + LENGTH_SENDER;	//16 - The info to only send once during a bulk transfer
        public const int PACKET_LENGTH_BULK = PACKET_LENGTH - PACKET_LENGTH_PRELIM;   //14

        private const byte FLAG_EXTENDED = 1;
        private const byte FLAG_RTR = 2;
        private const byte FLAG_BRIDGE_HB = 0x80;
        private const byte FLAG_SETTINGS = 0x40;

        ///<summary>The Serialisation library for receiving and sending data over Ethernet.</summary>
        public CanPacketSerialiser()
        {
            // Message for debug purposes
            if (BitConverter.IsLittleEndian)
            {
                Console.WriteLine("Your system is little endian, endian conversion will be performed when serialising packets.");
            }
            else
            {
                Console.WriteLine("Your system is big endian.");
            }
        }


        ///<summary>Serialise a CAN packet to binary format.</summary>
        public Byte[] Serialise(CanPacket packet, UInt64 busId, UInt64 senderId)
        {
            byte flags = 0;
            if (packet.Extended) flags |= FLAG_EXTENDED;
            if (packet.Rtr) flags |= FLAG_RTR;

            Byte[] buffer = new Byte[PACKET_LENGTH];
            Byte[] b_bus = CanUtilities.GetBytes(busId);
            Array.Copy(b_bus, 0, buffer, INDEX_BUS, b_bus.Length);
            Byte[] b_sender = CanUtilities.GetBytes(senderId);
            Array.Copy(b_sender, 0, buffer, INDEX_SENDER, b_sender.Length);
            Byte[] b_id = CanUtilities.GetBytes(packet.CanId);
            Array.Copy(b_id, 0, buffer, INDEX_IDENTIFIER, b_id.Length);
            buffer[INDEX_FLAGS] = flags;
            buffer[INDEX_LENGTH] = packet.Length;
            Byte[] b_data = CanUtilities.GetBytes(packet.Data);
            Array.Copy(b_data, 0, buffer, INDEX_DATA, b_data.Length);

            return buffer;
        }


        ///<summary>Serialise a list of CAN packets to binary format, with or without prelim data (bus id and sender id)</summary>
        public Byte[] SerialiseBulk(List<CanPacket> packetStore, UInt64 busId, UInt64 senderId, bool includePrelim, bool isSettings)
        {
            int numPackets = packetStore.Count;
            int length;
            int bufferOffset;

            if (includePrelim) length = PACKET_LENGTH + PACKET_LENGTH_BULK * (numPackets - 1);
            else length = PACKET_LENGTH_BULK * numPackets;

            Byte[] buffer = new Byte[length];

            if (includePrelim)
            {
                Byte[] b_bus = CanUtilities.GetBytes(busId);
                Array.Copy(b_bus, 0, buffer, INDEX_BUS, b_bus.Length);
                Byte[] b_sender = CanUtilities.GetBytes(senderId);
                Array.Copy(b_sender, 0, buffer, INDEX_SENDER, b_sender.Length);
                bufferOffset = 0;
            }
            else
            {
                bufferOffset = -INDEX_IDENTIFIER;
            }

            foreach (CanPacket pkt in packetStore)
            {
                byte flags = 0;
                if (pkt.Extended) flags |= FLAG_EXTENDED;
                if (pkt.Rtr) flags |= FLAG_RTR;
                if (isSettings) flags |= FLAG_SETTINGS;

                Byte[] b_id = CanUtilities.GetBytes(pkt.CanId);
                Array.Copy(b_id, 0, buffer, bufferOffset + INDEX_IDENTIFIER, b_id.Length);

                buffer[bufferOffset + INDEX_FLAGS] = flags;

                buffer[bufferOffset + INDEX_LENGTH] = pkt.Length;

                Byte[] b_data = CanUtilities.GetBytes(pkt.Data);
                Array.Copy(b_data, 0, buffer, bufferOffset + INDEX_DATA, b_data.Length);

                bufferOffset += PACKET_LENGTH_BULK;
            }

            return buffer;
        }


        ///<summary>Deserialise a CAN packet from binary format.</summary>
        ///<returns>The deserialised CAN packet or null if the buffer did not represent a valid CAN packet.</returns>
        public List<UdpPacket> Deserialise(Byte[] buffer, Boolean includePrelim=true, UInt64 busId=0, UInt64 senderId=0)
        {
            int offset;
	        if (includePrelim)
	        {
		        busId = CanUtilities.BytesToUInt64(buffer, INDEX_BUS);       //ntohll(*((UInt64*)(buffer + INDEX_BUS)));
		        senderId = CanUtilities.BytesToUInt64(buffer, INDEX_SENDER); //ntohll(*((UInt64*)(buffer + INDEX_SENDER)));
		        offset=0;
	        }
	        else
	        {
		        offset = -INDEX_IDENTIFIER;
	        }

	        //Wrapper which enables BulkDeserialisation
            List<UdpPacket> packets = new List<UdpPacket>();    //std::vector<UdpPacket>* packets = new std::vector<UdpPacket>;
	        for (int i = offset; i < (buffer.Length - PACKET_LENGTH_PRELIM); i += PACKET_LENGTH_BULK)
	        {
                UInt32 id = CanUtilities.BytesToUInt32(buffer, INDEX_IDENTIFIER+i);                  //UInt32 id = ntohl(*((UInt32*)(i + buffer + INDEX_IDENTIFIER)));
                Boolean extended = (buffer[INDEX_FLAGS + i] & FLAG_EXTENDED) > 0;       //bool extended = (buffer[INDEX_FLAGS + i] & FLAG_EXTENDED) > 0;
                Boolean rtr = (buffer[INDEX_FLAGS + i] & FLAG_RTR) > 0;                 //bool rtr = (buffer[INDEX_FLAGS + i] & FLAG_RTR) > 0;
                Boolean bridgeHb = (buffer[INDEX_FLAGS + i] & FLAG_BRIDGE_HB) > 0;      //bool bridgeHb = (buffer[INDEX_FLAGS + i] & FLAG_BRIDGE_HB) > 0;
                Byte length = buffer[INDEX_LENGTH + i];                                 //byte length = buffer[INDEX_LENGTH + i];
                UInt64 data = CanUtilities.BytesToUInt64(buffer, INDEX_DATA + i);                    //UInt64 data = ntohll(*((UInt64*)(i + buffer + INDEX_DATA)));

		        try
		        {
                    packets.Add(new UdpPacket(id, extended, rtr, length, data, bridgeHb, busId, senderId));  //packets->push_back(UdpPacket(id, extended, rtr, length, data, bridgeHb, busId, senderId));
		        }
		        catch (OverflowException)
		        {
			        // Apparently the packet was invalid because the UdpPacket constructor threw an exception
			        break; // Just return whatever packets were successfully processed
		        }
	        }
	        return packets;
        }
        
    }
}
