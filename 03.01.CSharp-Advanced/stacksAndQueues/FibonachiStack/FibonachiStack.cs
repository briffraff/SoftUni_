using System;
using System.Collections.Generic;

namespace FibonachiStack
{
    class FibonachiStack
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<long> fibonachiStack = new Stack<long>();

            fibonachiStack.Push(0);
            fibonachiStack.Push(1);

            for (int i = 0; i < n-1; i++)
            {
                long firstNum = fibonachiStack.Pop();
                long secondNum = fibonachiStack.Peek();

                fibonachiStack.Push(firstNum);
                fibonachiStack.Push(firstNum + secondNum);
            }

            Console.WriteLine(fibonachiStack.Peek());
        }
    }
}
