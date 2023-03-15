namespace SF2022User_19_Lib
{
    public class Calculations
    {
        private TimeSpan[] startTimes;
        private int[] durations;
        private TimeSpan beginWorkingTime;
        private TimeSpan endWorkingTime;
        private int consultationTime;

        public Calculations(TimeSpan[] startTimes, int[] durations, TimeSpan beginWorkingTime, TimeSpan endWorkingTime, int consultationTime)
        {
            this.startTimes = startTimes;
            this.durations = durations;
            this.beginWorkingTime = beginWorkingTime;
            if (beginWorkingTime >= endWorkingTime) endWorkingTime += TimeSpan.FromDays(1);
            this.endWorkingTime = endWorkingTime;
            this.consultationTime = consultationTime;
        }

        public string[] AvailablePeriods()
        {
            var result = new List<string>();
            int currentDuration = 0;

            for (TimeSpan checkTime = beginWorkingTime; checkTime + TimeSpan.FromMinutes(consultationTime) <= endWorkingTime; checkTime += TimeSpan.FromMinutes(consultationTime))
            {
                string freeTimeInterval;
                var checkTimeEnd = checkTime + TimeSpan.FromMinutes(consultationTime);

                if (currentDuration < durations.Length && checkTimeEnd > startTimes[currentDuration])
                {
                    checkTime = startTimes[currentDuration] + TimeSpan.FromMinutes(durations[currentDuration]);
                    checkTime -= TimeSpan.FromMinutes(consultationTime);

                    ++currentDuration;
                    continue;
                }

                freeTimeInterval = $"{checkTime.ToString("hh':'mm")} - {checkTimeEnd.ToString("hh':'mm")}";
                result.Add(freeTimeInterval);
            }                                                      

            return result.ToArray();
        }

        public void PrintAvailablePeriods()
        {
            var periods = this.AvailablePeriods();

            foreach (var period in periods)
            {
                Console.WriteLine(period);
            }
        }
    }
}