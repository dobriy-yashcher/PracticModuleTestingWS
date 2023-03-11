namespace SF2022User_19_Lib
{
    public class Calculations
    {
        public TimeSpan[] startTimes;
        public int[] durations;
        public TimeSpan beginWorkingTime;
        public TimeSpan endWorkingTime;
        public int consultationTime;

        public Calculations(TimeSpan[] startTimes, int[] durations, TimeSpan beginWorkingTime, TimeSpan endWorkingTime, int consultationTime)
        {
            this.startTimes = startTimes;
            this.durations = durations;
            this.beginWorkingTime = beginWorkingTime;
            this.endWorkingTime = endWorkingTime;
            this.consultationTime = consultationTime;
        }

        public string[] AvailablePeriods()
        {
            var result = new List<string>();
            int currentDuration = 0;

            for (TimeSpan checkTime = beginWorkingTime; checkTime < endWorkingTime; checkTime += TimeSpan.FromMinutes(consultationTime))
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