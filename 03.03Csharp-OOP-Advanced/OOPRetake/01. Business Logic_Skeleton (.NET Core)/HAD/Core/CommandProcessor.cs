using System.Collections.Generic;
using System.Linq;
using HAD.Contracts;

namespace HAD.Core
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly IManager heroManager;

        public CommandProcessor(IManager heroManager)
        {
            this.heroManager = heroManager;
        }

        public string Process(IList<string> arguments)
        {
            string command = arguments[0];

            string[] commandArguments = arguments.Skip(1).ToArray();

            string result = string.Empty;
            


            switch (command)
            {
                case "Hero":
                    result = this.heroManager.AddHero(commandArguments);
                    break;
                case "Item":
                    result = this.heroManager.AddItem(commandArguments);
                    break;
                case "Recipe":
                    result = this.heroManager.AddRecipe(commandArguments);
                    break;
                case "Inspect":
                    result = this.heroManager.Inspect(commandArguments);
                    break;
                case "Quit":
                    result = this.heroManager.Quit();
                    break;
            }

            return result;
        }
    }
}