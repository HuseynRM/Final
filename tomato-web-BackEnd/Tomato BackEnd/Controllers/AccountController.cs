using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using System.IO;
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
        private readonly IWebHostEnvironment _env;
        public AccountController(AppDbContext context, 
            UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IWebHostEnvironment env)
        {
            _context = context;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userManager = userManager;
            _env = env;
        }
        #region CreateRole
        //public async Task<IActionResult> CreateRole()
        //{
        //    IdentityRole identityRole1 = new IdentityRole("Member");
        //    IdentityRole identityRole2 = new IdentityRole("Admin");


        //    await _roleManager.CreateAsync(identityRole1);
        //    await _roleManager.CreateAsync(identityRole2);

        //    return Content("ok");
        //}
        #endregion
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

            AppUser existUser = await _userManager.FindByEmailAsync(registerModel.Email);
            if (existUser != null)
            {
                ModelState.AddModelError("Email", "Email already taken");
                return View();
            }
            AppUser newUser = new AppUser()
            {
                Email = registerModel.Email,
                UserName = registerModel.UserName,
                IsAdmin = false,
            };

            IdentityResult identityResult = await _userManager.CreateAsync(newUser, registerModel.Password);

            if (!identityResult.Succeeded)
            {
                foreach (IdentityError identityError in identityResult.Errors)
                {
                    ModelState.AddModelError("", identityError.Description);
                }
                return View(registerModel);
            }

            await _userManager.AddToRoleAsync(newUser, "Member");
            await _signInManager.SignInAsync(newUser, true);

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Web Tomato", "webtomato31@gmail.com"));
            message.To.Add(new MailboxAddress(newUser.UserName, newUser.Email));
            message.Subject = "Email Tesdiqleyin";

            string emailbody = string.Empty;

            using (StreamReader stream = new StreamReader(Path.Combine(_env.WebRootPath, "templates", "emailconfirm.html")))
            {
                emailbody = stream.ReadToEnd();
            }

            string emailconfirmtokent = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);

            string url = Url.Action("confirmemail", "account", new { Id = newUser.Id, token = emailconfirmtokent }, Request.Scheme);

            emailbody = emailbody.Replace("{{fullName}}", $"{newUser.UserName}").Replace("{{url}}", $"{url}");

            message.Body = new TextPart(TextFormat.Html) { Text = emailbody };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("webtomato31@gmail.com", "huseyn123");
            smtp.Send(message);
            smtp.Disconnect(true);

            return RedirectToAction("index", "home");
        }
        public async Task<IActionResult> ConfirmEmail(string Id, string token)
        {
            if (string.IsNullOrWhiteSpace(Id) || string.IsNullOrWhiteSpace(token))
            {
                return NotFound();
            }

            AppUser appUser = await _userManager.FindByIdAsync(Id);

            if (appUser == null)
            {
                return NotFound();
            }

            IdentityResult identityResult = await _userManager.ConfirmEmailAsync(appUser, token);
            if (!identityResult.Succeeded)
            {
                return NotFound();
            }

            return RedirectToAction("Login");
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgetPassword(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return NotFound();

            AppUser appUser = await _userManager.FindByEmailAsync(email);

            if (appUser == null)
                return NotFound();

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Web Tomato", "webtomato31@gmail.com"));
            message.To.Add(new MailboxAddress(appUser.UserName, appUser.Email));
            message.Subject = "Reset Password";

            string emailbody = string.Empty;

            using (StreamReader stream = new StreamReader(Path.Combine(_env.WebRootPath, "templates", "forgetpassword.html")))
            {
                emailbody = stream.ReadToEnd();
            }

            string forgetpasswordtoken = await _userManager.GeneratePasswordResetTokenAsync(appUser);

            string url = Url.Action("changepassword", "account", new { Id = appUser.Id, token = forgetpasswordtoken }, Request.Scheme);

            emailbody = emailbody.Replace("{{fullName}}", $"{appUser.UserName} ").Replace("{{url}}", $"{url}");

            message.Body = new TextPart(TextFormat.Html) { Text = emailbody };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("webtomato31@gmail.com", "huseyn123");
            smtp.Send(message);
            smtp.Disconnect(true);

            return View();
        }

        public async Task<IActionResult> ChangePassword(string Id, string token)
        {
            if (string.IsNullOrWhiteSpace(Id) || string.IsNullOrWhiteSpace(token))
            {
                return NotFound();
            }

            AppUser appUser = await _userManager.FindByIdAsync(Id);

            if (appUser == null)
            {
                return NotFound();
            }

            ResetPasswordVM resetPasswordVM = new ResetPasswordVM
            {
                Id = Id,
                Token = token
            };

            return View(resetPasswordVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ResetPasswordVM resetPasswordVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (string.IsNullOrWhiteSpace(resetPasswordVM.Id) || string.IsNullOrWhiteSpace(resetPasswordVM.Token))
            {
                return NotFound();
            }

            AppUser appUser = await _userManager.FindByIdAsync(resetPasswordVM.Id);

            if (appUser == null)
            {
                return NotFound();
            }

            IdentityResult identityResult = await _userManager.ResetPasswordAsync(appUser, resetPasswordVM.Token, resetPasswordVM.Password);

            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(resetPasswordVM);
            }

            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(MemberLoginModel loginModel)
        {

            AppUser user = await _userManager.FindByEmailAsync(loginModel.Email);

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

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login");
        }

    }
}
