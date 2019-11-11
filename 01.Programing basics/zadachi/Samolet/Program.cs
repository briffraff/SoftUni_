using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Airplane
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minute = int.Parse(Console.ReadLine());
            int polet = int.Parse(Console.ReadLine());

            int time = (hour * 60) + minute;
            int kacane = time + polet;
            int minTime = kacane % 60;
            int hourTime = kacane / 60;
            if (hourTime >= 24)
            {
                hourTime -= 24;
            }
            Console.WriteLine($"{hourTime}h {minTime}m");


        }
    }
}