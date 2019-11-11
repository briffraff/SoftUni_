using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChetniNechetniPozicii
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double nechetnaSuma = 0;
            double nechetenMin = double.MaxValue;
            double nechetenMax = double.MinValue;
            double chetnaSuma = 0;
            double chetenMin = double.MaxValue;
            double chetenMax = double.MinValue;

            double num = 0;
            string no = "No";

            for (int i = 1; i <= n; i++)
            {
                //vuvejdane na n na broi chisla
                num = double.Parse(Console.ReadLine());

                //subirane na chetnite i nechetnite chisla
                if (i % 2 == 0)
                {
                    chetnaSuma = chetnaSuma + num;
                }
                else
                {
                    nechetnaSuma = nechetnaSuma + num;
                }

                ////proverka za nai-golqmo chetno ili nechetno chislo
                if (i % 2 == 0 && num >= chetenMax)
                {
                    chetenMax = num;
                }
                else if (num >= nechetenMax)
                {
                    nechetenMax = num;
                }

                //proverka za nai-malko chetno ili nechetno chislo

                if (i % 2 == 0 && num <= chetenMin)
                {
                    chetenMin = num;
                }
                else if (num <= nechetenMax)
                {
                    nechetenMin = num;
                }
            }

            //PECHATANE NA REZULTATITE

            //sumata na nechetnite
            Console.WriteLine($"OddSum = {nechetnaSuma}");

            //proverka za neutralna stoinost - Nechetni
            if (nechetenMin == double.MaxValue)
            {
                Console.WriteLine($"OddMin = {no}");
            }
            else
            {
                Console.WriteLine($"OddMin = {nechetenMin}");
            }

            if (nechetenMax == double.MinValue)
            {
                Console.WriteLine($"OddMax = {no}");
            }
            else
            {
                Console.WriteLine($"OddMax = {nechetenMax}");
            }

            //sumata na chetni
            Console.WriteLine($"EvenSum = {chetnaSuma}");

            //proverka za neutralna stoinost - chetni
            if (chetenMin == double.MaxValue)
            {
                Console.WriteLine($"EvenMin = {no}");
            }
            else
            {
                Console.WriteLine($"EvenMin = {chetenMin}");
            }

            if (chetenMax == double.MinValue)
            {
                Console.WriteLine($"EvenMax = {no}");
            }
            else
            {
                Console.WriteLine($"EvenMax = {chetenMax}");
            }
        }
    }
}