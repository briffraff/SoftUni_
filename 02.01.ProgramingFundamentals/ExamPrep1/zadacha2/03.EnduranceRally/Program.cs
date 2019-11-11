using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.EnduranceRally
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] driverNames = Console.ReadLine().Split().ToArray();
            double[] trackZones = Console.ReadLine().Split().Select(double.Parse).ToArray();
            int[] checkPointIdx = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<double> Fuel = new List<double>();

            foreach (var currentName in driverNames)
            {
                double startingFuel = (double)currentName[0];
                Fuel.Add(startingFuel);
            }

            for (int i = 0; i < trackZones.Length; i++)
            {
                if (checkPointIdx.Contains(i))
                {
                    for (int j = 0; j < driverNames.Length; j++)
                    {
                        if (Fuel[j] > 0)
                        {
                            Fuel[j] += trackZones[i];
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < driverNames.Length; j++)
                    {
                        if (Fuel[j] > 0)
                        {
                            Fuel[j] -= trackZones[i];

                            if (Fuel[j] <= 0)
                            {
                                Fuel[j] = i * -1;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < driverNames.Length; i++)
            {
                if (Fuel[i] > 0)
                {
                    Console.WriteLine($"{driverNames[i]} - fuel left {Fuel[i]:f2}");
                }
                else
                {
                    Console.WriteLine($"{driverNames[i]} - reached {Fuel[i] * -1}");
                }
            }

        }
    }
}
