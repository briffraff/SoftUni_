using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paralepiped
{
    class Program
    {
        static void Main(string[] args)
        {

            var n = int.Parse(Console.ReadLine());

            int shirina = 3 * n + 1;
            int visochina = 4 * n + 4;
            int dilte = n - 2;
            int dots = n * 2 + 1;

            //purvi red
            Console.WriteLine("+{0}+{1}", new string('~', dilte), new string('.', dots));

            //TOP
            string midPart = "\\" + new string('~', dilte) + "\\";

            for (int i = 0; i < n * 2 + 1; i++)
            {
                dots -= 1;
                Console.WriteLine("|{0}{1}{2}", new string('.', i), midPart, new string('.', dots));
            }

            //BOTT
            string rightPart = "|" + new string('~', dilte) + "|";
            //int dotsBott = shirina - rightPart.Length - 1;
            dots = n * 2;

            for (int i = 0; i < n * 2 + 1; i++)
            {
                Console.WriteLine("{0}\\{1}{2}", new string('.', i), new string('.', dots), rightPart);
                dots -= 1;
            }

            //posleden red
            dots = n * 2 + 1;
            Console.WriteLine("{1}+{0}+", new string('~', n - 2), new string('.', dots));

        }
    }
}
