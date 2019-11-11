using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.Anonymous_Vox
{
    class Program
    {
        static void Main(string[] args)
        {

            //regex1 - ([A-Za-z0-9]+)(?<placeholder>.+)(\1)
            //regex2 - {\s*(?<replacer>[A-za-z0-9]+)\s*?([A-za-z0-9]+)?\s*}

            string pattern = @"([A-Za-z0-9]+)(?<placeholder>.+)(\1)";

            string input = Console.ReadLine();

            List<string> replacers = Console.ReadLine().Split("}{".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

            var matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                if (replacers.Count > 0)
                {
                    string oldMatch = match.ToString();
                    string newMatch = match.Groups["1"].Value + replacers[0] + match.Groups["1"].Value;

                    input = input.Replace(oldMatch,newMatch);

                    replacers.RemoveAt(0);
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(input);
        }
    }
}
