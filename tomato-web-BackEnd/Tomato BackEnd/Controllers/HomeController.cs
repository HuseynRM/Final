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
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Settings = await _context.Settings.ToListAsync(),
                RestaurantHome = await _context.RestaurantHomes.FirstOrDefaultAsync(),
                HomeSpecials = await _context.HomeSpecials.ToListAsync(),
                Features = await _context.Features.ToListAsync(),
                AboutTestimonial = await _context.AboutTestimonials.ToListAsync()
            };
            return View(homeVM);
        }
    }
}
