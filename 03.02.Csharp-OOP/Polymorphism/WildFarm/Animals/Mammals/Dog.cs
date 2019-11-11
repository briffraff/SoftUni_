using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;
using WildFarm.Foods.Interfaces;

namespace WildFarm.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const double IncreaseWeight = 0.40;

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Woof!");
        }

        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                this.Weight += food.Quantity * IncreaseWeight;
                this.FoodEaten += food.Quantity;

            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
