using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainingFile
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int inputNum = int.Parse(Console.ReadLine());

            Stack<int> number = new Stack<int>();

            while (inputNum > 0)
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
