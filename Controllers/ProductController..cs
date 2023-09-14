using System;
using System.ComponentModel;
using System.Data.Common;
using identityMVC.Data;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
namespace IdentityMVC.Controllers;
public class ProductController : Controller
{
    private readonly AppDbContext _db;

    public ProductController(AppDbContext db)
    {
        _db = db;

    }
    public IActionResult Index()
    {
        IEnumerable<Item>? objItemList = _db.Items;
        return View(objItemList);
    }
}