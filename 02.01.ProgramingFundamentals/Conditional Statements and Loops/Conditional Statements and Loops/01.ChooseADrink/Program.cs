using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ChooseADrink
{
    class Program
    {
        static void Main(string[] args)
        {
            string sku = Console.ReadLine();
            string properGeometry = "";

            if (sku == "Athlete")
            {
                properGeometry = "Water";
            }
            else if (sku == "Businessman" || sku == "Businesswoman")
            {
                properGeometry = "Coffee";
            }
            else if (sku == "SoftUni Student")
            {
                properGeometry = "Beer";
            }
            else
            {
                properGeometry = "Tea";
            }

            Console.WriteLine(properGeometry);

            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            bool d = a == b == c;
        }
    }
}
