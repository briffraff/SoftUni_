using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodStrings
{
    public class Box<T>
        where T : IComparable<T>
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

        public int GetGreaterThan(T inputItem)
        {
            int count = 0;

            foreach (var item in this.Items)
            {
                if (item.CompareTo(inputItem) > 0)
                {
                    count++;
                }

            }

            return count;
        }

        public void Swap(int index1, int index2)
        {
            T tempVar = this.Items[index1];
            this.items[index1] = items[index2];
            this.items[index2] = tempVar;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in this.Items)
            {
                sb.AppendLine($"{item.GetType().FullName}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
