using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shevica
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            //TOP
            //1
            Console.Write(new string('.', 3 * n / 2));
            Console.Write("x");
            Console.Write(new string('.', 3 * n / 2));
            Console.WriteLine();

            //2
            Console.Write(new string('.', (3 * n / 2) - 1));
            Console.Write("/");
            Console.Write("x");
            Console.Write("\\");
            Console.Write(new string('.', (3 * n / 2) - 1));
            Console.WriteLine();

            //3
            Console.Write(new string('.', (3 * n / 2) - 1));
            Console.Write("x");
            Console.Write("|");
            Console.Write("x");
            Console.Write(new string('.', (3 * n / 2) - 1));
            Console.WriteLine();


            //MID 
            for (int i = n / 2; i >= 1; i--)
            {
                Console.Write(new string('.', i + 1 / 2));
                Console.Write(new string('x', (n * 3 / 2) - (i + 1 / 2)));
                Console.Write("|");
                Console.Write(new string('x', (n * 3 / 2) - (i + 1 / 2)));
                Console.Write(new string('.', i + 1 / 2));
                Console.WriteLine();
            }

            Console.Write(new string('x', n * 3 / 2));
            Console.Write("|");
            Console.Write(new string('x', n * 3 / 2));
            Console.WriteLine();

            for (int i = 1; i <= n / 2; i++)
            {
                Console.Write(new string('.', i + 1 / 2));
                Console.Write(new string('x', (n * 3 / 2) - (i + 1 / 2)));
                Console.Write("|");
                Console.Write(new string('x', (n * 3 / 2) - (i + 1 / 2)));
                Console.Write(new string('.', i + 1 / 2));
                Console.WriteLine();
            }

            //BOTT
            //half past
            Console.Write(new string('.', (3 * n / 2) - 1));
            Console.Write("/");
            Console.Write("x");
            Console.Write("\\");
            Console.Write(new string('.', (3 * n / 2) - 1));
            Console.WriteLine();

            //------------------------------------------------------------

            //BOTT
            //half past
            Console.Write(new string('.', (3 * n / 2) - 1));
            Console.Write("\\");
            Console.Write("x");
            Console.Write("/");
            Console.Write(new string('.', (3 * n / 2) - 1));
            Console.WriteLine();


            for (int i = n / 2; i >= 1; i--)
            {
                Console.Write(new string('.', i + 1 / 2));
                Console.Write(new string('x', (n * 3 / 2) - (i + 1 / 2)));
                Console.Write("|");
                Console.Write(new string('x', (n * 3 / 2) - (i + 1 / 2)));
                Console.Write(new string('.', i + 1 / 2));
                Console.WriteLine();
            }

            Console.Write(new string('x', n * 3 / 2));
            Console.Write("|");
            Console.Write(new string('x', n * 3 / 2));
            Console.WriteLine();
            //MID 
            
            for (int i = 1; i <= n / 2; i++)
            {
                Console.Write(new string('.', i + 1 / 2));
                Console.Write(new string('x', (n * 3 / 2) - (i + 1 / 2)));
                Console.Write("|");
                Console.Write(new string('x', (n * 3 / 2) - (i + 1 / 2)));
                Console.Write(new string('.', i + 1 / 2));
                Console.WriteLine();
            }
            //3
            Console.Write(new string('.', (3 * n / 2) - 1));
            Console.Write("x");
            Console.Write("|");
            Console.Write("x");
            Console.Write(new string('.', (3 * n / 2) - 1));
            Console.WriteLine();
            //2
            Console.Write(new string('.', (3 * n / 2) - 1));
            Console.Write("\\");
            Console.Write("x");
            Console.Write("/");
            Console.Write(new string('.', (3 * n / 2) - 1));
            Console.WriteLine();
            //TOP
            //1
            Console.Write(new string('.', 3 * n / 2));
            Console.Write("x");
            Console.Write(new string('.', 3 * n / 2));
            Console.WriteLine();

        }
    }
}
