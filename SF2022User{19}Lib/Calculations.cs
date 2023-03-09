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

                freeTimeInterval = $"{checkTime.Hours}:{checkTime.Minutes}-{checkTimeEnd.Hours}:{checkTimeEnd.Minutes}";
                result.Add(freeTimeInterval);

                /*if (checkTimeEnd < startTimes[currentDuration])
                {
                }*/
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