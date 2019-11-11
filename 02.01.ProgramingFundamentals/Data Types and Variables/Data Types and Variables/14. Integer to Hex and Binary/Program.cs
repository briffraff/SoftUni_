using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Integer_to_Hex_and_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());

            string hexaD = Convert.ToString(inputNumber, 16).ToUpper();

            string binary = Convert.ToString(inputNumber, 2);
            Console.WriteLine(hexaD);
            Console.WriteLine(binary);
        }
    }
}
