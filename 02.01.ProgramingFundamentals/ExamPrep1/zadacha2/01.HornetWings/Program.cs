using System;

namespace _01.HornetWings
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double m = double.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            double distance = (n / 1000) * m;
            double time = (n/100)+(n/p)*5;

            Console.WriteLine($"{distance:F2} m.");
            Console.WriteLine($"{time} s.");

        }
    }
}
