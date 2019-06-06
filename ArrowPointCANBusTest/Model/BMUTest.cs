﻿using System;
using ArrowPointCANBusTool.CanBus;
using ArrowPointCANBusTool.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrowPointCANBusTest.Model
{
    [TestClass]
    public class BMUTest
    {
        [TestMethod]
        public void SetupBMU()
        {
            BMU bmu = new BMU(0x200);
            Assert.IsTrue(bmu.InRange(new CanPacket(0x202)));
            Assert.IsFalse(bmu.InRange(new CanPacket(0x2FF)));
        }

        [TestMethod]
        public void SimulateSOCCan()
        {
            BMU bmu = new BMU(0x200);

            CanPacket SOCcanPacket = new CanPacket(0x2F4);
            SOCcanPacket.SetFloat(0, 100);  // AMP Hours
            SOCcanPacket.SetFloat(1, 89);   // Percentage SOC

            bmu.Update(SOCcanPacket);

            Assert.AreEqual(bmu.SOCAh, (float)100);
            Assert.AreEqual(bmu.SOCPercentage, (float)89);            
        }

    }
}