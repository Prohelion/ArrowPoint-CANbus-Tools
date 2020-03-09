using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Tritium.CanLibrary;

namespace Tritium.CanLibraryTest
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
            Byte[] bytes = serialiser.serialise(packet, busId, clientId);
            List<UdpPacket> receivedPacket = serialiser.deserialise(bytes);

            foreach (UdpPacket pkt in receivedPacket)
            {
                if (pkt.getBusId() == busId && pkt.getSenderId() == clientId &&
                    pkt.getId() == packet.getId() && pkt.isExtended() == packet.isExtended() &&
                    pkt.isRTR() == packet.isRTR() && pkt.getLength() == packet.getLength() &&
                    pkt.getData() == packet.getData())
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

            CanUdpClient canUdpClientSend = new CanUdpClient();
            CanUdpClient canUdpClientReceive = new CanUdpClient();
            canUdpClientReceive.packetReceived += receivePacket;

            canUdpClientSend.open();
            canUdpClientReceive.open();

            canUdpClientSend.send(packet);
            Thread.Sleep(1000);

            canUdpClientSend.close();
            canUdpClientReceive.close();

            Console.WriteLine("Done, you should have received a packet");
        }

        static void receivePacket(CanPacket receivedPacket)
        {
            if (receivedPacket.getId() == packet.getId() && receivedPacket.isExtended() == packet.isExtended() &&
                receivedPacket.isRTR() == packet.isRTR() && receivedPacket.getLength() == packet.getLength() &&
                receivedPacket.getData() == packet.getData())
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
