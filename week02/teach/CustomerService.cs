/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

                // Test Cases

        // Test 1
        // Scenario: make a queue with a bad size (0) and check it defaults to 10
        // Expected Result: max_size shows 10
        Console.WriteLine("Test 1");
        var cs = new CustomerService(0);
        Console.WriteLine(cs);
        // Defect(s) Found: none, the constructor already handled this

        Console.WriteLine("=================");

        // Test 2
        // Scenario: add one customer and then serve them
        // Expected Result: it displays the customer I typed in
        Console.WriteLine("Test 2");
        cs = new CustomerService(4);
        cs.AddNewCustomer();
        cs.ServeCustomer();
        // Defect(s) Found: ServeCustomer deleted the customer first and then tried
        // to read it, so it crashed. Had to flip the order.

        Console.WriteLine("=================");

        // Test 3
        // Scenario: queue of size 2, try adding 3 customers
        // Expected Result: third one gets an error message
        Console.WriteLine("Test 3");
        cs = new CustomerService(2);
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        Console.WriteLine(cs);
        // Defect(s) Found: the full check used > instead of >=, so it let in one
        // customer too many

        Console.WriteLine("=================");

        // Test 4
        // Scenario: serve from an empty queue
        // Expected Result: error message instead of a crash
        Console.WriteLine("Test 4");
        cs = new CustomerService(2);
        cs.ServeCustomer();
        // Defect(s) Found: no empty check at all, it just crashed
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
        if (_queue.Count >= _maxSize) {
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
        if (_queue.Count == 0) {
            Console.WriteLine("No customers in the queue.");
            return;
        }

        var customer = _queue[0];
        _queue.RemoveAt(0);
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