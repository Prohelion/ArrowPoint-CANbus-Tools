using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Model;
using ArrowPointCANBusTool.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTest.Services
{
    [TestFixture]
    class BatteryChargeServiceTest
    {

        [Test]
        public void CreateChargeService()
        {
            BatteryChargeService batteryChargeService = BatteryChargeService.Instance;
            Assert.AreEqual(batteryChargeService.ChargeToPercentage, 100);
        }

//        [Test]
        public void BasicChargeTest()
        {

            CanService.Instance.ConnectViaLoopBack();
            
            CanPacket bmuOneEngaged = new CanPacket(0x6F7);
            bmuOneEngaged.SetUint8(1,BMU.PRECHARGE_STATUS_RUN);
            bmuOneEngaged.SetUint8(0, 0x04);

            CanPacket bmuTwoEngaged = new CanPacket(0x6F7);
            bmuTwoEngaged.SetUint8(1, BMU.PRECHARGE_STATUS_RUN);
            bmuTwoEngaged.SetUint8(0, 0x04);

            CanService.Instance.SendMessage(bmuOneEngaged);
            CanService.Instance.SendMessage(bmuTwoEngaged);

            BatteryChargeService batteryChargeService = BatteryChargeService.Instance;
            batteryChargeService.ChargerService = TDKService.Instance;

            batteryChargeService.StartCharge();
            Assert.IsTrue(batteryChargeService.IsCharging);
            batteryChargeService.StopCharge();
            Assert.IsFalse(batteryChargeService.IsCharging);

            CanService.Instance.Disconnect();
        }

    }
}
