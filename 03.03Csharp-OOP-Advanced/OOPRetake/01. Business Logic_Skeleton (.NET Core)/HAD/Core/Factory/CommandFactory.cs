using HAD.Core.Factory.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HAD.Core.Factory
{
    public class CommandFactory : ICommandFactory
    {
        public string CreateCommand(string command, IList<string> arguments)
        {
            Type type = typeof(HeroManager);

            var methods = type.GetMethods().Where(x => x.Name.Contains("Add") || x.Name.Contains("Quit") || x.Name.Contains("Inspect"));

            var instance = Activator.CreateInstance(type, true);

            foreach (var method in methods)
            {
                if (method.Name == command)
                {
                    method.Invoke(instance, new object[] { arguments });
                }
            }

            return String.Empty;
        }
    }
}
