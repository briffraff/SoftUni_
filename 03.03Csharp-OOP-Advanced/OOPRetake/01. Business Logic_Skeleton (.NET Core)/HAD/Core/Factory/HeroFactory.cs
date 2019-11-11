namespace HAD.Core.Factory
{
    using System;
    using System.Linq;
    using System.Reflection;

    using HAD.Contracts;
    using Contracts;

    public class HeroFactory : IHeroFactory
    {
        public IHero CreateHero(string heroType, string name)
        {

            Type typeOfHero = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x=>x.Name == heroType);

            IHero instanceObject = (IHero) Activator.CreateInstance(typeOfHero, name);

            return instanceObject;

            //IHero hero = null;

            //switch (heroType)
            //{
            //    case "Assassin":
            //        hero = new Assassin(name);
            //        break;
            //    case "Barbarian":
            //        hero = new Barbarian(name);
            //        break;
            //    case "Wizard":
            //        hero = new Wizard(name);
            //        break;
            //}

            //return hero;
        }
    }
}
