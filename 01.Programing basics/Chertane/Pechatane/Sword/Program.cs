using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sword
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int shirina = (2 * n) + 1;

            //purvi red 
            int diez = (shirina - 3) / 2;
            string topMid = "/^\\";
            Console.WriteLine("{0}{1}{0}", new string('#', diez), topMid);

            // Top cikul
            int freespaces = 3;
            for (int i = 1; i <= n / 2; i++)
            {
                diez -= 1;
                Console.WriteLine("{0}.{1}.{0}", new string('#', diez), new string(' ', freespaces));
                freespaces += 2;
            }

            // MID
            freespaces = (shirina - 3 - 2 * diez) / 2;

            // SOFT 
            Console.WriteLine("{0}|{1}S{1}|{0}", new string('#', diez), new string(' ', freespaces));
            Console.WriteLine("{0}|{1}O{1}|{0}", new string('#', diez), new string(' ', freespaces));
            Console.WriteLine("{0}|{1}F{1}|{0}", new string('#', diez), new string(' ', freespaces));
            Console.WriteLine("{0}|{1}T{1}|{0}", new string('#', diez), new string(' ', freespaces));
            if (n == 5)
            {
                for (int i = 0; i < 1; i++)
                {
                    Console.WriteLine("{0}|{1} {1}|{0}", new string('#', diez), new string(' ', freespaces));
                }
            }
            else
            {
                for (int i = 1; i <= (n + 3) / 2 - 2/*(n / 2) - 1*/; i++)
                {
                    Console.WriteLine("{0}|{1} {1}|{0}", new string('#', diez), new string(' ', freespaces));
                }
            }
            // freespaces 
            //if (n % 2 == 0)
            //{

            //}


            //else if (n % 2 != 0)
            //{
            //    //n+3/2-2
            //    for (int i = 1; i <= ((shirina - 3 - 1 * diez) / 2) - 1; i++)
            //    {
            //        Console.WriteLine("{0}|{1} {1}|{0}", new string('#', diez), new string(' ', freespaces));
            //    }
            //}

            // UNI
            freespaces = (shirina - 3 - 2 * diez) / 2;
            Console.WriteLine("{0}|{1}U{1}|{0}", new string('#', diez), new string(' ', freespaces));
            Console.WriteLine("{0}|{1}N{1}|{0}", new string('#', diez), new string(' ', freespaces));
            Console.WriteLine("{0}|{1}I{1}|{0}", new string('#', diez), new string(' ', freespaces));

            // mid
            Console.WriteLine("@{0}@", new string('=', shirina - 2));

            //BOTT
            int bottDiezi = diez + 2;
            int bottFreespaces = shirina - 6 - 2 * diez;
            for (int i = 1; i <= n / 2; i++)
            {
                Console.WriteLine("{0}|{1}|{0}", new string('#', bottDiezi), new string(' ', bottFreespaces));
            }

            int bottDots = bottFreespaces;
            Console.WriteLine("{0}\\{1}/{0}", new string('#', bottDiezi), new string('.', bottDots));

        }
    }
}
