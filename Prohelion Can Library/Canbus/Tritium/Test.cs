using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Prohelion.CanLibrary;

namespace Prohelion.CanLibrary.Tritium
{
    ///<summary>This class contains some functions to test the CAN library.</summary>
    public class CanLibraryTest
    {
        static UInt64 busId = 123;
        static UInt64 clientId = 312;
        static CanPacket packet = new CanPacket(987, true, 2, 1);

        ///<summary>Test if serialising and then deserialising a packet results in the same packet.</summary>
        public static void serialisationTest()
        {
            Console.WriteLine("Testing serialisation");

            CanPacketSerialiser serialiser = new CanPacketSerialiser();
            Byte[] bytes = serialiser.Serialise(packet, busId, clientId);
            List<UdpPacket> receivedPacket = serialiser.Deserialise(bytes);

            foreach (UdpPacket pkt in receivedPacket)
            {
                if (pkt.getBusId() == busId && pkt.getSenderId() == clientId &&
                    pkt.CanId == packet.CanId && pkt.Extended == packet.Extended &&
                    pkt.Rtr == packet.Rtr && pkt.Length == packet.Length &&
                    pkt.Data == packet.Data)
                {
                    Console.WriteLine("Succeeded");
                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }
        }

        ///<summary>Test if when sending a packet the same packet is also received.</summary>
        public static void sendReceiveTest()
        {
            Console.WriteLine("Testing send and receive");

            TritiumCanClient canUdpClientSend = new TritiumCanClient();
            TritiumCanClient canUdpClientReceive = new TritiumCanClient();
            canUdpClientReceive.ReceivedCanPacketCallBack += receivePacket;

            canUdpClientSend.Connect();
            canUdpClientReceive.Connect();

            canUdpClientSend.SendMessage(packet);
            Thread.Sleep(1000);

            canUdpClientSend.Disconnect();
            canUdpClientReceive.Disconnect();

            Console.WriteLine("Done, you should have received a packet");
        }

        static void receivePacket(CanPacket receivedPacket)
        {
            if (receivedPacket.CanId == packet.CanId && receivedPacket.Extended == packet.Extended &&
                receivedPacket.Rtr == packet.Rtr && receivedPacket.Length == packet.Length &&
                receivedPacket.Data == packet.Data)
            {
                Console.WriteLine("Received correct packet");
            }
            else
            {
                Console.WriteLine("Received incorrect packet (might have another source)");
            }
        }
    }
}
