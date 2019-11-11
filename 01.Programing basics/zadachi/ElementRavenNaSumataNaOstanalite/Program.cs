using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementRavenNaSumataNaOstanalite
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var sum = 0;
            var num = 0;
            int max = int.MinValue;
            // promenliva za min
            //int min = int.MaxValue;

            for (int i = 1; i <= n; i++)
            {
                num = int.Parse(Console.ReadLine());

                if (num > max)
                {
                    max = num;
                }
                // Namirane na nai-malkoto zadadeno ot potrebitelq chislo
                //if (num < min)
                //{
                //    min = num;
                //}
                sum = sum + num;
            }
            //Console.WriteLine(sum);
            //Console.WriteLine(min);
            //Console.WriteLine(max);
            sum = sum - max;
            if (sum == max)
                Console.WriteLine("Yes sum = " + sum);
            else
                Console.WriteLine("No Diff = " + Math.Abs(sum - max));
        }
    
    }
}
