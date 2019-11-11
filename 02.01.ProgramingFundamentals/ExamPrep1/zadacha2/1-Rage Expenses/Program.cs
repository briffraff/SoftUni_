using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        //variant 1 
        int lostGamesCount = int.Parse(Console.ReadLine());
        double headsetPrice = double.Parse(Console.ReadLine());
        double mousePrice = double.Parse(Console.ReadLine());
        double keyboardPrice = double.Parse(Console.ReadLine());
        double displayPrice = double.Parse(Console.ReadLine());

        double headsets = (lostGamesCount / 2);
        double mouses = (lostGamesCount / 3);
        double keyboards = (lostGamesCount / 3 / 2);
        double displays = Math.Floor(keyboards / 2);

        double expenses = headsets * headsetPrice + mouses * mousePrice + keyboards * keyboardPrice + displays * displayPrice;

        Console.WriteLine($"Rage expenses: {expenses:f2} lv.");

        ////variant2
        //int lostGames = int.Parse(Console.ReadLine());
        //double headsetPrice = double.Parse(Console.ReadLine());
        //double mousePrice = double.Parse(Console.ReadLine());
        //double keyboardPrice = double.Parse(Console.ReadLine());
        //double displayPrice = double.Parse(Console.ReadLine());

        //double expenses = 0;
        //int keyboard = 0;

        //for (int i = 1; i <= lostGames; i++)
        //{

        //    int headset = 0;
        //    int mouse = 0;
        //    if (i % 2 == 0)
        //    {
        //        expenses += headsetPrice;
        //        headset++;
        //    }
        //    if (i % 3 == 0)
        //    {
        //        expenses += mousePrice;
        //        mouse++;
        //    }
        //    if (headset > 0 && mouse > 0)
        //    {
        //        expenses += keyboardPrice;
        //        keyboard++;
        //        headset--;
        //        mouse--;
        //    }
        //    if (keyboard == 2)
        //    {
        //        expenses += displayPrice;
        //        keyboard = 0;
        //    }
        //}
        //Console.WriteLine($"Rage expenses: {expenses:f2} lv.");

    }
}