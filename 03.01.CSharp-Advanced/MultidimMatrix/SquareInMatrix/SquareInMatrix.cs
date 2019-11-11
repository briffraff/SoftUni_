using System;
using System.Linq;

namespace SquareInMatrix
{
    class SquareInMatrix
    {
        static void Main(string[] args)
        {
            int[] inputSplit = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            int rows = inputSplit[0];
            int cols = inputSplit[1];

            string[,] matrix = new string[rows,cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] characters = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = characters[col];
                }
            }

            int counter = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    bool areEqual = matrix[row, col] == matrix[row, col + 1] &&
                                    matrix[row, col] == matrix[row + 1, col] &&
                                    matrix[row, col] == matrix[row + 1, col + 1];
                    if (areEqual)
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
