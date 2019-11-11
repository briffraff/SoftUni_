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

            Console.Write(" Vuvedete temperaturata v C : ");
            var cel = double.Parse(Console.ReadLine());

            var far = cel * 9 / 5 + 32;
            Console.Write("Temperaturata vuv Far e: ");
            Console.Write(Math.Round(far, 2));
            Console.WriteLine();



        }
    }
}
