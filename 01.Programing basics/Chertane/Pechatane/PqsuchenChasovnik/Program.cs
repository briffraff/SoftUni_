using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PqsuchenChasovnik
{
    class Program
    {
        static void Main(string[] args)
        {

            var n = int.Parse(Console.ReadLine());

            int shirochina = 2 * n + 1;
            int visochina = 2 * n + 1;

            //TOP

            //purvi red
            Console.WriteLine(new string('*', shirochina));

            //vtori red
            shirochina = shirochina - 4;
            Console.WriteLine(".*{0}*.", new string(' ', shirochina));

            //top cikul

            int dots = 1;

            for (int i = 1; i <= n - 2; i++)
            { 
                Console.WriteLine("{0}*{1}*{0}", new string('.', dots + i), new string('@', shirochina-2));
                shirochina -= 2;
            }

            int shirochina2 = 2 * n + 1;

            //MID
            Console.WriteLine("{0}*{0}", new string('.', (shirochina2 - 1) / 2));

            //BOTT

            //bott cikul
            int dots2 = (shirochina2 - 3) / 2;

            for (int i = 0; i < n-2; i++)
            {
                Console.WriteLine("{0}*{1}@{1}*{0}",new string('.',dots2),new string(' ',i));
                dots2 -= 1;
            }

            //predposleden red
            Console.WriteLine(".*{0}*.", new string('@', shirochina2 - 4));

            //posleden red
            Console.WriteLine(new string('*', shirochina2));
        }
    }
}
