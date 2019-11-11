using System;
using System.Collections;
using System.Collections.Generic;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {

        private int[] stones;

        public Lake(int[] Stones)
        {
            this.stones = Stones;
        }

        public int[] Stones
        {
            get { return stones; }
            set { stones = value; }
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.Stones.Length; i += 2)
            {
                yield return this.Stones[i];
            }

            int lastOddIndex = 0;

            if((this.Stones.Length - 1) % 2 == 0)
            {
                lastOddIndex = this.Stones.Length - 2;
            }
            else
            {
                lastOddIndex = this.Stones.Length - 1;
            }

            for (int i = lastOddIndex; i > 0; i -= 2)
            {
                yield return this.Stones[i];
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
