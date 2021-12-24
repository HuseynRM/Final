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
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SettingController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.Settings.Count() / 4m);
            Settings setting = _context.Settings.First();
            return View(setting);
        }
        public async Task<IActionResult> Delete(int id)
        {
            Settings setting = await _context.Settings.FirstOrDefaultAsync(x => x.Id == id);
            if (setting == null)
            {
                return RedirectToAction("index");
            };
            if (_context.Settings.Count() == 1)
            {
                return RedirectToAction("index");
            }
            _context.Settings.Remove(setting);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            Settings setting = await _context.Settings.FirstOrDefaultAsync(x => x.Id == id);
            if (setting == null)
            {
                return RedirectToAction("index");
            }

            return View(setting);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Settings settings)
        {
            Settings existSetting = await _context.Settings.FirstOrDefaultAsync(x => x.Id == id);
            if (existSetting == null)
            {
                return RedirectToAction("index");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            existSetting.Facebook = settings.Facebook;

            existSetting.Google = settings.Google;

            existSetting.LinkIn = settings.LinkIn;

            existSetting.Location = settings.Location;

            existSetting.Mail = settings.Mail;

            existSetting.Phone = settings.Phone;

            existSetting.Pinteres = settings.Pinteres;

            existSetting.Twitter = settings.Twitter;

            existSetting.YouTube = settings.YouTube;

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
    }
}
