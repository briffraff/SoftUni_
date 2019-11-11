using System;
using System.Linq;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        string text = "";
        while (input != "Visual Studio crash")
        {
            text += input + " ";
            input = Console.ReadLine();
        }

        string[] words = Regex.Split(text, @"(?<![1-9])0(?<=0)\s|\s").Where(s => !string.IsNullOrEmpty(s)).ToArray();

        for (int i = 0; i < words.Length; i++)
        {
            if (words[i] == "32656" && words[i + 1] == "19759" && words[i + 2] == "32763")
            {
                int length = int.Parse(words[i + 3]);
                string word = "";

                for (int j = 0; j < length; j++)
                {
                    word += (char)int.Parse(words[i + 4 + j]);
                }
                Console.WriteLine(word);
                word = "";
            }
        }
    }
}