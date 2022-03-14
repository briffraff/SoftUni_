namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {

        private T[] elements;
        private int startIndex;
        private int endIndex;

        public class Node
        {
            public T Item { get; set; }
            public Node Next { get; set; }

            public Node(T item)
            {
                this.Item = Item;
            }

            public Node(T item, Node next) : this(item)
            {
                this.Next = next;
            }
        }

        private Node head;
        private Node tail;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            bool check = false;
            var curNode = this.head;

            while (true)
            {
                if (curNode == null)
                {
                    break;
                }

                if (curNode.Item.Equals(item))
                {
                    check = true;
                }

                curNode = curNode.Next;
            }

            return check;
        }

        public T Dequeue()
        {
            IsEmpty();

            var oldQueue = this.head;
            var newQueue = this.head.Next;

            this.head = null;
            this.head = newQueue;

            this.endIndex--;
            this.Count--;
            return oldQueue.Item;
        }

        void Check()
        {
            if (elements.Length == endIndex)
            {
                System.Array.Resize(ref elements, elements.Length + 128);
                this.startIndex = 0;
                this.endIndex = this.Count;
            }
        }

        public void Enqueue(T item)
        {
            if (this.Count >= this.elements.Length)
            {
                Check();
            }

            if (this.head == null)
            {
                this.head = new Node(item);
                this.Count++;
                return;
            }
            else
            {
                var node = this.head;
                while (node.Next != null)
                {
                    node = node.Next;

                    this.elements[this.endIndex] = item;
                    this.endIndex++;
                    this.Count++;
                }

                node.Next = new Node(item);
            }
        }

        public T Peek()
        {
            IsEmpty();

            return this.elements[startIndex];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int currentIndex = 0; currentIndex < this.Count; currentIndex++)
            {
                var index = (this.startIndex + currentIndex);
                yield return this.elements[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void IsEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The Queue is empty");
            }
        }


    }
}