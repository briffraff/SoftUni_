using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sladkari
{
    class Program
    {
        static void Main(string[] args)
        {
            //broi dni ,sladkari,torti,gofreti,palachinki

            //Console.Write("Vuvedete broq na dnite na kampaniqta: ");
            var broiDni = int.Parse(Console.ReadLine());
            //Console.Write("Kolko sladkari shte uchastvat: ");
            var broiSladkari = int.Parse(Console.ReadLine());
            //Console.Write("Kolko sa tortite: ");
            var broiTorti = int.Parse(Console.ReadLine());
            //Console.Write("Kolko sa gofretite: ");
            var broiGofreti = int.Parse(Console.ReadLine());
            //Console.Write("Kolko sa palachinkite: ");
            var broiPalachinki = int.Parse(Console.ReadLine());

            //ceni v levove
            double cenaTorti = 45;
            double cenaGofreti = 5.80;
            double cenaPalachinki = 3.20;

            //obshto pari za
            double torti = broiTorti * cenaTorti;
            double gofreti = broiGofreti * cenaGofreti;
            double palachinki = broiPalachinki * cenaPalachinki;

            //parite izkarani ot edin gotvach za edin den
            double pariGotvach = torti + gofreti + palachinki;

            //vsichki pari
            double vsichkiPari = broiDni * broiSladkari * pariGotvach;

            //pari za pokrivane na razhodi
            double razhodi = vsichkiPari * 0.125;

            //chisti pari 
            double chistiPari = vsichkiPari - razhodi;


            if (broiDni >= 0 && broiSladkari >= 0 && broiTorti >= 0 && broiGofreti >= 0 && broiPalachinki >= 0 |
                broiDni <= 365 && broiSladkari <= 1000 && broiTorti <= 2000 && broiGofreti <= 2000 && broiPalachinki <= 2000)
            {
                //Console.WriteLine();
                //Console.Write("Subranata suma e = ");
                Console.Write("{0:f2}", chistiPari);
                //Console.WriteLine();

            }
            else
            {
                //Console.WriteLine();
                //Console.WriteLine("Vuveli ste chislo izvun diapazona na kampaniqta");
                //Console.WriteLine();

            }





        }
    }
}
