using System;
using System.IO;

namespace LineNumbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            string path = "../../04. Streams-Exercise";
            string fileName = "text.txt";
            string fileNameToSave = "newText.txt";

            string savePath = Path.Combine(path, fileNameToSave);
            path = Path.Combine(path, fileName);

            using (StreamReader reader = new StreamReader(path))
            {
                using (StreamWriter writer = new StreamWriter(savePath))
                {
                    string line = "";
                    int count = 1;

                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine($"Line {count}: {line}");
                        count++;
                    }
                }
            }
        }
    }
}
