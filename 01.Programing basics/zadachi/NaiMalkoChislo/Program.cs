using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaiGolqmoChislo
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            int min = int.Parse(Console.ReadLine());

            for (int i = 0; i < n - 1; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num <= min)
                {
                    min = num;
                }
            }

            Console.WriteLine(min);
        }
    }
}
