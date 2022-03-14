
namespace _04.BinarySearchTree
{
    using System;

    public interface IAbstractBinarySearchTree<T> where T : IComparable<T>
    {
        void Insert(T element);
        bool Contains(T element);
        void EachInOrder(Action<T> action);
        IAbstractBinarySearchTree<T> Search(T element);
    }
}