using System;
using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.CanBus;
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
            ICanInterface canLoopback = new CanLoopback(ReceivedCanPacketCallBack);

            canLoopback.Connect();
            Assert.IsTrue(canLoopback.IsConnected());

            canLoopback.Disconnect();
            Assert.IsFalse(canLoopback.IsConnected());
        }

        [TestMethod]
        public void TestReceived()
        {
            ICanInterface canLoopback = new CanLoopback(ReceivedCanPacketCallBack);

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
