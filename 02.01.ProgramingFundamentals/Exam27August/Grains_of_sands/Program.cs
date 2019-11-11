using System;
using System.Collections.Generic;
using System.Linq;

namespace Grains_of_sands
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] numbersInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> list = new List<int>(numbersInput);

            string input = "";

            while ((input = Console.ReadLine()) != "Mort")
            {
                string[] split = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = split[0];
                int value = int.Parse(split[1]);

                switch (command)
                {
                    case "Add":
                        list.Add(value);
                        break;

                    case "Remove":
                        if (list.Contains(value))
                        {
                            list.Remove(value);
                        }
                        else
                        {
                            if (value <= list.Count - 1)
                            {
                                list.RemoveAt(value);
                            }
                        }
                        break;

                    case "Replace":

                        int replacement = int.Parse(split[2]);
                        rePlacer(list, value, replacement);
                        break;

                    case "Increase":
                        intCreaser(list, value);
                        break;

                    case "Collapse":
                        list = list.Where(x => x >= value).ToList();
                        break;
                    default:
                        break;
                }

            }

            Console.WriteLine(string.Join(" ", list));
        }

        private static void rePlacer(List<int> list, int value, int replacement)
        {
            if (list.Contains(value))
            {
                int valueIndex = list.IndexOf(value);

                list[valueIndex] = replacement;
            }
        }
        private static void intCreaser(List<int> list, int value)
        {
            int currentNum = 0;
            int lastItem = list[list.Count - 1];

            foreach (var number in list) // prevurtane prez spisuka i zapisvane na chislo po-golqmo ot tursenoto
            {
                if (number >= value)
                {
                    currentNum = number;
                    break;
                }
            }

            if (currentNum != 0) // Ako ima chislo po-golqmo ot tursenoto ,to se dobavq kum vsichki 
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i] += currentNum;
                }
            }
            else // ako nqma chislo po-golqmo ot tursenoto dobavq poslednoto kum vsichki
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i] += lastItem;
                }
            }

        }
    }
}
