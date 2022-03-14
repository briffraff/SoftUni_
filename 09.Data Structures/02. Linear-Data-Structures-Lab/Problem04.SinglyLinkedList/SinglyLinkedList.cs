using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        public class Node
        {
            internal T Data { get; set; }
            internal Node Next { get; set; }

            public Node(T data)
            {
                Data = data;
            }

            public Node(T data, Node next) : this(data)
            {
                Data = data;
                Next = null;
            }
        }

        private Node Head;

        public int Count { get; set; }

        public void AddFirst(T item)
        {
            var newNode = new Node(item)
            {
                Data = item,
                Next = this.Head
            };

            this.Head = newNode;

            this.Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node(item);
            if (this.Head == null)
            {
                this.Head = newNode;
            }
            else
            {
                var node = this.Head;
                while (node.Next != null)
                {
                    node = node.Next;
                }

                node.Next = newNode;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            IsEmpty();

            return this.Head.Data;
        }

        public T GetLast()
        {
            IsEmpty();

            var current = this.Head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            return current.Data;
        }

        public T RemoveFirst()
        {
            IsEmpty();

            var oldHead = this.Head;
            this.Head = oldHead.Next;

            this.Count--;
            return oldHead.Data;
        }

        public T RemoveLast()
        {
            IsEmpty();

            var current = this.Head;
            var last = default(T);

            while (true)
            {
                if (current.Next == null)
                {
                    last = current.Data;
                    current = null;
                    break;
                }

                if(current.Next.Next != null)
                {
                    current = current.Next;
                }
                else
                {
                    last = current.Next.Data;
                    current.Next = null;
                    break;
                }
            }

            this.Count--;
            return last;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.Head;

            while (true)
            {
                if (currentNode == null)
                {
                    break;
                }

                yield return currentNode.Data;
                currentNode = currentNode.Next;
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
                throw new InvalidOperationException("The Linked List is empty!");
            }
        }
    }
}