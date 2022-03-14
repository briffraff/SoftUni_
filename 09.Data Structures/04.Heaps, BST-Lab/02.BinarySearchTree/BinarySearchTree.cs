using System.Runtime.CompilerServices;

namespace _04.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T> where T : IComparable<T>
    {
        private class Node
        {
            public T Value { get; private set; }
            public Node LeftChild { get; set; }
            public Node RightChild { get; set; }

            public Node(T value)
            {
                this.Value = value;
            }
        }

        private Node Root;

        public BinarySearchTree() { }

        private BinarySearchTree(Node node)
        {
            this.PreOrderCopy(node);
        }

        private void PreOrderCopy(Node node)
        {
            if (node == null)
            {
                return;
            }

            this.Insert(node.Value);
            this.PreOrderCopy(node.LeftChild);
            this.PreOrderCopy(node.RightChild);
        }

        public bool Contains(T element)
        {
            var node = this.FindNode(element);
            var check = node != null;
            return check;
        }

        private Node FindNode(T element)
        {
            var node = this.Root;

            while (node != null)
            {
                if (element.CompareTo(node.Value) < 0)
                {
                    node = node.LeftChild;
                }
                else if (element.CompareTo(node.Value) > 0)
                {
                    node = node.RightChild;
                }
                else
                {
                    break;
                }
            }

            return node;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(action, this.Root);
        }

        private void EachInOrder(Action<T> action, Node node)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(action, node.LeftChild);
            action.Invoke(node.Value);
            this.EachInOrder(action, node.RightChild);
        }

        public void Insert(T element)
        {
            this.Root = this.Insert(element, this.Root);
        }

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.LeftChild = this.Insert(element, node.LeftChild);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.RightChild = this.Insert(element, node.RightChild);
            }

            return node;
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            var node = this.FindNode(element);

            if (node == null)
            {
                return null;
            }

            return new BinarySearchTree<T>(node);
        }
    }
}
