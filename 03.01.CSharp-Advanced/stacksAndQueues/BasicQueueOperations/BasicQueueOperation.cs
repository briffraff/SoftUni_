using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class BasicQueueOperation
    {
        static void Main(string[] args)
        {
            //GET FIRST LINE
            string[] references = Console.ReadLine().Split(" ").ToArray();

            int numbersToEnque = 0;
            int numbersToDeque = 0;
            int number = 0;

            if (references.Length == 3)
            {
                numbersToEnque = int.Parse(references[0]);
                numbersToDeque = int.Parse(references[1]);
                number = int.Parse(references[2]);
            }
            else
            {
                Environment.Exit(0);
            }

            //GET SECOND LINE
            string[] inputNums = Console.ReadLine().Split(' ').ToArray();

            Queue<int> numbers = new Queue<int>(inputNums.Length);

            for (int i = numbersToEnque - numbersToDeque; i > 0; i--)
            {
                numbers.Enqueue(int.Parse(inputNums[i]));
            }

            //PRINT
            if (numbers.Contains(number))
            {
                Console.WriteLine("true");
            }
            else if (numbers.Count == 0)
            {
                Console.WriteLine("0");
            }
            else if (numbers.Contains(number) == false)
            {
                int smallestNumber = Int32.MaxValue;

                foreach (var num in numbers)
                {
                    if (num < smallestNumber)
                    {
                        smallestNumber = num;
                    }
                }
                Console.WriteLine(smallestNumber);
            }
        }
    }
}
