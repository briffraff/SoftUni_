namespace _03BarracksFactory.Models.Units
{
    public class Archer : Unit
    {
        private const int DefaultHealth = 25;
        private const int DefaultDamage = 7;

        protected Archer() 
            : base(DefaultHealth, DefaultDamage)
        {
        }
    }
}
