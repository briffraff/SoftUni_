using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int totalSumDeleted = 0;

            while (listOfNumbers.Count > 0)
            {
                int currentIndex = int.Parse(Console.ReadLine());
                int removedNumber = 0;

                if (currentIndex < 0)
                {
                    removedNumber = listOfNumbers[0];
                    listOfNumbers[0] = listOfNumbers[listOfNumbers.Count - 1];
                }
                else if (currentIndex > listOfNumbers.Count - 1)
                {
                    removedNumber = listOfNumbers[listOfNumbers.Count - 1];
                    listOfNumbers[listOfNumbers.Count - 1] = listOfNumbers[0];
                }
                else
                {
                    removedNumber = listOfNumbers[currentIndex];
                    listOfNumbers.RemoveAt(currentIndex);
                }

                totalSumDeleted += removedNumber;

                for (int i = 0; i < listOfNumbers.Count; i++)
                {
                   
                    if (listOfNumbers[i] <= removedNumber)
                    {
                        listOfNumbers[i] += removedNumber;
                    }
                    else
                    {
                        listOfNumbers[i] -= removedNumber;
                    }
                }
            }
            Console.WriteLine(totalSumDeleted);
        }
    }
}
