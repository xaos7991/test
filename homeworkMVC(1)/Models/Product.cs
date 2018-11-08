using System;
using System.Collections.Generic;


namespace Shop.Models
{
    public class Product
    {
        public Product()
        {
        }

        public Product(string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Продукт не может существовать без имени");

            if (price <= 0)
                throw new ArgumentException("Продукт не может быть с отрицательной или нулевой ценой");

            Name = name;
            Price = price;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}