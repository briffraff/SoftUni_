using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawFort
{
    class Program
    {
        static void Main(string[] args)
        {
            //vuvejdane na chislo
            int n = int.Parse(Console.ReadLine());
            int dolniCherti = 2 * n - 2 * (n / 2) - 4;
            int shirina = 2 * n;
            int shirinaKoloni = n / 2;
            int prazno = n * 2 - 2;
            int praznoPredposleden = n / 2 + 1;


            //pechatane na purvi red
            Console.Write("/" + new string('^', shirinaKoloni) + "\\");

            if (n >= 5)
            {
                Console.Write(new string('_', dolniCherti));
            }

            Console.WriteLine("/" + new string('^', shirinaKoloni) + "\\");


            //sredna chast
            if (n >= 5)
            {
                for (int i = 1; i < n - 2; i++)
                {
                    Console.WriteLine("|" + new string(' ', prazno) + "|");
                }
            }
            else
            {
                for (int i = 1; i < n - 1; i++)
                {
                    Console.WriteLine("|" + new string(' ', prazno) + "|");
                }
            }

            //pechatane na predposleden red
            if (n >= 5)
            {
                Console.WriteLine("|" +
                    new string(' ', praznoPredposleden) +
                    new string('_', dolniCherti) +
                    new string(' ', praznoPredposleden) +
                    "|");
            }

            //pechatane na posledniq red
            Console.Write("\\" + new string('_', shirinaKoloni) + "/");
            if (n >= 5)
            {
                Console.Write(new string(' ', dolniCherti));
            }
            Console.WriteLine("\\" + new string('_', shirinaKoloni) + "/");
        }
    }
}