using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodDoubles
{
    public class Box<T> where T : IComparable
    {
        private List<T> items;

        public Box(List<T> items)
        {
            this.Items = items;
        }

        public List<T> Items
        {
            get { return items; }
            set { items = value; }
        }

        public int GetGreaterThan(T targetItem)
        {
            int count = 0;

            foreach (var item in this.Items)
            {
                if (item.CompareTo(targetItem) > 0)
                {
                    count++;
                }
            }
 
            return count;
        }
    }
}
