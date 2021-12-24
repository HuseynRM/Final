using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomato_BackEnd.DAL;
using Tomato_BackEnd.Models;

namespace Tomato_BackEnd.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class AboutTestimonialController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public AboutTestimonialController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.SpecialService.Count() / 4m);
            List<AboutTestimonial> testimonials = await _context.AboutTestimonials.Skip((page - 1) * 4).Take(4).ToListAsync();

            return View(testimonials);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AboutTestimonial aboutTestimonial)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _context.AboutTestimonials.AddAsync(aboutTestimonial);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            AboutTestimonial aboutTestimonial = await _context.AboutTestimonials.FirstOrDefaultAsync(x => x.Id == id);
            if (aboutTestimonial == null)
            {
                return RedirectToAction("index");
            }
            if (_context.SpecialService.Count() == 2)
            {
                return RedirectToAction("index");
            }
            _context.AboutTestimonials.Remove(aboutTestimonial);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            AboutTestimonial aboutTestimonial = await _context.AboutTestimonials.FirstOrDefaultAsync(x => x.Id == id);
            if (aboutTestimonial == null)
            {
                return RedirectToAction("index");
            }
            return View(aboutTestimonial);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id , AboutTestimonial aboutTestimonial)
        {
            AboutTestimonial existTestimonial = await _context.AboutTestimonials.FirstOrDefaultAsync(x => x.Id == id);
            if (existTestimonial == null)
            {
                return RedirectToAction("index");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }
            existTestimonial.QuoteAuthor = aboutTestimonial.QuoteAuthor;

            existTestimonial.QuoteBody = aboutTestimonial.QuoteBody;

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
    }
}
