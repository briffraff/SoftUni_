using System;
using System.Text;
using Chronometer.Interfaces;

namespace Chronometer
{
    class Program
    {
        static void Main(string[] args)
        {
            Chronometer chrono = new Chronometer();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "exit")
            {
                string command = input;

                switch (command)
                {
                    case "start":
                        chrono.Start();
                        break;
                    case "stop":
                        chrono.Stop();
                        break;
                    case "lap":
                        chrono.Lap();
                        break;
                    case "laps":
                        var laps = chrono.Laps;

                        StringBuilder sb = new StringBuilder();

                        int index = 0;

                        if (laps.Count == 0)
                        {
                            sb.AppendLine("Laps: no laps");
                            Console.WriteLine(sb.ToString().TrimEnd());
                            sb.Clear();
                            continue;
                        }

                        sb.AppendLine("Laps:");
                        foreach (var lap in laps)
                        {
                            sb.AppendLine($"{index}. {lap}");
                            index++;
                        }

                        Console.WriteLine(sb.ToString().TrimEnd());

                        break;
                    case "time":
                        var time = chrono.GetTime;
                        Console.WriteLine(time);
                        break;
                    case "reset":
                        chrono.Reset();
                        break;
                }
            }
        }
    }
}
