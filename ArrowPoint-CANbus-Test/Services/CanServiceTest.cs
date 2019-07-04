using System;
using System.Threading;
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
            CanService.Instance.ConnectViaLoopBack();

            Assert.IsTrue(CanService.Instance.IsConnected());

            CanService.Instance.Disconnect();
            Assert.IsFalse(CanService.Instance.IsConnected());
        }

        [TestMethod]
        public void SendMessage()
        {
            CanService.Instance.ConnectViaLoopBack();
            Assert.IsTrue(CanService.Instance.IsConnected());

            CanPacket canPacket = new CanPacket(0x400);
            Assert.IsNull(CanService.Instance.LastestCanPacketById(0x400));

            CanService.Instance.SendMessage(canPacket);

            Assert.IsNotNull(CanService.Instance.LastestCanPacketById(0x400));

            CanService.Instance.Disconnect();
            Assert.IsFalse(CanService.Instance.IsConnected());
        }

        [TestMethod]
        public void SendAt10HzTest()
        {            
            CanService.Instance.ConnectViaLoopBack();
            Assert.IsTrue(CanService.Instance.IsConnected());

            CanPacket canPacket = new CanPacket(0x400);

            Assert.IsNull(CanService.Instance.LastestCanPacketById(0x400));

            CanService.Instance.SetCanToSendAt10Hertz(canPacket);

            // Normally you would see one every 1/10 of a second           
            // first one arrives instantly as we are on local loopback
            Assert.IsNotNull(CanService.Instance.LastestCanPacketById(0x400));

            CanService.Instance.ClearLastCanPacket();
            Assert.IsNull(CanService.Instance.LastestCanPacketById(0x400));

            Thread.Sleep(250);

            // Normally you would see one every 1/10 of a second       
            // so we wait for the seoncd one
            Assert.IsNotNull(CanService.Instance.LastestCanPacketById(0x400));

            CanService.Instance.ClearLastCanPacket();

            CanService.Instance.StopSendingCanAt10Hertz(canPacket);

            Thread.Sleep(250);

            Assert.IsNull(CanService.Instance.LastestCanPacketById(0x400));

            CanService.Instance.Disconnect();
            Assert.IsFalse(CanService.Instance.IsConnected());
        }

    }
}
