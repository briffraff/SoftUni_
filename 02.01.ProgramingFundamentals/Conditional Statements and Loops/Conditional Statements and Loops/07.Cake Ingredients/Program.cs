using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Cake_Ingredients
{
    class Program
    {
        static void Main(string[] args)
        {
            int ingredCounter = 0;

            while (ingredCounter < 20)
            {
                string ingredients = Console.ReadLine();

                if (ingredients == "Bake!"|| ingredients == "bake!")
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Adding ingredient {ingredients}.");
                    ingredCounter += 1;
                }
            }
            Console.WriteLine($"Preparing cake with {ingredCounter} ingredients. ");
        }
    }
}
