using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Comparing_Floats
{
    class Program
    {
        static void Main(string[] args)
        {

            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());

            double eps = 0.000001;
            double difference = Math.Abs(num1 - num2);

            if (difference <= eps)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }
    }
}
