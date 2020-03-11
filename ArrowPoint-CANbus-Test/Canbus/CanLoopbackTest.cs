using System;
using ArrowPointCANBusTool.CanLibrary;
using NUnit.Framework;
using Prohelion.CanLibrary;
using Prohelion.CanLibrary.Loopback;

namespace ArrowPointCANBusTest.Canbus
{
    [TestFixture]
    public class CanLoopbackTest
    {
        private Boolean receivedIt = false;

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

            CanPacket canPacket = new CanPacket(0x400);
            canLoopback.SendMessage(canPacket);

            Assert.IsTrue(receivedIt);

            canLoopback.Disconnect();
            Assert.IsFalse(canLoopback.IsConnected());
        }

        private void ReceivedCanPacketCallBack(CanPacket canPacket)
        {
            receivedIt = true;
        }

    }
}
