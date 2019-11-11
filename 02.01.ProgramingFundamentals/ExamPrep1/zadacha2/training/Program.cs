using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace training
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] split = "Gosho,Pesho,Ivan".Split(",".ToCharArray()).ToArray();
            foreach (var first in split)
            {
                char symbol = first[0];
                var code = (int)first[0];
                Console.WriteLine($"the ASCII code : {code} => \"{symbol}\"");
            }
            //the ASCII code: 71 => "G"
            //the ASCII code: 80 => "P"
            //the ASCII code: 73 => "I"

            //REGEX zagotovka
            string didiPattern = @"(?<didiMatch>[^A-Za-z-]+)"; //DidiMon
            string inputText = Console.ReadLine();
            string[] didiArray = Regex.Matches(inputText, didiPattern).Cast<Match>().Select(o => o.Value).ToArray();
            List<string> listDidi = new List<string>(didiArray);

            List<string> list = Console.ReadLine().Split(" ").ToList();
            string input = "";

            while ((input = Console.ReadLine()) != "Play!")
            {
                string delimiters = ",/*{-}+ ";

                string[] adds = "* 1-+ , 2+, }3, {4/-,5".Split(delimiters.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

                foreach (var newadd in adds)
                {
                    list.Add(newadd);
                }

                if (list.Count >= 10)
                {
                    break;
                }
            }

            Dictionary<string, string> dict = new Dictionary<string, string>();

            if (list.Count >= 10)
            {
                for (int i = 0; i < list.Count-1; i++)
                {

                    string elementKey = list[i];
                    string elementValue = list[i + 1];

                    //dict.Add(elementKey,elementValue);
                    dict[elementKey] = elementValue;
                }
            }

            foreach (var dictPart in dict.OrderBy(x => x.Key))
            {
                string keyElement = dictPart.Key;
                string valueElement = dictPart.Value;

                Console.WriteLine($"{keyElement} <:> {valueElement}");
            }
        }
    }
}
