using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());

                if (numbers.ContainsKey(currentNum) == false)
                {
                    numbers.Add(currentNum, 0);
                }

                numbers[currentNum]++;
            }

            Console.WriteLine(numbers.Where(x => x.Value % 2 == 0).FirstOrDefault().Key);
        }
    }
}
