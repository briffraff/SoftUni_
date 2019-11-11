using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Choose_a_Drink_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string prof = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            double price = 0;

            if (prof == "Athlete")
            {
                price = quantity*0.70;
            }
            else if (prof == "Businessman" || prof == "Businesswoman")
            {
                price = quantity * 1.00;

            }
            else if (prof == "SoftUni Student")
            {
                price = quantity * 1.70;
            }
            else
            {
                price = quantity * 1.20;
            }

            Console.WriteLine("The {0} has to pay {1:f2}." ,prof,price);
            Console.WriteLine();
        }
    }
}
