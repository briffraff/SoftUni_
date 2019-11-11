using System.Collections.Generic;

namespace HAD.Core.Factory.Contracts
{
    public interface ICommandFactory
    {
        string CreateCommand(string command, IList<string> arguments);
    }
}
