using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Vehicles.Interfaces
{
    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }

        double TankCapacity { get; }

        bool isVehicleEmpty { get; set; }

        void Drive(double distance);

        void Refuel(double fuel);
    }
}
