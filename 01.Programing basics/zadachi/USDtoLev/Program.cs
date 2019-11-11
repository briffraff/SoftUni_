using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad2Degre
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Vuvedete stoinost v Dolari : ");
            var dolari = double.Parse(Console.ReadLine());

            var levove = dolari * 1.79549;

            Console.Write("Stoinosta v levove e = ");
            Console.Write(Math.Round(levove, 2));
            Console.WriteLine();

        }
    }
}
