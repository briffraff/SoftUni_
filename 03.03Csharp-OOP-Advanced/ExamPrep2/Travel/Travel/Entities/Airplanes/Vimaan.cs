using Travel.Entities.Airplanes.Contracts;

namespace Travel.Entities.Airplanes
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.Immutable;
	using System.Linq;
	using Entities.Contracts;

	public abstract class Vimaan : IAirplane
	{

	    public int BaggageCompartments { get; }
	    public int Seats { get; }
	    public bool IsOverbooked { get; }

	    public IReadOnlyCollection<IPassenger> Passengers { get; }
	    public IReadOnlyCollection<IBag> BaggageCompartment { get; }

	    public IPassenger RemovePassenger(int seat)
	    {
	        throw new NotImplementedException();
	    }

	    public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
	    {
	        throw new NotImplementedException();
	    }

        public void AddPassenger(IPassenger passenger)
	    {
	        throw new NotImplementedException();
	    }

	    public void LoadBag(IBag bag)
	    {
	        throw new NotImplementedException();
	    }




        //public ArrayList bagazhi;
        //public ArrayList pustinqci;

        //public Vimaan(int mesta, int chanti) {
        //	this.pustinqci = new ArrayList();
        //	this.Mesta = mesta;
        //	this.Bagazhnik = chanti;
        //	this.bagazhi = new ArrayList();
        //}
        //public int Mesta { get; }
        //public int Bagazhnik { get; }
        //public ImmutableArray Bagazh => this.bagazhi;
        //public ImmutableArray Pustinqci => this.pustinqci;
        //public bool IsOverbooked => this.Pustinqci.getLength() > this.Mesta;
        //      public void AddPustinqk(IPassenger pustinqk {
        //	this.pustinqci.Add(pustinqk);
        //}
        //public IPassenger RemovePustinqk(int mestoIndeks) {

        //	this.pustinqci.RemoveAt(mestoIndeks);

        //	var pustinqk = this.pustinqci[mestoIndeks];

        //	return pustinqk;
        //}

        //public IEnumerable<IBag>Out(IPassenger passenger) {
        //	var passengerBags = this.bagazhi
        //		.Where(b => b.Owner == passenger)
        //		.ToArray();

        //	foreach (var bag in passengerBags)
        //		this.bagazhi.Remove(bag);

        //	return passengerBags;
        //}

        //public void LoadBag(IBag bag) {
        //	var isBaggageCompartmentFull = this.BaggageCompartment.Count > this.BaggageCompartments;
        //	if (isBaggageCompartmentFull)
        //		throw new InvalidOperationException($"No more bag room in {this.GetType().ToString()}!");

        //	this.bagazhi.Add(bag);
        //}

    }
}