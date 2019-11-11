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

            Console.Write("Vuvedete stoinost v rad : ");
            var rad = double.Parse(Console.ReadLine());

            var deg = rad * 180 / Math.PI;

            Console.Write("Preobrazuvano v gradusi = ");
            Console.Write(Math.Round(deg, 2));
            Console.WriteLine();

        }
    }
}
