using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari.Core
{
    public class Engine
    {
        public void Run()
        {
            string driverName = Console.ReadLine();
            Car car = new Car(driverName);
            Console.WriteLine(car.ToString());

        }
    }
}
