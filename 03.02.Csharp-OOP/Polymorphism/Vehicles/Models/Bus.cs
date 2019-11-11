using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double fuelConsumptionInSummer = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override void Drive(double distance)
        {
            double currentFuelConsumption = this.FuelConsumption;

            if (!isVehicleEmpty)
            {
                currentFuelConsumption += fuelConsumptionInSummer;
            }

            double fuelNeeded = distance * currentFuelConsumption;

            if (this.FuelQuantity < fuelNeeded)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= fuelNeeded;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }
    }
}
