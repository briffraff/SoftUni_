using System;
using System.Collections.Generic;
using System.Linq;

namespace setsOfElements
{
    class setsOfElements
    {
        static void Main(string[] args)
        {
            int[] setsLenght = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int nSet = setsLenght[0];
            int mSet = setsLenght[1];
            int countNums = nSet + mSet;

            Dictionary<int,int> n = new Dictionary<int, int>();
            Dictionary<int, int> m = new Dictionary<int, int>();

            for (int i = 0; i < countNums; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (i < nSet)
                {
                    n[number] = 0;
                }
                else if( i > nSet-1)
                {
                    m[number] = 0;
                }
            }

            List<int> list = new List<int>();

            foreach (var num in n)
            {
                if (m.ContainsKey(num.Key))
                {
                    list.Add(num.Key);
                }
            }

            Console.Write(string.Join(" ",list));
            Console.WriteLine();
        }
    }
}
