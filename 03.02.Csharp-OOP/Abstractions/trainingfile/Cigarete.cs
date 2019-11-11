using System;
using System.Collections.Generic;
using System.Text;

namespace trainingfile
{
    public class Cigarete
    {
        private int tobacoWeight;

        public Cigarete(int tobacoWeight)
        {
            this.TobacoWeight = tobacoWeight;
        }

        public int TobacoWeight
        {
            get { return tobacoWeight; }
            set { tobacoWeight = value; }
        }
    }
}
