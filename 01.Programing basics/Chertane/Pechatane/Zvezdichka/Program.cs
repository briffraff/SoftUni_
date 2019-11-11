using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zvezdichka
{
    class Program
    {
        static void Main(string[] args)
        {
            //vuvejdane na goleminata na zvezdichkata
            int n = int.Parse(Console.ReadLine());


            //pechatane na purvi red
            Console.Write(new string('*', 1));
            Console.Write(new string('.', n));
            Console.Write(new string('*', 1));
            Console.Write(new string('.', n));
            Console.WriteLine(new string('*', 1));

            //zavurtane na cikul ,koito pe4ata razlichnite redove
            for (int i = 1; i <= n - 2; i++)
            {
                Console.Write(new string('.', i));
                Console.Write(new string('*', 1));
                Console.Write(new string('.', n - i));
                Console.Write(new string('*', 1));
                Console.Write(new string('.', n - i));
                Console.Write(new string('*', 1));
                Console.WriteLine(new string('.', i));
            }


            //printirane na povtarqem element *****
            Console.Write(new string('.', ((2 * n + 3) - 5) / 2));
            Console.Write(new string('*', 5));
            Console.WriteLine(new string('.', ((2 * n + 3) - 5) / 2));
            //printirane na centralnata os
            Console.WriteLine(new string('*', 2 * n + 3));
            //printirane na povtarqem element *****
            Console.Write(new string('.', ((2 * n + 3) - 5) / 2));
            Console.Write(new string('*', 5));
            Console.WriteLine(new string('.', ((2 * n + 3) - 5) / 2));


            //zavurtane na cikul ,koito pe4ata razlichnite redove
            for (int i = n - 2; i >= 1; i--)
            {
                Console.Write(new string('.', i));
                Console.Write(new string('*', 1));
                Console.Write(new string('.', n - i));
                Console.Write(new string('*', 1));
                Console.Write(new string('.', n - i));
                Console.Write(new string('*', 1));
                Console.WriteLine(new string('.', i));
            }

            //pechatane na posleden red
            Console.Write(new string('*', 1));
            Console.Write(new string('.', n));
            Console.Write(new string('*', 1));
            Console.Write(new string('.', n));
            Console.WriteLine(new string('*', 1));


            Console.WriteLine();



        }
    }
}

