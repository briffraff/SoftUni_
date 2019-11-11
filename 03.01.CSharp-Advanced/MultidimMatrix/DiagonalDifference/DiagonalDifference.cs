using System;
using System.Collections.Concurrent;
using System.Linq;

namespace DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[][] matrix = new int[matrixSize][];
            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                int theNum = matrix[row][row];
                primaryDiagonalSum += theNum ;
                secondaryDiagonalSum += matrix[row][matrix.Length - 1 - row];
            }

           Console.WriteLine(Math.Abs(primaryDiagonalSum - secondaryDiagonalSum));


        }
    }
}
