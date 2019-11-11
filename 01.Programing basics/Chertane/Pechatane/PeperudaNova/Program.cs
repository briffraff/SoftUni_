using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeperudaNova
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int width = (4 * n) - 4;
            int freeSpaces = (4 * n) - 8;
            int midDifPart = 6;
            int arrows = (width - midDifPart ) /2;
            string midDifPartString = "*|**|*";
            string leftTopWing = "*\\";
            string rightTopWing = "/*";
            string leftBottWing = "*/";
            string rightBottWing = "\\*";

            //TOP
            for (int i = 1; i <= n - 2; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(leftTopWing);
                }
                Console.Write(new string(' ',freeSpaces));
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(rightTopWing);
                }
                Console.WriteLine();
                freeSpaces -= 4;
            }

            //MID
            {
                for (int i = 0; i < width / 2; i++)
                {
                    Console.Write("\\/");
                }
                Console.WriteLine();
                for (int i = 1; i <= n / 2; i++)
                {
                    Console.WriteLine(new string('<', arrows) + midDifPartString + new string('>', arrows));
                }
                for (int i = 0; i < width / 2; i++)
                {
                    Console.Write("/\\");
                }
                Console.WriteLine();
            }

            //BOTT
            for (int i = n-2 ; i >= 1; i--)
            {
                freeSpaces += 4;
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(leftBottWing);
                }
                Console.Write(new string(' ',freeSpaces));
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(rightBottWing);
                }
                Console.WriteLine(); 
            }
        }
    }
}
