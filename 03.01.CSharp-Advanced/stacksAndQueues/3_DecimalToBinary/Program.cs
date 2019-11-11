using System;
using System.Collections.Generic;

namespace _3_DecimalToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            long inputNum = long.Parse(Console.ReadLine());

            Stack<long> number = new Stack<long>();

            while (inputNum != 0)
            {
                number.Push(inputNum % 2);
                inputNum /= 2;
            }

            while (number.Count > 0)
            {
                Console.Write(number.Pop());
            }

            Console.WriteLine();
        }
    }
}
