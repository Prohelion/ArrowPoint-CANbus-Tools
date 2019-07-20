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
    [NonParallelizable]
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
        [NonParallelizable]
        public void CheckBasicComms()
        {
            TDKService tdkService = TDKService.NewInstance;            
            tdkService.ChargerIpAddress = ChargerIpAddress;
            tdkService.ChargerIpPort = ChargerIpPort;
            tdkService.SendMessageGetResponse("ADR 05");
            Assert.AreEqual("OK", tdkService.SendMessageGetResponse("RMT LOC"));
            Assert.AreEqual("LOC",tdkService.SendMessageGetResponse("RMT?"));
        }

        [Test]
        [NonParallelizable]
        public void CheckNetworkError()
        {
            TDKService tdkService = TDKService.NewInstance;
            tdkService.ChargerIpAddress = null;            

            try
            {
                tdkService.SendMessageGetResponse("RMT LOC");
            } catch
            {
                Assert.IsTrue(true, "Network should have thrown an exception");
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
        [NonParallelizable]
        public void StartStopChargeTest()
        {            
            TDKService tdkService = TDKService.NewInstance;
            tdkService.ChargerIpAddress = ChargerIpAddress;
            tdkService.ChargerIpPort = ChargerIpPort;
            tdkService.SupplyVoltageLimit = 230;
            tdkService.SupplyCurrentLimit = 10;

            tdkService.StartCharge();
            Assert.IsTrue(tdkService.IsCharging,"Charger is not charging and should be");

            tdkService.StopCharge();
            Assert.IsFalse(tdkService.IsCharging, "Charger is charging and should be stopped");                        
        }

        [Test]
        [NonParallelizable]
        public void SetChargePower()
        {
            TDKService tdkService = TDKService.NewInstance;
            tdkService.ChargerIpAddress = ChargerIpAddress;
            tdkService.ChargerIpPort = ChargerIpPort;
            tdkService.SupplyVoltageLimit = 230;
            tdkService.SupplyCurrentLimit = 10;

            tdkService.StartCharge();
            Assert.IsTrue(tdkService.IsCharging,"Charger is not charging and should be");

            tdkService.RequestedCurrent = 3.2f;
            tdkService.RequestedVoltage = 32.1f;

            // We call it twice as it gets set on the first time and read on the second
            tdkService.ChargerUpdateInner();
            tdkService.ChargerUpdateInner();

            Assert.AreEqual(tdkService.ChargerCurrent, tdkService.RequestedCurrent);
            Assert.AreEqual(tdkService.ChargerVoltage, tdkService.RequestedVoltage);

            tdkService.StopCharge();
            Assert.IsFalse(tdkService.IsCharging, "Charger is still charging and should be stopped");
        }

        [Test]
        [NonParallelizable]
        public void OverVoltageTest()
        {
            TDKService tdkService = TDKService.NewInstance;
            // 300V is the max for the charger
            tdkService.SupplyVoltageLimit = 230;
            tdkService.SupplyCurrentLimit = 10;
            tdkService.RequestedVoltage = 500;
            Assert.AreEqual(tdkService.ChargerVoltage, tdkService.ChargerVoltageLimit, "Voltage has not been dropped to the Supply Voltage limit");
            
            tdkService.SupplyVoltageLimit = 120;
            tdkService.SupplyCurrentLimit = 10;

            // Power supply voltage is now lower than the max for the charger
            // so the charger can only supply at that voltage
            tdkService.RequestedVoltage = tdkService.ChargerVoltageLimit;
            Assert.AreEqual(tdkService.ChargerVoltage, 120);
        }

        [Test]
        [NonParallelizable]
        public void OverCurrentTest()
        {
            // Request more current that the charger provides, make sure it steps us down
            TDKService tdkService = TDKService.NewInstance;
            tdkService.SupplyVoltageLimit = 230;
            tdkService.SupplyCurrentLimit = 10;
            tdkService.RequestedCurrent = 80;
            Assert.AreEqual(tdkService.ChargerCurrent, tdkService.ChargerCurrentLimit);

            // Request more current that the mains provides, make sure it steps us down            
            tdkService.SupplyVoltageLimit = 230;
            tdkService.SupplyCurrentLimit = 10;
            tdkService.RequestedCurrent = 20;
            Assert.AreEqual(tdkService.ChargerCurrent, 5);
        }

        [Test]
        [NonParallelizable]
        public void AdjustVoltageTest()
        {
            TDKService tdkService = TDKService.NewInstance;
            tdkService.SupplyVoltageLimit = 230;
            tdkService.SupplyCurrentLimit = 10;
            tdkService.RequestedVoltage = 160;

            Assert.AreEqual(tdkService.ChargerVoltage, 160);

            tdkService.RequestedVoltage = 150;
            Assert.AreEqual(tdkService.ChargerVoltage, 150);

            tdkService.RequestedVoltage = 170;
            Assert.AreEqual(tdkService.ChargerVoltage, 170);

            tdkService.RequestedVoltage = 0;
            Assert.AreEqual(tdkService.ChargerVoltage, 0);

            tdkService.RequestedVoltage = 120;
            Assert.AreEqual(tdkService.ChargerVoltage, 120);

            // Over the max of the charger, so should bring us back down
            tdkService.RequestedVoltage = 240;
            Assert.AreEqual(tdkService.ChargerVoltage, tdkService.ChargerVoltageLimit);

            tdkService.RequestedVoltage = 0;
            Assert.AreEqual(tdkService.ChargerVoltage, 0);
        }

        [Test]
        [NonParallelizable]
        public void AdjustCurrentTest()
        {
            TDKService tdkService = TDKService.NewInstance;
            tdkService.SupplyVoltageLimit = 230;
            tdkService.SupplyCurrentLimit = 10;

            // Max available is 5
            tdkService.RequestedCurrent = 8;

            Assert.AreEqual(tdkService.ChargerCurrent, 5);

            tdkService.RequestedCurrent = 7;
            Assert.AreEqual(tdkService.ChargerCurrent, 5);

            tdkService.RequestedCurrent = 4;
            Assert.AreEqual(tdkService.ChargerCurrent, 4);

            tdkService.RequestedCurrent = 0;
            Assert.AreEqual(tdkService.ChargerCurrent, 0);

            tdkService.RequestedCurrent = 3;
            Assert.AreEqual(tdkService.ChargerCurrent, 3);

            // Over the max of the supply, so should bring us back down
            tdkService.RequestedCurrent = 11;
            Assert.AreEqual(tdkService.ChargerCurrent, 5);

            tdkService.RequestedCurrent = 0;
            Assert.AreEqual(tdkService.ChargerCurrent, 0);
        }


    }
}
