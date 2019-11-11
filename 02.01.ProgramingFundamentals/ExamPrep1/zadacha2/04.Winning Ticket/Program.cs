using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.Winning_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine()
                .Split(new[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var ticket in input)
            {
                if (ticket.Length == 20)
                {
                    string leftSide = ticket.Substring(0, 10);
                    string rightSide = ticket.Substring(10);

                    string jackpotPattern = @"(#{20}|@{20}|\${20}|\^{20})";
                    var regexJackpot = Regex.IsMatch(ticket, jackpotPattern);
                    var jackpotLen = ((Regex.Match(ticket, jackpotPattern)).Length) / 2;

                    var regexLeftRightPattern = @"(#{6,9}|@{6,9}|\${6,9}|\^{6,9})";
                    var regexLeftIf = Regex.IsMatch(leftSide, regexLeftRightPattern);
                    var regexRightIf = Regex.IsMatch(rightSide, regexLeftRightPattern);

                    var regexLeftmatch = Regex.Match(leftSide, regexLeftRightPattern);
                    var regexRightmatch = Regex.Match(rightSide, regexLeftRightPattern);

                    var leftLen = Regex.Match(leftSide, regexLeftRightPattern).Value.Length;
                    var rightLen = Regex.Match(rightSide, regexLeftRightPattern).Value.Length;

                    if (regexJackpot)
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - {jackpotLen}{ticket[0]} Jackpot!");

                    }
                    else if (regexLeftIf && regexRightIf && regexLeftmatch.Value[0] == regexRightmatch.Value[0])
                    {
                        if (leftLen < rightLen)
                        {
                            int lenght = leftLen;
                             Console.WriteLine($"ticket \"{ticket}\" - {lenght}{regexLeftmatch.Value[0]}");
                        }
                        else
                        {
                            int lenght = rightLen;
                            Console.WriteLine($"ticket \"{ticket}\" - {lenght}{regexLeftmatch.Value[0]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                }
                else
                {
                    Console.WriteLine("invalid ticket");
                }
            }
        }
    }
}
