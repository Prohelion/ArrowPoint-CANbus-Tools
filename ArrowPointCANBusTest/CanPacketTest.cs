using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArrowPointCANBusTool.CanBus;

namespace ArrowPointCANBusTest
{
    [TestClass]
    public class CanPacketTest
    {
        [TestMethod]
        public void TestCanId500()
        {
            CanPacket canPacket = new CanPacket(0x500);
            Assert.AreEqual(canPacket.CanId, (uint)0x500);
        }

        [TestMethod]
        public void TestCanId500Base10()
        {
            CanPacket canPacket = new CanPacket(0x500);
            Assert.AreEqual(canPacket.CanIdBase10, (uint)1280);
        }

        [TestMethod]
        public void TestCanId500Hex()
        {
            CanPacket canPacket = new CanPacket(0x500);
            Assert.AreEqual(canPacket.CanIdAsHex.ToString(), "500");
        }

        [TestMethod]
        public void TestCanIdLarge()
        {
            CanPacket canPacket = new CanPacket((int)0x1806E5F4ul);
            Assert.AreEqual(canPacket.CanId, (uint)0x1806E5F4ul);
        }

        [TestMethod]
        public void TestCanIdLargeBase10()
        {
            CanPacket canPacket = new CanPacket((int)0x1806E5F4ul);
            Assert.AreEqual(canPacket.CanIdBase10, (uint)403105268);
        }
        
        [TestMethod]
        public void TestCanIdLargeHex()
        {
            CanPacket canPacket = new CanPacket((int)0x1806E5F4ul);
            Assert.AreEqual(canPacket.CanIdAsHex.ToString(), "1806E5F4");
        }

    }
}
