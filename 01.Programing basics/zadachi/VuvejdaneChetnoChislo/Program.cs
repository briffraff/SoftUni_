using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuvejdaneChetnoChislo
{
    class Program
    {
        static void Main(string[] args)
        {

            int n;

            while (true)
            {
                try
                {
                    n = int.Parse(Console.ReadLine());

                    if (n % 2 != 0)
                    {
                        Console.WriteLine("Invalid number!");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid number!");
                }
            }
            Console.WriteLine($"Even number entered: {n}");
            Console.WriteLine();
        }
    }
}