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
        public void MainTest()
        {
            var expected = new string[]
            {
                "08:00 - 08:30",
                "08:30 - 09:00",
                "09:00 - 09:30",
                "09:30 - 10:00",
                "11:30 - 12:00",
                "12:00 - 12:30",
                "12:30 - 13:00",
                "13:00 - 13:30",
                "13:30 - 14:00",
                "14:00 - 14:30",
                "14:30 - 15:00",
                "15:40 - 16:10",
                "16:10 - 16:40",
                "17:30 - 18:00"
            };
         
            Calculations calc = new
            (
                startTimes: new TimeSpan[] {
                    new TimeSpan(10, 0, 0),
                    new TimeSpan(11, 0, 0),
                    new TimeSpan(15, 0, 0),
                    new TimeSpan(15, 30, 0),
                    new TimeSpan(16, 50, 0),
                },
                durations: new int[] { 60, 30, 10, 10, 40 },
                beginWorkingTime: TimeSpan.FromHours(8),
                endWorkingTime: TimeSpan.FromHours(18),
                consultationTime: 30
            );

            var actual = calc.AvailablePeriods();

            for (int i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}
