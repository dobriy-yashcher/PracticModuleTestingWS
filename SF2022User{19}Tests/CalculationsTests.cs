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
            var expected = new string[] {
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

            Calculations calc = new (
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
            CheckResult(actual, expected);
        }

        [TestMethod]
        public void AvailablePeriods_NoTimeAtBeginDay()
        {
            var expected = new string[] {
                "09:00 - 09:30",
                "09:30 - 10:00",
                "10:00 - 10:30",
                "10:30 - 11:00",
                "11:00 - 11:30",
                "11:30 - 12:00",
                "12:00 - 12:30",
                "12:30 - 13:00",
                "13:00 - 13:30",
                "13:30 - 14:00"
            };

            Calculations calc = new (
                startTimes: new TimeSpan[] {
                    new TimeSpan(8, 0, 0)
                },
                durations: new int[] { 60 },
                beginWorkingTime: TimeSpan.FromHours(8),
                endWorkingTime: TimeSpan.FromHours(14),
                consultationTime: 30
            );

            var actual = calc.AvailablePeriods();     
            CheckResult(actual, expected);
        }

        [TestMethod]
        public void AvailablePeriods_NoTimeAtEndDay()
        {
            var expected = new string[] {
                "08:00 - 08:30",
                "08:30 - 09:00",
                "09:00 - 09:30",
                "09:30 - 10:00",
                "10:00 - 10:30",
                "10:30 - 11:00",
                "11:00 - 11:30",
                "11:30 - 12:00",
                "12:30 - 13:00",
                "13:00 - 13:30",
                "13:30 - 14:00"
            };

            Calculations calc = new (
                startTimes: new TimeSpan[] {
                    new TimeSpan(12, 0, 0)
                },
                durations: new int[] { 30 },
                beginWorkingTime: TimeSpan.FromHours(8),
                endWorkingTime: TimeSpan.FromHours(14),
                consultationTime: 30
            );

            var actual = calc.AvailablePeriods();   
            CheckResult(actual, expected);
        }

        [TestMethod]
        public void AvailablePeriods_NoTimeBetweenConsultation()
        {
            var expected = new string[] {
                "08:00 - 08:30",
                "08:30 - 09:00",
                "09:00 - 09:30",
                "09:30 - 10:00",
                "10:00 - 10:30",
                "11:30 - 12:00",
                "12:00 - 12:30",
                "12:30 - 13:00",
                "13:00 - 13:30",
                "13:30 - 14:00"
            };

            Calculations calc = new (
                startTimes: new TimeSpan[] {
                    new TimeSpan(10, 30, 0),
                    new TimeSpan(11, 0, 0),
                },
                durations: new int[] { 20, 30 },
                beginWorkingTime: TimeSpan.FromHours(8),
                endWorkingTime: TimeSpan.FromHours(14),
                consultationTime: 30
            );

            var actual = calc.AvailablePeriods();    
            CheckResult(actual, expected);
        }

        [TestMethod]
        public void AvailablePeriods_DurationIs400_ZeroPeriodsReturned()
        {
            var expected = new string[] { };

            Calculations calc = new (
                startTimes: new TimeSpan[] {
                    new TimeSpan(8, 0, 0),
                },
                durations: new int[] { 400 },
                beginWorkingTime: TimeSpan.FromHours(8),
                endWorkingTime: TimeSpan.FromHours(14),
                consultationTime: 30
            );

            var actual = calc.AvailablePeriods();
            CheckResult(actual, expected);
        }

        [TestMethod]
        public void AvailablePeriods_BeginTimeOverEndTime_11Periods()
        {
            var expected = new string[] {
                "08:00 - 10:00",
                "10:00 - 12:00",
                "12:00 - 14:00",
                "14:00 - 16:00",
                "16:00 - 18:00",
                "18:00 - 20:00",
                "20:00 - 22:00",
                "22:00 - 00:00",
                "00:00 - 02:00",
                "02:00 - 04:00",
                "04:00 - 06:00"
            };

            Calculations calc = new (
                startTimes: new TimeSpan[] { },
                durations: new int[] { },
                beginWorkingTime: TimeSpan.FromHours(8),
                endWorkingTime: TimeSpan.FromHours(7),
                consultationTime: 120
            );

            var actual = calc.AvailablePeriods();   
            CheckResult(actual, expected);
        }

        [TestMethod]
        public void AvailablePeriods_ConsultationTimeOverWorkingTime_ZeroPeriodsReturned()
        {
            var expected = new string[] { };

            Calculations calc = new (
                startTimes: new TimeSpan[] { },
                durations: new int[] { },
                beginWorkingTime: TimeSpan.FromHours(8),
                endWorkingTime: TimeSpan.FromHours(9),
                consultationTime: 65
            );

            var actual = calc.AvailablePeriods();
            CheckResult(actual, expected);
        }

        /// <summary>
        /// ДОДЕЛАТЬ!
        /// </summary>
        [TestMethod]
        public void AvailablePeriods_ConsultationTimeIs37AndSomeBusyPeriods_00000000000000PeriodsReturned()
        {
            var expected = new string[] { };

            Calculations calc = new(
                startTimes: new TimeSpan[] { 
                    new TimeSpan(8, 0, 0),
                    new TimeSpan(8, 0, 0),
                    new TimeSpan(8, 0, 0),
                },
                durations: new int[] { },
                beginWorkingTime: TimeSpan.FromHours(8),
                endWorkingTime: TimeSpan.FromHours(15),
                consultationTime: 37
            );

            var actual = calc.AvailablePeriods();
            CheckResult(actual, expected);
        }

        private void CheckResult(string[] actual, string[] expected)
        {
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}
