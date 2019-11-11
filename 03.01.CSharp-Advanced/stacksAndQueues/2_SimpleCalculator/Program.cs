using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Stack<string> numbers = new Stack<string>(input.Reverse());

            while (numbers.Count > 1)
            {
                int currentNum = int.Parse(numbers.Pop());
                string theOperator = numbers.Pop();
                int nextNum = int.Parse(numbers.Pop());

                switch (theOperator)
                {
                    case "+":
                        numbers.Push((currentNum + nextNum).ToString());
                        break;
                    case "-":
                        numbers.Push((currentNum - nextNum).ToString());
                        break;
                }
            }
            Console.WriteLine(numbers.Pop());
        }
    }
}
