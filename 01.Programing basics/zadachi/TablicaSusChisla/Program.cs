using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablicaSusChisla
{
    class Program
    {
        static void Main(string[] args)
        {
            //INPUT
            int n = int.Parse(Console.ReadLine());

            int num = 0;

            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    num = i + k + 1;

                    if (num > n)
                    {
                        num = 2 * n - num;
                    }
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }
        }
    }
}