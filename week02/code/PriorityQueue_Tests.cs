using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: 3 items, different priorities, dequeue all 3
    // Expected Result: high, medium, low
    // Defect(s) Found: dequeue returned the value but never removed it from the list
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("high", 5);
        priorityQueue.Enqueue("medium", 3);

        Assert.AreEqual("high", priorityQueue.Dequeue());
        Assert.AreEqual("medium", priorityQueue.Dequeue());
        Assert.AreEqual("low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: two items tied at priority 4
    // Expected Result: first, second, back
    // Defect(s) Found: >= in the compare meant the tie went to the later item, should go to the first one
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first", 4);
        priorityQueue.Enqueue("back", 1);
        priorityQueue.Enqueue("second", 4);

        Assert.AreEqual("first", priorityQueue.Dequeue());
        Assert.AreEqual("second", priorityQueue.Dequeue());
        Assert.AreEqual("back", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: highest priority item is last in the queue
    // Expected Result: c comes out first
    // Defect(s) Found: loop was Count - 1 so it skipped the last item
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("a", 1);
        priorityQueue.Enqueue("b", 2);
        priorityQueue.Enqueue("c", 9);

        Assert.AreEqual("c", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: dequeue when empty
    // Expected Result: InvalidOperationException, "The queue is empty."
    // Defect(s) Found: none
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}