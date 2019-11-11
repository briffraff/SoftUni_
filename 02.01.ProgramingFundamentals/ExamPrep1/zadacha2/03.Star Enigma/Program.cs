using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            string starReg = @"[STARstar]";
            Regex messageReg = new Regex(@"[^@\-:!>]*@([A-Za-z]+)[^@\-:!>]*:(\d+)!(A|D)!->(\d+)[^@\-:!>]*");

            List<string> attacked = new List<string>();
            List<string> destroyed = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                var starMatches = Regex.Matches(line, starReg);
                int step = starMatches.Count;
                StringBuilder decMessage = new StringBuilder();

                for (int j = 0; j < line.Length; j++)
                {
                    char current = (char)(line[j] - step);

                    string debug = (line[j] - step).ToString();

                    decMessage.Append(current);
                }

                if (messageReg.IsMatch(decMessage.ToString()))
                {
                    Match match = messageReg.Match(decMessage.ToString());
                    string type = match.Groups[3].Value;
                    string name = match.Groups[1].Value;

                    if (type == "D")
                    {
                        destroyed.Add(name);
                    }

                    if (type == "A")
                    {
                        attacked.Add(name);
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attacked.Count}");
            foreach (string planet in attacked.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }
            Console.WriteLine($"Destroyed planets: {destroyed.Count}");
            foreach (string planet in destroyed.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}
