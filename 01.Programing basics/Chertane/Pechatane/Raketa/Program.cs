using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raketa
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            int shirina = 3 * n;
            int dotsLeftRight = (shirina - 2) / 2;
            int freeSpaces = 0;

            //TOP

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}/{1}\\{0}", new string('.', dotsLeftRight), new string(' ', freeSpaces));
                dotsLeftRight -= 1;
                freeSpaces += 2;
            }

            Console.WriteLine("{0}{1}{0}", new string('.', dotsLeftRight + 1), new string('*', freeSpaces));

            //MID
            for (int i = 0; i < n * 2; i++)
            {
                Console.WriteLine("{0}|{1}|{0}", new string('.', dotsLeftRight + 1), new string('\\', freeSpaces - 2));
            }

            //BOTT
            int zvezdichki = freeSpaces - 2;
            //int dotsBott = ((shirina - zvezdichki)-2)/2;
            int dotsBott = dotsLeftRight + 1;

            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine("{0}/{1}\\{0}", new string('.', dotsBott), new string('*', zvezdichki));
                dotsBott -= 1;
                zvezdichki += 2;
            }
        }
    }
}
