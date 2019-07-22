using System;
using System.Threading;
using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Services;
using NUnit.Framework;

namespace ArrowPointCANBusTest.Services
{
    [TestFixture]
    [NonParallelizable]
    public class CanServiceTest
    {

        [Test]
        [NonParallelizable]
        public void ConnectTest()
        {
            CanService canService = CanService.NewInstance;
            canService.ConnectViaLoopBack();

            Assert.IsTrue(canService.IsConnected(),"Can Service is Not Connected");

            canService.Disconnect();

            Assert.IsFalse(canService.IsConnected(), "Can Service is Not Disconnected");
        }

        [Test]
        [NonParallelizable]
        public void SendMessage()
        {
            CanService canService = CanService.NewInstance;
            canService.ConnectViaLoopBack();

            Assert.IsTrue(canService.IsConnected(), "Can Service is Not Connected");

            CanPacket canPacket = new CanPacket(0x400);
            Assert.IsNull(canService.LastestCanPacketById(0x400),"A Can Packet exists when it should not");

            canService.SendMessage(canPacket);

            Assert.IsNotNull(canService.LastestCanPacketById(0x400),"Can Packet does not appear to have been sent and received");

            canService.Disconnect();
            Assert.IsFalse(canService.IsConnected(), "Can Service is Not Disconnected");
        }

        [Test]
        [NonParallelizable]
        public void SendAt10HzTest()
        {
            CanService canService = CanService.NewInstance;
            canService.ConnectViaLoopBack();            
            canService.ClearLastCanPacket();

            Assert.IsTrue(canService.IsConnected());

            CanPacket canPacket = new CanPacket(0x500);

            Assert.IsNull(canService.LastestCanPacketById(0x500));

            canService.SetCanToSendAt10Hertz(canPacket);

            // Normally you would see one every 1/10 of a second           
            // first one arrives instantly as we are on local loopback
            Assert.IsNotNull(canService.LastestCanPacketById(0x500));

            canService.ClearLastCanPacket();
            Assert.IsNull(canService.LastestCanPacketById(0x500));

            Thread.Sleep(250);

            // Normally you would see one every 1/10 of a second       
            // so we wait for the seoncd one
            Assert.IsNotNull(canService.LastestCanPacketById(0x500));

            canService.ClearLastCanPacket();

            canService.StopSendingCanAt10Hertz(canPacket);

            Thread.Sleep(250);

            Assert.IsNull(canService.LastestCanPacketById(0x500));

            canService.Disconnect();
            Assert.IsFalse(canService.IsConnected());
        }

    }
}
