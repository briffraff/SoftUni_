using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Interfaces;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine
    {

        public void Run()
        {

            string[] carSplitArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double carFuelQuantity = double.Parse(carSplitArgs[1]);
            double carConsumption = double.Parse(carSplitArgs[2]);
            double carTankCapacity = double.Parse(carSplitArgs[3]);

            string[] truckSplitArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double truckFuelQuantity = double.Parse(truckSplitArgs[1]);
            double truckConsumption = double.Parse(truckSplitArgs[2]);
            double truckTankCapacity = double.Parse(truckSplitArgs[3]);

            string[] busSplitArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double busFuelQuantity = double.Parse(busSplitArgs[1]);
            double busConsumption = double.Parse(busSplitArgs[2]);
            double busTankCapacity = double.Parse(busSplitArgs[3]);


            IVehicle car = new Car(carFuelQuantity, carConsumption, carTankCapacity);
            IVehicle truck = new Truck(truckFuelQuantity, truckConsumption, truckTankCapacity);
            IVehicle bus = new Bus(busFuelQuantity,busConsumption,busTankCapacity);


            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] splitInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string command = splitInput[0];
                    string vehicleType = splitInput[1];

                    if (command == "Drive")
                    {
                        double distance = double.Parse(splitInput[2]);

                        if (vehicleType == "Car")
                        {
                            car.Drive(distance);
                        }

                        else if (vehicleType == "Truck")
                        {
                            truck.Drive(distance);
                        }
                        else if (vehicleType == "Bus")
                        {
                            bus.isVehicleEmpty = false;
                            bus.Drive(distance);
                        }

                    }
                    else if (command == "DriveEmpty")
                    {
                        double distance = double.Parse(splitInput[2]);

                        if (vehicleType == "Bus")
                        {
                            bus.isVehicleEmpty = true;
                            bus.Drive(distance);
                        }
                    }
                    else if (command == "Refuel")
                    {
                        double liters = double.Parse(splitInput[2]);

                        if (vehicleType == "Car")
                        {
                            car.Refuel(liters);
                        }

                        else if (vehicleType == "Truck")
                        {
                            truck.Refuel(liters);
                        }
                        else if (vehicleType == "Bus")
                        {
                            bus.Refuel(liters);
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}
