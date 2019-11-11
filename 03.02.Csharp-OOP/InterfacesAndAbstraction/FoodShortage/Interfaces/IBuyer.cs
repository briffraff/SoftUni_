using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Interfaces
{
    public interface IBuyer
    {
        int Food { get; set; }

        void BuyFood();
    }
}
