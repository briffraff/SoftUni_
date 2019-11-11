using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine().ToLower();
            int nightsCount = int.Parse(Console.ReadLine());

            double studio = 0;
            double doubleRoom = 0;
            double suiteRoom = 0;


            if (month == "may" || month == "october")
            {
                if (nightsCount > 7 && month == "october")
                {
                    studio = (50 * 0.95)*(nightsCount-1);
                }
                else if (nightsCount > 7)
                {
                    studio = (50 * 0.95)*nightsCount;
                }
                else
                {
                    studio = 50 * nightsCount;
                }
                doubleRoom = 65*nightsCount;
                suiteRoom = 75*nightsCount;
            }

            else if (month == "june" || month == "september")
            {
                if (nightsCount > 14 )
                {
                    doubleRoom = (72 * 0.90) * nightsCount;
                }
                else
                {
                    doubleRoom = 72 * nightsCount;
                }
                if (nightsCount > 7 && month == "september")
                {
                    studio = 60 * (nightsCount-1);
                }
                else
                {
                    studio = 60 *nightsCount;
                }
                suiteRoom = 82 * nightsCount;
            }

            else if (month == "july" || month == "august" || month == "december")
            {
                if (nightsCount > 14)
                {
                    suiteRoom = (89 * 0.85) * nightsCount;
                }
                else
                {
                    suiteRoom = 89 * nightsCount;
                }
                studio = 68 * nightsCount;
                doubleRoom = 77 * nightsCount;
            }

            Console.WriteLine($"Studio: {studio:f2} lv.");
            Console.WriteLine($"Double: {doubleRoom:f2} lv.");
            Console.WriteLine($"Suite: {suiteRoom:f2} lv.");

        }
    }
}
