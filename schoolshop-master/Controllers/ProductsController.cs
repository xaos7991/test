using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
    [Route("products")]
    public class ProductsController : Controller
    {
        private readonly ShopContext _db;

        public ProductsController(ShopContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var products = await _db.Products.ToListAsync();

            return View(products);
        }

        [HttpGet]
        [Route("add")]
        [Route("edit/{id:int}")]
        public async Task<IActionResult> Product(int? id)
        {
            if (!id.HasValue)
                return View();

            var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
            return View(product);
        }

        [HttpGet]
        [Route("delete/{id:int}", Name = "ProductDeleteRoute")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product != null)
            {
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> Save(Product product)
        {
            if (product.Id == default(int))
            {
                _db.Products.Add(product);
            }
            else
            {
                _db.Products.Attach(product);
                _db.Entry(product).State = EntityState.Modified;
            }

            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("{productId:int}/addToCart")]
        public async Task<IActionResult> AddToCart(int productId)
        {
            var order = await _db.Orders
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.Status == OrderStatus.NotPayed);
          
            if (order == null)
            {
                order = new Order();
                _db.Orders.Add(order);
                await _db.SaveChangesAsync();
            }

            var orderItem = order.Items.FirstOrDefault(x => x.ProductId == productId);

            if (orderItem == null)
            {
                orderItem = new OrderItem
                {
                    ProductId = productId,
                    OrderId = order.Id,
                    Count = 1
                };

                _db.OrderItems.Add(orderItem);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            orderItem.Count++;
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }


    }
}
