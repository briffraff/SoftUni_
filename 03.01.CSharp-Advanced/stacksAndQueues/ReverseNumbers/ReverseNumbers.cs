using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseNumbers
{
    class ReverseNumbers
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();

            Stack<int> numbers = new Stack<int>(input.Length);

            foreach (var num in input)
            {
                numbers.Push(int.Parse(num));
            }

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
