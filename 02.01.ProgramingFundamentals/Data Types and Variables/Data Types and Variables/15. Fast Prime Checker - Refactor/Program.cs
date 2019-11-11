using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Fast_Prime_Checker___Refactor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberEnd = int.Parse(Console.ReadLine());
            for (int num = 2; num <= numberEnd; num++)
            {
                bool isPrime = true;
                for (int delitel = 2; delitel <= Math.Sqrt(num); delitel++)
                {
                    if (num % delitel == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine($"{num} -> {isPrime}");
            }

        }
    }
}
