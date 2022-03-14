using System;
using System.Collections.Generic;

namespace _01.BSTOperations
{
    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T> where T : IComparable<T>
    {
        public class Node
        {
            public T Value { get; internal set; }
            public Node LeftChild { get; set; }
            public Node RightChild { get; set; }
            public int Count { get; set; }

            public Node(T value)
            {
                this.Value = value;
            }
        }

        public Node Root { get; internal set; }

        private BinarySearchTree(Node node)
        {
            this.PreOrderCopy(node);
        }

        public BinarySearchTree() { }

        //Binary Search Tree Operations
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

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            var node = this.FindNode(element);

            if (node == null)
            {
                return new BinarySearchTree<T>(){};
            }

            return new BinarySearchTree<T>(node);
        }

        public void Delete(T element)
        {
            if (this.Root == null)
            {
                throw new InvalidOperationException();
            }

            this.Root = this.Delete(this.Root , element);
        }

        private Node Delete(Node node , T element)
        {
            // Base case
            if (node == null)
            {
                return node;
            }

            // Recursive calls for ancestors of
            // node to be deleted
            if (node.Value.CompareTo(element) > 0)
            {
                node.LeftChild = Delete(node.LeftChild, element);
                return node;
            }
            else if (node.Value.CompareTo(element) < 0)
            {
                node.RightChild = Delete(node.RightChild, element);
                return node;
            }

            // We reach here when Root is the node
            // to be deleted.

            // If one of the children is empty
            if (node.LeftChild == null)
            {
                Node temp = node.RightChild;
                return temp;
            }
            else if (node.RightChild == null)
            {
                Node temp = node.LeftChild;
                return temp;
            }
            // If both children exist
            else
            {
                Node succParent = node;

                // Find successor
                Node succ = node.RightChild;

                while (succ.LeftChild != null)
                {
                    succParent = succ;
                    succ = succ.LeftChild;
                }

                // Delete successor. Since successor
                // is always left child of its parent
                // we can safely make successor's right
                // right child as left of its parent.
                // If there is no succ, then assign
                // succ->right to succParent->right
                if (succParent != node)
                    succParent.LeftChild = succ.RightChild;
                else
                    succParent.RightChild = succ.RightChild;

                // Copy Successor Data to Root
                node.Value = succ.Value;

                return node;
            }
        }

        public void DeleteMin()
        {
            if (this.Root == null)
            {
                throw new InvalidOperationException();
            }

            this.Root = this.DeleteMin(this.Root);
        }

        private Node DeleteMin(Node node)
        {
            if (node.LeftChild == null)
            {
                return node.RightChild;
            }
            node.LeftChild = this.DeleteMin(node.LeftChild);
            node.Count = 1 + this.Count(node.LeftChild) + this.Count(node.RightChild);
            return node;
        }

        public void DeleteMax()
        {
            if (this.Root == null)
            {
                throw new InvalidOperationException();
            }

            this.Root = this.DeleteMax(this.Root);
        }

        private Node DeleteMax(Node node)
        {
            if (node.RightChild == null)
            {
                return node.LeftChild;
            }

            node.RightChild = this.DeleteMax(node.RightChild);
            node.Count = 1 + this.Count(node.LeftChild) + this.Count(node.RightChild);
            return node;
        }

        public int Count()
        {
            return this.Count(this.Root);
        }

        private int Count(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Count;
        }

        public int GetRank(T element)
        {
            return this.GetRank(element, this.Root);
        }

        private int GetRank(T element, Node node)
        {
            if (node == null)
            {
                return 0;
            }

            if (element.CompareTo(node.Value) < 0)
            {
                return this.GetRank(element, node.LeftChild);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                return 1 + this.Count(node.LeftChild) + this.GetRank(element, node.RightChild);
            }

            return this.Count(node.LeftChild);
        }

        public T Select(int rank)
        {
            Node node = this.Select(this.Root, rank);

            if (node == null)
            {
                throw new InvalidOperationException();
            }

            return node.Value;
        }

        private Node Select(Node node, int rank)
        {
            if (node == null)
            {
                return null;
            }

            int leftCount = this.Count(node.LeftChild);

            if (leftCount == rank)
            {
                return node;
            }

            if (leftCount > rank)
            {
                return this.Select(node.LeftChild, rank);
            }
            else
            {
                return this.Select(node.RightChild, rank - (leftCount + 1));
            }
        }

        public T Ceiling(T element)
        {
            return this.Select(this.GetRank(element) + 1);
        }

        public T Floor(T element)
        {
            return this.Select(this.GetRank(element) - 1);
        }

        public IEnumerable<T> Range(T startRange, T endRange)
        {
            var collection = new List<T>();

            this.Range(this.Root, startRange, endRange, collection);

            return collection;
        }

        private void Range(Node node, T startRange, T endRange, List<T> queue)
        {
            if (node == null)
            {
                return;
            }

            bool nodeInLowerRange = startRange.CompareTo(node.Value) < 0;
            bool nodeInUpperRange = endRange.CompareTo(node.Value) > 0;

            if (nodeInLowerRange)
            {
                this.Range(node.LeftChild, startRange, endRange, queue);
            }

            if (startRange.CompareTo(node.Value) <= 0 && endRange.CompareTo(node.Value) >= 0)
            {
                queue.Add(node.Value);
            }

            if (nodeInUpperRange)
            {
                this.Range(node.RightChild, startRange, endRange, queue);
            }
        }


        //Basic Tree Operations
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

            node.Count = 1 + this.Count(node.LeftChild) + this.Count(node.RightChild);
            return node;
        }

        public bool Contains(T element)
        {
            var node = this.FindNode(element);
            var check = node != null;
            return check;
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

    }
}

