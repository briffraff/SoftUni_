using System;
using System.Linq;

namespace MaxSum
{
    class MaxSum
    {
        static void Main(string[] args)
        {
            //split the row and col size
            int[] splitInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = splitInput[0];
            int cols = splitInput[1];

            //matrix init
            int[,] matrix = new int[rows, cols];

            //fill the matrix 
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] splitMatrixRows = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = splitMatrixRows[col];
                }
            }

            //rec the values
            int maxSum = int.MinValue;
            int rowMaxStartIdx = 0;
            int colMaxStartIdx = 0;
          
            //walk through the matrix and calculate sum
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int sum =
                        matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                        matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                        matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        rowMaxStartIdx = row;
                        colMaxStartIdx = col;
                    }
                }
            }

            //PRINT
            Console.WriteLine("Sum = {0}", maxSum);

            for (int row = rowMaxStartIdx; row <= rowMaxStartIdx + 2; row++)
            {
                for (int col = colMaxStartIdx; col <= colMaxStartIdx + 2; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
