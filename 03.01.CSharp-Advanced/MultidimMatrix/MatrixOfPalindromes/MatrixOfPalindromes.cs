using System;
using System.Linq;

namespace MatrixOfPalindromes
{
    class MatrixOfPalindromes
    {
        static void Main(string[] args)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int cols = input[1];

            string[][] matrix = new string[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new string[cols];

                for (int col = 0; col < cols; col++)
                {
                    matrix[row][col] = $"{alphabet[row]}{alphabet[row + col]}{alphabet[row]}";
                }
            }

            foreach (var s in matrix)
            {
                Console.WriteLine(string.Join(" ", s));
            }

        }
    }
}
