using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Count_the_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int intCount = 0;
 
            try
            {
                while (intCount < 100)
                {
                    int number = int.Parse(Console.ReadLine());
                    intCount += 1;
                    int numberLnght = (number.ToString()).Length;

                    if (numberLnght > 7)
                    {
                        Console.WriteLine(intCount-1);
                        break;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine(intCount);
            }
        }
    }
}
