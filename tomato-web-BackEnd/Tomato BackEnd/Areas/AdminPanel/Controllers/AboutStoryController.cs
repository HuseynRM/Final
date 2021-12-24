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
    public class AboutStoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AboutStoryController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.SpecialService.Count() / 4m);
            List<AboutStory> stories = await _context.AboutStory.Skip((page - 1) * 4).Take(4).ToListAsync();

            return View(stories);
        }
        public async Task<IActionResult> Edit(int id)
        {
            AboutStory story = await _context.AboutStory.FirstOrDefaultAsync(x => x.Id == id);
            if (story == null)
            {
                return RedirectToAction("index");
            }
            return View(story);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AboutStory story)
        {
            AboutStory existstory = await _context.AboutStory.FirstOrDefaultAsync(x => x.Id == id);
            if (existstory == null)
            {
                return RedirectToAction("index");
            }
            if (story.StoryImgFile != null)
            {
                if (story.StoryImgFile.ContentType != "image/png" && story.StoryImgFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (story.StoryImgFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("ImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + story.StoryImgFile.FileName;
                var path = Path.Combine(rootPath, "uploads/story", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    story.StoryImgFile.CopyTo(stream);
                }
                if (existstory.StoryImg != null)
                {
                    string existPath = Path.Combine(_env.WebRootPath, "uploads/story", existstory.StoryImg);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }
                }
                existstory.StoryImg = fileName;
            }

            if (!ModelState.IsValid)
            {
                return View();
            }
            existstory.StoryContent = story.StoryContent;

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            AboutStory story = await _context.AboutStory.FirstOrDefaultAsync(x => x.Id == id);
            if (story == null)
            {
                return RedirectToAction("index");
            }
            if (_context.SpecialService.Count() == 2)
            {
                return RedirectToAction("index");
            }

;
            string rootPath = _env.WebRootPath;
            var path = Path.Combine(rootPath, "uploads/story", story.StoryImg);
            System.IO.File.Delete(path);


            _context.AboutStory.Remove(story);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AboutStory story)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (story.StoryImgFile != null)
            {
                if (story.StoryImgFile.ContentType != "image/png" && story.StoryImgFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Jpeg ve ya png formatinda file daxil edilmelidir");
                    return View();
                }
                if (story.StoryImgFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("ImageFile", "File olcusu 5mb-dan cox olmaz!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + story.StoryImgFile.FileName;
                var path = Path.Combine(rootPath, "uploads/story", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    story.StoryImgFile.CopyTo(stream);
                }
                story.StoryImg = fileName;
            }
            await _context.AboutStory.AddAsync(story);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }

    }
}
