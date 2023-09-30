using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using identityMVC.Models;
using Microsoft.AspNetCore.Authorization;
using identityMVC.Data;

namespace identityMVC.Controllers;

public class CartController : Controller
{
    private readonly AppDbContext _db;

    public CartController(AppDbContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        var cart = HttpContext.Session.Get<List<ProductItem>>("cart");
        if (cart != null)
        {
            ViewBag.total = cart.Sum(s => s.Quantity * s.Product.Price);
            ViewBag.Quantity = cart.Select(i => i.Quantity).Aggregate(0, (acc, x) => acc + x);
        }
        else
        {
            cart = new List<ProductItem>();
            ViewBag.total = 0;
            ViewBag.Quantity = 0;
        }


        return View(cart);
    }
    public IActionResult Add(int id)
    {
        var item = _db.Items.Find(id);
        var cart = HttpContext.Session.Get<List<ProductItem>>("cart");

        int index = cart.FindIndex(w => w.Product.Id == id);
        cart[index].Quantity++;


        HttpContext.Session.Set<List<ProductItem>>("cart", cart);
        return RedirectToAction("Index");
    }
    public IActionResult Minus(int id)
    {
        var item = _db.Items.Find(id);
        var cart = HttpContext.Session.Get<List<ProductItem>>("cart");

        int index = cart.FindIndex(w => w.Product.Id == id);

        if (cart[index].Quantity == 1)
        {
            cart.RemoveAt(index);
        }
        else
        {
            cart[index].Quantity--;
        }


        HttpContext.Session.Set<List<ProductItem>>("cart", cart);
        return RedirectToAction("Index");
    }
    public IActionResult Remove(int id)
    {
        var item = _db.Items.Find(id);
        var cart = HttpContext.Session.Get<List<ProductItem>>("cart");

        int index = cart.FindIndex(w => w.Product.Id == id);

        cart.RemoveAt(index);

        HttpContext.Session.Set<List<ProductItem>>("cart", cart);

        return RedirectToAction("Index");
    }
    public IActionResult Submit()
    {

        return RedirectToAction("Index", "Order");
    }

}