using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using WildFarm.Foods.Interfaces;


namespace WildFarm.Foods.Factory
{
    using WildFarm.Foods;

    public class FoodFactory : IFoodFactory
    {

        public IFood CreateFood(string foodType, int quantity)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == foodType.ToLower());

            IFood instance = (IFood)Activator.CreateInstance(type);

            return instance;
        }

        //public IFood CreateFood(string type, int quantity)
        //{
        //    IFood outFood = null;
        //    type = type.ToLower();

        //    switch (type)
        //    {
        //        case "fruit":
        //            outFood = new Fruit(quantity);
        //            break;
        //        case "meat":
        //            outFood = new Meat(quantity);
        //            break;
        //        case "seeds":
        //            outFood = new Seeds(quantity);
        //            break;
        //        case "vegetable":
        //            outFood = new Vegetable(quantity);
        //            break;
        //        default:
        //            throw new ArgumentException("Invalid food type");
        //    }

        //    return outFood;
        //}

    }
}
