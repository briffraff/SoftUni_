using System.Collections.Generic;

namespace P01_RawData
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private List<Tyre> tires;


        public Car(string model, Engine engine, Cargo cargo, List<Tyre> tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }

        public string Model
        {
            get => model;
            set => model = value;
        }

        internal Engine Engine
        {
            get => engine;
            set => engine = value;
        }

        public Cargo Cargo
        {
            get => cargo;
            set => cargo = value;
        }

        public List<Tyre> Tires
        {
            get => tires;
            set => tires = value;
        }
    }
}
