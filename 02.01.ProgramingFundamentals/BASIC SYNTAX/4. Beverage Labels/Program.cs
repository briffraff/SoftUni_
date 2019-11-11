using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Beverage_Labels
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfProduct = Console.ReadLine(); //name

            double volume = double.Parse(Console.ReadLine()); //ml
            double energy = double.Parse(Console.ReadLine()); //kcal
            double sugar = double.Parse(Console.ReadLine()); //g

            double kcal = (volume / 100) * energy;
            double g = (volume / 100) * sugar;

            Console.WriteLine("{0}ml {1}:\n{2}kcal, {3}g sugars" ,volume,nameOfProduct,kcal,g);
        }
    }
}
