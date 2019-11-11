using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KokteilMargarita
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int visochina = (7 * n) + 3;
            int shirina = (8*n)+2;

            //TOP
            Console.WriteLine("'&${0}" , new string('_',(shirina-3)).Replace("_", "'"));

            int edkavichkaLeft = 2;
            int edkavichkaRight = shirina - 2 - edkavichkaLeft;

            for (int i = 0; i < n-1; i++)
            {
            Console.WriteLine("{0}\\{1}'", new string('_', edkavichkaLeft).Replace("_", "'") ,new string('_',edkavichkaRight).Replace("_", "'"));
                edkavichkaLeft += 1;
                edkavichkaRight -= 1;
            }

            string figura = "^*";

            for (int i = 0; i < (shirina / 2) - 1; i++)
            {
                Console.Write(figura);
                if (i == (shirina/2)-2)
                {
                    Console.WriteLine("^'");
                }
            }

            //MID
            int edKavichka = 0;
            int freespaces = n;
            int freespacesRight = shirina - freespaces - 6;

            for (int i = 1; i < n; i++)
            {
               Console.WriteLine("{2}\\\\{0}\\{1}//{2}'" ,new string(' ',freespaces) ,new string(' ',freespacesRight) ,new string('_',edKavichka).Replace("_","'"));

                edKavichka += 1;
                freespacesRight -= 2;

                if (i == n-1)
                {
                    freespaces = shirina - 3 - (edKavichka * 2); 
                    Console.WriteLine("{2}\\{0}/{2}'", new string('~', freespaces), new string(' ', freespacesRight), new string('_', edKavichka).Replace("_", "'"));
                }
            }

            for (int i = 1; i < (3 * n)-3; i++)
            {
                edKavichka += 1;
                freespaces -= 2;
                Console.WriteLine("{1}\\{0}/{1}'", new string(' ', freespaces), new string('_', edKavichka).Replace("_", "'"));
                if (i == n - 2)
                {
                    edKavichka += 1;
                    freespaces -= 2;
                    Console.WriteLine("{1}\\{0}/{1}'", new string('_', freespaces), new string('_', edKavichka).Replace("_", "'"));

                }
                if (i == n - 2)
                {
                    edKavichka += 1;
                    freespaces -= 2;
                    Console.WriteLine("{1}\\{0}/{1}'", new string('.', freespaces), new string('_', edKavichka).Replace("_", "'"));
                }
                if (i == (n*2))
                {
                    edKavichka += 1;
                    freespaces -= 2;
                    Console.WriteLine("{1}\\{0}/{1}'", new string('_', freespaces), new string('_', edKavichka).Replace("_", "'"));
                }
            }

            //BOT
            for (int i = 1; i <= (n*2)+1 ; i++)
            {
             Console.WriteLine("{0}|||{0}'", new string('_', (shirina - 3) / 2).Replace("_", "'"));
            }

            int dolnicherti = shirina - 1;

            Console.WriteLine("{0}'", new string('_',dolnicherti));

            int tirenca = dolnicherti - 2;
            Console.WriteLine("'{0}''", new string('-',tirenca));

        }
    }
}
