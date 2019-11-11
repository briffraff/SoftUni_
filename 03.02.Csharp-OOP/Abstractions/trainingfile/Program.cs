using System;
using System.Linq;

namespace trainingfile
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //M_:ar;lbo:_ro Go_;:ld;20, 1, 4,::_
            //V;::i_;c;t,;o:_;r;y W;h;_i;t_,;e 10 ,3, 9_:

            Steck steck = new Steck("");
            Cigarete cigara = new Cigarete(0);
            Kutiq kutiqCigari = new Kutiq(0);

            string inputText = "";
            while ((inputText = Console.ReadLine()) != "end")
            {
                string[] input = inputText.Split(";,:_".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
                string concatString = "";

                foreach (var item in inputText)
                {
                    concatString += item;
                }

                string cigaretesName = ""; //*

                string concatDigits = "";

                foreach (var i in concatString)
                {
                    if (char.IsLetter(i) || i == ' ')
                    {
                        cigaretesName += i;
                    }

                    if (char.IsDigit(i) || i == ' ')
                    {
                        concatDigits += i;
                    }
                }

                string[] digitsSplit = concatDigits.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                int CigaretesCount = int.Parse(digitsSplit[0]); //*
                int BoxCount = int.Parse(digitsSplit[1]); //*
                int cigaretaWeight = int.Parse(digitsSplit[2]); //*

                steck = new Steck(cigaretesName);
                cigara = new Cigarete(cigaretaWeight);
                kutiqCigari = new Kutiq(BoxCount);

                for (int i = 0; i < BoxCount; i++)
                {
                    steck.Kutii.Add(kutiqCigari);
                }

                for (int i = 0; i < CigaretesCount; i++)
                {
                    kutiqCigari.Cigaretes.Add(cigara);
                }
            }

            //PRINT
            Console.WriteLine($"Ime na steka : {steck.Name}");

            if (steck.Kutii.Count == 1)
            {
                Console.WriteLine($"V steka ima {steck.Kutii.Count} kutiq!");
            }
            else
            {
                Console.WriteLine($"V steka ima {steck.Kutii.Count} kutii!");
            }

            Console.WriteLine($"V kutiqta ima {kutiqCigari.Cigaretes.Count} cigari!");
            Console.WriteLine($"Obshto teglo na kutiqta : {kutiqCigari.Cigaretes.Count * steck.Kutii.Count * cigara.TobacoWeight} grama");
            Console.WriteLine();

        }
    }
}