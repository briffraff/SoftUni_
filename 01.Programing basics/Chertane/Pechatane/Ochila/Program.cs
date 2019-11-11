using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ochila
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var LeftRightGlass = n * 2 - 2;
            var LRFrame = 2 * n;

            //TOP
            Console.Write(new string('*', LRFrame));
            Console.Write(new string(' ', n));
            Console.WriteLine(new string('*', LRFrame));

            //MID
            for (int i = 0; i < n - 2; i++)
            {
                //Left Glass
                Console.Write("*");
                Console.Write(new string('/', LeftRightGlass));
                Console.Write("*");

                //Bridge
                if (i == (n - 1) / 2 - 1)
                {
                    Console.Write(new string('|', n));
                }
                 else
                {
                    Console.Write(new string(' ',n));
                }

                //Right Glass
                Console.Write("*");
                Console.Write(new string('/', LeftRightGlass));
                Console.WriteLine("*");
            }
            //BOTT
            Console.Write(new string('*', LRFrame));
            Console.Write(new string(' ', n));
            Console.WriteLine(new string('*', LRFrame));
        }
    }
}

