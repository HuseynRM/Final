using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tomato_BackEnd.DAL;
using Tomato_BackEnd.Models;

namespace Tomato_BackEnd.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.ShopLists.Count() / 4m);
            return View(await _context.ShopLists.Include(a => a.ShopCatagory).Skip((page - 1) * 4).Take(4).ToListAsync());
        }
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Categories = await _context.ShopCatagories.ToListAsync();
            ShopList list = await _context.ShopLists.FirstOrDefaultAsync(x => x.Id == id);
            if (list == null)
            {
                return RedirectToAction("index");
            }
            return View(list);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ShopList shopList)
        {
            ViewBag.Categories = await _context.ShopCatagories.ToListAsync();

            ShopList existlist = await _context.ShopLists.FirstOrDefaultAsync(x => x.Id == id);
            if (!await _context.ShopCatagories.AnyAsync(x => x.Id == shopList.ShopCatagoryId)) return RedirectToAction("index");
            if (existlist == null)
            {
                return RedirectToAction("index");
            }
            if (shopList.ImgFile != null)
            {
                if (shopList.ImgFile.ContentType != "image/png" && shopList.ImgFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (shopList.ImgFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("ImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + shopList.ImgFile.FileName;
                var path = Path.Combine(rootPath, "uploads/Product", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    shopList.ImgFile.CopyTo(stream);
                }
                if (existlist.Img != null)
                {
                    string existPath = Path.Combine(_env.WebRootPath, "uploads/Product", existlist.Img);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }
                }
                existlist.Img = fileName;
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            existlist.ShopCatagoryId = shopList.ShopCatagoryId;
            existlist.Price = shopList.Price;
            existlist.FName = shopList.FName;
            existlist.ProductSingleId = shopList.ProductSingleId;

            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.ShopCatagories.ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ShopList shopList)
        {
            ViewBag.Categories = await _context.ShopCatagories.ToListAsync();
            if (!await _context.ShopCatagories.AnyAsync(x => x.Id == shopList.ShopCatagoryId))
            {
                ModelState.AddModelError("ShopCatagoryId", "Xetaniz var!");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (shopList.ImgFile != null)
            {
                if (shopList.ImgFile.ContentType != "image/png" && shopList.ImgFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (shopList.ImgFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("ImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + shopList.ImgFile.FileName;
                var path = Path.Combine(rootPath, "uploads/Product", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    shopList.ImgFile.CopyTo(stream);
                }
                shopList.Img = fileName;
            }
            
            await _context.ShopLists.AddAsync(shopList);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");

        }
        public async Task<IActionResult> Delete(int id)
        {
            ShopList list = await _context.ShopLists.FirstOrDefaultAsync(x => x.Id == id);
            if (list == null)
            {
                return RedirectToAction("index");
            }

            if (_context.ShopLists.Count() == 2)
            {
                return RedirectToAction("index");
            }

            string rootPath = _env.WebRootPath;
            var path = Path.Combine(rootPath, "uploads/Product", list.Img);
            System.IO.File.Delete(path);

            _context.ShopLists.Remove(list);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
    }
}
