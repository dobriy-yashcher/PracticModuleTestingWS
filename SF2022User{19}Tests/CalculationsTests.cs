using SF2022User_19_Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF2022User_19_Tests
{
    [TestClass]
    public class CalculationsTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Calculations calc = new
            (
                startTimes: null,
                durations: null,
                beginWorkingTime: TimeSpan.FromHours(8),
                endWorkingTime: TimeSpan.FromHours(18),
                consultationTime: 30
            );

            var res = calc.AvailablePeriods();

            Assert.IsNotNull( calc );
        }
    }
}
