namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private Dictionary<T, int> indexes;
        private List<T> elements;

        public PriorityQueue()
        {
            this.elements = new List<T>();
            this.indexes = new Dictionary<T, int>();
        }

        public int Count => this.elements.Count;

        public T Dequeue()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T result = this.elements[0];
            this.Swap(0, this.Count - 1);
            this.elements.RemoveAt(this.Count - 1);
            this.indexes.Remove(result);
            this.HeapDown(0);
            return result;
        }

        public void Enqueue(T element)
        {
            this.elements.Add(element);
            this.indexes.Add(element, this.Count - 1);
            this.HeapUp(this.Count - 1);
        }

        private void HeapUp(int index)
        {
            var formula = (index - 1) / 2;

            var parentIndex = formula;

            while (index > 0 && this.IsGreater(parentIndex, index))
            {
                this.Swap(parentIndex, index);
                (index, parentIndex) = (parentIndex, formula);
            }
        }

        private bool IsGreater(int index, int parentIndex)
        {
            var check = this.elements[index].CompareTo(this.elements[parentIndex]) > 0;
            return check;
        }

        private void Swap(int index, int parentIndex)
        {
            (this.elements[index], this.elements[parentIndex]) = (this.elements[parentIndex], this.elements[index]);

            this.indexes[this.elements[index]] = index;
            this.indexes[this.elements[parentIndex]] = parentIndex;
        }

        public T ExtractMin()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T element = this.elements[0];
            var lastIndex = this.elements.Count - 1;

            this.Swap(0, lastIndex);
            this.elements.RemoveAt(lastIndex);
            this.HeapDown(0);

            return element;
        }

        private void HeapDown(int index)
        {
            var biggerChildIndex = this.GetBigger(index);

            while (this.IsValidIndex(biggerChildIndex) && this.IsGreater(index, biggerChildIndex))
            {
                this.Swap(index, biggerChildIndex);
                (index, biggerChildIndex) = (biggerChildIndex, this.GetBigger(index));
            }
        }

        private bool IsValidIndex(int index)
        {
            var check = index >= 0 && index < this.elements.Count;
            return check;
        }

        private int GetBigger(int index)
        {
            var firstChildIndex = index * 2 + 1;
            var secondChildIndex = index * 2 + 2;

            if (secondChildIndex < this.elements.Count)
            {
                if (this.IsGreater(firstChildIndex, secondChildIndex))
                {
                    return firstChildIndex;
                }

                return secondChildIndex;
            }
            else if (firstChildIndex < this.elements.Count)
            {
                return firstChildIndex;
            }
            else
            {
                return -1;
            }
        }

        public T Peek()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.elements[0];
        }

        public void DecreaseKey(T key)
        {
            HeapUp(this.indexes[key]);
        }
    }
}
