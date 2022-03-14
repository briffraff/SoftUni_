using System;
using System.Collections.Generic;
using _01.BSTOperations;

public interface IAbstractBinarySearchTree<T> where T : IComparable<T>
{
    BinarySearchTree<T>.Node Root { get; }

    //Basic Tree Operations
    void Insert(T element);
    bool Contains(T element);
    void EachInOrder(Action<T> action);

    //Binary Search Tree Operations
    IAbstractBinarySearchTree<T> Search(T element);
    void Delete(T element);
    void DeleteMin();
    void DeleteMax();
    int Count();
    int GetRank(T element);
    T Select(int rank);
    T Ceiling(T element);
    T Floor(T element);
    IEnumerable<T> Range(T startRange, T endRange);
}

