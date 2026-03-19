using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items with different priorities
    // Expected Result: Highest priority item is removed first
    // Defect(s) Found: Dequeue did not remove item and loop skipped last element
    public void TestPriorityQueue_HighestPriority()
    {
        var pq = new PriorityQueue();

        pq.Enqueue("A", 1);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 3);

        var result = pq.Dequeue();

        Assert.AreEqual("B", result);
    }

    [TestMethod]
    // Scenario: Multiple items with same priority
    // Expected Result: First inserted item is removed first (FIFO)
    // Defect(s) Found: >= caused later items to override earlier ones
    public void TestPriorityQueue_FIFO_SamePriority()
    {
        var pq = new PriorityQueue();

        pq.Enqueue("A", 5);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 5);

        var result = pq.Dequeue();

        Assert.AreEqual("A", result);
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: Exception thrown with correct message
    // Defect(s) Found: (should pass if implemented correctly) | No bugs found :)
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Dequeue should remove item from queue
    // Expected Result: Second dequeue should return next item
    // Defect(s) Found: Item was not being removed
    public void TestPriorityQueue_Removal()
    {
        var pq = new PriorityQueue();

        pq.Enqueue("A", 1);
        pq.Enqueue("B", 2);

        pq.Dequeue(); // removes B
        var result = pq.Dequeue();

        Assert.AreEqual("A", result);
    }
}