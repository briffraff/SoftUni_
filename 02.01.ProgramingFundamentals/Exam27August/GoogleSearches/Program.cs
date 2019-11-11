using System;

namespace GoogleSearches
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int totalDays = int.Parse(Console.ReadLine());
            int usersCount = int.Parse(Console.ReadLine());
            decimal moneyPerSearch = decimal.Parse(Console.ReadLine());

            int countUser = 0;
            decimal totalMoney = 0;

            for (int i = 0; i < usersCount; i++)
            {
                int wordsCount = int.Parse(Console.ReadLine());
                countUser++;

                if (wordsCount > 5)
                {
                    continue;
                }

                if (wordsCount == 1)
                {
                    moneyPerSearch = moneyPerSearch * 2;
                    totalMoney += moneyPerSearch;
                }

                if (countUser % 3 == 0 )
                {
                    moneyPerSearch = moneyPerSearch * 3;
                    totalMoney += moneyPerSearch;
                }

                if (countUser % 3 == 0 && wordsCount == 1)
                {
                    moneyPerSearch = moneyPerSearch * 2;
                    moneyPerSearch = moneyPerSearch * 3;
                    totalMoney += moneyPerSearch;
                }
                else
                {
                    totalMoney += moneyPerSearch;
                }
            }

            Console.WriteLine($"Total money earned for {totalDays} days: {(totalMoney * totalDays):f2}");
        }
    }
}
