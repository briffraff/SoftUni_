using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvadratnaMreja
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            //TOP
            Console.Write(new string('+', 1) + (' '));

            for (int i = 1; i <= n - 2; i++)
            {
                Console.Write(new string('-', 1));
                Console.Write(" ");
            }

            Console.WriteLine(new string('+', 1));

            //MID
            for (int i = 1; i <= n - 2; i++)
            {
                Console.Write(new string('|', 1) + (' '));

                for (int r = 1; r <= n - 2; r++)
                {
                    Console.Write(new string('-', 1));
                    Console.Write(" ");
                }

                Console.WriteLine(new string('|', 1));

            }

            //BOTT
            Console.Write(new string('+', 1) + (' '));

            for (int i = 1; i <= n - 2; i++)
            {
                Console.Write(new string('-', 1));
                Console.Write(" ");
            }

            Console.WriteLine(new string('+', 1));


        }
    }
}