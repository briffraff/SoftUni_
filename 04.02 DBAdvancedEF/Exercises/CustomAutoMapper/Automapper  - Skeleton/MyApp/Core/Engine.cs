using System;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Core.Contracts;

namespace MyApp.Core
{
    public class Engine : IEngine
    {
        private readonly IServiceProvider _provider;

        public Engine(IServiceProvider provider)
        {
            this._provider = provider;
        }

        public void Run()
        {
            string input = "";

            while ((input = Console.ReadLine()) != "Exit")
            {

                string[] inputArgs = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var commandInterpreter = this._provider.GetService<ICommandInterpreter>();
                string result = commandInterpreter.Read(inputArgs);

                Console.WriteLine(result);

            }
        }
    }
}
