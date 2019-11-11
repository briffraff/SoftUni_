using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _02.SoftUni_Karaoke
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] participants = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] availableSongs = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            //string[] input = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

            Dictionary<string, Dictionary<string, int>> output = new Dictionary<string, Dictionary<string, int>>();

            string inputText = "";

            while ((inputText = Console.ReadLine()) != "dawn")
            {
                string[] input2 = inputText.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string currentParticipant = input2[0];
                string currentSong = input2[1];
                string currentAward = input2[2];

                if (participants.Contains(currentParticipant) && availableSongs.Contains(currentSong))
                {
                    if (output.ContainsKey(currentParticipant) == false)
                    {
                        output.Add(currentParticipant, new Dictionary<string, int>());

                        if (output[currentParticipant].ContainsKey(currentAward) == false)
                        {
                            output[currentParticipant].Add(currentAward, 1);
                        }
                    }
                    else
                    {
                        if (output[currentParticipant].ContainsKey(currentAward) == false)
                        {
                            output[currentParticipant].Add(currentAward, 1);
                        }
                        else
                        {
                            output[currentParticipant][currentAward]++;
                        }
                    }
                }
            }

            if (output.Values.Count != 0)
            {
                foreach (var singer in output.OrderByDescending(x=>x.Value.Keys.Count).ThenBy(x=>x.Key))
                {
                    Console.WriteLine($"{singer.Key}: {singer.Value.Keys.Count} awards");

                    foreach (var prize in singer.Value.OrderBy(x => x.Key))
                    {
                        Console.WriteLine($"--{prize.Key}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No awards");
            }

        }
    }
}
