using System;
using System.Collections.Generic;
using System.Linq;

namespace wardrobe
{
    class wardrobe
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> dict =
                new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] splitInput = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string color = splitInput[0];
                string[] items = splitInput[1].Split(",").ToArray();

                if (dict.ContainsKey(color) == false)
                {
                    dict.Add(color, new Dictionary<string, int>());
                }

                for (int j = 0; j < items.Length; j++)
                {
                    string item = items[j];

                    if (dict[color].ContainsKey(item) == false)
                    {
                        dict[color].Add(item, 1);
                    }
                    else
                    {
                        dict[color][item]++;
                    }
                }
            }

            string[] inputCommands = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries);

            string targetColor = inputCommands[0];
            string targetItem = inputCommands[1];

            foreach (var colour in dict)
            {
                Console.WriteLine($"{colour.Key} clothes:");

                foreach (var item in colour.Value)
                {
                    if (dict.ContainsKey(targetColor) && dict[targetColor].ContainsKey(targetItem) && 
                        targetColor == colour.Key && targetItem == item.Key)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}