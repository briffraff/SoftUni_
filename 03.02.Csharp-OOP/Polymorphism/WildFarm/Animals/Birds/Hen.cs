using System;
using WildFarm.Foods;
using WildFarm.Foods.Interfaces;

namespace WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        private const double IncreaseWeight = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Cluck");
        }

        public override void Eat(IFood food)
        {
            this.Weight += food.Quantity * IncreaseWeight;
            this.FoodEaten += food.Quantity;
        }
    }
}
