using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diapazon1do100
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            while (n > 100 || n < 1)
            {
                Console.WriteLine("Enter a number in the range[1...100]:Invalid number!");
                n = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"The number is: {n}");
        }
    }
}