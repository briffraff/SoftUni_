namespace P01_RawData
{
    public class Cargo
    {
        private int weight;
        private string type;

        public Cargo(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }



    }
}
