using System;
using ArrowPointCANBusTool.Canbus;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrowPointCANBusTest.Canbus
{
    [TestClass]
    public class CanLoopbackTest
    {
        private Boolean receivedIt = false;

        [TestMethod]
        public void TestConnect()
        {
            ICanTrafficInterface canLoopback = new CanLoopback(ReceivedCanPacketCallBack);

            canLoopback.Connect();
            Assert.IsTrue(canLoopback.IsConnected());

            canLoopback.Disconnect();
            Assert.IsFalse(canLoopback.IsConnected());
        }

        [TestMethod]
        public void TestReceived()
        {
            ICanTrafficInterface canLoopback = new CanLoopback(ReceivedCanPacketCallBack);

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
