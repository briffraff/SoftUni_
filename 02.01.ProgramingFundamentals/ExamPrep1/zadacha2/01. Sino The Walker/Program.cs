using System;
using System.Linq;

namespace _01._Sino_The_Walker
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] time = Console.ReadLine().Split(':').Select(int.Parse).ToArray();

            int seconds = time[2];
            int minutes = time[1];
            int hours = time[0];

            int stepsCount = int.Parse(Console.ReadLine()) % 86400;
            int secondsPersStep = int.Parse(Console.ReadLine()) % 86400;

            int timetoAdd = stepsCount * secondsPersStep;

            seconds += timetoAdd;

            for (int i = 0; i < time.Length; i++)
            {
                if (seconds >= 60)
                {
                    seconds -= 60;
                    minutes += 1;
                    i--;
                }

                if (minutes >= 60)
                {
                    minutes -= 60;
                    hours += 1;
                }

                if (hours > 23)
                {
                    hours = 0;
                }
            }

            Console.WriteLine($"Time Arrival: {hours:d2}:{minutes:d2}:{seconds:d2}");

        }
    }
}
