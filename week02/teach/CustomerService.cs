using System.Diagnostics;
using System.Runtime.CompilerServices;

/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        var cs = new CustomerService(10);
        Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Four customers are added to the queue and then three customers are served.
        // Expected Result: One last customer should be left in the queue with the correct information.
        Console.WriteLine("Test 1");

        var customer1 = new CustomerService.Customer("Alice", "A123", "Problem 1");
        var customer2 = new CustomerService.Customer("Bob", "B456", "Problem 2");

        Trace.Assert(customer1.ToString() == "Alice (A123)  : Problem 1", "Customer 1 ToString() failed");
        Trace.Assert(customer2.ToString() == "Bob (B456)  : Problem 2", "Customer 2 ToString() failed");

        cs.AddNewCustomer();
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        cs.AddNewCustomer();

        Trace.Assert(cs.ToString() == "[size=4 max_size=10 => Alice (A123)  : Problem 1, Bob (B456)  : Problem 2, Craig (C789)  : Problem 3, Dan (D123)  : Problem 4]", "CustomerService ToString() failed after adding customers");

        cs.ServeCustomer();
        cs.ServeCustomer();
        cs.ServeCustomer();

        Trace.Assert(cs.ToString() == "[size=1 max_size=10 => Dan (D123)  : Problem 4]", "CustomerService ToString() failed after serving customers");

        // Defect(s) Found: 

        // No defects found!

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Five new customers are added to the queue, but the maximum size of the queue is set to 3.  The last two customers should not be added to the queue.
        // Expected Result: The queue should only contain the first three customers and the last two customers should not be added to the queue.
        Console.WriteLine("Test 2");

        cs = new CustomerService(3);
        Console.WriteLine(cs);

        cs.AddNewCustomer();
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        cs.AddNewCustomer();

        Trace.Assert(cs.ToString() == "[size=3 max_size=3 => Alice (A123)  : Problem 1, Bob (B456)  : Problem 2, Craig (C789)  : Problem 3]", "CustomerService ToString() failed after adding customers with max size");

        cs.ServeCustomer();
        cs.ServeCustomer();
        cs.ServeCustomer();

        Trace.Assert(cs.ToString() == "[size=0 max_size=3 => ]", "CustomerService ToString() failed after serving all customers");


        // Defect(s) Found: 
        // Program quits with an exception when trying to add more customers than the maximum size of the queue.  The program should handle this case gracefully and not allow more customers to be added than the maximum size of the queue.
        // Which shouldn't be so...

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count > _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        _queue.RemoveAt(0);
        var customer = _queue[0];
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}