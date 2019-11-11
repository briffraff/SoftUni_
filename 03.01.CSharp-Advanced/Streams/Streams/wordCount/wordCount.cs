using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace wordCount
{
    class wordCount
    {
        static void Main(string[] args)
        {
            string path = "../../04. Streams-Exercise";
            string fileName = "text.txt";
            string fileNameWords = "words.txt";
            string fileNameResults = "results.txt";

            string savePath = Path.Combine(path, fileNameResults);

            List<string> words = new List<string>();

            string textPath = Path.Combine(path, fileName);
            using (StreamReader reader = new StreamReader(textPath))
            {
                string line = "";
                string[] split = null;

                while ((line = reader.ReadLine()) != null)
                {
                    split = line
                        .Split("-,.!? ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    foreach (var word in split)
                    {
                        words.Add(word.ToLower());
                    }
                }
            }

            Dictionary<string, int> dict = new Dictionary<string, int>();

            string wordsPath = Path.Combine(path, fileNameWords);
            using (StreamReader reader = new StreamReader(wordsPath))
            {
                string line = "";

                while ((line = reader.ReadLine()) != null)
                {
                    if (dict.ContainsKey(line) == false)
                    {
                        dict.Add(line, 0);
                    }
                    else
                    {
                        dict[line]++;
                    }
                }

                foreach (var wor in words)
                {
                    if (dict.ContainsKey(wor))
                    {
                        dict[wor]++;
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter(savePath))
            {
                foreach (var item in dict.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                    writer.WriteLine($"{item.Key} - {item.Value}");
                }

            }

        }
    }
}
