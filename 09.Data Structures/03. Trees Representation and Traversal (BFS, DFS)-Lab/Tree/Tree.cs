using System.Collections;
using System.Linq;

namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        public List<Tree<T>> Children;
        public T Value;
        public Tree<T> Parent;

        public Tree(T value)
        {
            this.Value = value;
            this.Children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                this.Children.Add(child);
            }
        }

        public List<T> OrderBfs()
        {
            var queue = new Queue<Tree<T>>();
            var result = new List<T>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();
                result.Add(subtree.Value);

                foreach (var child in subtree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        private void Dfs(Tree<T> node, ICollection<T> result)
        {
            foreach (var child in node.Children)
            {
                this.Dfs(child, result);
            }

            result.Add(node.Value);
        }

        public List<T> OrderDfs()
        {
            var list = new List<T>();
            this.Dfs(this,list);
            return list;
        }

        private Stack<T> DfsWithStack()
        {
            var result = new Stack<T>();
            var stack = new Stack<Tree<T>>();
            stack.Push(this);

            while (stack.Count > 0)
            {
                var node = stack.Pop();

                foreach (var child in node.Children)
                {
                    stack.Push(child);
                }

                result.Push(node.Value);
            }

            return result;
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var parentNode = this.FindParentWithBfs(parentKey);

            if (parentNode is null)
            {
                throw new ArgumentNullException();
            }
            parentNode.Children.Add(child);
            child.Parent = parentNode;
        }

        private Tree<T> FindParentWithBfs(T parentKey)
        {
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();

                if (subtree.Value.Equals(parentKey))
                {
                    return subtree;
                }

                foreach (var child in subtree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        public void RemoveNode(T nodeKey)
        {
            var deleteNode = FindParentWithBfs(nodeKey);

            if (deleteNode is null)
            {
                throw new ArgumentNullException();
            }

            var parentNode = deleteNode.Parent;

            if (parentNode is null)
            {
                throw new ArgumentException();
            }

            //parentNode.Children.Remove(deleteNode);
            parentNode.Children = parentNode.Children.Where(node => !node.Value.Equals(nodeKey)).ToList();
            deleteNode.Parent = null;
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = this.FindParentWithBfs(firstKey);
            var secondNode = this.FindParentWithBfs(secondKey);

            if (firstNode is null || secondNode is null)
            {
                throw new ArgumentNullException();
            }

            var firstParent = firstNode.Parent;
            var secondParent = secondNode.Parent;

            if (firstParent is null || secondParent is null)
            {
                throw new ArgumentException();
            }

            var indexOfFirstChild = firstParent.Children.IndexOf(firstNode);
            var indexOfSecondChild = firstParent.Children.IndexOf(secondNode);

            firstParent.Children[indexOfFirstChild] = secondNode;
            secondNode.Parent = firstParent;

            secondParent.Children[indexOfSecondChild] = firstNode;
            firstNode.Parent = secondParent;
        }
    }
}
