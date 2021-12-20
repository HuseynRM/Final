using Microsoft.AspNetCore.Identity;
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
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(MemberRegisterModel registerModel)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser existUser = await _userManager.FindByNameAsync(registerModel.Email);
            if (existUser != null)
            {
                ModelState.AddModelError("Email", "Email already taken");
                return View();
            }
            AppUser newUser = new AppUser()
            {
                Email = registerModel.Email,
                IsAdmin = false,
            };

            var result = await _userManager.CreateAsync(newUser, registerModel.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    if (item.Code == "PasswordTooShort")
                    {
                        item.Description = "Passwordun uzunlugu 8-den kicik ola bilmez";
                    }
                    else if (item.Description == "ConfirmedPassword and Password do not match.")
                    {
                        item.Description = "Alinmadi";
                    }
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }

            await _userManager.AddToRoleAsync(newUser, "Member");
            await _signInManager.SignInAsync(newUser, true);

            return RedirectToAction("index", "home");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(MemberLoginModel loginModel)
        {

            AppUser user = await _userManager.FindByNameAsync(loginModel.Email);

            if (user == null || user.IsAdmin)
            {
                ModelState.AddModelError("", "Email or Password is incorrect");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, loginModel.IsPersistent, true);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Email or Password is incorrect");
                return View();
            }

            return RedirectToAction("index", "home");
        }
    }
}
