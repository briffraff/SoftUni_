using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Exchange_Variable_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Before:" + "\n" + "a = "+"{0}" + "\n" + "b = " + "{1}" ,num1,num2);
            Console.WriteLine("After:" + "\n" + "a = " + "{1}" + "\n" + "b = " + "{0}", num1, num2);

        }
    }
}
