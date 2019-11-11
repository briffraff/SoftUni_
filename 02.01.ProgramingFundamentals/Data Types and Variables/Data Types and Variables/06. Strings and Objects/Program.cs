using System;

namespace _06._Strings_and_Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstWord = Console.ReadLine();
            string secondWord = Console.ReadLine();

            string wordCombo = firstWord + " " + secondWord;

            Console.WriteLine(wordCombo);
        }
    }
}
