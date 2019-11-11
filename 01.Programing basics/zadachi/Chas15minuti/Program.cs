using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chas15minuti
{
    class Program
    {
        static void Main(string[] args)
        {
            int chas = int.Parse(Console.ReadLine());
            int minuti = int.Parse(Console.ReadLine());

            minuti = minuti + 15;


            if (minuti > 59)
            {
                chas = chas + 1;
                minuti = minuti - 60;
            }
            if (chas > 24)
            {
                chas = 1;
            }
            else if (chas > 23)
            {
                chas = 0;
            }
            if (minuti < 10)
            {
                Console.WriteLine($"{chas:0}:{minuti % 60:00}");
            }
            else
            {
                Console.WriteLine($"{chas:0}:{minuti % 60:00}");
            }


            //int h = int.Parse(Console.ReadLine());
            //int m = int.Parse(Console.ReadLine());

            //DateTime hm = DateTime.ParseExact($"{h}:{m}", "H:m", null);

            //hm = hm.AddMinutes(15);

            //Console.WriteLine(hm.ToString("H:mm"));


        }
    }
}
