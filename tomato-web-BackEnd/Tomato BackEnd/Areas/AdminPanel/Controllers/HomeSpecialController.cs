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
    public class HomeSpecialController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public HomeSpecialController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.HomeSpecials.Count() / 4m);
            List<HomeSpecial> specials = await _context.HomeSpecials.Skip((page - 1) * 4).Take(4).ToListAsync();

            return View(specials);
        }
        public async Task<IActionResult> Edit(int id)
        {
            HomeSpecial Homespec = await _context.HomeSpecials.FirstOrDefaultAsync(x => x.Id == id);
            if (Homespec == null)
            {
                return RedirectToAction("index");
            }
            return View(Homespec);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HomeSpecial homespec)
        {
            HomeSpecial existHome = await _context.HomeSpecials.FirstOrDefaultAsync(x => x.Id == id);
            if (existHome == null)
            {
                return RedirectToAction("index");
            }
            if (homespec.SpecialImgFile != null)
            {
                if (homespec.SpecialImgFile.ContentType != "image/png" && homespec.SpecialImgFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (homespec.SpecialImgFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("ImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + homespec.SpecialImgFile.FileName;
                var path = Path.Combine(rootPath, "uploads/HomeSpec", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    homespec.SpecialImgFile.CopyTo(stream);
                }
                if (existHome.SpecialImgFile != null)
                {
                    string existPath = Path.Combine(_env.WebRootPath, "uploads/HomeSpec", existHome.SepialImg);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }
                }
                existHome.SepialImg = fileName;
            }
            existHome.SpecialName = homespec.SpecialName;

            existHome.Text = homespec.Text;
            existHome.Text1 = homespec.Text1;

            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HomeSpecial homespec)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (homespec.SpecialImgFile != null)
            {
                if (homespec.SpecialImgFile.ContentType != "image/png" && homespec.SpecialImgFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (homespec.SpecialImgFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("ImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + homespec.SpecialImgFile.FileName;
                var path = Path.Combine(rootPath, "uploads/HomeSpec", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    homespec.SpecialImgFile.CopyTo(stream);
                }
                homespec.SepialImg = fileName;
            }

            await _context.HomeSpecials.AddAsync(homespec);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            HomeSpecial restaurantHome = await _context.HomeSpecials.FirstOrDefaultAsync(x => x.Id == id);
            if (restaurantHome == null)
            {
                return RedirectToAction("index");
            }

            if (_context.HomeSpecials.Count() == 2)
            {
                return RedirectToAction("index");
            }

            string rootPath = _env.WebRootPath;
            var path = Path.Combine(rootPath, "uploads/HomeSpec", restaurantHome.SepialImg);
            System.IO.File.Delete(path);

            _context.HomeSpecials.Remove(restaurantHome);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
    }
}
