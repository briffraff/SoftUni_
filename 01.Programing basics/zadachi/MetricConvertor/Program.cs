using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricConvertor
{
    class Program
    {
        static void Main(string[] args)
        {


            double number = double.Parse(Console.ReadLine());
            string inCurrency = Console.ReadLine();
            string outCurrency = Console.ReadLine();

            var mm = 1000.0;
            var cm = 100.0;
            var mi = 0.000621371192;
            var inn = 39.3700787;
            var km = 0.001;
            var ft = 3.2808399;
            var yd = 1.0936133;
            var m = 1.0;


            if (inCurrency == "mm")
            {
                number = number / mm;
            }
            else if (inCurrency == "cm")
            {
                number = number / cm;
            }
            else if (inCurrency == "mi")
            {
                number = number / mi;
            }
            else if (inCurrency == "in")
            {
                number = number / inn;
            }
            else if (inCurrency == "km")
            {
                number = number / km;
            }
            else if (inCurrency == "ft")
            {
                number = number / ft;
            }
            else if (inCurrency == "yd")
            {
                number = number / yd;
            }
            else if (inCurrency == "m")
            {
                number = number / m;
            }


            if (outCurrency == "mm")
            {
                number = number * mm;
            }
            else if (outCurrency == "cm")
            {
                number = number * cm;
            }
            else if (outCurrency == "mi")
            {
                number = number * mi;
            }
            else if (outCurrency == "in")
            {
                number = number * inn;
            }
            else if (outCurrency == "km")
            {
                number = number * km;
            }
            else if (outCurrency == "ft")
            {
                number = number * ft;
            }
            else if (outCurrency == "yd")
            {
                number = number * yd;
            }
            else if (outCurrency == "m")
            {
                number = number * m;
            }

            Console.WriteLine($"{number:f8} {outCurrency:f8}");

            //double numbersToConvert = double.Parse(Console.ReadLine());

            //string firstNumber = Console.ReadLine();
            //string secondNumber = Console.ReadLine();

            //var currencies = new Dictionary<string, double>()
            //{
            //    {"mm", 1000 },
            //    {"cm", 100 },
            //    {"mi", 0.000621371192},
            //    {"in", 39.3700787},
            //    {"km", 0.001},
            //    {"ft", 3.2808399},
            //    {"yd", 1.0936133},
            //    {"m", 1}
            //};

            //double result = numbersToConvert / currencies[firstNumber] * currencies[secondNumber];

            //Console.WriteLine("{0} {1}", result, secondNumber);

        }
    }
}
