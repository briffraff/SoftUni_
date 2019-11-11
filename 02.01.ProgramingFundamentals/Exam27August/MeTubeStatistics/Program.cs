using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MeTubeStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictViews = new Dictionary<string, int>();
            //videoName        //views  //likes  
            var dictLikes = new Dictionary<string, int>();

            string input = "";
            string videoName = "";
            int views = 0;
            string command = "";
            int likes = 0;

            while ((input = Console.ReadLine()) != "stats time")
            {
                if (input.Contains("-"))
                {
                    string[] splitInput = input
                        .Split("-", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    videoName = splitInput[0];
                    views = int.Parse(splitInput[1]);

                    if (dictViews.ContainsKey(videoName) == false && dictLikes.ContainsKey(videoName) == false)
                    {
                        dictViews.Add(videoName, 0);
                        dictLikes.Add(videoName, 0);
                    }

                    if (dictViews.ContainsKey(videoName))
                    {
                        dictViews[videoName] += views;
                    }
                }

                if (input.Contains(":"))
                {
                    string[] likesSplit = input
                        .Split(":", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    command = likesSplit[0];
                    videoName = likesSplit[1];

                    if (dictViews.ContainsKey(videoName) &&
                        dictLikes.ContainsKey(videoName) &&
                        command.ToLower() == "like")
                    {
                        dictLikes[videoName] += 1;
                    }
                    else if (dictViews.ContainsKey(videoName) &&
                             dictLikes.ContainsKey(videoName) &&
                             command.ToLower() == "dislike")
                    {
                        //eventualna proverka dali da se ogranichi do 0
                        dictLikes[videoName] -= 1;
                    }
                }
            }

            input = Console.ReadLine();

            if (input == "by views")
            {
                foreach (var video in dictViews.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"{video.Key} - {dictViews[video.Key]} views - {dictLikes[video.Key]} likes");
                }
            }

            if (input == "by likes")
            {
                foreach (var video in dictLikes.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"{video.Key} - {dictViews[video.Key]} views - {dictLikes[video.Key]} likes");
                }
            }


        }
    }
}
