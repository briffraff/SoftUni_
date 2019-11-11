using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PostOffice
{
    class Program
    {
        static void Main(string[] args)
        {
            string leftsidePattern = @"[#$%*&]+([A-Z]+)[#$%*&]+";
            string midPattern = @"(\d{2}){1}:(\d{2}){1}";
            string rightsidePattern = @"";

            List<string> capitals = new List<string>();
            List<string> mids = new List<string>();

            string[] input = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToArray();

            string leftPart = input[0];
            string midPart = input[1];
            string[] rightPart = input[2].Split(" ").ToArray();

            List<string> words = new List<string>(rightPart);

            MatchCollection capitalLetters = Regex.Matches(leftPart, leftsidePattern);
            foreach (Match capital in capitalLetters)
            {
                string theMatch = capital.Groups[1].Value;
                foreach (var match in theMatch)
                {
                    capitals.Add(match.ToString());
                }
            }

            MatchCollection middlePart = Regex.Matches(midPart, midPattern);
            foreach (var mid in middlePart)
            {
                mids.Add(mid.ToString());
            }


            for (int i = 0; i < mids.Count; i++)
            {
                string[] splitWord = mids[i].Split(':');
                string symbol = splitWord[0];
                int symbolCode = int.Parse(symbol);
                char symbolut = Convert.ToChar(symbolCode);

                string lenght = splitWord[1];
                int wordLenght = int.Parse(lenght);

                foreach (var word in words)
                {
                    if (word[0] == symbolut && word.Length == wordLenght + 1)
                    {
                        Console.WriteLine(word);
                    }
                }
            }
        }
    }
}
