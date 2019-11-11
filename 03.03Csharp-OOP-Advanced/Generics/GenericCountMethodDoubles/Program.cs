using System;
using System.Collections.Generic;

namespace GenericCountMethodDoubles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<double> list = new List<double>();

            for (int i = 0; i < n; i++)
            {
                double number = double.Parse(Console.ReadLine());
                list.Add(number);
            }

            double target = double.Parse(Console.ReadLine());

            Box<double> box = new Box<double>(list);
            var result = box.GetGreaterThan(target);
            Console.WriteLine(result);
        }
    }
}
