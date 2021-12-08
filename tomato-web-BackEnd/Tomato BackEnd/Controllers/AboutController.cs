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
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            AboutVM aboutVM = new AboutVM()
            {
                AboutStory = await _context.AboutStory.FirstOrDefaultAsync(),
                SpecialServices = await _context.SpecialService.ToListAsync(),
                AboutTeams = await _context.AboutTeams.ToListAsync()
            };
            return View(aboutVM);
        }
    }
}
