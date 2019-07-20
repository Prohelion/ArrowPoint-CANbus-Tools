using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArrowPointCANBusTool.Services;

namespace ArrowPointCANBusTest.Services
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    [TestFixture]
    class TDKServiceTest
    {
        private TDKSimulator tdkSimulator;

        private readonly bool USE_SIMULATOR = true;
        private string ChargerIpAddress;
        private int ChargerIpPort;

        [SetUp]
        public void RunBeforeAnyTests()
        {
            if (USE_SIMULATOR)
            {
                ChargerIpAddress = "127.0.0.1";
                ChargerIpPort = 10000;

                tdkSimulator = new TDKSimulator
                {
                    SimulatorIpAddress = ChargerIpAddress,
                    SimulatorIpPort = ChargerIpPort
                };
                tdkSimulator.StartSimulator();
                Thread.Sleep(100);
            }
            else
            {
                ChargerIpAddress = "192.168.14.35";
                ChargerIpPort = 100;
            }
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            tdkSimulator?.StopSimulator();
        }

        [Test]
        public void CheckBasicComms()
        {
            TDKService tdkService = TDKService.Instance;            
            tdkService.ChargerIpAddress = ChargerIpAddress;
            tdkService.ChargerIpPort = ChargerIpPort;
            Assert.AreEqual("OK", tdkService.SendMessageGetResponse("RMT LOC"));
            Assert.AreEqual("LOC",tdkService.SendMessageGetResponse("RMT?"));
        }

        [Test]
        public void CheckNetworkError()
        {
            TDKService tdkService = TDKService.Instance;
            tdkService.ChargerIpAddress = null;            

            try
            {
                tdkService.SendMessageGetResponse("RMT LOC");
            } catch
            {
                Assert.IsTrue(true, "Network should have thown an exception");
            }

            tdkService.ChargerIpAddress = ChargerIpAddress;
            tdkService.ChargerIpPort = ChargerIpPort;

            try
            {
                tdkService.SendMessageGetResponse("RMT LOC");                
            }
            catch
            {
                Assert.Fail("Network should not have thown an exception, look like IP is not set");
            }
        }

        [Test]
        public void StartStopChargeTest()
        {            
            TDKService tdkService = TDKService.Instance;
            tdkService.ChargerIpAddress = ChargerIpAddress;
            tdkService.ChargerIpPort = ChargerIpPort;
            tdkService.SupplyVoltageLimit = 230;
            tdkService.SupplyCurrentLimit = 10;

            tdkService.StartCharge();

            Assert.IsTrue(tdkService.IsCharging);

            tdkService.StopCharge();
            Assert.IsFalse(tdkService.IsCharging);                        
        }

        [Test]
        public void SetChargePower()
        {
            TDKService tdkService = TDKService.Instance;
            tdkService.ChargerIpAddress = ChargerIpAddress;
            tdkService.ChargerIpPort = ChargerIpPort;
            tdkService.SupplyVoltageLimit = 230;
            tdkService.SupplyCurrentLimit = 10;

            tdkService.StartCharge();
            Assert.IsTrue(tdkService.IsCharging);

            tdkService.CurrentRequested = 3.2f;
            tdkService.VoltageRequested = 32.1f;

            // We call it twice as it gets set on the first time and read on the second
            tdkService.UpdateInner();
            tdkService.UpdateInner();

            Assert.AreEqual(tdkService.ChargerCurrent, tdkService.CurrentRequested);
            Assert.AreEqual(tdkService.ChargerVoltage, tdkService.VoltageRequested);

            tdkService.StopCharge();
            Assert.IsFalse(tdkService.IsCharging);
        }

        [Test]
        public void OverVoltageTest()
        {
            TDKService tdkService = TDKService.Instance;
            // 300V is the max for the charger
            tdkService.SupplyVoltageLimit = 230;
            tdkService.SupplyCurrentLimit = 10;
            tdkService.VoltageRequested = 500;
            Assert.AreEqual(tdkService.ChargerVoltage, tdkService.ChargerVoltageLimit);
            
            tdkService.SupplyVoltageLimit = 120;
            tdkService.SupplyCurrentLimit = 10;

            // Power supply voltage is now lower than the max for the charger
            // so the charger can only supply at that voltage
            tdkService.VoltageRequested = tdkService.ChargerVoltageLimit;
            Assert.AreEqual(tdkService.ChargerVoltage, 120);
        }

        [Test]
        public void OverCurrentTest()
        {
            // Request more current that the charger provides, make sure it steps us down
            TDKService tdkService = TDKService.Instance;
            tdkService.SupplyVoltageLimit = 230;
            tdkService.SupplyCurrentLimit = 10;
            tdkService.CurrentRequested = 80;
            Assert.AreEqual(tdkService.ChargerCurrent, tdkService.ChargerCurrentLimit);

            // Request more current that the mains provides, make sure it steps us down            
            tdkService.SupplyVoltageLimit = 230;
            tdkService.SupplyCurrentLimit = 10;
            tdkService.CurrentRequested = 20;
            Assert.AreEqual(tdkService.ChargerCurrent, 5);
        }

        [Test]
        public void AdjustVoltageTest()
        {
            TDKService tdkService = TDKService.Instance;
            tdkService.SupplyVoltageLimit = 230;
            tdkService.SupplyCurrentLimit = 10;
            tdkService.VoltageRequested = 160;

            Assert.AreEqual(tdkService.ChargerVoltage, 160);

            tdkService.VoltageRequested = 150;
            Assert.AreEqual(tdkService.ChargerVoltage, 150);

            tdkService.VoltageRequested = 170;
            Assert.AreEqual(tdkService.ChargerVoltage, 170);

            tdkService.VoltageRequested = 0;
            Assert.AreEqual(tdkService.ChargerVoltage, 0);

            tdkService.VoltageRequested = 120;
            Assert.AreEqual(tdkService.ChargerVoltage, 120);

            // Over the max of the charger, so should bring us back down
            tdkService.VoltageRequested = 240;
            Assert.AreEqual(tdkService.ChargerVoltage, tdkService.ChargerVoltageLimit);

            tdkService.VoltageRequested = 0;
            Assert.AreEqual(tdkService.ChargerVoltage, 0);
        }

        [Test]
        public void AdjustCurrentTest()
        {
            TDKService tdkService = TDKService.Instance;
            tdkService.SupplyVoltageLimit = 230;
            tdkService.SupplyCurrentLimit = 10;

            // Max available is 5
            tdkService.CurrentRequested = 8;

            Assert.AreEqual(tdkService.ChargerCurrent, 5);

            tdkService.CurrentRequested = 7;
            Assert.AreEqual(tdkService.ChargerCurrent, 5);

            tdkService.CurrentRequested = 4;
            Assert.AreEqual(tdkService.ChargerCurrent, 4);

            tdkService.CurrentRequested = 0;
            Assert.AreEqual(tdkService.ChargerCurrent, 0);

            tdkService.CurrentRequested = 3;
            Assert.AreEqual(tdkService.ChargerCurrent, 3);

            // Over the max of the supply, so should bring us back down
            tdkService.CurrentRequested = 11;
            Assert.AreEqual(tdkService.ChargerCurrent, 5);

            tdkService.CurrentRequested = 0;
            Assert.AreEqual(tdkService.ChargerCurrent, 0);
        }


    }
}
