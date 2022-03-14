using System.Linq;

namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;

        private T[] items;

        public ReversedList()
            : this(DEFAULT_CAPACITY) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.items[this.Count - 1 - index];
            }
            set
            {
                this.ValidateIndex(index);
                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            this.Shrink();
            this.items[this.Count] = item;
            this.Count++;
        }

        public bool Contains(T item)
        {
            foreach (var element in this.items.Take(this.Count))
            {
                if (element.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (item.Equals(this.items[this.Count - 1 - i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            this.Shrink();
            index = this.Count - 1 - index;

            for (int i = index; i < this.Count; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            int index = this.IndexOf(item);

            if (index == -1)
            {
                return false;
            }

            this.RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);
            index = this.Count - 1 - index;

            for (int i = index; i < this.Count + 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default(T);
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void Shrink()
        {
            if (this.items.Length == this.Count)
            {
                T[] newArr = new T[this.items.Length * 2];
                Array.Copy(this.items, newArr, this.Count);
                this.items = newArr;
            }
        }

        private void ValidateIndex(int index)
        {
            var lessThanZero = index < 0;
            var moreThanCount = index >= this.Count;

            if (lessThanZero || moreThanCount)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }
        }
    }
}