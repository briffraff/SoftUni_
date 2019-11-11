using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kupa
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int fullRange = 5 * n;


            //TOP
            for (int i = 0; i < n / 2; i++)
            {
                string topLeftRightDots = new string('.', n + i);
                string topMidDiez = new string('#', 5 * n - (2 * topLeftRightDots.Length));
                string topFullRaw = ($"{topLeftRightDots}{topMidDiez}{topLeftRightDots}");
                Console.Write(topFullRaw);
                Console.WriteLine();
            }

            for (int i = 0; i < n / 2 + 1; i++)
            {
                string dotsLeftRight = new string('.', n + (n / 2) + i);
                string midPartDots = new string('.', fullRange - (2 * dotsLeftRight.Length) - 2);
                string topMidPart = ($"{dotsLeftRight}#{midPartDots}#{dotsLeftRight}");
                Console.Write(topMidPart);
                Console.WriteLine();
            }

            //MID
            string middotsLeftRight = new string('.', ((n * 5) - n) / 2);
            string midDots = new string('#', n);
            string midFullRaw = $"{middotsLeftRight}{midDots}{middotsLeftRight}";
            Console.Write(midFullRaw);
            Console.WriteLine();

            //BOTT 

            for (int i = 1; i <= n / 2; i++)
            {
                string bottomDiez = new string('#', n + 4);
                string bottomLeftRightDots = new string('.', (5 * n - bottomDiez.Length) / 2);
                string bottomFullRaw = ($"{bottomLeftRightDots}{bottomDiez}{bottomLeftRightDots}");
                Console.Write(bottomFullRaw);
                Console.WriteLine();
            }

            // DANCE part
            string txtDance = "D^A^N^C^E^";
            string botLeftRightDots = new string('.', (5 * n - txtDance.Length) / 2);
            string botFullRaw = ($"{botLeftRightDots}{txtDance}{botLeftRightDots}");
            Console.Write(botFullRaw);
            Console.WriteLine();

            //last part
            for (int i = 1; i <= n / 2 + 1; i++)
            {
                string bottomDiez = new string('#', n + 4);
                string bottomLeftRightDots = new string('.', (5 * n - bottomDiez.Length) / 2);
                string bottomFullRaw = ($"{bottomLeftRightDots}{bottomDiez}{bottomLeftRightDots}");
                Console.Write(bottomFullRaw);
                Console.WriteLine();
            }
        }
    }
}