using System;
using Problem01.List;
using Problem02.Stack;
using Problem03.Queue;
using Problem04.SinglyLinkedList;

namespace MainProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkedlist = new SinglyLinkedList<int>();
            linkedlist.AddFirst(5);
            Console.WriteLine(string.Join(" ", linkedlist));
        }
    }
}
