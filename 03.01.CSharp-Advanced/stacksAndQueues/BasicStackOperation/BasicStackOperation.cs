using System;
using System.Linq;
using System.Collections.Generic;

namespace BasicStackOperation
{
    class BasicStackOperation
    {
        static void Main(string[] args)
        {
            //GET FIRST LINE
            string[] references = Console.ReadLine().Split(' ').ToArray();

            int numbersToPop = 0;
            int numbersToPush = 0;
            int number = 0;

            if (references.Length == 3)
            {
                numbersToPop = int.Parse(references[1]);
                numbersToPush = int.Parse(references[0]);
                number = int.Parse(references[2]);
            }
            else
            {
                Environment.Exit(0);
            }

            //GET SECOND LINE
            string[] inputNums = Console.ReadLine().Split(' ').ToArray();

            Stack<int> numbers = new Stack<int>(inputNums.Length);

            for (int i = 0; i < numbersToPush - numbersToPop; i++)
            {
                numbers.Push(int.Parse(inputNums[i]));
            }

            //PRINT
            if (numbers.Contains(number))
            {
                Console.WriteLine("true");
            }
            else if(numbers.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                int smallestNumberInStack = Int32.MaxValue;

                foreach (var nu in numbers)
                {
                    if (nu < smallestNumberInStack)
                    {
                        smallestNumberInStack = nu;
                    }
                }
                Console.WriteLine(smallestNumberInStack);
            }
        }
    }
}
