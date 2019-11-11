using Chronometer.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chronometer
{
    public class Chronometer : IChronometer
    {
        private int miliseconds = 0;
        private int seconds = 0;
        private int minutes = 0;
        private bool isRunning = false;

        public Chronometer()
        {
            Laps = new List<string>();
        }

        public string GetTime => Calc();

        public List<string> Laps { get; }

        public void Start()
        {
            this.isRunning = true;

            Task.Run(() =>
            {
                while (this.isRunning)
                {
                    Thread.Sleep(1);
                    this.miliseconds++;
                }
            });
        }

        public void Stop()
        {
            this.isRunning = false;
        }

        public string Lap()
        {
            string lapTime = GetTime;
            this.Laps.Add(lapTime);
            return lapTime;

        }

        public void Reset()
        {
            this.Stop();
            miliseconds = 0;
            Laps.Clear();
        }

        private string Calc()
        {
            int currentMilisecond = miliseconds;
            miliseconds = currentMilisecond + miliseconds % 1000;
            minutes = miliseconds / 60000;
            seconds = miliseconds / 1000;

            string result = $"{minutes:D2}:{seconds:D2}:{miliseconds:D4}";
            return result;
        }


    }
}
