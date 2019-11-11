using System;

namespace nFaktoriel
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 1;

            if (n >= 1 && n <= 12)
            {

                for (int i = 1; i <= n; i++)
                {
                    sum = sum * i;
                }
                Console.WriteLine(sum);
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}