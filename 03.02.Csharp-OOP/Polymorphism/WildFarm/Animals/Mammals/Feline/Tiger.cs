using System;
using WildFarm.Foods;
using WildFarm.Foods.Interfaces;

namespace WildFarm.Animals.Mammals.Feline
{
    public class Tiger : Feline
    {
        private const double IncreaseWeight = 1.00;

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("ROAR!!!");
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
