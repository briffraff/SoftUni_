using System;
using System.Collections.Generic;
using System.Text;

namespace trainingfile
{
    public class Kutiq
    {
        private List<Cigarete> cigaretes;

        public Kutiq(int counter)
        {
            this.cigaretes = new List<Cigarete>();
        }

        public List<Cigarete> Cigaretes
        {
            get { return cigaretes; }
            set { cigaretes = value; }
        }

    }
}
