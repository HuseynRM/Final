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
    public class HomeInfoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public HomeInfoController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.RestaurantHomes.Count() / 4m);
            List<RestaurantHome> restaurants = await _context.RestaurantHomes.Skip((page - 1) * 4).Take(4).ToListAsync();

            return View(restaurants);
        }
        public async Task<IActionResult> Edit(int id)
        {
            RestaurantHome restaurantHome = await _context.RestaurantHomes.FirstOrDefaultAsync(x => x.Id == id);
            if (restaurantHome == null)
            {
                return RedirectToAction("index");
            }
            return View(restaurantHome);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RestaurantHome restaurantHome)
        {
            RestaurantHome existHome = await _context.RestaurantHomes.FirstOrDefaultAsync(x => x.Id == id);
            if (existHome == null)
            {
                return RedirectToAction("index");
            }
            if (restaurantHome.HomeImgFile != null)
            {
                if (restaurantHome.HomeImgFile.ContentType != "image/png" && restaurantHome.HomeImgFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (restaurantHome.HomeImgFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("ImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + restaurantHome.HomeImgFile.FileName;
                var path = Path.Combine(rootPath, "uploads/ResHome", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    restaurantHome.HomeImgFile.CopyTo(stream);
                }
                if (existHome.HomeImg != null)
                {
                    string existPath = Path.Combine(_env.WebRootPath, "uploads/ourteam", existHome.HomeImg);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }
                }
                existHome.HomeImg = fileName;
            }
            if (restaurantHome.HomeImgFile1 != null)
            {
                if (restaurantHome.HomeImgFile1.ContentType != "image/png" && restaurantHome.HomeImgFile1.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (restaurantHome.HomeImgFile1.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("ImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + restaurantHome.HomeImgFile1.FileName;
                var path = Path.Combine(rootPath, "uploads/ResHome", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    restaurantHome.HomeImgFile1.CopyTo(stream);
                }
                if (existHome.HomeImg1 != null)
                {
                    string existPath = Path.Combine(_env.WebRootPath, "uploads/ResHome", existHome.HomeImg1);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }
                }
                existHome.HomeImg1 = fileName;
            }
            if (restaurantHome.HomeImgFile2 != null)
            {
                if (restaurantHome.HomeImgFile2.ContentType != "image/png" && restaurantHome.HomeImgFile2.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (restaurantHome.HomeImgFile2.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("ImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + restaurantHome.HomeImgFile2.FileName;
                var path = Path.Combine(rootPath, "uploads/ResHome", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    restaurantHome.HomeImgFile2.CopyTo(stream);
                }
                if (existHome.HomeImg2 != null)
                {
                    string existPath = Path.Combine(_env.WebRootPath, "uploads/ResHome", existHome.HomeImg1);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }
                }
                existHome.HomeImg2 = fileName;
            }

            existHome.Info1 = restaurantHome.Info1;

            existHome.Info2 = restaurantHome.Info2;

            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RestaurantHome restaurantHome)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (restaurantHome.HomeImgFile != null)
            {
                if (restaurantHome.HomeImgFile.ContentType != "image/png" && restaurantHome.HomeImgFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (restaurantHome.HomeImgFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("ImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + restaurantHome.HomeImgFile.FileName;
                var path = Path.Combine(rootPath, "uploads/ResHome", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                   restaurantHome.HomeImgFile.CopyTo(stream);
                }
                restaurantHome.HomeImg = fileName;
            }

            if (restaurantHome.HomeImgFile1 != null)
            {
                if (restaurantHome.HomeImgFile1.ContentType != "image/png" && restaurantHome.HomeImgFile1.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (restaurantHome.HomeImgFile1.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("ImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + restaurantHome.HomeImgFile1.FileName;
                var path = Path.Combine(rootPath, "uploads/ResHome", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    restaurantHome.HomeImgFile1.CopyTo(stream);
                }
                restaurantHome.HomeImg1 = fileName;
            }

            if (restaurantHome.HomeImgFile2 != null)
            {
                if (restaurantHome.HomeImgFile2.ContentType != "image/png" && restaurantHome.HomeImgFile2.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (restaurantHome.HomeImgFile2.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("ImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + restaurantHome.HomeImgFile2.FileName;
                var path = Path.Combine(rootPath, "uploads/ResHome", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    restaurantHome.HomeImgFile2.CopyTo(stream);
                }
                restaurantHome.HomeImg2 = fileName;
            }

            await _context.RestaurantHomes.AddAsync(restaurantHome);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            RestaurantHome restaurantHome = await _context.RestaurantHomes.FirstOrDefaultAsync(x => x.Id == id);
            if (restaurantHome == null)
            {
                return RedirectToAction("index");
            }

            if (_context.RestaurantHomes.Count() == 2)
            {
                return RedirectToAction("index");
            }
    
            string rootPath = _env.WebRootPath;
            var path = Path.Combine(rootPath, "uploads/ResHome", restaurantHome.HomeImg);
            System.IO.File.Delete(path);

            string rootPath1 = _env.WebRootPath;
            var path1 = Path.Combine(rootPath1, "uploads/ResHome", restaurantHome.HomeImg1);
            System.IO.File.Delete(path1);

            string rootPath2 = _env.WebRootPath;
            var path2 = Path.Combine(rootPath2, "uploads/ResHome", restaurantHome.HomeImg2);
            System.IO.File.Delete(path2);

            _context.RestaurantHomes.Remove(restaurantHome);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
    }
}
