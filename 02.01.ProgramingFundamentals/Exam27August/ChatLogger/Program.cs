using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ChatLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> chat = new List<string>();

            string input = "";

            while ((input = Console.ReadLine()) != "end")
            {
                string[] splitInput = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = splitInput[0];
                string message = splitInput[1];

                switch (command)
                {
                    case "Chat":
                        chat.Add(message);
                        break;
                    case "Delete":
                        if (chat.Contains(message))
                        {
                            chat.Remove(message);
                        }
                        break;
                    case "Edit":

                        if (chat.Contains(message))
                        {
                            string replacement = splitInput[2];

                            int wordIdx = chat.IndexOf(message);
                            chat[wordIdx] = replacement;
                        }
                        break;
                    case "Pin":
                        if (chat.Contains(message))
                        {
                            string currentMessage = message;
                            chat.Remove(message);
                            chat.Add(currentMessage);
                        }
                        break;
                    case "Spam":

                        foreach (var msg in splitInput)
                        {
                            if (msg != "Spam")
                            {
                                chat.Add(msg);
                            }
                        }

                        break;

                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, chat));
        }
    }
}
