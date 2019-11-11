using System;
using System.IO;


namespace TrainingFile
{
    class TrainingFile
    {
        static void Main(string[] args)
        {
            //csproj e bazoviqt file
            string pathBackward = "../../../"; //tri papki nazad ot bazoviq file
            string pathForward = "bin/debug"; // dve papki napred ot bazoviq file

            string fileName = "TrainingFile.cs";

            string fullPath = Path.Combine(pathBackward, fileName);
            string fullPath2 = Path.Combine(pathForward, fileName);

            Console.WriteLine(fullPath);
            Console.WriteLine(fullPath2);

            StreamReader read = new StreamReader(fullPath);

            using (read)
            {
                string line = read.ReadLine();
                int count = 1;

                while (line != null)
                {
                    Console.WriteLine($"Line {count++}:   {line}");

                    line = read.ReadLine();
                }
            }

            Console.WriteLine();
            StreamReader read2 = new StreamReader(fullPath2);

            using (read2)
            {
                string line = read2.ReadLine();
                int count = 1;

                while (line != null)
                {
                    Console.WriteLine($"Line {count++}:   {line}");

                    line = read2.ReadLine();
                }
            }

        }
    }
}
