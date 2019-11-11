using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18.Different_Integers_Size
{
    class Program
    {
        static void Main(string[] args)
        {

            string number = Console.ReadLine();
            bool isSbyte = sbyte.TryParse(number, out sbyte sbyteResult);
            
            Console.WriteLine($"{number} can fit in: "); 
            Console.WriteLine($"{number} can't fit in any type");

        }
    }
}
