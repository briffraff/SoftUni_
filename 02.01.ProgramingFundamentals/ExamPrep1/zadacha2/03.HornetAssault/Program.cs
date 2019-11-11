using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HornetAssault
{
    class Program
    {
        static void Main(string[] args)
        {

            List<long> beehives = Console.ReadLine()
                .Split(" ")
                .Select(long.Parse)
                .ToList();

            List<long> hornets = Console.ReadLine()
                .Split(" ")
                .Select(long.Parse)
                .ToList();


            for (int i = 0; i < beehives.Count; i++)
            {
                long hornetsPower = hornets.Sum();

                if (beehives[i] < hornetsPower)
                {
                    beehives[i] = 0;
                }
                else
                {
                    beehives[i] -= hornetsPower;
                    hornets.RemoveAt(0);
                }
            }

            if (beehives.Sum() > 0)
            {
                 Console.WriteLine(string.Join(" ",beehives
                     .Where(b => b != 0)));
            }
            else
            {
                Console.WriteLine(string.Join(" ",hornets));
            }
        }
    }
}
