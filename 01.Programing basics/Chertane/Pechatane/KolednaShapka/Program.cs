using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolednaShapka
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int width = (4 * n) + 1;
            int visochina = 2 * n + 5;
            int freespaces = (width - 3) / 2;

            string purviRed = "/|\\";
            string vtoriRed = "\\|/";

            //TOP
            //purvi red
            Console.WriteLine("{0}{1}{0}",new string('.',freespaces),purviRed);
            //vtori red
            Console.WriteLine("{0}{1}{0}", new string('.', freespaces), vtoriRed);

            //MID
            for (int i = 0; i < 2 * n; i++)
            {
                Console.Write("{0}*{1}*{1}*{0}", new string('.', freespaces - i), new string('-', i));
                Console.WriteLine();
            }

            //BOTT
            string predPosleden = "*.";

            Console.WriteLine(new string('*',width));

            for (int i = 0; i < (width/predPosleden.Length); i++)
            {
                Console.Write(predPosleden);
            }
            Console.WriteLine("*");

            Console.WriteLine(new string('*', width));
        }
    }
}
