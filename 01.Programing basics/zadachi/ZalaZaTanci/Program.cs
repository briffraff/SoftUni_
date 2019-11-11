using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZalaZaTanci
{
    class Program
    {
        static void Main(string[] args)
        {
            //Nova zala.Broi tanciori ?

            //Vuvejda duljinata na zalata - 10.00 do 100.00
            Console.Write("Vuvedete duljinata na zalata: ");
            double l = double.Parse(Console.ReadLine());

            //Vuvejda shirinata na zalata - 10.00 do 100.00
            Console.Write("Vuvedete shirinata na zalata: ");
            double w = double.Parse(Console.ReadLine());

            //Vuvejda stranata na garderoba - 2.00 do 20.00
            Console.Write("Vuvedete stranata na garderoba: ");
            double a = double.Parse(Console.ReadLine());

            //Definirane na promenlivi i prevrushtane na stoinostite ot Metri v santimetri
            double kvadraturaZala = (l * w) * 100;
            double garderob = (a * a) * 100;
            double skameika = kvadraturaZala / 10;
            double tancior = 7040;
            var broiTanciori = ((kvadraturaZala - garderob - skameika) / tancior) * 100;
            var i = l + w;



            if (i >= 20)
            {
                if (l >= 10 && l <= 100)
                {

                }
                else
                {
                    Console.WriteLine("Vuvedenata duljina {0} e izvun diapazona", l);
                    Console.WriteLine();
                }

                if (w >= 10 && w <= 100)
                {

                }
                else
                {
                    Console.WriteLine("Vuvedenata shirina {0} e izvun diapazona", w);
                    Console.WriteLine();
                }

                if (a >= 2 && a <= 20)
                {

                }
                else
                {
                    Console.WriteLine("Vuvedenata strana {0} na garderoba e izvun diapazona", a);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Vuvedenite danni ne sa v diapazona");
                Console.WriteLine();
            }


            if (l >= 10 && w >= 10 && a >= 2 | l <= 100 && w <= 100 && a <= 20)
            {
                Console.WriteLine();
                Console.WriteLine("Broqt na tanciorite e {0}", (Math.Floor(broiTanciori)));
                Console.WriteLine();
            }
        }
    }
}

