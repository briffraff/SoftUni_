using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {
            //VARIANT S (@)
            int n = int.Parse(Console.ReadLine());

            //PROMENLIVI
            int width = (4 * n) + 1;
            int height = (2 * n) + 1;
            int dots = 1;
            int hash = 2 * n - 1;
            int spaces = 1;

            //TOP
            //1
            Console.WriteLine(new string('#', width));

            for (int i = 1; i <= n; i++)
            {
                //(@) red
                if ((n / 2) + 1 == i)
                {
                    Console.WriteLine("{0}{1}{2}(@){2}{1}{0}",
                        new string('.', dots),
                        new string('#', hash),
                        new string(' ', (spaces - 3) / 2));
                    dots++;
                    hash -= 2;
                    spaces += 2;
                }

                //vsicko ostanalo
                else
                {
                    Console.WriteLine("{0}{1}{2}{1}{0}",
                        new string('.', dots),
                        new string('#', hash),
                        new string(' ', spaces));
                    dots++;
                    hash -= 2;
                    spaces += 2;
                }
            }

            //BOTT
            hash = 2 * n - 1;
            for (int row = 1; row <= n; row++)
            {
                Console.WriteLine("{0}{1}{0}",
                    new string('.', dots),
                    new string('#', hash));

                dots++;
                hash -= 2;
            }


            //VARIANT BEZ (@)

            //    int N = int.Parse(Console.ReadLine());


            //    int width = (4 * N) + 1;
            //    int height = (2 * N) + 1;
            //    int dots = 1;
            //    int hash = 2 * N - 1;
            //    int spaces = 1;

            //    Console.WriteLine(new string('#', width));

            //    for (int row = 1; row <= N; row++)
            //    {
            //        Console.WriteLine("{0}{1}{2}{1}{0}",new string('.', dots),new string('#', hash),new string(' ', spaces));
            //        dots++;
            //        hash -= 2;
            //        spaces += 2;
            //    }

            //    hash = 2 * N - 1;
            //    for (int row = 1; row <= N; row++)
            //    {
            //        Console.WriteLine("{0}{1}{0}",new string('.', dots),new string('#', hash));

            //        dots++;
            //        hash -= 2;

            //    }
            //}
        }
    }
}