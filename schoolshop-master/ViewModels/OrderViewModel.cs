using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models;

namespace Shop.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Number { get; set; }

        public decimal TotalSum => Items.Sum(x => x.TotalSum);

        public List<OrderItemViewModel> Items { get; set; }
        public OrderStatus Status { get; internal set; }
    }

    public class OrderItemViewModel
    {
        public decimal TotalSum => ProductPrice * Count;

        public string ProductName { get; set; }
        public int Count { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
