namespace Problem00.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private T[] elements;
        private int startIndex;
        private int endIndex;
        public static int DEFAULT_CAPACITY = 4;

        public CircularQueue() : this(DEFAULT_CAPACITY)
        {
        }

        public CircularQueue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            this.elements = new T[capacity];
        }

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Grow();
            }

            this.elements[this.endIndex] = item;
            this.endIndex = (this.endIndex + 1) % this.elements.Length;
            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new Exception("Queue is empty!");
            }
            else
            {
                this.startIndex = (this.startIndex + 1) % this.elements.Length;
                this.Count--;

                var element = new T[this.Count];

                return element[this.startIndex];
            }
        }
        
        private void Grow()
        {
            this.elements = this.CopyElements(new T[this.elements.Length * 2]);
            this.startIndex = 0;
            this.endIndex = this.Count;
        }

        private T[] CopyElements(T[] resultArr)
        {
            for (int i = 0; i < this.Count; i++)
            {
                resultArr[i] = this.elements[(this.startIndex + i) % this.elements.Length];
            }

            return resultArr;
        }

        public T Peek()
        {
            return this.elements[this.startIndex];
        }

        public T[] ToArray()
        {
            return this.CopyElements(new T[this.Count]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int currentIndex = 0; currentIndex < this.Count; currentIndex++)
            {
                var index = (this.startIndex + currentIndex) % this.elements.Length;
                yield return this.elements[index];
            }
        }
        
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    }
}
