using System;
using System.Text.RegularExpressions;

namespace ChoreWars
{
    class Program
    {
        static void Main(string[] args)
        {

            int dishesTime = 0;
            int cleanTime = 0;
            int laundryTime = 0;

            string input = "";
            string disheshPattern = @"(<([0-9]|[a-z|0-9]+)>)";
            string cleanPattern = @"(\[([0-9]|[A-Z|0-9]+)])";
            string laundryPattern = @"(\{(.+?)})";


            while ((input = Console.ReadLine()) != "wife is happy")
            {
                MatchCollection dishes = Regex.Matches(input, disheshPattern);
                MatchCollection cleaning = Regex.Matches(input, cleanPattern);
                MatchCollection laundry = Regex.Matches(input, laundryPattern);

                foreach (Match dish in dishes)
                {
                    foreach (var d in dish.Value)
                    {
                        if (char.IsDigit(d))
                        {
                            dishesTime += int.Parse(d.ToString());
                        }
                    }
                }

                foreach (Match clean in cleaning)
                {
                    foreach (var c in clean.Value)
                    {
                        if (char.IsDigit(c))
                        {
                            cleanTime += int.Parse(c.ToString());
                        }
                    }
                }

                foreach (Match laund in laundry)
                {
                    foreach (var l in laund.Value)
                    {
                        if (char.IsDigit(l))
                        {
                            laundryTime += int.Parse(l.ToString());
                        }
                    }
                }

            }

            int totalTime = dishesTime + cleanTime + laundryTime;

            Console.WriteLine($"Doing the dishes - {dishesTime} min.");
            Console.WriteLine($"Cleaning the house - {cleanTime} min.");
            Console.WriteLine($"Doing the laundry - {laundryTime} min.");
            Console.WriteLine($"Total - {totalTime} min.");

        }
    }
}
