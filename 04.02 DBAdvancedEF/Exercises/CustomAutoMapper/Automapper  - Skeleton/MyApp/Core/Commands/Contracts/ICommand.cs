using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Core.Commands.Contracts
{
    interface ICommand
    {
        string Execute(string[] inputArgs);
    }
}
