using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace functionalPrograming
{
    class TrainingFile
    {
        static void Main(string[] args)
        {
            //izvajdane samo na bukvite 

            string name = "P$e^s)-!ho 448";
            Console.WriteLine(@"text: {0}", name);

            //variant 0
            string letterPattern = @"([^\s]+)\s(\d{3})";
            MatchCollection collection = Regex.Matches(name, letterPattern);

            string nam = "";
            foreach (Match i in collection)
            {
                nam = i.Groups[1].Value;
                nam = string.Join("", nam.Where(char.IsLetter));
            }

            Console.WriteLine(nam);




            //variant 1
            //string newName = "";

            //foreach (var letter in name)
            //{
            //    if (char.IsLetter(letter))
            //    {
            //        newName += letter;
            //    }
            //}
            //Console.WriteLine(newName);

            //variant 2 
            name = string.Join("", name.Where(char.IsLetter));
            Console.WriteLine($"extracted text: {name}");

        }
    }
}
