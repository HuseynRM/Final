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
            ViewBag.TotalPageCount = Math.Ceiling(_context.MenuLists.Count() / 4m);
            List<MenuList> menu =
                await _context.MenuLists.Include(a => a.MenuCatagory).Skip((page - 1) * 4).Take(4).ToListAsync();
            return View(menu);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.MenuCatagories.ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MenuList menu)
        {
            ViewBag.Categories = await _context.MenuCatagories.ToListAsync();
            if (!_context.MenuCatagories.Any(x => x.Id == menu.MenuCatagoryId))
            {
                ModelState.AddModelError("MenuCatagoryId", "Xetaniz var!");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _context.MenuLists.AddAsync(menu);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            MenuList menu = await _context.MenuLists.FirstOrDefaultAsync(x => x.Id == id);
            if (menu == null)
            {
                return RedirectToAction("index");
            }


            _context.MenuLists.Remove(menu);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Categories = await _context.MenuCatagories.ToListAsync();
            MenuList menu = await _context.MenuLists.FirstOrDefaultAsync(x => x.Id == id);
            if (menu == null)
            {
                return RedirectToAction("index");
            }

            return View(menu);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MenuList menuList)
        {
            ViewBag.Categories = _context.MenuCatagories.ToList();

            MenuList existmennu = await _context.MenuLists.FirstOrDefaultAsync(x => x.Id == id);
            if (!await _context.MenuCatagories.AnyAsync(x => x.Id == menuList.MenuCatagoryId)) return RedirectToAction("index");
            if (existmennu == null)
            {
                return RedirectToAction("index");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            existmennu.Name = menuList.Name;
            existmennu.Price = menuList.Price;
            existmennu.Desc = menuList.Desc;
            existmennu.MenuCatagoryId = menuList.MenuCatagoryId;

            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
    }
}
