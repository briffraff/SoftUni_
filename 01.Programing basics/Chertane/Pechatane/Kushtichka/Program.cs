using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kushtichka
{
    class Program
    {
        static void Main(string[] args)
        {
            //INPUT
            int n = int.Parse(Console.ReadLine());

            //TOP - pokriv

            if (n % 2 == 0)
            {
                for (int i = 1; i <= n - i; i++)
                {
                    Console.Write(new string('-', n / 2 - i));
                    Console.Write(new string('*', i));
                    Console.Write(new string('*', i));
                    Console.Write(new string('-', n / 2 - i));

                    Console.WriteLine();
                }
            }

            else
            {
                for (int i = 0; i <= n - i; i++)
                {
                    Console.Write(new string('-', (n - i) - (n / 2) - 1));
                    Console.Write(new string('*', i));
                    Console.Write("*");
                    Console.Write(new string('*', i));
                    Console.Write(new string('-', (n - i) - (n / 2) - 1));
                    Console.WriteLine();
                }
            }

            //BOTT - osnova 
            for (int i = 0; i <= n / 2 - 1; i++)
            {
                Console.Write("|");
                Console.Write(new string('*', n - 2));
                Console.Write("|");
                Console.WriteLine();
            }
        }
    }
}
