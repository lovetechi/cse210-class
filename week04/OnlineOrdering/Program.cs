using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        // First order: customer in USA
        var addr1 = new Address("123 Maple St", "Springfield", "IL", "USA");
        var customer1 = new Customer("John Doe", addr1);
        var order1 = new Order(customer1);
        order1.AddProduct(new Product("Widget", "W-100", 3.50, 5));
        order1.AddProduct(new Product("Gadget", "G-200", 12.99, 2));

        // Second order: international customer
        var addr2 = new Address("456 Oak Ave", "Toronto", "ON", "Canada");
        var customer2 = new Customer("Jane Smith", addr2);
        var order2 = new Order(customer2);
        order2.AddProduct(new Product("Thingamajig", "T-300", 7.25, 3));
        order2.AddProduct(new Product("Doohickey", "D-400", 15.00, 1));

        var orders = new[] { order1, order2 };

        foreach (var o in orders)
        {
            Console.WriteLine("==============================");
            Console.WriteLine(o.GetPackingLabel());
            Console.WriteLine();
            Console.WriteLine(o.GetShippingLabel());
            Console.WriteLine();
            Console.WriteLine("Total Price: " + o.GetTotalPrice().ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine();
        }
    }
}