using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Calories_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            int ingredCounter = 0;
            int calories = 0;
            int n = int.Parse(Console.ReadLine());

            while (ingredCounter < n)
            {
            string ingredients = Console.ReadLine().ToLower();

                if (ingredCounter < 20)
                {
                    if (ingredients == "cheese")
                    {
                        ingredCounter += 1;
                        calories += 500;
                    }
                    else if (ingredients == "tomato sauce")
                    {
                        ingredCounter += 1;
                        calories += 150;
                    }
                    else if (ingredients == "salami")
                    {
                        ingredCounter += 1;
                        calories += 600;
                    }
                    else if (ingredients == "pepper")
                    {
                        ingredCounter += 1;
                        calories += 50;
                    }
                    else
                    {
                        ingredCounter += 1;
                        calories += 0;
                    }
                }
                else
                {
                  break;
                }
            }
            Console.WriteLine($"Total calories: {calories}");
        }
    }
}
