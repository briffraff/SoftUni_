using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chetnaNechetnaSuma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int evenSum = 0;
            int oddSum = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    evenSum = evenSum + num;
                }
                else
                {
                    oddSum = oddSum + num;
                }
            }
            Console.WriteLine(evenSum);
            Console.WriteLine(oddSum);

            var sum = evenSum;

            if (evenSum == oddSum)
            {
                Console.WriteLine("Yes, sum = " + sum);
            }
            else
            {
                Console.WriteLine("No, diff = " + Math.Abs(evenSum - oddSum));
            }
        }
    }
}
