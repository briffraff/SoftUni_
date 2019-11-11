using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace customMinFunc
{
    class customMinFunc
    {
        public delegate int BinaryOperator(int[] num);

        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(theFunc(numbers,minValue));

        }

        public static int theFunc(int[] num, BinaryOperator opr)
        {
            return opr(num);
        }

        public static int minValue(int[] num)
        {
            return num.Min();
        }

    }
}
