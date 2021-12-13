using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomato_BackEnd.DAL;
using Tomato_BackEnd.ViewModels;

namespace Tomato_BackEnd.Controllers
{
    public class MenuListController : Controller
    {
        private readonly AppDbContext _context;
        public MenuListController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            MenuListVM menuListVM = new MenuListVM()
            {
                MenuCatagories = await _context.MenuCatagories.ToListAsync(),
                MenuLists = await _context.MenuLists.ToListAsync(),
                Settings = await _context.Settings.ToListAsync()
            };
            return View(menuListVM);
        }
    }
}
