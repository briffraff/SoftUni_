using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pekarna
{
    class Program
    {
        static void Main(string[] args)
        {

            var gramajTestoNachalo = int.Parse(Console.ReadLine());
            var gramajHlebnoIzdelie = int.Parse(Console.ReadLine());
            var cenaHlebnoIzdelie = double.Parse(Console.ReadLine());
            var broiProdadeniHlebni = int.Parse(Console.ReadLine());
            var broiProdadeniSladkishi  = int.Parse(Console.ReadLine());

            double dnevniPrihodi = broiProdadeniHlebni * cenaHlebnoIzdelie;
            double nujnoTestoHlebni = broiProdadeniHlebni * gramajHlebnoIzdelie; //
            double ostavashtoTesto = gramajTestoNachalo - nujnoTestoHlebni;
            double gramajNovoTesto = gramajTestoNachalo - ostavashtoTesto;

            double proizvedenoTesto = (gramajTestoNachalo + gramajNovoTesto)/1000; //
            double cenaProizvedenoTesto = proizvedenoTesto * 4;//

            //sladkishi
            double cenaSladkish = cenaHlebnoIzdelie + cenaHlebnoIzdelie * 25 / 100;
            double gramajSladkish = gramajHlebnoIzdelie - gramajHlebnoIzdelie * 20 / 100;
            double nujnoTestoSladkishi = broiProdadeniSladkishi * gramajSladkish;
            double noshtniPrihodi = broiProdadeniSladkishi * cenaSladkish;

            double izpolzvanoTesto = nujnoTestoHlebni + nujnoTestoSladkishi;//
            double chistaPechalba = (dnevniPrihodi + noshtniPrihodi) - cenaProizvedenoTesto;

            Console.WriteLine($"Pure income: {chistaPechalba:f2} lv.");
            Console.WriteLine("Dough used: {0} g.",Math.Round(izpolzvanoTesto));

        }
    }
}
