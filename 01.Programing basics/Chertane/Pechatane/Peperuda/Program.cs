using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peperuda
{
    class Program
    {
        static void Main(string[] args)
        {
            //INPUT
            int n = int.Parse(Console.ReadLine());

            //TOP 
            for (int i = 1; i <= n - 2; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(new string('*', n - 2) + ("\\") + (" ") + ("/") + new string('*', n - 2));
                }
                if (i % 2 == 0)
                {
                    Console.WriteLine(new string('-', n - 2) + ("\\") + (" ") + ("/") + new string('-', n - 2));
                }
            }

            //MID 
            Console.WriteLine(new string(' ', n - 1) + ("@") + new string(' ', n - 1));

            //BOTT
            for (int i = 1; i <= n - 2; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(new string('*', n - 2) + ("/") + (" ") + ("\\") + new string('*', n - 2));
                }
                if (i % 2 == 0)
                {
                    Console.WriteLine(new string('-', n - 2) + ("/") + (" ") + ("\\") + new string('-', n - 2));
                }
            }
        }
    }
}

