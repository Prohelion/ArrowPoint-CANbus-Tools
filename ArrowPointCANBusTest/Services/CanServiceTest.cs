using System;
using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Charger;
using ArrowPointCANBusTool.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrowPointCANBusTest.Services
{
    [TestClass]
    public class CanServiceTest
    {

        [TestMethod]
        public void ConnectTest()
        {

            CanService canService = new CanService();
            canService.ConnectViaLoopBack();

            Assert.IsTrue(canService.IsConnected());

            canService.Disconnect();
            Assert.IsFalse(canService.IsConnected());
        }

        [TestMethod]
        public void SendMessage()
        {

            CanService canService = new CanService();
            canService.ConnectViaLoopBack();
            Assert.IsTrue(canService.IsConnected());

            CanPacket canPacket = new CanPacket(0x400);
            Assert.IsNull(canService.LastestCanPacket(0x400));

            canService.SendMessage(canPacket);

            Assert.IsNotNull(canService.LastestCanPacket(0x400));

            canService.Disconnect();
            Assert.IsFalse(canService.IsConnected());
        }

        [TestMethod]
        public void SendAt10HzTest()
        {

            CanService canService = new CanService();
            canService.ConnectViaLoopBack();
            Assert.IsTrue(canService.IsConnected());

            CanPacket canPacket = new CanPacket(0x400);

            Assert.IsNull(canService.LastestCanPacket(0x400));

            canService.SetCanToSendAt10Hertz(canPacket);

            // Normally you would wait half a second for this
            canService.CanSenderLoopInner();
            Assert.IsNotNull(canService.LastestCanPacket(0x400));

            canService.ClearLastCanPacket();
            Assert.IsNull(canService.LastestCanPacket(0x400));

            // Normally you would wait half a second for this
            canService.CanSenderLoopInner();
            Assert.IsNotNull(canService.LastestCanPacket(0x400));

            canService.Disconnect();
            Assert.IsFalse(canService.IsConnected());
        }

    }
}
