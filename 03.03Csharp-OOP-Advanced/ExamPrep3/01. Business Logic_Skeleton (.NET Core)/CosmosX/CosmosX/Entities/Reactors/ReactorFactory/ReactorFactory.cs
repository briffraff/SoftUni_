using CosmosX.Entities.Containers.Contracts;
using CosmosX.Entities.Reactors.Contracts;
using CosmosX.Entities.Reactors.ReactorFactory.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CosmosX.Entities.Reactors.ReactorFactory
{
    public class ReactorFactory : IReactorFactory
    {
        private const string reactorText = "Reactor";

        public IReactor CreateReactor(string reactorTypeName, int id, IContainer moduleContainer, int additionalParameter)
        {
            Type reactorType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == (reactorTypeName + reactorText));

            IReactor instance = (IReactor) Activator.CreateInstance(reactorType,id,moduleContainer,additionalParameter);

            return instance;
        }
    }
}
