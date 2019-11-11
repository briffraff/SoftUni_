using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace TrainingFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = @"R.A.F - Root Action Formula";
            string authorName = @"
                                     Author:
                                      ____  _  __  __       ____        __  __ 
                                     |  _ \(_)/ _|/ _|     |  _ \ __ _ / _|/ _|
                                     | |_) | | |_| |_ _____| |_) / _` | |_| |_ 
                                     |  _ <| |  _|  _|_____|  _ < (_| |  _|  _|
                                     |_| \_\_|_| |_|       |_| \_\__,_|_| |_|  
            ";

            Console.WriteLine(authorName);

            string textToSum = "Borisla52944  v B0orisov";
            int sum = 0;

            //variant 1
            foreach (var symbol in textToSum)
            {
                if (char.IsLetterOrDigit(symbol))
                {
                    sum += symbol;
                }
            }

            Console.WriteLine(sum);

            //variant 2
            int sum2 = textToSum.Where(char.IsLetter).Sum(x => x);

            //tryparse
            string a = "123";
            int result;

            bool b = int.TryParse(a, out result);
            if (b)
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Failed!");
            }

        }
    }
}
