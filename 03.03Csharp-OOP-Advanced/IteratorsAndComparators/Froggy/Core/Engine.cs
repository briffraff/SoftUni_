using System;
using System.Linq;

namespace Froggy.Core
{
    public class Engine
    {
        public void Run()
        {
            int[] stonesSplit = Console.ReadLine()
                .Split(",.".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Lake lake = new Lake(stonesSplit);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
