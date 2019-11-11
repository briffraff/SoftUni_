using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();

        Dictionary<string, Dictionary<string, int>> playerPool = new Dictionary<string, Dictionary<string, int>>();

        while (input != "Season end")
        {
            if (input.Contains(" -> "))
            {
                string[] splitted = input.Split(" -> ").ToArray();
                string player = splitted[0];
                string position = splitted[1];
                int skill = int.Parse(splitted[2]);

                if (!playerPool.ContainsKey(player))
                {
                    playerPool.Add(player, new Dictionary<string, int>());
                    playerPool[player].Add(position, skill);
                }
                else
                {
                    if (!playerPool[player].ContainsKey(position))
                    {
                        playerPool[player].Add(position, skill);
                    }
                    else if (playerPool[player][position] < skill)
                    {
                        playerPool[player][position] = skill;
                    }
                }
            }
            else if (input.Contains(" vs "))
            {
                string[] battle = input.Split(" vs ").ToArray();
                string player1 = battle[0];
                string player2 = battle[1];

                if (playerPool.ContainsKey(player1) && playerPool.ContainsKey(player2))
                {
                    foreach (var p1 in playerPool[player1])
                    {
                        if (!playerPool.ContainsKey(player1) || !playerPool.ContainsKey(player2))
                        {
                            break;
                        }
                        foreach (var p2 in playerPool[player2])
                        {
                            if (p1.Key == p2.Key)
                            {
                                if (playerPool[player1].Values.Sum() < playerPool[player2].Values.Sum())
                                {
                                    playerPool.Remove(player1);
                                    break;
                                }
                                else
                                {
                                    playerPool.Remove(player2);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            input = Console.ReadLine();
        }

        foreach (var player in playerPool.OrderByDescending(s => s.Value.Values.Sum()).ThenBy(n => n.Key))
        {
            Console.WriteLine(player.Key + ": " + player.Value.Values.Sum() + " skill");
            foreach (var position in player.Value.OrderByDescending(p => p.Value))
            {
                Console.WriteLine("- " + position.Key + " <::> " + position.Value);
            }
        }
    }
}