using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Interval_of_numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            if (num1 < num2)
            {
                for (int i = num1; i <=num2; i++)
                {
                    Console.WriteLine(num1);
                    num1 += 1;
                }
            }
            else if (num1 > num2)
            {
                int switchNum1 = num2; //num1
                int switchNum2 = num1; //num2
                for (int i = switchNum1; i <= switchNum2; i++)
                {
                    Console.WriteLine(switchNum1);
                    switchNum1 += 1;
                }

            }
        }
    }
}
