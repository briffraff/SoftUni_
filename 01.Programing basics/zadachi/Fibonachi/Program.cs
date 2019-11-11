using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonachi
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int baza = 1;
            int f0 = 1;
            int f1 = 1;
            int fSum = 0;

            if (n < 2)
            {
                Console.WriteLine(baza);
            }
            else
            {
                for (int i = 2; i < n + 1; i++)
                {
                    fSum = f0 + f1;
                    f0 = f1;
                    f1 = fSum;
                }
                Console.WriteLine(fSum);
            }
        }
    }
}