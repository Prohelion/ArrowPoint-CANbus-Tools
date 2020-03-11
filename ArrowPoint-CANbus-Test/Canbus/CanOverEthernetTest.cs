using System;
using System.Threading;
using System.Threading.Tasks;
using ArrowPointCANBusTool.CanLibrary;
using NUnit.Framework;
using Prohelion.CanLibrary;
using Prohelion.CanLibrary.Loopback;

namespace ArrowPointCANBusTest.Canbus
{
    [TestFixture]
    public class CanOverEthernetTest
    {
        private Boolean receivedIt = false;
        private const int TEST_CAN_ID = 0x112233;

        [Test]
        public void TestConnect()
        {
            ICanTrafficInterface canLoopback = new CanLoopback()
            {
                ReceivedCanPacketCallBack = ReceivedCanPacketCallBack
            };

            canLoopback.Connect();
            Assert.IsTrue(canLoopback.IsConnected());

            canLoopback.Disconnect();
            Assert.IsFalse(canLoopback.IsConnected());
        }

        [Test]
        public void TestReceived()
        {
            ICanTrafficInterface canLoopback = new CanLoopback()
            {
                ReceivedCanPacketCallBack = ReceivedCanPacketCallBack
            };

            canLoopback.Connect();
            Assert.IsTrue(canLoopback.IsConnected());

            receivedIt = false;

            CanPacket canPacket = new CanPacket(TEST_CAN_ID);
            canLoopback.SendMessage(canPacket);

            // Wait half a second for it to receive the packet back as it requires the listener loop to receive and process it
            Thread.Sleep(500);

            Assert.IsTrue(receivedIt);

            canLoopback.Disconnect();
            Assert.IsFalse(canLoopback.IsConnected());
        }

        private void ReceivedCanPacketCallBack(CanPacket canPacket)
        {
            if (canPacket.CanId == TEST_CAN_ID)
                receivedIt = true;
        }

    }
}
