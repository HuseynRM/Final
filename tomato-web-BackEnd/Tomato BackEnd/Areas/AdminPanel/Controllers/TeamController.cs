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
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TeamController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.AboutTeams.Count() / 4m);
            List<AboutTeam> Team = await _context.AboutTeams.Skip((page - 1) * 4).Take(4).ToListAsync();

            return View(Team);
        }
        public async Task<IActionResult> Edit(int id)
        {
            AboutTeam team = await _context.AboutTeams.FirstOrDefaultAsync(x => x.Id == id);
            if (team==null)
            {
                return RedirectToAction("index");
            }
            return View(team);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AboutTeam team)
        {
            AboutTeam existTeam = await _context.AboutTeams.FirstOrDefaultAsync(x => x.Id == id);
            if (existTeam == null)
            {
                return RedirectToAction("index");
            }
            if (team.TeamImgFile != null)
            {
                if (team.TeamImgFile.ContentType != "image/png" && team.TeamImgFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (team.TeamImgFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("ImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + team.TeamImgFile.FileName;
                var path = Path.Combine(rootPath, "uploads/ourteam", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    team.TeamImgFile.CopyTo(stream);
                }
                if (existTeam.TeamImg != null)
                {
                    string existPath = Path.Combine(_env.WebRootPath, "uploads/ourteam", existTeam.TeamImg);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }
                }
                existTeam.TeamImg = fileName;
            }

            if (!ModelState.IsValid)
            {
                return View();
            }
            existTeam.CookName = team.CookName;

            existTeam.Designation = team.Designation;

            existTeam.Facebook = team.Facebook;

            existTeam.Google = team.Google;

            existTeam.Twiter = team.Twiter;

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            AboutTeam team = await _context.AboutTeams.FirstOrDefaultAsync(x => x.Id == id);
            if (team == null)
            {
                return RedirectToAction("index");
            }
            if (_context.SpecialService.Count() == 2)
            {
                return RedirectToAction("index");
            }

;
            string rootPath = _env.WebRootPath;
            var path = Path.Combine(rootPath, "uploads/ourteam", team.TeamImg);
            System.IO.File.Delete(path);


            _context.AboutTeams.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AboutTeam team)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (team.TeamImgFile != null)
            {
                if (team.TeamImgFile.ContentType != "image/png" && team.TeamImgFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (team.TeamImgFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("ImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + team.TeamImgFile.FileName;
                var path = Path.Combine(rootPath, "uploads/ourteam", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    team.TeamImgFile.CopyTo(stream);
                }
                team.TeamImg = fileName;
            }
            await _context.AboutTeams.AddAsync(team);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
    }
}
