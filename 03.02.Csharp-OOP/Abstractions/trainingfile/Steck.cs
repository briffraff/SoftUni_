using System;
using System.Collections.Generic;
using System.Text;

namespace trainingfile
{
    public class Steck
    {
        private string name;
        private List<Kutiq> kutii;

        public Steck(string name)
        {
            this.Name = name;
            this.Kutii = new List<Kutiq>();
        }

        public List<Kutiq> Kutii
        {
            get { return kutii; }
            set { kutii = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
