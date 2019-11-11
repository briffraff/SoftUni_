using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lisica
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            int shirina = 2 * n + 3;
            int visochina = 2 * n + 3;

            int outerParts = 1;
            int innerParts = shirina - 2 - 2 * outerParts;

            //TOP
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("{0}\\{1}/{0}", new string('*', outerParts), new string('-', innerParts));
                outerParts += 1;
                innerParts -= 2;
            }

            //MID
            int zvezdichkiLeftRight = (n - 1) / 2;
            int zvezdichkiMid = shirina - 2 * zvezdichkiLeftRight - 4;

            for (int i = 0; i < n / 3; i++)
            {
                Console.WriteLine("|{0}\\{1}/{0}|", new string('*', zvezdichkiLeftRight), new string('*', zvezdichkiMid));
                zvezdichkiLeftRight += 1;
                zvezdichkiMid -= 2;
            }

            //BOTT
            outerParts = 1;
            innerParts = shirina - 2 - 2 * outerParts;

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("{0}\\{1}/{0}", new string('-', outerParts), new string('*', innerParts));
                outerParts += 1;
                innerParts -= 2;
            }
        }
    }
}
