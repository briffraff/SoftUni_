using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int shirina = (2 * n) + 2;

            //TOP
            int freespaces = n - 2;
            int freespacesTOPmid = 0;

            for (int i = 0; i < n - 1; i++)
            {
                Console.WriteLine("{0}/{1}|  |{1}\\", new string(' ', freespaces), new string(' ', freespacesTOPmid));
                freespaces -= 1;
                freespacesTOPmid += 1;
            }

            //vejdi
            Console.WriteLine(new string('-', shirina));

            //MID
            int freespacesMIDmid = n + 1;
            int freespacesMIDlr = (shirina - 4 - freespacesMIDmid) / 2;
            
            //za chetnite vhodove;
            if(n % 2 == 0)
            {
                freespacesMIDmid += 1;
            }

            Console.WriteLine("|{1}_{0}_{1}|",new string(' ',freespacesMIDmid),new string(' ',freespacesMIDlr));
            Console.WriteLine("|{1}@{0}@{1}|", new string(' ', freespacesMIDmid), new string(' ', freespacesMIDlr));

            for (int i = 1; i <= n/2; i++)
            {
                Console.WriteLine("|{0}|",new string(' ',shirina -2));
            }

            string nos = "OO";
            string mustaci = "/  \\";
            string usta = "||||";
            freespaces = n - 2;

            Console.WriteLine("|{0}{1}{0}|",new string(' ',freespaces+1),nos);
            Console.WriteLine("|{0}{1}{0}|", new string(' ', freespaces), mustaci);
            Console.WriteLine("|{0}{1}{0}|", new string(' ', freespaces), usta);

            //BOTT
            freespaces = shirina - 2;

            for (int i = 1; i <=n+1; i++)
            {
            Console.WriteLine("{1}{0}{2}",new string('`',freespaces),new string('\\',i),new string('/',i));
                freespaces -= 2;                
            }
        }
    }
}
