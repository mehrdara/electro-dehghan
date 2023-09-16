using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using identityMVC.Models;
using Microsoft.AspNetCore.Authorization;
using identityMVC.Data;
using OnlineShop.Models;

namespace identityMVC.Controllers
{

    public class OrderController : Controller
    {
        private readonly AppDbContext _db;

        public OrderController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Checkout()
        {
            return View();
        }

        //POST Checkout action method

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Checkout(Order Order)
        {
            List<ProductItem> products = HttpContext.Session.Get<List<ProductItem>>("cart");
            if (products != null)
            {
                foreach (var product in products)
                {
                    Order.Products.Add(product.Product);
                }
            }

            HttpContext.Session.Set("products", new List<Item>());
            return View();
        }
    }
}
