using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_00
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("a = ");
            var a = int.Parse(Console.ReadLine());
            var suma = a * a;
            Console.Write("Square = ");
            Console.WriteLine(suma);

        }
    }
}
