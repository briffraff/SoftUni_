using System;
using System.Collections.Generic;
using System.Linq;

namespace cupsAndBottles
{
    class cupsAndBottles
    {
        static void Main(string[] args)
        {
            int[] cups = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> cupsQueue = new Queue<int>(cups);

            int[] bottles = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> bottlesStack = new Stack<int>(bottles);

            int wastedWaterTotal = 0;

            while (true)
            {
                int currentBottle = bottlesStack.Peek();
                int currentCup = cupsQueue.Peek();
                int remainingWater = 0;
                int waterInACup = 0;


                if (currentBottle >= currentCup)
                {
                    wastedWaterTotal += (currentBottle - currentCup);
                    bottlesStack.Pop();
                    cupsQueue.Dequeue();
                }

                if (currentBottle < currentCup)
                {
                    waterInACup = currentCup;

                    while (true)
                    {
                        waterInACup -= currentBottle;
                        if (waterInACup > 0)
                        {
                            cupsQueue.Dequeue();
                        }
                        else if (waterInACup <= 0)
                        {
                            break;
                        }
                    }
                }

                if (cupsQueue.Count == 0)
                {
                    Console.Write($"Bottles: ");
                    Console.WriteLine(string.Join(" ", bottlesStack));
                    break;
                }
                else if (bottlesStack.Count == 0)
                {
                    Console.Write($"Cups: ");
                    Console.WriteLine(string.Join(" ", cupsQueue));
                    break;
                }
            }
            Console.WriteLine($"Wasted litters of water: {wastedWaterTotal}");

        }
    }
}
