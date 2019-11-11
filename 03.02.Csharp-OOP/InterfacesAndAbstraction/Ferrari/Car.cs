using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public class Car
    {
        private string driverName;

        public Car(string driverName)
        {
            this.DriverName = driverName;
        }


        public string Model => "488-Spider";

        public string GasPower => "Zadu6avam sA!";

        public string Breaks => "Brakes!";

        public string DriverName
        {
           get => driverName;
            set => driverName = value;
        }

        public override string ToString()
        {
            string result = $"{this.Model}/{this.Breaks}/{this.GasPower}/{this.DriverName}";

            return result;
        }
    }
}
