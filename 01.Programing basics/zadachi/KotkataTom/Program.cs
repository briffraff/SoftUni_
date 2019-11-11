using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KotkataTom
{
    class Program
    {
        static void Main(string[] args)
        {

            int dayoff = int.Parse(Console.ReadLine());
            int rabotnidni = 365 - dayoff;
            int tRabota = rabotnidni * 63;
            int tPochivka = dayoff * 127;
            int norma = 30000;
            int razlika = Math.Abs(norma - (tRabota + tPochivka));
            int vremezaigra = tRabota + tPochivka;
            int H = razlika / 60;
            int m = razlika % 60;


            if (norma > vremezaigra)
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{H} hours and {m} minutes less for play");
            }
            else
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{H} hours and {m} minutes more for play");
            }

        }
    }
}