using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSymbols
{
    class CountSymbols
    {
        static void Main(string[] args)
        {
            Dictionary<char,int> dict = new Dictionary<char, int>();

            string input = Console.ReadLine();

            foreach (var character in input)
            {
                if (dict.ContainsKey(character) == false)
                {
                    dict.Add(character,0);
                }

                dict[character]++;
            }

            foreach (var item in dict.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
