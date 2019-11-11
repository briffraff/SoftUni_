using System;
using AnimalFarm.Core;

namespace AnimalFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
            engine.Print();
        }
    }
}
