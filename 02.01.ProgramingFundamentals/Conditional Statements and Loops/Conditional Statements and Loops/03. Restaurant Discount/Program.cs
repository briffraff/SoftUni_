using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Restaurant_Discount
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupCount = int.Parse(Console.ReadLine());
            string Package = Console.ReadLine().ToLower();

            string hall = "";
            double pricePerPerson = 0;
            double discount = 0;
            int packagePrice = 0;
            double totalmoney = 0;

            int priceSmallHall = 2500;  //$
            int priceTerrace = 5000; //$
            int priceGreatHall = 7500; //$

            if(Package == "normal")
            {
                discount = 0.95; //5%
                packagePrice = 500;
            }
            else if(Package == "gold")
            {
                discount = 0.90; //10%
                packagePrice = 750;
            }
            else if (Package == "platinum")
            {
                discount = 0.85; //15%;
                packagePrice = 1000;
            }

            if (groupCount <= 50)
            {
                hall = "Small Hall";
                totalmoney = (priceSmallHall + packagePrice) *discount;
                pricePerPerson = totalmoney / groupCount;
            }
            else if (groupCount > 50 && groupCount <= 100)
            {
                hall = "Terrace";
                totalmoney = (priceTerrace + packagePrice) * discount;
                pricePerPerson = totalmoney / groupCount;
            }
            else if (groupCount > 100 && groupCount <= 120)
            {
                hall = "Great Hall";
                totalmoney = (priceGreatHall + packagePrice) * discount;
                pricePerPerson = totalmoney / groupCount;
            }
            else
            {
                Console.WriteLine("We do not have an appropriate hall.");
            }

            if (groupCount <= 120)
            {
                Console.WriteLine("We can offer you the {0}", hall);
                Console.WriteLine("The price per person is {0:f2}$" ,pricePerPerson);
            }
        }
    }
}
