namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
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

        private Node top;

        public int Count { get; private set; }

        public void Push(T item)
        {
            var old = this.top;

            var newNode = new Node(item)
            {
                Element = item,
                Next = old
            };

            this.top = newNode;
            this.Count++;
        }

        public T Pop()
        {
            this.IsEmpty();

            var oldTop = this.top.Element;
            var newTop = this.top.Next;

            this.top = null;
            this.top = newTop;

            this.Count--;
            return oldTop;
        }

        public T Peek()
        {
            this.IsEmpty();
            return this.top.Element;
        }

        public void Clear()
        {
            while (this.Count != 0)
            {
                this.Pop();
            }
        }

        public bool Contains(T item)
        {
            var check = false;
            var curNode = this.top;

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

        public IEnumerator<T> GetEnumerator()
        {
            var curNode = this.top;

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
                throw new InvalidOperationException("The Stack is empty!");
            }
        }
    }
}