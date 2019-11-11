using System;
using System.Linq;
using Telephony.Interfaces;

namespace Telephony
{
    public class Smartphone : ICalling, IBrowsing
    {
        public void Call(string number)
        {
            if (number.All(char.IsDigit))
            {
                Console.WriteLine($"Calling... {number}");
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        }

        public void Browse(string webpage)
        {
            if (webpage.Any(char.IsDigit) == false)
            {
                Console.WriteLine($"Browsing: {webpage}!");
            }
            else
            {
                Console.WriteLine("Invalid URL!");
            }
        }
    }
}
