using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Hornet_Comm
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternPrivate = @"^([0-9]+)\s<->\s([A-Za-z0-9]+)$";
            string patternBroadcast = @"^([^0-9]+)\s<->\s([A-Za-z0-9]+)$";

            List<string> listOfPrivateMsg = new List<string>();
            List<string> listofBroadcastMsg = new List<string>();

            string input = "";

            while ((input = Console.ReadLine()) != "Hornet is Green")
            {

                Match privateMessage = Regex.Match(input, patternPrivate);
                Match broadcastMessage = Regex.Match(input, patternBroadcast);

                if (privateMessage.Success)
                {

                    string[] split = input.Split(" <-> ").ToArray();

                    char[] firstquery = split[0].ToCharArray().Reverse().ToArray();
                    string recipientCode = string.Join("", firstquery);

                    string secondQuery = split[1];
                    string message = string.Join("", secondQuery);

                    // string recipientCode = string.Join("",privateMessage.Groups[1].Value.Reverse());
                    //string message = string.Join("",privateMessage.Groups[2].Value);

                    string outputCombo = $"{recipientCode} -> {message}";
                    listOfPrivateMsg.Add(outputCombo);

                }

                
                if(broadcastMessage.Success)
                {
                    string message = broadcastMessage.Groups[1].Value;
                    string frequencyValue = broadcastMessage.Groups[2].Value;
                    string frequency = "";

                    for (int i = 0; i < frequencyValue.Length; i++)
                    {
                        if (char.IsUpper(frequencyValue[i]))
                        {
                            frequency += frequencyValue[i].ToString().ToLower();
                        }
                        else
                        {
                            frequency += frequencyValue[i].ToString().ToUpper();

                        }
                    }

                    string output = $"{frequency} -> {message}";
                    listofBroadcastMsg.Add(output);

                }
            }

            Console.WriteLine("Broadcasts:");

            if (listofBroadcastMsg.Count > 0)
            {
                Console.WriteLine(string.Join("\n",listofBroadcastMsg));
            }
            else
            {
                Console.WriteLine("None");
            }
            
            Console.WriteLine("Messages:");

            if (listOfPrivateMsg.Count > 0)
            {
                Console.WriteLine(string.Join("\n", listOfPrivateMsg));
            }
            else
            {
                Console.WriteLine("None");
            }
        }
    }
}
