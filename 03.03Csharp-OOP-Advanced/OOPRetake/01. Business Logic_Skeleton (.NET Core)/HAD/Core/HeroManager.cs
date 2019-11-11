using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using HAD.Contracts;
using HAD.Core.Factory;
using HAD.Core.Factory.Contracts;
using HAD.Entities.Heroes;
using HAD.Entities.Items;
using HAD.Utilities;

namespace HAD.Core
{
    public class HeroManager : IManager
    {
        private readonly IDictionary<string, IHero> heroes;
        private readonly IHeroFactory heroFactory;

        public HeroManager()
        {
            this.heroes = new Dictionary<string, IHero>();
            this.heroFactory = new HeroFactory();
        }

        public string AddHero(IList<string> arguments)
        {
            string heroName = arguments[0];
            string heroTypeName = arguments[1];

            IHero hero = this.heroFactory.CreateHero(heroTypeName, heroName);

            if (hero != null)
            {
                this.heroes.Add(heroName, hero);
            }

            string result = string.Format(Constants.HeroCreateMessage, hero.GetType().Name, hero.Name); ;
            return result;
        }

        public string AddItem(IList<string> arguments)
        {
            string itemName = arguments[0];
            string heroName = arguments[1];
            int strengthBonus = int.Parse(arguments[2]);
            int agilityBonus = int.Parse(arguments[3]);
            int intelligenceBonus = int.Parse(arguments[4]);
            int hitPointsBonus = int.Parse(arguments[2]);
            int damageBonus = int.Parse(arguments[6]);

            CommonItem newItem = new CommonItem(
                itemName,
                strengthBonus,
                agilityBonus,
                intelligenceBonus,
                hitPointsBonus,
                damageBonus);

            this.heroes[heroName].AddItem(newItem);

            string result = string.Format(Constants.ItemCreateMessage, newItem.Name, heroName);
            return result;
        }

        public string AddRecipe(IList<string> arguments)
        {
            string itemName = arguments[0];
            string heroName = arguments[1];
            int strengthBonus = int.Parse(arguments[2]);
            int agilityBonus = int.Parse(arguments[3]);
            int intelligenceBonus = int.Parse(arguments[4]);
            int hitPointsBonus = int.Parse(arguments[2]);
            int damageBonus = int.Parse(arguments[6]);

            List<CommonItem> requiredItems = new List<CommonItem>();

            var commonItems = this.heroes[heroName].Items.Where(x => x.GetType().Name == "CommonItem");

            foreach (var commonItem in commonItems)
            {
                requiredItems.Add((CommonItem) commonItem);
            }

            RecipeItem newItem = new RecipeItem(
                itemName,
                strengthBonus,
                agilityBonus,
                intelligenceBonus,
                hitPointsBonus,
                damageBonus,
                requiredItems);

            string result = string.Format(Constants.RecipeCreateMessage, newItem.Name, heroName);
            return result;

        }

        public string Inspect(IList<string> arguments)
        {
            string heroName = arguments[0];
            var commonItems = this.heroes[heroName].Items.Where(x => x.GetType().Name == "CommonItem");

            var stringResult = "";

            foreach (var commonItem in commonItems)
            {
                if (heroes.ContainsKey(heroName) && heroes[heroName].Items.Count > 0)
                {
                    stringResult = heroes[heroName].ToString() +"\n" + commonItem.ToString();
                }
                else
                {
                    stringResult = "Items: None";
                }
            }


            //        Hero: { heroName}, Class: { heroType}
            //        HitPoints: { hitpoints}, Damage: { damage}
            //        Strength: { strength}
            //        Agility: { agility}
            //        Intelligence: { intelligence}
            //        Items:
            //###Item: {item1Name}
            //###+{strengthBonus} Strength
            //###+{agilityBonus} Agility
            //###+{intelligenceBonus} Intelligence
            //###+{hitpointsBonus} HitPoints
            //###+{damageBonus} Damage

            return stringResult;
        }

        public string Quit()
        {
            int counter = 1;

            StringBuilder result = new StringBuilder();

            var sortedHeroes = this.heroes
                .Values
                .OrderByDescending(h => h.Strength + h.Intelligence + h.Agility)
                .ThenByDescending(h => h.HitPoints + h.Damage)
                .ToList();

            foreach (var hero in sortedHeroes)
            {
                string itemLine = hero.Items.Count != 0
                    ? string.Join(", ", hero.Items.Select(i => i.Name))
                    : "None";

                result
                    .AppendLine($"{counter}. {hero.GetType().Name}: {hero.Name}")
                    .AppendLine($"###HitPoints: {hero.HitPoints}")
                    .AppendLine($"###Damage: {hero.Damage}")
                    .AppendLine($"###Strength: {hero.Agility}")
                    .AppendLine($"###Agility: {hero.Agility}")
                    .AppendLine($"###Intelligence: {hero.Agility}")
                    .AppendLine($"###Items: {itemLine}");

                counter++;
            }

            return result.ToString().Trim();
        }
    }
}