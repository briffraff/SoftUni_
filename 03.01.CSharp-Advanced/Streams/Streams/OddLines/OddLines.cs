using System;
using System.IO;

namespace OddLines
{
    class OddLines
    {
        static void Main(string[] args)
        {
            string path = "../../04. Streams-Exercise";
            string fileName = "text.txt";

            path = Path.Combine(path,fileName);

            StreamReader reader = new StreamReader(path);

            using (reader)
            {
                string line = "";
                int count = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    if (count % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    count++;
                }
            }
        }
    }
}
