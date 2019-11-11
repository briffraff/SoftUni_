using System;
using WildFarm.Foods;
using WildFarm.Foods.Interfaces;

namespace WildFarm.Animals.Mammals.Feline
{
    public class Cat : Feline
    {
        private const double IncreaseWeight = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }

        public override void Eat(IFood food)
        {
            if (food is Meat || food is Vegetable)
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
