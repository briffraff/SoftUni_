using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03.Softuni_Bar
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            string customerName = "";
            string product = "";
            long count = 0;
            double price = 0;
            double totalPrice = count * price;
            double totalIncome = 0;

            List<string> list = new List<string>();

            bool isBreak = true;

            while (isBreak)
            {
                input = Console.ReadLine();
                string pattern = @"^%(?<customer>[A-z][a-z]+)%[^\$\|\%\.]*?<(?<product>[\w]*)>[^\$\|\%\.]*?\|(?<count>\w+)\|[^\$\|\%\.]*?(?<price>\d*\.?\d)\$$";
                string pattern2 = @"%(?<customer>[A-Z][a-z]+)%[^\|\$%\.]*<(?<product>\w+)>[^\|\$%\.]*\|(?<count>\d)\|([^\|\$%\.]*\|)?(?<price>[0-9]+\.?[0-9]+)\$";
                var matches = Regex.Matches(input, pattern2);

                if (input == "end of shift")
                {
                    isBreak = false;
                }
                else
                {
                    foreach (Match word in matches)
                    {
                        customerName = word.Groups["customer"].Value;
                        product = word.Groups["product"].Value;
                        count = long.Parse(word.Groups["count"].Value);
                        price = double.Parse(word.Groups["price"].Value);
                        totalPrice = count * price;
                        list.Add($"{customerName}: {product} - {totalPrice:f2}");
                        totalIncome += totalPrice;
                    }
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine,list));
            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
