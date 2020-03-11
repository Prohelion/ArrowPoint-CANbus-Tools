using System;
using ArrowPointCANBusTool.CanLibrary;
using ArrowPointCANBusTool.Model;
using ArrowPointCANBusTool.Services;
using NUnit.Framework;
using Prohelion.CanLibrary;

namespace ArrowPointCANBusTest.Model
{
    [TestFixture]
    public class CMUTest
    {
        [Test]
        public void SetupCMU()
        {
            CanService.Instance.ConnectViaLoopBack();

            CMU cmu = new CMU(0x203, true);
            Assert.IsTrue(cmu.InRange(new CanPacket(0x204)));
            Assert.IsFalse(cmu.InRange(new CanPacket(0x207)));

            CanService.Instance.Disconnect();
        }

        [Test]
        public void SimulateSOCCan()
        {
            CanService.Instance.ConnectViaLoopBack();

            CMU cmu = new CMU(0x203, true);

            Assert.IsNull(cmu.CellTemp);
            Assert.AreEqual(cmu.State, CanReceivingNode.STATE_NA);
            
            CanPacket PCBcanPacket = new CanPacket(0x203);
            PCBcanPacket.Short16Pos2 = 520;  // PCB Temp
            PCBcanPacket.Short16Pos3 = 320;  // PCB Temp
            cmu.TestCanPacketReceived(PCBcanPacket);
            Assert.AreEqual(cmu.PCBTemp, 52);
            Assert.AreEqual(cmu.CellTemp, 32);
            Assert.AreEqual(cmu.State, CanReceivingNode.STATE_ON);
            
            CanPacket Battery1canPacket = new CanPacket(0x204);
            Battery1canPacket.UShort16Pos0 = 1;
            Battery1canPacket.UShort16Pos1 = 11;
            Battery1canPacket.UShort16Pos2 = 21;
            Battery1canPacket.UShort16Pos3 = 31;
            cmu.TestCanPacketReceived(Battery1canPacket);

            CanPacket Battery2canPacket = new CanPacket(0x205);
            Battery2canPacket.UShort16Pos0 = 41;
            Battery2canPacket.UShort16Pos1 = 51;
            Battery2canPacket.UShort16Pos2 = 61;
            Battery2canPacket.UShort16Pos3 = 71;
            cmu.TestCanPacketReceived(Battery2canPacket);

            Assert.AreEqual(cmu.Cell0mV, (uint)1);
            Assert.AreEqual(cmu.Cell1mV, (uint)11);
            Assert.AreEqual(cmu.Cell2mV, (uint)21);
            Assert.AreEqual(cmu.Cell3mV, (uint)31);
            Assert.AreEqual(cmu.Cell4mV, (uint)41);
            Assert.AreEqual(cmu.Cell5mV, (uint)51);
            Assert.AreEqual(cmu.Cell6mV, (uint)61);
            Assert.AreEqual(cmu.Cell7mV, (uint)71);
            Assert.AreEqual(cmu.State, CanReceivingNode.STATE_ON);

            CanService.Instance.Disconnect();
        }

    }
}
