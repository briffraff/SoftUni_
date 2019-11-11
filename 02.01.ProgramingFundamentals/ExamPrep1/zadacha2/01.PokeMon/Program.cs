using System;

namespace _01.PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int startPower = pokePower;
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactorY = int.Parse(Console.ReadLine());

            int counterOfPoked = 0;
            int remainPower = 0;
            //decimal AveragePower = startPower * 0.5m;

            while (pokePower >= distance)
            {
                pokePower = pokePower - distance;
                remainPower = pokePower;
                counterOfPoked++;

                if (startPower == remainPower*2 && exhaustionFactorY > 0)
                {
                    pokePower = pokePower / exhaustionFactorY;
                    remainPower = pokePower;
                }
            }

            Console.WriteLine(remainPower);
            Console.WriteLine(counterOfPoked);
        }
    }
}
