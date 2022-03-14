using System;
using NUnit.Framework;
using _03.PriorityQueue;

[TestFixture]
public class PriorityQueueTests
{
    [Test]
    public void DecreaseKey_SingleElement()
    {
        var queue = new PriorityQueue<TestNode<int>>();

        var testNode = new TestNode<int>() { Value = 1 };

        queue.Add(testNode);
        queue.DecreaseKey(testNode);

        Assert.AreEqual(1, queue.Size);
        Assert.AreEqual(1, queue.Dequeue().Value);
    }

    [Test]
    public void DecreaseKey_TwoElements()
    {
        var queue = new PriorityQueue<TestNode<int>>();

        var testNode1 = new TestNode<int>() { Value = 2 };
        var testNode2 = new TestNode<int>() { Value = 3 };

        queue.Add(testNode1);
        queue.Add(testNode2);

        testNode2.Value = 1;
        queue.DecreaseKey(testNode2);

        Assert.AreEqual(2, queue.Size);
        Assert.AreEqual(1, queue.Dequeue().Value);
    }

    [Test]
    public void DecreaseKey_MultipleElements()
    {
        var queue = new PriorityQueue<TestNode<int>>();

        var testNode1 = new TestNode<int>() { Value = 6 };
        var testNode2 = new TestNode<int>() { Value = 3 };
        var testNode3 = new TestNode<int>() { Value = 4 };
        var testNode4 = new TestNode<int>() { Value = 2 };
        var testNode5 = new TestNode<int>() { Value = 8 };

        queue.Add(testNode1);
        queue.Add(testNode2);
        queue.Add(testNode3);
        queue.Add(testNode4);
        queue.Add(testNode5);

        testNode5.Value = 1;
        queue.DecreaseKey(testNode5);

        Assert.AreEqual(1, queue.Dequeue().Value);
        Assert.AreEqual(2, queue.Dequeue().Value);

        testNode1.Value = 1;
        queue.DecreaseKey(testNode1);
        Assert.AreEqual(1, queue.Dequeue().Value);
    }
}

class TestNode<T> : IComparable<TestNode<T>> where T : IComparable<T>
{
    public T Value { get; set; }

    public int CompareTo(TestNode<T> other)
    {
        return this.Value.CompareTo(other.Value);
    }
}
