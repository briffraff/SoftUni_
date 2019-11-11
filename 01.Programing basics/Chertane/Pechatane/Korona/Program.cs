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

            int shirina = (2 * n) - 1;
            int visochina = n / 2 + 4;
            int dots = 1;
            int freespace = n - 2;
            int zvezdicki = n / 2 - 2;
            int dotsMid = 1;


            //TOP
            Console.WriteLine("@{0}@{0}@", new string(' ', freespace));

            //MID
            //1
            freespace = n - 3;
            Console.WriteLine("**{0}*{0}**", new string(' ', freespace));

            //for
            int space = n - 5;

            for (int i = 1; i <= n - visochina + 2; i++)
            {
                Console.WriteLine("*{0}*{1}*{2}*{1}*{0}*", new string('.', dots), new string(' ', space), new string('.', dotsMid));
                dots++;
                space -= 2;
                dotsMid += 2;
            }

            //predposleden
            Console.WriteLine("*{0}*{1}*{0}*", new string('.', n / 2 - 1), new string('.', n - 3));

            //last
            dots = n / 2;
            Console.WriteLine("*{0}{1}.{1}{0}*", new string('.', dots), new string('*', n - dots - 2));

            //BOTT
            for (int i = 1; i <= 2; i++)
            {
                Console.WriteLine(new string('*', shirina));
            }
        }
    }
}