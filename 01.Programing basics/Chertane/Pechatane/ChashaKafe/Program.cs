using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChashaKafe
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            int shirina = 3 * n + 6;
            int visochina = 3 * n + 1;
            int freespacesLeft = n;
            string para = "~ ~ ~";

            //Para
            for (int i = 1; i <= n; i++)
            {
                int freespacesRight = shirina - freespacesLeft - 5;
                Console.WriteLine("{0}{1}{2}", new string(' ', freespacesLeft), para, new string(' ', freespacesRight));
            }

            // =
            Console.WriteLine(new string('=', shirina - 1));

            //Java
            if (n <= 3)  
            {
                string java1 = "JAVA";
                int dilte3 = n;
                Console.WriteLine("|{0}{2}{0}|{1}|", new string('~', dilte3), new string(' ', n - 1), java1);
            }
            for (int i = 2; i <= n - 2; i++)
            {
                int dilte = shirina - 3 - n + 1;
                Console.WriteLine("|{0}|{1}|", new string('~', dilte), new string(' ', n - 1));

                if (i == n / 2)
                {
                    string java = "JAVA";
                    int dilte2 = n;
                    Console.WriteLine("|{0}{2}{0}|{1}|", new string('~', dilte2), new string(' ', n - 1), java);
                }
            }

            // =
            Console.WriteLine(new string('=', shirina - 1));

            // cikul @
            for (int i = 0; i < n; i++)
            {
                int kliomba = shirina - 3 - n + 1;
                int freespacesKliomba = 0;
                Console.WriteLine("{0}\\{1}/", new string(' ', freespacesKliomba + i), new string('@', kliomba - 2 * i));
            }

            // posleden red
            int lastRowFreeSpaces = n;
            Console.WriteLine(new string('=', shirina - lastRowFreeSpaces), new string(' ', lastRowFreeSpaces));

        }
    }
}
