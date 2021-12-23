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
    public class SpecialServiceController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SpecialServiceController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.SpecialService.Count() / 4m);
            List<SpecialService> testimonials = await _context.SpecialService.Skip((page - 1) * 4).Take(4).ToListAsync();

            return View(testimonials);
        }
        public  IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecialService specialService)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (specialService.ServiceIMgFile != null)
            {
                if (specialService.ServiceIMgFile.ContentType != "image/png" && specialService.ServiceIMgFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (specialService.ServiceIMgFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("ImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + specialService.ServiceIMgFile.FileName;
                var path = Path.Combine(rootPath, "uploads/testimonial", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    specialService.ServiceIMgFile.CopyTo(stream);
                }
                specialService.ServiceIMg = fileName;
            }
            await _context.SpecialService.AddAsync(specialService);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
        public async  Task<IActionResult> Delete(int id)
        {
            SpecialService testimonial = await _context.SpecialService.FirstOrDefaultAsync(x => x.Id == id);
            if (testimonial == null)
            {
                return RedirectToAction("index");
            }
            if (_context.SpecialService.Count() == 2)
            {
                return RedirectToAction("index");
            }

;
            string rootPath = _env.WebRootPath;
            var path = Path.Combine(rootPath, "uploads/testimonial", testimonial.ServiceIMg);
            System.IO.File.Delete(path);


            _context.SpecialService.Remove(testimonial);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            SpecialService testimonial =await _context.SpecialService.FirstOrDefaultAsync(x => x.Id == id);
            if (testimonial == null)
            {
                return RedirectToAction("index");
            }

            return View(testimonial);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SpecialService testimonial)
        {
            SpecialService existTestimonial =await _context.SpecialService.FirstOrDefaultAsync(x => x.Id == id);
            if (existTestimonial == null)
            {
                return RedirectToAction("index");
            }
            if (testimonial.ServiceIMgFile != null)
            {
                if (testimonial.ServiceIMgFile.ContentType != "image/png" && testimonial.ServiceIMgFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (testimonial.ServiceIMgFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("ImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + testimonial.ServiceIMgFile.FileName;
                var path = Path.Combine(rootPath, "uploads/testimonial", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    testimonial.ServiceIMgFile.CopyTo(stream);
                }
                if (existTestimonial.ServiceIMg != null)
                {
                    string existPath = Path.Combine(_env.WebRootPath, "uploads/testimonial", existTestimonial.ServiceIMg);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }
                }
                existTestimonial.ServiceIMg = fileName;
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            existTestimonial.ServiceDesc = testimonial.ServiceDesc;

            existTestimonial.ServiceTitle = testimonial.ServiceTitle;

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
    }
}
