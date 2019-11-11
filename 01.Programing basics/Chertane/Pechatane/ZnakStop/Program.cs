using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZnakStop
{
    class Program
    {
        static void Main(string[] args)
        {
            //INPUT
            int n = int.Parse(Console.ReadLine());

            //Promenlivi
            var midStopLines = (n * 4 - 6) / 2;
            var midBotLines = n * 4 - 1;
            string txt = "STOP!";
            var topLeftRightDots = n + 1;
            var topMidLines = n * 2 + 1;
            var topMidLines2raw = n * 2 - 1;
            var fullRangeRaw = n * 4 + 3;


            //TOP
            //Purvi red
            Console.Write(new string('.', topLeftRightDots));
            Console.Write(new string('_', topMidLines));
            Console.WriteLine(new string('.', topLeftRightDots));
            //Vtori red
            Console.WriteLine(new string('.', n) + ("//") + (new string('_', topMidLines2raw)) + ("\\\\") + new string('.', n));

            //TOP-Cikul

            for (int i = 1; i <= n - 1; i++)
            {
                var topLeftRightSides = 2 * (n - i) + 4;

                for (int j = 1; j <= n - i; j++)
                {
                    Console.Write(".");
                }

                Console.Write("//");
                Console.Write(new string('_', fullRangeRaw - topLeftRightSides));
                Console.Write(new string('\\', 2));

                for (int j = 1; j <= n - i; j++)
                {
                    Console.Write(".");
                }
                Console.WriteLine();
            }

            //MID
            //stop
            Console.WriteLine(new string('/', 2) + new string('_', midStopLines) + txt + new string('_', midStopLines) + new string('\\', 2));
            //underStop
            Console.WriteLine(new string('\\', 2) + new string('_', midBotLines) + new string('/', 2));

            //BOTT- Obraten Cikul

            for (int i = n - 1; i >= 1; i--)
            {
                var topLeftRightSides = 2 * (n - i) + 4;

                for (int j = 1; j <= n - i; j++)
                {
                    Console.Write(".");
                }

                Console.Write(new string('\\', 2));
                Console.Write(new string('_', fullRangeRaw - topLeftRightSides));
                Console.Write(new string('/', 2));

                for (int j = 1; j <= n - i; j++)
                {
                    Console.Write(".");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

        }
    }
}