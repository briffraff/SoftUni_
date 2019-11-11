using System;
using System.Linq;
using System.Reflection;

namespace HAD
{
    using Contracts;
    using Core;
    using IO;

    public class StartUp
    {
        public static void Main(string[] args)
        {

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IManager heroManager = new HeroManager();

            ICommandProcessor commandProcessor = new CommandProcessor(heroManager);

            var engine = new Engine(reader, writer, commandProcessor);
            engine.Run();

        }
    }
}
