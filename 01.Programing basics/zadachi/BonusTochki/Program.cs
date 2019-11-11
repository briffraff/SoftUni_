using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusTochki
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            double bonus = 0;

            if (number <= 100)
            {
                bonus = 5;
            }
            else if (number <= 1000)
            {
                bonus = 0.2 * number;
            }
            else
            {
                bonus = 0.1 * number;
            }
            if (number % 2 == 0)
            {
                bonus = bonus + 1;
            }
            if (number % 10 == 5)
            {
                bonus = bonus + 2;
            }

            double totalPoints = bonus + number;

            Console.WriteLine(bonus);
            Console.WriteLine(totalPoints);
        }
    }
}
