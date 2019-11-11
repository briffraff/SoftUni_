using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriodicTable
{
    class PeriodicTable
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] splitInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                foreach (var compound in splitInput)
                {
                    set.Add(compound);
                }

            }

            Console.WriteLine(string.Join(" ", set.OrderBy(x => x)));
        }
    }
}
