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
    public class MenuController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public MenuController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.SpecialService.Count() / 4m);
            List<MenuList> menu =
                await _context.MenuLists.Include(a=>a.MenuCatagory).Skip((page - 1) * 4).Take(4).ToListAsync();
            return View(menu);
        }
        public IActionResult Create()
        {
            ViewBag.Categories = _context.MenuCatagories.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

    }
}
