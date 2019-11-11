using System;
using StrategyPattern.Core;

namespace StrategyPattern
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //Engine engine = new Engine();
            //engine.Run();

            EngineEqualityLogic engine = new EngineEqualityLogic();
            engine.Run();
        }
    }
}
