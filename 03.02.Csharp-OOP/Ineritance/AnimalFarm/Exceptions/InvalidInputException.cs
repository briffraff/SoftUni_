using System;

namespace AnimalFarm.Exceptions
{
    public class InvalidInputException : FormatException
    {
        public InvalidInputException(string message = "Invalid input!") : base(message)
        {
        }
    }
}
