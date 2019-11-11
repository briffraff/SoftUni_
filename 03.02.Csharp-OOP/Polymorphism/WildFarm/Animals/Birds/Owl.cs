using System;
using WildFarm.Foods;
using WildFarm.Foods.Interfaces;

namespace WildFarm.Animals.Birds
{
    public class Owl : Bird
    {
        private const double IncreaseWeight = 0.25;

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot");
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
