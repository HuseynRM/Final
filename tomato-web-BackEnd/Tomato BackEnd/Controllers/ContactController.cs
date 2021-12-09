using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomato_BackEnd.DAL;
using Tomato_BackEnd.Models;
using Tomato_BackEnd.ViewModels;

namespace Tomato_BackEnd.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ContactController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            ContactVM contactVM = new ContactVM() 
            { 
                Settings = await _context.Settings.ToListAsync()
            };
            return View(contactVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GetContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("index");
            }
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
