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
            var sideA = double.Parse(Console.ReadLine());
            var h = double.Parse(Console.ReadLine());

            var lice = sideA * h / 2;

            Console.WriteLine(Math.Round(lice, 2));

        }
    }
}
