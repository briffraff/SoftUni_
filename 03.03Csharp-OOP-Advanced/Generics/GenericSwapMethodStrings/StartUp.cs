using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodStrings
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            List<string> messages = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();
                messages.Add(message);
            }

            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            TheList<string> list = new TheList<string>(messages);
            list.Swap(indexes[0],indexes[1]);
            Console.WriteLine(list);


        }
    }
}
