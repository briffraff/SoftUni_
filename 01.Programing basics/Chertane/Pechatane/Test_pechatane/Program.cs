using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_pechatane
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            int shirina = 4 * n + 1;
            int zvezdi = 1;
            int tirenca = (shirina - zvezdi) / 2 - n + 2;
            int firstTirenca = tirenca + 1;

            Console.WriteLine(new string('-', 2 * firstTirenca + 3));
            Console.WriteLine("{0} * {0}", new string('-', firstTirenca));

            for (int i = 0; i <= n; i++)
            {
                Console.WriteLine("{0} {1}{1}* {0}", new string('-', tirenca), new string('*', zvezdi));
                zvezdi += 1;
                tirenca -= 1;
            }

            for (int i = 0; i <= n + 1; i++)
            {
                Console.WriteLine("{0} {1}{1}* {0}", new string('-', tirenca), new string('*', zvezdi));
                zvezdi -= 1;
                tirenca += 1;
            }

            Console.WriteLine("{0} * {0}", new string('-', firstTirenca));
            Console.WriteLine(new string('-', 2 * firstTirenca + 3));






            for (int i = 0; i <= n; i++)
            {
                for (int k = 0; k <= n - i; k++)
                {
                    Console.Write("*");
                }
                Console.Write("-");
                Console.Write(new string('_', i));
                Console.Write(new string('_', i + 1));
                Console.Write("-");

                for (int k = 0; k <= n - i; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            for (int i = n - 1; i >= 0; i--)
            {
                for (int k = 0; k <= n - i; k++)
                {
                    Console.Write("*");
                }
                Console.Write("-");
                Console.Write(new string('_', i));
                Console.Write(new string('_', i + 1));
                Console.Write("-");

                for (int k = 0; k <= n - i; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}