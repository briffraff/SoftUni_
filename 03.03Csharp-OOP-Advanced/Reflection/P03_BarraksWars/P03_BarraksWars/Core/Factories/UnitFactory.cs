using System.Linq;
using System.Reflection;
using _03BarracksFactory.Models.Units;

namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type type = assembly.GetTypes().First(t => t.Name == unitType);

            IUnit instance = (IUnit)Activator.CreateInstance(type,true);

            return instance;

        }
    }
}
