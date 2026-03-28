class Program
{
    static void Main(string[] args)
    {
        // --- Order 1: US Customer ---
        Address usAddress = new Address("123 Oak Street", "Springfield", "IL", "USA");
        Customer usCustomer = new Customer("Alice Johnson", usAddress);

        Order order1 = new Order(usCustomer);
        order1.AddProduct(new Product("Wireless Mouse", "WM-4821", 29.99, 2));
        order1.AddProduct(new Product("USB-C Hub", "UCH-1177", 49.95, 1));
        order1.AddProduct(new Product("Laptop Stand", "LS-0093", 35.00, 1));

        Console.WriteLine("========================================");
        Console.WriteLine("           ORDER 1 SUMMARY             ");
        Console.WriteLine("========================================");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}");
        Console.WriteLine();

        // --- Order 2: International Customer ---
        Address intlAddress = new Address("45 Maple Avenue", "Toronto", "Ontario", "Canada");
        Customer intlCustomer = new Customer("Carlos Rivera", intlAddress);

        Order order2 = new Order(intlCustomer);
        order2.AddProduct(new Product("Mechanical Keyboard", "MK-3390", 89.99, 1));
        order2.AddProduct(new Product("Monitor Light Bar", "MLB-2256", 39.99, 2));

        Console.WriteLine("========================================");
        Console.WriteLine("           ORDER 2 SUMMARY             ");
        Console.WriteLine("========================================");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}");
    }
}