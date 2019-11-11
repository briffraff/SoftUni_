using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramka
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            //TOP
            Console.WriteLine(new string('*', n));

            //MID

            for (int i = 1; i <= n - 2; i++)
            {
                Console.WriteLine("*" + new string(' ', n - 2) + "*");

            }
            
            //BOTTOM
            Console.WriteLine(new string('*', n));

        }
    }
}
