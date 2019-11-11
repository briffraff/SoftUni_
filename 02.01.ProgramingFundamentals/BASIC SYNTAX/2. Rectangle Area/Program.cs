using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            float a = float.Parse(Console.ReadLine());
            float b = float.Parse(Console.ReadLine());

            float c = a * b;

            Console.WriteLine("{0:f2}" ,c);
        }
    }
}
