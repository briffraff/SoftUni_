using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Putuvane
{
    class Program
    {
        static void Main(string[] args)
        {
            double distanceKm = double.Parse(Console.ReadLine());
            double razhod100 = double.Parse(Console.ReadLine());
            double cenaLitur = double.Parse(Console.ReadLine());
            double nalichnaSuma = double.Parse(Console.ReadLine());

            double ratio = distanceKm / 100;
            double nujniLitri = razhod100 * ratio;
            double nujnaSuma = nujniLitri * cenaLitur;

            double nedostig = Math.Abs(nujnaSuma - nalichnaSuma);

            if(nalichnaSuma >= nujnaSuma)
            {
                Console.WriteLine($"You can take a trip. {nedostig:f2} money left.");
            }
            else
            {
                double cashBack = nalichnaSuma/5;
                Console.WriteLine($"Sorry, you cannot take a trip. Each will receive {cashBack:f2} money.");
            }
            Console.WriteLine();
        }
    }
}
