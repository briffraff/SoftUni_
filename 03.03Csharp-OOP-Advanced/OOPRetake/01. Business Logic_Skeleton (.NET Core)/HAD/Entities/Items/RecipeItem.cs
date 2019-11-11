using System;
using System.Collections.Generic;
using System.Text;

namespace HAD.Entities.Items
{
    public class RecipeItem : BaseItem
    {

        public RecipeItem(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus,List<CommonItem> requiredItems)
            : base(name,
                strengthBonus,
                agilityBonus,
                intelligenceBonus, 
                hitPointsBonus, 
                damageBonus)
        {
            this.RequiredItems = requiredItems;
        }

        public ICollection<CommonItem> RequiredItems { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"###Item: {this.Name}");
            sb.AppendLine(base.ToString());

            return sb.ToString();
        }
    }

}
