using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.HornetArmada
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, long> legionsActivity = new Dictionary<string, long>();

            Dictionary<string, Dictionary<string, long>> legionInfo = 
                new Dictionary<string, Dictionary<string, long>>();

            while (n-- > 0)
            {
                string[] data = Console.ReadLine()
                    .Split("=->: ".ToCharArray(),StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                long lastActivity = long.Parse(data[0]);
                string legionName = data[1];
                string soldierType = data[2];
                long soldierCount = long.Parse(data[3]);




            }
        }
    }
}
