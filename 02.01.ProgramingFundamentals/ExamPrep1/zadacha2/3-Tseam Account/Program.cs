using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');

        List<string> games = new List<string>(input);


        while (input[0] != "Play!")
        {
            if (input[0] == "Install" && !games.Contains(input[1]))
            {
                games.Add(input[1]);
            }
            else if (input[0] == "Uninstall" && games.Contains(input[1]))
            {
                games.Remove(input[1]);
            }
            else if (input[0] == "Update" && games.Contains(input[1]))
            {
                games.Remove(input[1]);
                games.Add(input[1]);
            }
            else if (input[0] == "Expansion")
            {
                string[] game = input[1].Split('-');
                if (games.Contains(game[0]))
                {
                    var ex = input[1].Split('-');
                    if (games.Contains(ex[0]))
                    {
                        var exp = string.Join(":", ex);
                        var index = games.IndexOf(ex[0]);
                        games.Insert(index + 1, exp);
                    }

                }
            }
            input = Console.ReadLine().Split(' ');
        }

        foreach (var game in games)
        {
            Console.Write(game + " ");
        }
    }
}