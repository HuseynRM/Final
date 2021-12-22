using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomato_BackEnd.DAL;
using Tomato_BackEnd.Models;

namespace Tomato_BackEnd.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SettingController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            Settings setting = _context.Settings.First();
            return View(setting);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Settings settings)
        {
            if (_context.Settings.Count() == 1)
            {
                ModelState.AddModelError("", "Yalniz 1 eded setting ola biler,yaratdiginiz settingi deyise bilersiz");
                return View();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Settings.Add(settings);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
