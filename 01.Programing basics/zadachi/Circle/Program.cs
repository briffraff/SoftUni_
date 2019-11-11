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
            var r = double.Parse(Console.ReadLine());

            var lice = Math.PI * r * r;
            var perimetur = 2 * Math.PI * r;
            Console.WriteLine(lice);
            Console.WriteLine(perimetur);

        }
    }
}
