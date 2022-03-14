using System.Linq;
using System.Text;

namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> children;

        public Tree(int key, params Tree<T>[] children)
        {
            this.Key = key;
            this.children = new List<Tree<T>>();

            foreach (var child in children)
            {
                this.AddChild(child);
                child.Parent = this;
            }
        }

        public int Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            var sb = new StringBuilder();

            this.DfsAsString(sb, this , 0);

            return sb.ToString().Trim();
        }

        private void DfsAsString(StringBuilder sb, Tree<T> tree, int indent)
        {
            sb.Append(' ', indent).AppendLine(tree.Key.ToString());

            foreach (var child in tree.children)
            {
                this.DfsAsString(sb,child,indent + 2);
            }
        }

        public List<int> GetMiddleKeys()
        {
            return this.BfsWithResultKeys(tree => tree.children.Count > 0 && tree.Parent != null)
                .Select(tree => tree.Key).ToList();
        }

        public IEnumerable<int> GetLeafKeys()
        {
            return this.BfsWithResultKeys(tree => tree.children.Count == 0)
                .Select(tree => tree.Key);
        }

        private IEnumerable<Tree<T>> BfsWithResultKeys(Predicate<Tree<T>> predicate)
        {
            var queue = new Queue<Tree<T>>();
            var result = new List<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();

                if (predicate.Invoke(subtree))
                {
                    result.Add(subtree);
                }

                foreach (var subtreeChild in subtree.children)
                {
                    queue.Enqueue(subtreeChild);
                }
            }

            return result;
        }

        public int GetDeepestLeftomostNode()
        {
            return this.GetDeepestNode().Key;
        }

        private Tree<T> GetDeepestNode()
        {
            var leafs = this.BfsWithResultKeys(tree => tree.children.Count == 0);

            Tree<T> deepestNode = null;
            var maxDepth = 0;

            foreach (Tree<T> leaf in leafs)
            {
                var depth = this.GetDepth(leaf);
                if (depth > maxDepth)
                {
                    maxDepth = depth;
                    deepestNode = leaf;
                }
            }

            return deepestNode;
        }

        private int GetDepth(Tree<T> leaf)
        {
            var depth = 0;
            var tree = leaf;

            while (tree.Parent != null)
            {
                depth++;
                tree = tree.Parent;
            }

            return depth;
        }

        public IEnumerable<T> GetLongestPath()
        {
            throw new NotImplementedException();
        }
    }
}
