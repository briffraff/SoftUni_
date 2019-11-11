using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //top
            Console.Write(new string('.', n + 4));
            Console.Write(new string('_', n));
            Console.Write("/|\\");
            Console.Write(new string('_', n));
            Console.WriteLine(new string('.', n + 4));
            //secrow
            Console.Write(new string('.', n + 4));
            Console.Write('/');
            Console.Write(new string('-', (4 * n + 11) - (n + 4) * 2 - 2));
            Console.Write('\\');
            Console.WriteLine(new string('.', n + 4));

            //firstloop
            for (int i = 0; i <= 2; i++)
            {
                Console.Write(new string('.', (n + 3) - i));
                Console.Write('/');
                Console.Write(new string('.', (4 * n + 11) - ((n + 3) - i + 1) * 2));
                Console.Write('\\');
                Console.WriteLine(new string('.', (n + 3) - i));
            }
            //middline
            Console.Write(new string('.', n));
            Console.Write('/');
            Console.Write(new string('_', (4 * n + 11) - 2 * n - 2));
            Console.Write('\\');
            Console.WriteLine(new string('.', n));

            //secloop
            for (int i = 0; i < n - 2; i++)
            {
                Console.Write(new string('.', n - 1 - i));
                Console.Write('/');
                Console.Write(new string('.', (4 * n + 11) - ((n - i - 1 + 1) * 2)));
                Console.Write('\\');
                Console.WriteLine(new string('.', n - 1 - i));
            }
            //hatend
            Console.Write('.');
            Console.Write('/');
            Console.Write(new string('_', (4 * n + 11) - 4));
            Console.Write('\\');
            Console.WriteLine('.');

            Console.Write('/');
            Console.Write(new string('_', (4 * n + 11) - 2));
            Console.WriteLine('\\');

            //thirdloop THE LEG
            for (int i = 0; i < n; i++)
            {
                Console.Write(new string('.', n * 2 + 4));
                Console.Write("|$|");
                Console.WriteLine(new string('.', n * 2 + 4));
            }

            //end
            Console.Write("....");
            Console.Write(new string('_', n * 2));
            Console.Write("|$|");
            Console.Write(new string('_', n * 2));
            Console.WriteLine("....");

            Console.Write("...");
            Console.Write('/');
            Console.Write(new string('_', (4 * n + 11) - 8));
            Console.Write('\\');
            Console.WriteLine("...");

        }
    }
}