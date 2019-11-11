using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DataTransfer
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> list = new List<string>();

            string pattern = @"s:([^;]*);r:([^;]*);m--""([A-Za-z\s]*)""";
            string digitsPattern = @"[0-9]";
            string lettersPattern = "[A-Za-z ]+";

            int totalData = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                MatchCollection matches = Regex.Matches(input, pattern);

                foreach (Match match in matches)
                {
                    MatchCollection digitsRegex = Regex.Matches(match.Value, digitsPattern);
                    foreach (var digit in digitsRegex)
                    {
                        totalData += int.Parse(digit.ToString());
                    }

                    string senderName = match.Groups[1].Value;
                    MatchCollection senderRegex = Regex.Matches(senderName, lettersPattern);
                    senderName = "";
                    foreach (var let in senderRegex)
                    {
                        senderName += let;
                    }

                    string recieverName = match.Groups[2].Value;
                    MatchCollection recieverRegex = Regex.Matches(recieverName, lettersPattern);
                    recieverName = "";
                    foreach (var let in recieverRegex)
                    {
                        recieverName += let;
                    }

                    string currentMessage = match.Groups[3].Value;
                    MatchCollection messageRegex = Regex.Matches(currentMessage, lettersPattern);
                    currentMessage = "";
                    foreach (var let in messageRegex)
                    {
                        currentMessage += let;
                    }

                    Console.WriteLine($"{senderName} says \"{currentMessage}\" to {recieverName}");
                }
            }

            Console.WriteLine($"Total data transferred: {totalData}MB");
        }
    }
}
