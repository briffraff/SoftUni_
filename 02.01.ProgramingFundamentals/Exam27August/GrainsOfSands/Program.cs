using System;
using System.Collections.Generic;
using System.Linq;

namespace GrainsOfSand
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();

            string input = "";

            while ((input = Console.ReadLine()) != "Mort")
            {
                string[] split = input.Split(" ").ToArray();
                string command = split[0];
                int value = int.Parse(split[1]);

                if (command == "Add")
                {
                    numbers.Add(value);
                }
                else if (command == "Remove")
                {
                    if (numbers.Contains(value))
                    {
                        numbers.Remove(value);
                    }
                    else if (numbers.Count > value)
                    {
                        numbers.RemoveAt(value);
                    }
                }
                else if (command == "Replace")
                {
                    int replacement = int.Parse(split[2]);

                    if (numbers.Contains(value) == true)
                    {
                        int valueIdx = numbers.IndexOf(value);
                        numbers[valueIdx] = replacement;
                    }
                }
                else if (command == "Collapse")
                {
                    foreach (var num in numbers)
                    {
                        if (num < value)
                        {
                            numbers.Remove(num);
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
