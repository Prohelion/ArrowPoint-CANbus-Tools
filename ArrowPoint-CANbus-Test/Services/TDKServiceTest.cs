using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTest.Services
{
    [TestFixture]
    class TDKServiceTest
    {
        private TDKSimulator tdkSimulator;

        [SetUp]
        public void RunBeforeAnyTests()
        {
            tdkSimulator = new TDKSimulator();
            tdkSimulator.StartSimulator();
        }

        [Test]
        public void DoNothing()
        {
            Assert.IsTrue(true);
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            tdkSimulator.StopSimulator();
        }


    }
}
