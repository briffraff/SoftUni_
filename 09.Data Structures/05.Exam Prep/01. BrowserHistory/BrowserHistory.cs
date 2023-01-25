namespace _01._BrowserHistory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Interfaces;

    public class BrowserHistory : IHistory
    {
        private LinkedList<ILink> links;

        public BrowserHistory()
        {
            this.links = new LinkedList<ILink>();
        }

        public int Size => this.links.Count;

        public void Clear()
        {
            this.links.Clear();
        }

        public bool Contains(ILink link)
        {
            return this.links.Contains(link);
        }

        public ILink DeleteFirst()
        {
            if (this.links.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var element = this.links.Last.Value;
            this.links.RemoveLast();

            return element;
        }

        public ILink DeleteLast()
        {
            if (this.links.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var element = this.links.First.Value;
            this.links.RemoveFirst();

            return element;
        }

        public ILink GetByUrl(string url)
        {
            var node = this.links.First;

            while (node != null)
            {
                if (node.Value.Url == url)
                {
                    return node.Value;
                }

                node = node.Next;
            }

            return null;
        }

        public ILink LastVisited()
        {
            if (this.links.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.links.First.Value;
        }

        public void Open(ILink link)
        {
            this.links.AddFirst(link);
        }

        public int RemoveLinks(string url)
        {
            url = url.ToLower();
            int count = 0;

            var node = this.links.First;

            while(node != null)
            {
                var nextNode = node.Next;

                if (node.Value.Url.ToLower().Contains(url))
                {
                    this.links.Remove(node);
                    count++;
                }

                node = nextNode;
            }

            if(count == 0)
            {
                throw new InvalidOperationException();
            }

            return count;
        }

        public ILink[] ToArray()
        {
            return this.links.ToArray();
        }

        public List<ILink> ToList()
        {
            return this.links.ToList();
        }

        public string ViewHistory()
        {
            if (this.links.Count == 0)
            {
                return "Browser history is empty!";
            }
            var sb = new StringBuilder();

            foreach (var link in this.links)
            {
                sb.AppendLine(link.ToString());
            }

            return sb.ToString();
        }
    }
}
