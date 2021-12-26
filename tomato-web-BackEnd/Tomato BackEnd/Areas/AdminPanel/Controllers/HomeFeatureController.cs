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
    public class HomeFeatureController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public HomeFeatureController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.HomeSpecials.Count() / 4m);
            List<Features> features = await _context.Features.Skip((page - 1) * 4).Take(4).ToListAsync();

            return View(features);
        }
        public async Task<IActionResult> Edit(int id)
        {
            Features features = await _context.Features.FirstOrDefaultAsync(x => x.Id == id);
            if (features == null)
            {
                return RedirectToAction("index");
            }
            return View(features);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Features features)
        {
            Features existfeature = await _context.Features.FirstOrDefaultAsync(x => x.Id == id);
            if (existfeature == null)
            {
                return RedirectToAction("index");
            }
            if (features.FeatureImgFile != null)
            {
                if (features.FeatureImgFile.ContentType != "image/png" && features.FeatureImgFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (features.FeatureImgFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("ImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + features.FeatureImgFile.FileName;
                var path = Path.Combine(rootPath, "uploads/Feature", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    features.FeatureImgFile.CopyTo(stream);
                }
                if (existfeature.FeatureImgFile != null)
                {
                    string existPath = Path.Combine(_env.WebRootPath, "uploads/Feature", existfeature.FeatureImg);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }
                }
                existfeature.FeatureImg = fileName;
            }
            existfeature.Name = features.Name;

            existfeature.Desc = features.Desc;

            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Features features)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (features.FeatureImgFile != null)
            {
                if (features.FeatureImgFile.ContentType != "image/png" && features.FeatureImgFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (features.FeatureImgFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("ImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + features.FeatureImgFile.FileName;
                var path = Path.Combine(rootPath, "uploads/Feature", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    features.FeatureImgFile.CopyTo(stream);
                }
                features.FeatureImg = fileName;
            }

            await _context.Features.AddAsync(features);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            Features features = await _context.Features.FirstOrDefaultAsync(x => x.Id == id);
            if (features == null)
            {
                return RedirectToAction("index");
            }

            if (_context.Features.Count() == 2)
            {
                return RedirectToAction("index");
            }

            string rootPath = _env.WebRootPath;
            var path = Path.Combine(rootPath, "uploads/Feature", features.FeatureImg);
            System.IO.File.Delete(path);

            _context.Features.Remove(features);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
    }
}
