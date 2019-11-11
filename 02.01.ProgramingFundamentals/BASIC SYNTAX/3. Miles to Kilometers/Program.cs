using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Miles_to_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            double miles = double.Parse(Console.ReadLine());

            double milestokm = 1.60934;

            double km = miles * milestokm;

            Console.WriteLine("{0:f2}" ,km);
        }
    }
}
