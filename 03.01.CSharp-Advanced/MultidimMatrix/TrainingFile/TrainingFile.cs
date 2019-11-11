using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace TrainingFile
{
    class TrainingFile
    {
        static void Main(string[] args)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; //.count = 26

            Console.WriteLine("-------------------");
            Console.WriteLine("--[ ASCII CODES ]--");
            Console.WriteLine("-------------------");
            Console.WriteLine("PLEASE INSERT A char :");
            Console.WriteLine();

            string input = "";
            while ((input = Console.ReadLine()) != "stop")
            {
                if (input.Length != 1)
                {
                    Console.WriteLine($"SORRY! You've inserted '{input.Length}' chars!");
                }
                else
                {
                    int asciiCode = char.Parse(input);
                    int letterIdx = alphabet.IndexOf(input.ToUpper()) + 1;

                    if (alphabet.Contains(input.ToLower()))
                    {
                        Console.WriteLine($"'{input}' is a letter '{letterIdx}' - ASCII: '{asciiCode}' ");
                    }
                    else if(alphabet.Contains(input.ToUpper()))
                    {
                        Console.WriteLine($"'{input}' is a letter '{letterIdx}' - ASCII: '{asciiCode}' ");
                    }
                    else
                    {
                        Console.WriteLine($"'{input}' - ASCII: '{asciiCode}' ");
                    }
                }
            }
        }
    }
}
