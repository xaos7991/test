using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
        [Route("Cart")]
        public class CartController : Controller
        {
            public ShopContext _db;

            public CartController(ShopContext db)
            {
                _db = db;
            }

            [Route("")]
            public async Task<IActionResult> Index()
            {
                var orders = await _db.Orders
                    .Include(x => x.Items)
                    .ThenInclude(x => x.Product)
                    .ToListAsync();
 
                var ordersViewModel = orders
                .Where(x => x.Status == OrderStatus.NotPayed )
                    .Select(order => new OrderViewModel
                    {
                        Id = order.Id,
                        Number = order.Number,
                        Status = order.Status,
                        Items = order.Items
                            .Select(item => new OrderItemViewModel
                            {
                                ProductName = item.Product.Name,
                                ProductPrice = item.Product.Price,
                                Count = item.Count
                            }).ToList()
                    });

                return View(ordersViewModel);
            }
        }
    }
