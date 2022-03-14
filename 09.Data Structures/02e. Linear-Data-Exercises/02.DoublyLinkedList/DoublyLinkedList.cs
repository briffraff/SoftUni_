namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        public class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }

            public Node(T value)
            {
                Value = value;
            }

            public Node(T value, Node next, Node previous)
            {
                Value = value;
                Next = next;
                Previous = previous;
            }
        }

        internal Node Head { get; private set; }
        internal Node Tail { get; private set; }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node(item);

            if (this.Count == 0)
            {
                this.Head = newNode;
                this.Tail = newNode;
            }
            else
            {
                this.Head.Previous = newNode;
                newNode.Next = this.Head;
                this.Head = newNode;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node(item);

            if (this.Count == 0)
            {
                this.Head = newNode;
                this.Tail = newNode;
            }
            else
            {
                // set tail next property to be the new element
                this.Tail.Next = newNode;

                // set new element previous property to be the current tail
                newNode.Previous = this.Tail;

                // set new element as the current/newest tail
                this.Tail = newNode;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.Head.Value;
        }

        public T GetLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.Tail.Value;
        }

        public T RemoveFirst()
        {
            IsEmpty();

            var removedElement = this.Head.Value;

            if (this.Head.Next == null || this.Count == 0)
            {
                this.Head = null;
                this.Tail = null;
            }
            else
            {
                var newHead = this.Head.Next;
                this.Head = newHead;
                this.Head.Previous = null;
            }

            this.Count--;
            return removedElement;
        }

        public T RemoveLast()
        {
            IsEmpty();

            var removedElement = this.Tail.Value;

            if (this.Tail.Previous == null || this.Count == 0)
            {
                this.Head = null;
                this.Tail = null;
            }
            else
            {
                var newTail = this.Tail.Previous;
                this.Tail = newTail;
                this.Tail.Next = null;
            }

            this.Count--;
            return removedElement;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.Head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void IsEmpty()
        {
            var message = "The list is empty";

            if (this.Count == 0)
            {
                throw new InvalidOperationException(message);
            }
        }
    }
}