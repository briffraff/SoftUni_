using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trapezoid
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write(" Vuvedete temperaturata v F : ");
            var far = double.Parse(Console.ReadLine());

            var cel = (far - 32) / 1.8;

            Console.Write("Temperaturata vuv C e: ");
            Console.Write(Math.Round(cel, 2));
            Console.WriteLine();

        }
    }
}
