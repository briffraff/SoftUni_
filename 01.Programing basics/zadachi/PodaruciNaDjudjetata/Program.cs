using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodaruciNaDjudjetata
{
    class Program
    {
        static void Main(string[] args)
        {
            int nDjudjeta = int.Parse(Console.ReadLine());
            int obshtoPari = int.Parse(Console.ReadLine());
            double krainaSuma = 0.00;
            

            for (int i = 1; i <= nDjudjeta; i++)
            {
                string tipPodaruk = Console.ReadLine();

                if (tipPodaruk == "sand clock")
                {
                    krainaSuma += 2.20;
                }
                if (tipPodaruk == "magnet")
                {
                    krainaSuma += 1.50;
                }
                if (tipPodaruk == "cup")
                {
                    krainaSuma += 5.00;
                }
                if (tipPodaruk == "t-shirt")
                {
                    krainaSuma += 10.00;
                }
            }

            Console.WriteLine();

            double OstavashtiPari = Math.Abs(obshtoPari - krainaSuma);
            double PariZaDoplashtane = OstavashtiPari;

            if (obshtoPari >= krainaSuma)
            {
                Console.WriteLine($"Santa Claus has {OstavashtiPari:f2} more leva left!");
            }
            else
            {
                Console.WriteLine($"Santa Claus will need {PariZaDoplashtane:f2} more leva.");
            }
            Console.WriteLine();
        }
    }
}
