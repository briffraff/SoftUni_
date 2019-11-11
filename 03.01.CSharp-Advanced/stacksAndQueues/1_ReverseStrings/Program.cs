using System;
using System.Collections.Generic;

namespace _1_ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<string> stack = new Stack<string>();

            foreach (var letter in input)
            {
                stack.Push(letter.ToString());
            }

            foreach (var letter in stack)
            {
                Console.Write(letter);
            }

            Console.WriteLine();
        }
    }
}
