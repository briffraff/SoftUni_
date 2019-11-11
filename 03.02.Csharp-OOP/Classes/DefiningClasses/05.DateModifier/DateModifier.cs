using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class DateModifier
{
    public static void DateDiff(string date1, string date2)
    {
        int[] firstData = date1.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int[] secondData = date2.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        DateTime dateOne = new DateTime(firstData[0], firstData[1], firstData[2]);
        DateTime dateTwo = new DateTime(secondData[0],secondData[1],secondData[2]);

        TimeSpan difference = dateOne.Subtract(dateTwo);
        Console.WriteLine(Math.Abs(difference.TotalDays));
    }
}

