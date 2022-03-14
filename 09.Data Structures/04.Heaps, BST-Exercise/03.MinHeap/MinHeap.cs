namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class MinHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        private List<T> elements;

        public MinHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public T Dequeue()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T result = this.elements[0];
            this.Swap(0, this.Size - 1);
            this.elements.RemoveAt(this.Size - 1);
            this.HeapDown(0);
            return result;
        }

        public void Add(T element)
        {
            this.elements.Add(element);
            this.HeapUp(this.Size - 1);
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
            var check = this.elements[parentIndex].CompareTo(this.elements[index]) < 0;
            return check;
        }

        private void Swap(int index, int parentIndex)
        {
            (this.elements[index], this.elements[parentIndex]) = (this.elements[parentIndex], this.elements[index]);
        }

        public T ExtractMin()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T element = this.elements[0];
            var lastIndex = this.elements.Count - 1;

            this.Swap(lastIndex, 0);
            this.elements.RemoveAt(lastIndex);
            this.HeapDown(this.Size - 1);

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
    }
}
