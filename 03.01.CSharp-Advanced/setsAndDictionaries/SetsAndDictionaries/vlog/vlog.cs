using System;
using System.Collections.Generic;
using System.Linq;

namespace vlog
{
    class vlog
    {
        static void Main(string[] args)
        {
            string input = "";

            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "Statistics")
            {
                //EmilConrad joined The V-Logger

                string[] splitInput = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                string vloggerName = splitInput[0]; //first vlogger name
                string command = splitInput[1]; //command

                if (command == "joined" && dict.ContainsKey(vloggerName) == false)
                {
                    dict.Add(vloggerName, new List<string>());
                }

                if (command == "followed" && dict.ContainsKey(vloggerName))
                {
                    string secondVlogger = splitInput[2]; //second vlogger name

                    if (dict.ContainsKey(secondVlogger))
                    {
                        if (dict[secondVlogger].Contains(vloggerName) == false && secondVlogger != vloggerName)
                        {
                            dict[secondVlogger].Add(vloggerName);
                        }
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {dict.Count} vloggers in its logs.");

            int counterOfVloggers = 0;
            int counterOfVloggerFollows = 0;

            foreach (var vloger in dict.OrderByDescending(x => x.Value.Count))
            {
                if (dict.Count != 0)
                {
                    counterOfVloggers++;
                    string vlogerName = vloger.Key;
                    int followersCount = vloger.Value.Count;

                    if (counterOfVloggers == 1)
                    {
                        if (vloger.Value.Count == 0)
                        {

                            Console.WriteLine($"{counterOfVloggers}. {vlogerName} : {followersCount} followers, {counterOfVloggerFollows} following");
                        }
                        else
                        {
                            Console.WriteLine($"{counterOfVloggers}. {vlogerName} : {followersCount} followers, {counterOfVloggerFollows} following");
                            foreach (var follower in vloger.Value.OrderBy(x => x))
                            {
                                Console.WriteLine($"*  {follower}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{counterOfVloggers}. {vlogerName} : {followersCount} followers, {counterOfVloggerFollows} following");
                    }
                }
            }

        }
    }
}

