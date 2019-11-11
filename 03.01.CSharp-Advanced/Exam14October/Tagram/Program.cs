using System;
using System.Collections.Generic;
using System.Linq;

namespace Tagram
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> dict =
                new Dictionary<string, Dictionary<string, int>>();

            string input = "";
            while ((input = Console.ReadLine()) != "end")
            {
                string[] splitInput = input
                    .Split(" ->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (splitInput.Length == 3)
                {
                    string userName = splitInput[0];
                    string tag = splitInput[1];
                    int likes = int.Parse(splitInput[2]);

                    if (dict.ContainsKey(userName) == false)
                    {
                        dict.Add(userName, new Dictionary<string, int>());
                    }

                    if (dict[userName].ContainsKey(tag) == false)
                    {
                        dict[userName].Add(tag, likes);
                    }
                    else
                    {
                        dict[userName][tag] += likes;
                    }
                }

                if (splitInput.Length == 2)
                {
                    string userToBan = splitInput[1];
                    string banCommand = splitInput[0];

                    if (banCommand == "ban")
                    {
                        dict.Remove(userToBan);
                    }
                }
            }


            foreach (var user in dict.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Value.Count))
            {
                Console.WriteLine(user.Key);

                foreach (var tag in user.Value)
                {
                    Console.WriteLine($"- {tag.Key}: {tag.Value}");
                }
            }
        }
    }
}
