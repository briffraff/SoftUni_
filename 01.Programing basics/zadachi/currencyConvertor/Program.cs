using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad2Degre
{
    class Program
    {
        static void Main(string[] args)
        {

            // Console.Write("Vuvedete suma : ");
            var suma = double.Parse(Console.ReadLine());
            //Console.Write("/*USD,BGN,EUR,GBP*/ - Vuvedete vhodna valuta: ");
            string vhodnaValuta = Console.ReadLine();
            //Console.Write("/*USD,BGN,EUR,GBP*/ - Vuvedete jelanata ot vas valuta: ");
            string izhodnaValuta = Console.ReadLine();

            double dolar = 1.79549;
            double evro = 1.95583;
            //double lev = 1;
            double liri = 2.53405;


            while (izhodnaValuta == "BGN")
            {
                Console.WriteLine();
                //Console.Write("Sumata e = ");

                if (vhodnaValuta == "USD")
                {
                    Console.Write(Math.Round(suma * dolar, 2) + " " + izhodnaValuta); break;
                }
                if (vhodnaValuta == "EUR")
                {
                    Console.Write(Math.Round(suma * evro, 2) + " " + izhodnaValuta); break;
                }
                if (vhodnaValuta == "GBP")
                {
                    Console.Write(Math.Round(suma * liri, 2) + " " + izhodnaValuta); break;
                }
                if (vhodnaValuta == "BGN")
                {
                    Console.Write(Math.Round(suma * 1, 2) + " " + izhodnaValuta); break;
                }
            }

            while (izhodnaValuta == "USD")
            {
                Console.WriteLine();
                //Console.Write("Sumata e = ");

                if (vhodnaValuta == "USD")
                {
                    Console.Write(Math.Round(suma * 1, 2) + " " + izhodnaValuta); break;

                }
                if (vhodnaValuta == "EUR")
                {
                    Console.Write(Math.Round(suma * evro / dolar, 2) + " " + izhodnaValuta); break;
                }
                if (vhodnaValuta == "GBP")
                {
                    Console.Write(Math.Round(suma * liri / dolar, 2) + " " + izhodnaValuta); break;
                }
                if (vhodnaValuta == "BGN")
                {
                    Console.Write(Math.Round(suma / dolar, 2) + " " + izhodnaValuta); break;
                }
            }

            while (izhodnaValuta == "EUR")
            {
                Console.WriteLine();
                //Console.Write("Sumata e = ");

                if (vhodnaValuta == "USD")
                {
                    Console.Write(Math.Round((suma * dolar) / evro, 2) + " " + izhodnaValuta); break;

                }
                if (vhodnaValuta == "EUR")
                {
                    Console.Write(Math.Round(suma * 1, 2) + " " + izhodnaValuta); break;
                }
                if (vhodnaValuta == "GBP")
                {
                    Console.Write(Math.Round((suma * liri) / evro, 2) + " " + izhodnaValuta); break;
                }
                if (vhodnaValuta == "BGN")
                {
                    Console.Write(Math.Round(suma / evro, 2) + " " + izhodnaValuta); break;
                }
            }

            while (izhodnaValuta == "GBP")
            {
                Console.WriteLine();
                // Console.Write("Sumata e = ");

                if (vhodnaValuta == "USD")
                {
                    Console.Write(Math.Round((suma * dolar) / liri, 2) + " " + izhodnaValuta); break;

                }
                if (vhodnaValuta == "EUR")
                {
                    Console.Write(Math.Round((suma * evro) / liri, 2) + " " + izhodnaValuta); break;
                }
                if (vhodnaValuta == "GBP")
                {
                    Console.Write(Math.Round(suma * 1, 2) + " " + izhodnaValuta); break;
                }
                if (vhodnaValuta == "BGN")
                {
                    Console.Write(Math.Round(suma / liri, 2) + " " + izhodnaValuta); break;
                }
            }

            Console.WriteLine();
            Console.WriteLine();

        }
    }
}
