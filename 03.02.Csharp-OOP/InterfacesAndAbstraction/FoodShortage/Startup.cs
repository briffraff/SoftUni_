using System;
using FoodShortage.Core;

namespace FoodShortage
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
