------------------	CALCULATED PROPERTY-----------------

public decimal TotalPrice
				 => this.ArsenalParts.Sum(p => p.Price) +
					this.ShellParts.Sum(p => p.Price) +
					this.EnduranceParts.Sum(p => p.Price);

-------------------IReadOnlyCollection------------------

//FIELD
private List<Ibag> baggageCompartment

//CTOR
this.baggageCompartment = new List<Ibag>();

//PROP
public int BaggageCompartments { get; }

//collection
IReadOnlyCollection<IBag> BaggageCompartment => this.baggageCompartment.toList().asReadOnly()}



-------------------CREATING PARTFACTORY-----------------

		[-----------WITH REFLECTION--------------]
IN CLASS "VehicleFactory.ms"
--------
        private const string PartNameSuffix = "Part";

        public IPart CreatePart(string partType, string model, double weight, decimal price, int additionalParameter)
        {
            Type type = Assembly.GetCallingAssembly()
                                .GetTypes()
                                .FirstOrDefault(t => t.Name == partType + PartNameSuffix);

            var constructorInfo = type.GetConstructors();

            IPart part = (IPart)Activator.CreateInstance(type, model, weight, price, additionalParameter);

            return part;
        }

IN USE(INITIALIZE):
------
		//FLD
        private readonly IPartFactory partFactory;
		
		//CTOR
		public TankManager()
        {
            this.partFactory = new PartFactory(); //<--THE NAME OF THE FACTORY CLASS
        }
		
		// string vehicleModel = arguments[0];
		// string partType = arguments[1];
		// string model = arguments[2];
		// double weight = double.Parse(arguments[3]);
		// decimal price = decimal.Parse(arguments[4]);
		// int additionalParameter = int.Parse(arguments[5]);
			
		//CREATE
		IPart part = this.partFactory.CreatePart(partType,model,weight,price,additionalParameter);
		
		//CHECK
		if (part != null)
		{
			this.parts.Add(part.Model, part);
			// string methodName = "Add" + partType + "Part";
			// this.vehicles[vehicleModel].GetType().GetMethod(methodName).Invoke(this.vehicles[vehicleModel], new object[] { part });
		}
		
		[-----------WITH SWITCH----------------]
IPart part = null;

switch (partType)
{
   case "Arsenal":
	   part = new ArsenalPart(model, weight, price, additionalParameter);
	   this.vehicles[vehicleModel].AddArsenalPart(part);
	   break;
   case "Shell":
	   part = new ShellPart(model, weight, price, additionalParameter);
	   this.vehicles[vehicleModel].AddShellPart(part);
	   break;
   case "Endurance":
	   part = new EndurancePart(model, weight, price, additionalParameter);
	   this.vehicles[vehicleModel].AddEndurancePart(part);
	   break;
}

		[------------CLASS FACTORY WITH SWITCH-----------------]
        public IPart CreatePart(string partType, string model, double weight, decimal price, int additionalParameter)
        {
			Type typeOne = partType.GetType();
			
			   case "Arsenal":
				   return new ArsenalPart(model, weight, price, additionalParameter);
		
				   break;
			   case "Shell":
				   return ShellPart(model, weight, price, additionalParameter);
			
				   break;
			   case "Endurance":
				   return EndurancePart(model, weight, price, additionalParameter);
			
				   break;
		}
		