using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomato_BackEnd.Models;
using Tomato_BackEnd.ViewModels;

namespace Tomato_BackEnd.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [Authorize(Roles = "Member,Admin")]
        public async Task<IActionResult> Index()
        {
            IEnumerable<AppUser> appUsers = await _userManager.Users.ToListAsync();

            List<AppUserVM> appUserVMs = new List<AppUserVM>();

            foreach (AppUser appUser in appUsers)
            {
                AppUserVM appUserVM = new AppUserVM
                {
                    Id = appUser.Id,
                    Email = appUser.Email,
                    UserName = appUser.UserName,
                    IsDeleted = appUser.IsDeleted,
                    Role = (await _userManager.GetRolesAsync(appUser))[0],
                };

                appUserVMs.Add(appUserVM);
            }

            return View(appUserVMs);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeRole(string Id)
        {
            if (Id == null) return NotFound();

            AppUser appUser = await _userManager.FindByIdAsync(Id);

            if (appUser == null) return NotFound();

            AppUserVM appUserVM = new AppUserVM
            {
                Id = appUser.Id,
                Email = appUser.Email,
                Role = (await _userManager.GetRolesAsync(appUser))[0],
                UserName = appUser.UserName,
                IsDeleted = appUser.IsDeleted,
                Roles = new List<string> { "Admin", "Member" }
            };

            return View(appUserVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeRole(string Id, string Roles)
        {
            if (Id == null) return NotFound();

            AppUser appUser = await _userManager.FindByIdAsync(Id);

            if (appUser == null) return NotFound();

            string oldRole = (await _userManager.GetRolesAsync(appUser))[0];

            

            await _userManager.RemoveFromRoleAsync(appUser, oldRole);

            await _userManager.AddToRoleAsync(appUser, Roles);

            return RedirectToAction("Index");
        }

    }
}
