using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Foods.Interfaces
{
    public interface IFoodFactory
    {
        IFood CreateFood(string foodType, int quantity);
    }
}
