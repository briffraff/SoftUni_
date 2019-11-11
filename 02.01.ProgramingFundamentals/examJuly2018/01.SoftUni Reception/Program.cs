using System;

namespace _01.SoftUni_Reception
{
    class Program
    {
        static void Main(string[] args)
        {
      
            int firstEmploy = int.Parse(Console.ReadLine());
            int secondEmploy = int.Parse(Console.ReadLine());
            int thirdEmploy = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());

            int studentsPerHour = firstEmploy + secondEmploy + thirdEmploy;

            int rdyStuds = 0;

            int hours = 0;

            while (rdyStuds < studentsCount)
            {

                rdyStuds += studentsPerHour;
                hours++;

                if (hours % 4 == 0)
                {
                    hours++;
                }

            }

            Console.WriteLine($"Time needed: {hours}h.");

        }
    }
}
