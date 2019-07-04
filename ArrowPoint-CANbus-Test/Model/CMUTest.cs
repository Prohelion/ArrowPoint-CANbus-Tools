using System;
using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Model;
using ArrowPointCANBusTool.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrowPointCANBusTest.Model
{
    [TestClass]
    public class CMUTest
    {
        [TestMethod]
        public void SetupCMU()
        {
            CanService.Instance.ConnectViaLoopBack();

            CMU cmu = new CMU(0x203, true);
            Assert.IsTrue(cmu.InRange(new CanPacket(0x204)));
            Assert.IsFalse(cmu.InRange(new CanPacket(0x207)));
        }

        [TestMethod]
        public void SimulateSOCCan()
        {
            CanService.Instance.ConnectViaLoopBack();

            CMU cmu = new CMU(0x203, true);

            Assert.IsNull(cmu.CellTemp);
            Assert.AreEqual(cmu.State, CanReceivingNode.STATE_NA);

            
            CanPacket PCBcanPacket = new CanPacket(0x203);
            PCBcanPacket.SetInt16(2, 520);  // PCB Temp
            PCBcanPacket.SetInt16(3, 320);  // PCB Temp
            cmu.TestCanPacketReceived(PCBcanPacket);
            Assert.AreEqual(cmu.PCBTemp, 52);
            Assert.AreEqual(cmu.CellTemp, 32);
            Assert.AreEqual(cmu.State, CanReceivingNode.STATE_ON);
            
            CanPacket Battery1canPacket = new CanPacket(0x204);
            Battery1canPacket.SetUint16(0, 1);
            Battery1canPacket.SetUint16(1, 11);
            Battery1canPacket.SetUint16(2, 21);
            Battery1canPacket.SetUint16(3, 31);
            cmu.TestCanPacketReceived(Battery1canPacket);

            CanPacket Battery2canPacket = new CanPacket(0x205);
            Battery2canPacket.SetUint16(0, 41);
            Battery2canPacket.SetUint16(1, 51);
            Battery2canPacket.SetUint16(2, 61);
            Battery2canPacket.SetUint16(3, 71);
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
            
        }

    }
}
