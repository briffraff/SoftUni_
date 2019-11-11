using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxofString
{
    public class Box<T>
    {
        private T item;

        public Box(T item)
        {
            this.Item = item;
        }

        public T Item
        {
            get { return item; }
            set { item = value; }
        }

        public override string ToString()
        {
            return $"{this.Item.GetType().FullName}: {this.Item}";
        }
    }
}
