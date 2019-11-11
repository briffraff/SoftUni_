using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002.Add_a_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            int sum = num1 + num2;

            Console.WriteLine("{0} + {1} = {2}" ,num1,num2,sum);
        }
    }
}
