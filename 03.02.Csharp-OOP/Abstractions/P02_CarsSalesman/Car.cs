using System;
using System.Collections.Generic;
using System.Text;

namespace P02_CarsSalesman
{
    public class Car
    {
        private const string offset = "  ";

        private string model;
        private string engine;
        private int weight;
        private string color;

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = -1;
            this.Color = "n/a";
        }


        public Car(string model, Engine engine, int weight) : this(string model,Engine engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color) : this(string model,Engine engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}:\n", this.model);
            sb.Append(this.engine.ToString());
            sb.AppendFormat("{0}Weight: {1}\n", offset, this.weight == -1 ? "n/a" : this.weight.ToString());
            sb.AppendFormat("{0}Color: {1}", offset, this.color);

            return sb.ToString();
        }


        public string Engine 
        {
            get { return engine; }
            set { engine = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
    }
}
