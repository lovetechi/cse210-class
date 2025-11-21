using System;
using System.Collections.Generic;
using System.Linq;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    private double ShippingCost()
    {
        return _customer.IsInUSA() ? 5.0 : 35.0;
    }

    public double GetTotalPrice()
    {
        double sum = _products.Sum(p => p.GetTotalCost());
        return sum + ShippingCost();
    }

    public string GetPackingLabel()
    {
        var lines = _products.Select(p => $"{p.Name} (ID: {p.ProductId})");
        return "Packing Label:\n" + string.Join("\n", lines);
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.Name}\n{_customer.Address.GetFullAddress()}";
    }
}
