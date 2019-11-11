using System;
using System.Collections.Generic;

namespace GenericBoxofInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

           
            for (int i = 0; i < n; i++)
            {
                int numbers = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(numbers);
                Console.WriteLine(box.ToString());
            }
        }
    }
}
