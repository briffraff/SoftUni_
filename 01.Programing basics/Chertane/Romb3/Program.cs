using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romb2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Program for displaying pattern of *.");
            Console.Write("Enter the maximum number of *: ");
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= n; i++)

            {
                for (int j = 0; j < (n - i); j++)
                    Console.Write("-");
                for (int j = 1; j <= i; j++)
                    Console.Write(" ");
                for (int j = 1; j <= i - 1; j++)
                    Console.Write(" ");
                for (int j = 0; j < (n - i); j++)
                    Console.Write("-");

                Console.WriteLine();
            }

            for (int i = n - 1; i >= 1; i--)

            {
                for (int j = 0; j < (n - i); j++)
                    Console.Write("-");
                for (int j = 1; j <= i; j++)
                    Console.Write(" ");
                for (int j = 1; j <= i - 1; j++)
                    Console.Write(" ");
                for (int j = 0; j < (n - i); j++)
                    Console.Write("-");

                Console.WriteLine();
            }

            {
                Console.WriteLine();
            }







        }
    }
}
