using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using identityMVC.Data;
using Microsoft.AspNetCore.Authorization;
namespace IdentityMVC.Controllers
{
    public class ItemController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ItemController(AppDbContext db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            this._hostEnvironment = hostEnvironment;
        }
        [Authorize]

        public async Task<IActionResult> Index()
        {
            IEnumerable<Item>? objItemList = await _db.Items.ToListAsync();
            return View(objItemList);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Item obj)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (obj.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(obj.ImageFile.FileName); string extension = Path.GetExtension(obj.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    obj.ImageName = fileName;
                    string path = Path.Combine(wwwRootPath + "/Images/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        obj.ImageFile.CopyTo(fileStream);
                    }
                    _db.Items?.AddAsync(obj);
                    await _db.SaveChangesAsync();
                    TempData["success"] = "محصول با موفقیت اضافه شد !‌";
                }



                return RedirectToAction("Index");
            }

            return View(obj);
        }
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var ItemFromDb = await _db.Items.FindAsync(id);
            if (ItemFromDb == null)
            {
                return NotFound();
            }
            return View(ItemFromDb);

        }
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Item? temp = await _db.Items.FindAsync(id);
            if (temp != null)
            {
                _db.Items.Remove(temp);
                await _db.SaveChangesAsync();
                TempData["success"] = "محصول با موفقیت حذف شد !‌";

            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(Item obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.ImageFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(obj.ImageFile.FileName);
                    string extension = Path.GetExtension(obj.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    obj.ImageName = fileName;
                    string path = Path.Combine(wwwRootPath + "/Images/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        obj.ImageFile.CopyTo(fileStream);
                    }
                    if (TempData.ContainsKey("image"))

                    {
                        string? name = TempData["image"]?.ToString();

                        if (name != null)
                        {
                            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "Images", name);
                            if (System.IO.File.Exists(imagePath))
                            {
                                System.IO.File.Delete(imagePath);
                            }
                        }
                    }
                }
                _db.Items.Update(obj);
                await _db.SaveChangesAsync();
                TempData["success"] = "ویرایش با موفقیت انجام شد !‌";

                return RedirectToAction("Index");
            }
            return View(obj);
        }
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var item = await _db.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            TempData["image"] = item.ImageName;

            return View(item);
        }
        [HttpPost, ActionName("DeletePost")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Items.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Items.Remove(obj);
            _db.SaveChanges();
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "Images", obj.ImageName);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            TempData["success"] = "محصول با موفقیت حذف شد !‌";

            return RedirectToAction("Index");
        }
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var ItemFromDb = _db.Items.Find(id);
            if (ItemFromDb == null)
            {
                return NotFound();
            }
            return View(ItemFromDb);
        }
    }
}