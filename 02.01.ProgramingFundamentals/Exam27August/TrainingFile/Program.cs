using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace TrainingFile
{
    class Program
    {
        static void Main(string[] args)
        {

            string text = "2.2gfdf5.sdsf4.6sdfotv9.4330yeeeee3.562323fsdf";
            string floatPattern = @"(\d.\d+)";

            //v1
            var floats = Regex.Matches(text, floatPattern);

            double sum = 0;
            foreach (var f in floats)
            {
                sum += double.Parse(f.ToString());
            }

            Console.WriteLine(sum);


            //v2
            var suma = text
                .Split("abcdefghijklmnopqrstuvwxyz".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x.Length >= 3)
                .Select(double.Parse)
                .Sum();

            Console.WriteLine(suma);








        }
    }
}
