using System;
using Telephony.Core;
using Telephony.Interfaces;

namespace Telephony
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
