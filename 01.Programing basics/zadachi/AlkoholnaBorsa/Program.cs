using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkoholnaBorsa
{
    class Program
    {
        static void Main(string[] args)
        {
            //bira ,vino, rakia, uiski

            double cenaUiski = double.Parse(Console.ReadLine());
            double kolkoBira = double.Parse(Console.ReadLine());
            double kolkoVino = double.Parse(Console.ReadLine());
            double kolkoRakia = double.Parse(Console.ReadLine());
            double kolkoUiski = double.Parse(Console.ReadLine());


            double cenaRakia = cenaUiski / 2;
            double cenaBira = cenaRakia - ((cenaRakia * 80) / 100);
            double cenaVino = cenaRakia - ((cenaRakia * 40) / 100);

            double bira = kolkoBira * cenaBira;
            double vino = kolkoVino * cenaVino;
            double rakia = kolkoRakia * cenaRakia;
            double uiski = kolkoUiski * cenaUiski;

            double obshtoRazhodi = bira + vino + rakia + uiski;

            Console.WriteLine("{0:f2}", obshtoRazhodi);

        }
    }
}
