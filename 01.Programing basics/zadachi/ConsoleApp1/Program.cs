﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n-1; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    Console.Write("*");
                }
                for (int j = 1; j <= n+2; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }




        }
    }
}
