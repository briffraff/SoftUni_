using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolednaIgrachka
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int n = int.Parse(Console.ReadLine());

            int shirina = 5 * n;
            int visochina = 2 * n + 3;

            //TOP
            //purvi red
            string zvezdichki = new string('*', n);
            string tirenca = new string('-', (shirina - zvezdichki.Length) / 2);
            Console.WriteLine("{0}{1}{0}", tirenca, zvezdichki);

            //purvi top cikul
            int ampersand = n + 2;
            int topZvezdichki = 1;
            int topTirenca = (shirina - 2 * topZvezdichki - ampersand) / 2;

            for (int i = 1; i <= n / 2; i++)
            {
                Console.WriteLine("{0}{1}{2}{1}{0}",
                    new string('-', topTirenca),
                    new string('*', topZvezdichki),
                    new string('&', ampersand));
                ampersand += 2;
                topZvezdichki += 1;
                topTirenca -= 2;
            }

            //2 top cikul
            int top2Tirenca = n - 1;
            int top2zvezdichki = 2;
            int top2midPart = (shirina - 2 * top2Tirenca - 2 * top2zvezdichki);

            for (int i = 1; i <= n / 2; i++)
            {
                Console.WriteLine("{0}{1}{2}{1}{0}",
                    new string('-', top2Tirenca),
                    new string('*', top2zvezdichki),
                    new string('~', top2midPart));
                top2Tirenca -= 1;
                top2midPart += 2;
            }

            //MID
            string midTirenca = new string('-', n / 2);
            string midPart = new string('|', shirina - 2 * midTirenca.Length - 2);
            Console.WriteLine("{0}*{1}*{0}", midTirenca, midPart);

            //BOTT - chetno
            if (n % 2 == 0)
            {
                //purvi bott cikul
                int bott2Tirenca = n / 2;
                int bott2zvezdichki = 2;
                int bott2midPart = (shirina - 2 * bott2Tirenca - 2 * bott2zvezdichki);

                for (int i = 1; i <= n / 2; i++)
                {
                    Console.WriteLine("{0}{1}{2}{1}{0}",
                        new string('-', bott2Tirenca),
                        new string('*', bott2zvezdichki),
                        new string('~', bott2midPart));
                    bott2Tirenca += 1;
                    bott2midPart -= 2;
                }

                //Bott posleden cikul
                int bottAmpersand = n * 2;
                int BottZvezdichki = n / 2;
                int BottTirenca = (shirina - 2 * BottZvezdichki - bottAmpersand) / 2;
                for (int i = 1; i <= n / 2; i++)
                {
                    Console.WriteLine("{0}{1}{2}{1}{0}",
                        new string('-', BottTirenca),
                        new string('*', BottZvezdichki),
                        new string('&', bottAmpersand));
                    bottAmpersand -= 2;
                    BottZvezdichki -= 1;
                    BottTirenca += 2;
                }
            }

            //ako n e nechetno
            else
            {
                //purvi bott cikul
                int bott2Tirenca = n / 2 + 1;
                int bott2zvezdichki = 2;
                int bott2midPart = (shirina - 2 * bott2Tirenca - 2 * bott2zvezdichki);

                for (int i = 1; i <= n / 2; i++)
                {
                    Console.WriteLine("{0}{1}{2}{1}{0}",
                        new string('-', bott2Tirenca),
                        new string('*', bott2zvezdichki),
                        new string('~', bott2midPart));
                    bott2Tirenca += 1;
                    bott2midPart -= 2;
                }

                //Bott posleden cikul
                int bottAmpersand = n * 2 - 1;
                int BottZvezdichki = n / 2;
                int BottTirenca = (shirina - 2 * BottZvezdichki - bottAmpersand) / 2;
                for (int i = 1; i <= n / 2; i++)
                {
                    Console.WriteLine("{0}{1}{2}{1}{0}",
                        new string('-', BottTirenca),
                        new string('*', BottZvezdichki),
                        new string('&', bottAmpersand));
                    bottAmpersand -= 2;
                    BottZvezdichki -= 1;
                    BottTirenca += 2;
                }
            }
            //posleden red
            Console.WriteLine("{0}{1}{0}", tirenca, zvezdichki);
            Console.WriteLine();
        }
    }
}