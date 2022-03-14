using System;
using Problem02.DoublyLinkedList;

namespace CheckFunctionality
{
    class Program
    {
        static void Main(string[] args)
        {
            var doublyList = new DoublyLinkedList<int>();

            doublyList.AddFirst(5);
            doublyList.AddLast(6);
            doublyList.AddFirst(7);
            doublyList.AddFirst(8);

            Console.WriteLine(string.Join(" ", doublyList));

            Console.WriteLine(doublyList.Count);
        }
    }
}
