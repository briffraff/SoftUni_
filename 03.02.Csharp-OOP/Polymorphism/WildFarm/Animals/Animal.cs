using WildFarm.Animals.Interfaces;
using WildFarm.Foods;
using WildFarm.Foods.Interfaces;

namespace WildFarm.Animals
{
    public abstract class Animal : IAnimal
    {
        //fields
        private string name;
        private double weight;
        private int foodEaten;

        //ctor
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        //Prop
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }


        public int FoodEaten
        {
            get { return foodEaten; }
            set { foodEaten = value; }
        }


        //METHODS
        public abstract void ProduceSound();

        public abstract void Eat(IFood food);

    }
}
