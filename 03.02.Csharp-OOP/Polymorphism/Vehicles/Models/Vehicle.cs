using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        //fields
        private double tankCapacity;
        private double fuelQuantity;
        private double fuelConsumption;

        //ctor
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        //Prop
        public bool isVehicleEmpty { get; set; }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set
            {
                if (value > this.TankCapacity)
                {
                    value = 0;
                }

                fuelQuantity = value;
            }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public double TankCapacity
        {
            get { return tankCapacity; }
            set { tankCapacity = value; }
        }



        //Methods
        public virtual void Drive(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption;

            if (this.FuelQuantity < fuelNeeded)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= fuelNeeded;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }

        public void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.FuelQuantity + fuel > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }

            if (this is Truck)
            {
                fuel *= 0.95;
            }

            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.fuelQuantity:F2}";
        }
    }
}
