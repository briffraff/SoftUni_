using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaiGolqmoChislo
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int max = int.MinValue;
            // promenliva ,v koqto shte subirame chislata
            //int sum = 0;

            for (int i = 1; i <= n; i++)
            {
                var num = int.Parse(Console.ReadLine());

                if (num > max)
                {
                    max = num;
                }
                // sumata na vuvedenite ot potrebitelq chisla
                //sum += num;
            }
            //Console.WriteLine("Sum = "+ sum);
            Console.WriteLine(max);
        }
    }
}
