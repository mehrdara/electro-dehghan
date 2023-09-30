using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using identityMVC.Models;
using Microsoft.AspNetCore.Authorization;
using IdentityMVC.ViewModels;
using identityMVC.Data;

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
        // public async Task<IActionResult> Create(OrderViewModel order)
        // {
        //     if (ModelState.IsValid)
        //     {

        //         _db.Orders?.AddAsync(order);
        //         await _db.SaveChangesAsync();
        //         TempData["success"] = "سفارش شما  با موفقیت ثبت شد !‌";
        //         return RedirectToAction("Index");
        //     }

        //     return View(order);
        // }

        public async Task<IActionResult> Index()
        {

            OrderViewModel Order = new OrderViewModel();
            Order.ProductItems = HttpContext.Session.Get<List<ProductItem>>("cart");
            return View(Order);
        }
    }
}
