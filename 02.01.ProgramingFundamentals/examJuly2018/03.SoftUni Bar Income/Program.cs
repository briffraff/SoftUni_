using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03.SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"^%(?<customer>[A-za-z]+)%[^\$\|\%\.]*?<(?<product>[\w]*)>[^\$\|\%\.]*?\|(?<count>\w)\|[^\$\|\%\.]*?(?<price>\d*.?\d+)\$$";

            var matches = Regex.Matches(input, pattern);

            List<string> customers = new List<string>();

            string customerName = "";
            string product = "";
            double count = 0;
            double price = 0;
            double totalPrice = count * price;

            foreach (Match word in matches)
            {
                customerName = word.Groups[1].Value;
                product = word.Groups[2].Value;
                count = double.Parse(word.Groups[3].Value);
                price = double.Parse(word.Groups[4].Value);
            }

            Console.WriteLine($"{customerName}: {product} - {totalPrice}");

            //bool orderProcess = true;
            //var totalPrice = 0;
            //var totalIncome = 0;

            //while (true)
            //{
            //    string input = Console.ReadLine();

            //    if (input != "end of shift")
            //    {
            //        Console.WriteLine($"{customerName} : {product} - {totalPrice}");
            //    }
            //    else
            //    {
            //        List<string> splittedMatch = list.Split("%|<>$".ToCharArray());

            //        string customerName = splittedMatch[1];
            //        Console.WriteLine(customerName);
            //        string product = splittedMatch[2];
            //        var count = int.Parse(splittedMatch[3]);
            //        var price = int.Parse(splittedMatch[4]);
            //        totalPrice = count * price;
            //        totalIncome += totalPrice;
            //    }
            //}
            //Console.WriteLine($"Total income: {totalIncome}");
        }
    }
}
