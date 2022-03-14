namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class TreeFactory
    {
        private Dictionary<int, IntegerTree> nodesByKey;

        public TreeFactory()
        {
            this.nodesByKey = new Dictionary<int, IntegerTree>();
        }

        public IntegerTree CreateTreeFromStrings(string[] input)
        {
            foreach (var line in input)
            {
                var split = line.Split();
                var parent = int.Parse(split[0]);
                var child = int.Parse(split[1]);

                this.AddEdge(parent, child);
            }

            return this.GetRoot();
        }

        public IntegerTree CreateNodeByKey(int key)
        {
            if (this.nodesByKey.ContainsKey(key) == false)
            {
                this.nodesByKey.Add(key, new IntegerTree(key));
            }

            return this.nodesByKey[key];
        }

        public void AddEdge(int parent, int child)
        {
            var parentNode = this.CreateNodeByKey(parent);
            var childNode = this.CreateNodeByKey(child);

            childNode.AddParent(parentNode);
            parentNode.AddChild(childNode);
        }

        public IntegerTree GetRoot()
        {
            foreach (var kvp in this.nodesByKey)
            {
                if (kvp.Value.Parent is null)
                {
                    return kvp.Value;
                }
            }

            return null;
        }
    }
}
