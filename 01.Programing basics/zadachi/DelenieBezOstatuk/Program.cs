using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelenieBezOstatuk
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            

            if(n >=1 || n <=1000)
            {
                for (int  i = 1; i <= n; i++)
                {
                    double number = double.Parse(Console.ReadLine());
                   

                    if (number % 2 == 0)
                    {
                        p1++;
                    }
                    if (number % 3 == 0 )
                    {
                        p2++;
                    }
                    if(number % 4 == 0)
                    {
                        p3++;
                    }
                }
            }

            Console.WriteLine("{0:F2}%",p1/n*100);
            Console.WriteLine("{0:F2}%",p2/n*100);
            Console.WriteLine("{0:F2}%",p3/ n*100);
        }
    }
}
