using System.Collections.Generic;
using Travel.Entities.Contracts;

namespace Travel.Entities.Airplanes.Contracts
{
	public interface IAirplane
	{
		int BaggageCompartments { get; }
		int Seats { get; }
		bool IsOverbooked { get; }
    
		IPassenger RemovePassenger(int seat);
		IEnumerable<IBag> EjectPassengerBags(IPassenger passenger);

		IReadOnlyCollection<IPassenger> Passengers { get; }
		IReadOnlyCollection<IBag> BaggageCompartment { get; }

		void AddPassenger(IPassenger passenger);
		void LoadBag(IBag bag);
	}
}