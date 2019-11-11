using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalinka
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int width = (2 * n) + 1;
            int freespaces = (width - 5) / 2;

            //TOP
            string ladyBirdEyes = "@   @";
            Console.WriteLine("{0}{1}{0}",new string(' ',freespaces),ladyBirdEyes);

            freespaces += 1;
            string ladyBirdRogca = "\\_/";
            Console.WriteLine("{0}{1}{0}",new string(' ',freespaces),ladyBirdRogca);

            string ladyBirdHead = "/ \\";
            Console.WriteLine("{0}{1}{0}", new string(' ', freespaces), ladyBirdHead);

            string ladyBirdNeck = "|_|";
            Console.WriteLine("{0}{1}{0}", new string(' ', freespaces), ladyBirdNeck);

            //MID
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0}/{1}|{1}\\{0}",new string(' ',freespaces-i),new string(' ',i));
                Console.WriteLine();
            }

            //BOTT

            //predposleden cikul
            if(n % 2 != 0)
            {
                for (int i = 1; i <= n/2; i++)
                {
                    Console.WriteLine("|{0}@{1}|{1}@{0}|", new string(' ', n / 2 - 1), new string(' ', n / 2));
                }
            }
            else
            {
                for (int i = 1; i <= n / 2; i++)
                {
                    Console.WriteLine("|{0}@{1}|{1}@{0}|", new string(' ', n / 2 - 1), new string(' ', n / 2 - 1));
                }
            }
          
            // posleden cikul
            if (n == 2)
            { 
                for (int i = 0; i < n / 2-1; i++)
                {
                    Console.Write("{0}\\{1}|{1}/{0}", new string(' ', i), new string(' ', freespaces - i));
                    Console.WriteLine();
                }
            }
            else
            {
                for (int i = 0; i < n / 2; i++)
                {
                    Console.Write("{0}\\{1}|{1}/{0}", new string(' ', i), new string(' ', freespaces - i));
                    Console.WriteLine();
                }
            }

            //posleden red
            int chovki = n / 2;
            string chovkiString = new string('^',chovki);
            freespaces = (width - (2 * chovki) - 1) / 2;
            Console.WriteLine("{0}{1}|{1}{0}",new string(' ',freespaces),chovkiString);

        }
    }
}
