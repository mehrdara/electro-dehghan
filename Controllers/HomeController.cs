using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using identityMVC.Models;
using Microsoft.AspNetCore.Authorization;
using identityMVC.Data;

namespace identityMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _db;

    public HomeController(AppDbContext db, ILogger<HomeController> logger)
    {
        _logger = logger;
        _db = db;
    }
    public IActionResult Index()
    {
        var cart = HttpContext.Session.Get<List<ProductItem>>("cart");
        IEnumerable<Item>? objItemList = _db.Items;
        var items = new List<ProductItem>();
        objItemList.ToList().ForEach(i =>

        {
            if (cart == null)
            {
                items.Add(new ProductItem { Product = i, Quantity = 0 });
            }
            else
            {
                var p = cart.SingleOrDefault(o => o.Product.Id == i.Id);
                items.Add(new ProductItem { Product = i, Quantity = p == null ? 0 : p.Quantity });
            }

        }
        );

        return View(items);
    }
    public IActionResult Minus(int id)
    {
        var item = _db.Items.Find(id);
        var cart = HttpContext.Session.Get<List<ProductItem>>("cart");

        int index = cart.FindIndex(w => w.Product.Id == id);

        if (cart[index].Quantity == 1) //last item of a product
        {
            cart.RemoveAt(index); //remove it
        }
        else
        {
            cart[index].Quantity--; //reduce by 1
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
    public IActionResult Buy(int id)
    {
        IEnumerable<Item> items = _db.Items;
        var item = items.Where(i => i.Id == id).FirstOrDefault();
        var cart = HttpContext.Session.Get<List<ProductItem>>("cart");
        if (cart == null) //no item in the cart
        {
            cart = new List<ProductItem>();
            cart.Add(new ProductItem { Product = item, Quantity = 1 });
        }
        else
        {
            int index = cart.FindIndex(w => w.Product.Id == id);
            if (index != -1) //if item already in the 
            {
                cart[index].Quantity++; //increment by 1
            }
            else
            {
                cart.Add(new ProductItem { Product = item, Quantity = 1 });
            }
        }
        HttpContext.Session.Set<List<ProductItem>>("cart", cart);
        return RedirectToAction("Index");
    }


    public IActionResult Add(int id)
    {
        var item = _db.Items.Find(id);
        var cart = HttpContext.Session.Get<List<ProductItem>>("cart");

        int index = cart.FindIndex(w => w.Product.Id == id);
        cart[index].Quantity++; //increment by 1

        HttpContext.Session.Set<List<ProductItem>>("cart", cart);
        return RedirectToAction("Index");
    }
    [Authorize]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
