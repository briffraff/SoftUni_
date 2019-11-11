using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations2.Interfaces
{
    public interface IIdentifiable
    {
        string Id { get; }
        string Birthdate { get; }
    }
}
