using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.Regexmon
{
    class Program
    {
        static void Main(string[] args)
        {
            string bojoPattern = @"(?<bojoMatch>[A-Za-z]+-[A-Za-z]+)"; //BojoMon

            string didiPattern = @"(?<didiMatch>[^A-Za-z-]+)"; //DidiMon

            string input = Console.ReadLine();

            while (true)
            {
                var didiMatch = Regex.Match(input, didiPattern);

                if (didiMatch.Success)
                {
                    Console.WriteLine(didiMatch.Value);
                    input = input.Substring(input.IndexOf(didiMatch.Value) + didiMatch.Value.Length);
                }
                else
                {
                    break;
                }


                var bojoMatch = Regex.Match(input, bojoPattern);

                if (bojoMatch.Success)
                {
                    Console.WriteLine(bojoMatch.Value);
                    input = input.Substring(bojoMatch.Index + bojoMatch.Value.Length);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
