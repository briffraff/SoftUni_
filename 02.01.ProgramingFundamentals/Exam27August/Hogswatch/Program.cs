using System;

namespace Hogswatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int homesToVisit = int.Parse(Console.ReadLine());

            int initialPresents = int.Parse(Console.ReadLine());

            int additionalPresents = 0;
            int remainingHomes = 0;
            int visitedHomes = 0;
            int remainingPresents = 0;

            while (homesToVisit != 0)
            {
                int neededPresents = int.Parse(Console.ReadLine());
                initialPresents -= neededPresents;
                remainingPresents = initialPresents;
                visitedHomes++;
                homesToVisit -= 1;
                remainingHomes = homesToVisit;

            }

            if (initialPresents >= remainingPresents)
            {
                Console.WriteLine(remainingPresents);
            }
        }
    }
}
