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


    }
}