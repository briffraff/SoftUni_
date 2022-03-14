using System.ComponentModel;

namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }

            public Node(T element)
            {
                this.Element = element;
            }

            public Node(T element, Node next) : this(element)
            {
                this.Next = next;
            }
        }

        private Node head;

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
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
                }

                node.Next = new Node(item);
            }
            this.Count++;
        }

        public T Dequeue()
        {
            IsEmpty();

            var oldQueue = this.head;
            var newQueue = this.head.Next;

            this.head = null;
            this.head = newQueue;

            this.Count--;
            return oldQueue.Element;
        }

        public T Peek()
        {
            IsEmpty();

            return this.head.Element;
        }

        public bool Contains(T item)
        {
            var check = false;
            var curNode = this.head;

            while (true)
            {
                if (curNode == null)
                {
                    break;
                }

                if (curNode.Element.Equals(item))
                {
                    check = true;
                }

                curNode = curNode.Next;
            }

            return check;
        }

        public void Clear()
        {
            while (this.Count != 0)
            {
                this.Dequeue();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var curNode = this.head;

            while (curNode != null)
            {
                yield return curNode.Element;
                curNode = curNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void IsEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The Queue is empty!");
            }
        }
    }
}