using System;
using System.Linq;
using System.Net.Http.Headers;

namespace AppliedArithmetics
{
    class appliedArithmetics
    {
        static void Main(string[] args)
        {
            Action<int[]> print = p => Console.WriteLine(string.Join(" ", p));
            Func<int[], int[]> addFunc = num => num.Select(x => x + 1).ToArray();
            Func<int[], int[]> subFunc = num => num.Select(x => x - 1).ToArray();
            Func<int[], int[]> mplyFunc = num => num.Select(x => x * 2).ToArray();


            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            string command = "";

            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = addFunc(numbers);
                        break;
                    case "multiply":
                        numbers = mplyFunc(numbers);
                        break;
                    case "subtract":
                        numbers = subFunc(numbers);
                        break;
                    case "print":
                        print(numbers);
                        break;
                }
            }
        }
    }
}
