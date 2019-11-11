using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02SoftUniKaraoke
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> usernamePoints = new Dictionary<string, int>();
            Dictionary<string, int> usernameSubmission = new Dictionary<string, int>();

            string input = "";
            while ((input = Console.ReadLine()) != "exam finished")
            {

                string[] split = input.Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (split.Length != 2)
                {
                    string name = split[0];
                    string language = split[1];
                    int points = int.Parse(split[2]);

                    if (usernamePoints.ContainsKey(name) == false)
                    {
                        usernamePoints.Add(name, points);
                    }
                    else
                    {
                        usernamePoints[name] = points;
                    }

                    if (usernameSubmission.ContainsKey(language) == false)
                    {
                        usernameSubmission.Add(language, 1);
                    }
                    else
                    {
                        usernameSubmission[language]++;
                    }
                }
                else
                {
                    string name = split[0];

                    if (usernamePoints.ContainsKey(name))
                    {
                        usernamePoints.Remove(name);
                    }
                }
            }

            Console.WriteLine("Results:");

            foreach (var user in usernamePoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key} | {user.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var submission in usernameSubmission.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{submission.Key} - {submission.Value}");
            }

        }
    }
}