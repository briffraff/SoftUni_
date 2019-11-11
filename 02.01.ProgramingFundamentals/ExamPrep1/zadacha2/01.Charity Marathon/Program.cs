using System;

namespace _01.Charity_Marathon
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int participants = int.Parse(Console.ReadLine());
            int averageLaps = int.Parse(Console.ReadLine());
            double trackLength = double.Parse(Console.ReadLine());
            int trackCapacity = int.Parse(Console.ReadLine());
            double moneyPerKm = double.Parse(Console.ReadLine());

            int maxCapacity = trackCapacity * days;
            double raisedMoney = 0;

            if (maxCapacity > participants)
            {
                double totalkm = (participants * averageLaps * trackLength)/1000;
                raisedMoney = totalkm * moneyPerKm;
            }
            else
            {
                double totalkm = (maxCapacity * averageLaps * trackLength) / 1000;
                raisedMoney = totalkm * moneyPerKm;
            }


            Console.WriteLine($"Money raised: {raisedMoney:f2}");
        }
    }
}
