using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Test_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int maxSum = int.Parse(Console.ReadLine());
            int sum = 0;
            int combinationCounter = 0;

            for (int num1 = n; num1 >= 1; num1--)
            {
                for (int num2 = 1; num2 <= m; num2++)
                {
                    int multiply = (num1 * num2);
                    //Console.WriteLine($"{num1}*{num2}={multiply}");
                    sum += 3 * multiply;
                    combinationCounter += 1;

                    if (sum >= maxSum)
                    {
                        Console.WriteLine($"{combinationCounter} combinations");
                        Console.WriteLine($"Sum: {sum} >= {maxSum}");
                        return;
                    }
                }
            }
            Console.WriteLine($"{combinationCounter} combinations");
            Console.WriteLine($"Sum: {sum}");
        }
    }
}

