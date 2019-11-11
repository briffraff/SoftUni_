using WildFarm.Animals.Mammals.Feline.Interfaces;

namespace WildFarm.Animals.Mammals.Feline
{
    public abstract class Feline : Mammal,IFeline
    {
        private string breed;

        protected Feline(string name, double weight, string livingRegion,string breed) 
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed
        {
            get { return breed; }
            set { breed = value; }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
