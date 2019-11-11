using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = parameters[0];

                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);

                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];

                List<Tyre> tires = new List<Tyre>();

                for (int j = 0; j < 8; j += 2)
                {
                    double curTyrePressure = double.Parse(parameters[5 + j]);
                    int curTyreAge = int.Parse(parameters[6 + j]);
                    Tyre tyre = new Tyre(curTyreAge, curTyrePressure);
                    tires.Add(tyre);
                }

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);
                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            List<string> result = new List<string>();

            if (command == "fragile")
            {
                result = cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

            }
            else
            {
                result = cars
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();
            }

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
