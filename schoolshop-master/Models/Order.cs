using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Models
{
    public class Order
    {
        public Order()
        {
            Number = GenerateNumber();
            Items = new List<OrderItem>();
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public List<OrderItem> Items { get; set; }
        public OrderStatus Status { get; set; }


        private string GenerateNumber()
        {
            return $"{DateTime.Now.ToString("yyyyMMdd-HHmmss")}";
        }
    }

    public enum OrderStatus
    {
        NotPayed,
        Payed
    }
}