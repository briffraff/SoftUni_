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

            int shirina = n + 5;

            if (n % 2 != 0)
            {
                Environment.Exit(0);
            }
            else
            {
                //TOP
                //purvi red
                int dolniChertiLeftRight = (shirina - 1) / 2;
                Console.WriteLine("{0}^{0}", new string('_', dolniChertiLeftRight));

                string vtoriRed = "/|\\";
                dolniChertiLeftRight -= 1;
                Console.WriteLine("{0}{1}{0}", new string('_', dolniChertiLeftRight), vtoriRed);

                int dots = 0;
                if (n == 4)
                {
                    for (int i = 0; i <= n / 2; i++)
                    {
                        dolniChertiLeftRight -= 1;
                        Console.WriteLine("{0}/{1}|||{1}\\{0}", new string('_', dolniChertiLeftRight), new string('.', dots));
                        dots += 1;
                    }
                }
                else
                {
                    for (int i = 1; i <= n / 2; i++)
                    {
                        dolniChertiLeftRight -= 1;
                        Console.WriteLine("{0}/{1}|||{1}\\{0}", new string('_', dolniChertiLeftRight), new string('.', dots));
                        dots += 1;
                    }
                }

                if (n == 4)
                {
                    string razlichenRed = "_/.|||.\\_";
                    Console.WriteLine(razlichenRed);
                }
                else
                {
                    string topMid = "/..|||..\\";
                    int leftrightcherta = (shirina - 9) / 2;

                    Console.WriteLine("{0}{1}{0}", new string('_', leftrightcherta), topMid);

                    string topMidmid = "/.|||.\\";
                    leftrightcherta += 1;
                    Console.WriteLine("{0}{1}{0}", new string('_', leftrightcherta), topMidmid);

                }

                int leftrightDolnicherti = (shirina - 3) / 2;
                //MID
                for (int i = 1; i <= n; i++)
                {
                    string midRed = "|||";
                    Console.WriteLine("{0}{1}{0}", new string('_', leftrightDolnicherti), midRed);
                }

                //predposleden razlichen
                Console.WriteLine("{0}~~~{0}", new string('_', leftrightDolnicherti));

                int bottDots = 0;
                for (int i = 0; i <= n / 2 - 1; i++)
                {
                    leftrightDolnicherti -= 1;
                    Console.WriteLine("{0}//{1}!{1}\\\\{0}", new string('_', leftrightDolnicherti), new string('.', bottDots));
                    bottDots += 1;
                }

            }
        }
    }
}
