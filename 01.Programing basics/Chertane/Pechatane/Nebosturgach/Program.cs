using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebosturgach
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            int shirina = (2 * n) + 1;

            int freespace = 1;
            int praviCherti = n - 2;
            int tirenca = 3;
            int dolniCherti = n - 3;



            //TOP
            //part1
            for (int i = 1; i <= n - 3; i++)
            {
                Console.WriteLine("{1}{0}|{0}", new string(' ', dolniCherti), new string(' ', freespace + 2));
            }

            Console.WriteLine("{1}{0}_|_{0}", new string(' ', dolniCherti), new string(' ', freespace+1));

            //part2
            for (int i = 1; i <= n - 3; i++)
            {
                Console.WriteLine("{1}{0}|-|{0}", new string(' ', dolniCherti), new string(' ', freespace+1));
            }

            Console.WriteLine("{1}{0}_|-|_{0}", new string(' ', dolniCherti) ,new string(' ',freespace));

            //part3
            for (int i = 1; i <= n - 3; i++)
            {
            Console.WriteLine(" {0}|***|{0}", new string(' ', dolniCherti));
            }

            Console.WriteLine(" {0}|***|{0}" ,new string('_',dolniCherti));


            //  MID
            for (int i = 1; i <= (n*4)-1; i++)
            {
            Console.WriteLine("{0}{1}{2}{1}" ,new string(' ',freespace) ,new string('|',praviCherti) ,new string('-',tirenca));
            }

            //free row
            Console.WriteLine("{0}{1}{2}{1}_", new string('_', freespace), new string('|', praviCherti), new string('-', tirenca));


            //  BOTT
            for (int i = 0; i < n-2; i++)
            {
            Console.WriteLine("{0}" ,new string('|',shirina));
            }
        }
    }
}
