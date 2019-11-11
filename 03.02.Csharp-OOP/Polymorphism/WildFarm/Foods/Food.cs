using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods.Interfaces;

namespace WildFarm.Foods
{
    public abstract class Food : IFood
    {
        private int quantity;

        public Food()
        {

        }

        public Food(int quantity) : base()
        {
            this.Quantity = quantity;
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

    }
}
