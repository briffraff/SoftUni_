using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomList
{
    public class Box<T>
        where T : IComparable
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

        public void Sort(List<T> list)
        {
            this.Items.OrderBy(x=>x);
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

        public void Swap(int index1, int index2)
        {
            T tempVar = this.Items[index1];
            this.items[index1] = items[index2];
            this.items[index2] = tempVar;
        }

        public void Contains(T element)
        {
            if (this.Items.Contains(element))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }

        public void Remove(int index)
        {
            this.Items.RemoveAt(index);
        }

        public void Add(T element)
        {
            this.Items.Add(element);
        }

        public void MaxValue()
        {
            Console.WriteLine(this.Items.Max());
        }

        public void MinValue()
        {
            Console.WriteLine(this.Items.Min());
        }
    }
}
