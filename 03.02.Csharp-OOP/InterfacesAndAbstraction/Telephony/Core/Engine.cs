using System;

namespace Telephony.Core
{
    public class Engine
    {
        public void Run()
        {
            Smartphone smartphone = new Smartphone();

            string[] mobileNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] webPages = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);


            for (int i = 0; i < mobileNumbers.Length; i++)
            {
                smartphone.Call(mobileNumbers[i]);
            }

            for (int i = 0; i < webPages.Length; i++)
            {
                smartphone.Browse(webPages[i]);
            }

        }
    }
}
