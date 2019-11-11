using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonachi
{
    class Program
    {
        static void Main(string[] args)
        {
            //INPUT
            int n = int.Parse(Console.ReadLine());

            //Promenlivi
            string zvezda = "*";

            //Cikli
            for (int i = 1; i <= n; i++)
            {
                for (int k = 0; k < i; k++)
                {
                    //izpechatvane na redovete sus * ,kato se pribavq po 1 
                    //izvejda duljinata na simvolite
                    Console.Write(zvezda.Length + " ");
                    zvezda = zvezda + "*";

                    //proverka - ako duljinata stane poveche ot "n" izliza ot cikula
                    if (zvezda.Length > n)
                    {
                        return;
                    }

                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}