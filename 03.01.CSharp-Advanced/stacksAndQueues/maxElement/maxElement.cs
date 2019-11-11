using System;
using System.Collections.Generic;
using System.Linq;

namespace maxElement
{
    class maxElement
    {
        static void Main(string[] args)
        {
            int queriesCount = int.Parse(Console.ReadLine());
            Stack<int> Nums = new Stack<int>(queriesCount);

            for (int i = 0; i < queriesCount; i++)
            {
                string input = Console.ReadLine();

                if (input.Length > 1)
                {
                    string[] split = input.Split(" ");
                    int command = int.Parse(split[0]);
                    int number = int.Parse(split[1]);

                    Nums.Push(number);
                }
                else if (input == "2")
                {
                    Nums.Pop();
                }
                else if (input == "3")
                {
                    int currentMaxNumber = Int32.MinValue;

                    foreach (var num in Nums)
                    {
                        if (num > currentMaxNumber)
                        {
                            currentMaxNumber = num;
                        }
                    }
                    Console.WriteLine(currentMaxNumber);
                }
            }
        }
    }
}
