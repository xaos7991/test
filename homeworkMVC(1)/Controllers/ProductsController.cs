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
    }
}
