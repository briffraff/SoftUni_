using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumiraneNaGlasniBukvi
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine();
            var sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'a')
                {
                    sum += 1;
                }
                if (input[i] == 'e')
                {
                    sum += 2;
                }
                if (input[i] == 'i')
                {
                    sum += 3;
                }
                if (input[i] == 'o')
                {
                    sum += 4;
                }
                if (input[i] == 'u')
                {
                    sum += 5;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
