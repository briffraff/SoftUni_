namespace Tree
{
    using System.Collections.Generic;

    public interface IAbstractTree<T>
    {
        int Key { get; }
        IReadOnlyCollection<Tree<T>> Children { get; }

        void AddParent(Tree<T> parent);

        void AddChild(Tree<T> child);

        string GetAsString();

        IEnumerable<int> GetLeafKeys();

        List<int> GetMiddleKeys();

        int GetDeepestLeftomostNode();

        IEnumerable<T> GetLongestPath();
    }
}
