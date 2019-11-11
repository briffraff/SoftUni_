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

            var n = int.Parse(Console.ReadLine());

            var leftRight = (n - 1) / 2;
            

            for (int i = 1; i <= (n - 1) / 2; i++)
            {
                var mid = n - 2 * leftRight - 2;
                Console.Write(new string('-', leftRight));
                Console.Write("*");

                if (mid >= 0)
                {
                    Console.Write(new string('-', mid));
                    Console.Write("*");
                }
                Console.WriteLine(new string('-', leftRight));
                leftRight--;
            }

            for (int i = 1; i <= (n + 1) / 2; i++)
            {
                leftRight = (i - 1);

                var mid = n - 2 * leftRight - 2;
                Console.Write(new string('-', leftRight));
                Console.Write("*");

                if (mid >= 0)
                {
                    Console.Write(new string('-', mid));
                    Console.Write("*");
                }
                Console.WriteLine(new string('-', leftRight));
            }

        }
    }
}
