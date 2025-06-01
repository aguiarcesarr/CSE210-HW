using System;

class Program
{
    static void Main(string[] args)
    {
        Address usaAddress = new Address("123 Main St", "Springfield", "IL", "USA");
        Address ukAddress = new Address("456 High St", "London", "England", "UK");

        Customer usaCustomer = new Customer("John Doe", usaAddress);
        Customer ukCustomer = new Customer("Jane Smith", ukAddress);

        Product Laptop = new Product("Laptop", "P001", 899.99, 1);
        Product Mouse = new Product("Mouse", "P002", 29.99, 2);
        Product Phone = new Product("Phone", "P003", 499.99, 1);
        Product Headphones = new Product("Headphones", "P004", 199.99, 1);

        Order usaOrder = new Order(usaCustomer);
        usaOrder.AddProduct(Laptop);
        usaOrder.AddProduct(Mouse);

        Order ukOrder = new Order(ukCustomer);
        ukOrder.AddProduct(Phone);
        ukOrder.AddProduct(Headphones);

        Console.WriteLine(usaOrder.GetPackingLabel());
        Console.WriteLine(usaOrder.GetShippingLabel());
        Console.WriteLine($"Total Cost (USA Order): ${usaOrder.GetTotalCost():0.00}\n");

        Console.WriteLine(ukOrder.GetPackingLabel());
        Console.WriteLine(ukOrder.GetShippingLabel());
        Console.WriteLine($"Total Cost (UK Order): ${ukOrder.GetTotalCost():0.00}\n");
    }
}