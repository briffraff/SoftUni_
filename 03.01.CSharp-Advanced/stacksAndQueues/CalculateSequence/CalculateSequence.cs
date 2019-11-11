using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculateSequence
{
    class CalculateSequence
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            List<long> resultNums = new List<long>();
            Queue<long> numbers = new Queue<long>();
            resultNums.Add(n);
            numbers.Enqueue(n);

            for (int i = 0; i < 17; i++)
            {
                long currentNum = numbers.Dequeue();

                long a = currentNum + 1;
                long b = 2 * currentNum + 1;
                long c = currentNum + 2;

                numbers.Enqueue(a);
                numbers.Enqueue(b);
                numbers.Enqueue(c);

                resultNums.Add(a);
                resultNums.Add(b);
                resultNums.Add(c);
            }

            Console.WriteLine(string.Join(" ",resultNums.Take(50)));
        }
    }
}
