using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Histograma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;
            int counter = 0;


            if (n >= 1 && n <= 1000)
            {

                for (int i = 1; i <= n; i++)
                {
                    double num = double.Parse(Console.ReadLine());
                    ++counter;

                    if (num >= 800)
                    {
                        ++p5;
                    }
                    else if (num >= 600)
                    {
                        ++p4;
                    }
                    else if (num >= 400)
                    {
                        ++p3;
                    }
                    else if (num >= 200)
                    {
                        ++p2;
                    }
                    else
                    {
                        ++p1;
                    }
                }
            }
            else
            {
                Environment.Exit(0);
            }
            Console.WriteLine($"{100 * p1 / counter:F2}" + "%");
            Console.WriteLine($"{100 * p2 / counter:F2}" + "%");
            Console.WriteLine($"{100 * p3 / counter:F2}" + "%");
            Console.WriteLine($"{100 * p4 / counter:F2}" + "%");
            Console.WriteLine($"{100 * p5 / counter:F2}" + "%");


        }
    }
}