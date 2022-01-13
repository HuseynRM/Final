using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomato_BackEnd.DAL;
using Tomato_BackEnd.Models;
using Tomato_BackEnd.ViewModels;

namespace Tomato_BackEnd.Controllers
{
    public class ProductListController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public ProductListController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(int? categoryId,int page=1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.ShopLists.Count() / 4m);

            List<ShopList> ShopList = new List<ShopList>();
            if (categoryId == null)
            {
                ShopList = await _context.ShopLists.Include(x => x.ShopCatagory).Skip((page - 1) * 6).Take(6).ToListAsync();
            }
            else
            {
                ViewBag.SelectedCategoryId = categoryId;
                ShopList = await _context.ShopLists.Include(x => x.ShopCatagory).Skip((page-1)*6).Take(6).Where(x => x.ShopCatagoryId == categoryId).ToListAsync();
            }
            ProductListVM productListVM = new ProductListVM()
            {
                ShopLists = ShopList,
                
                ShopCatagorys = await _context.ShopCatagories.Include(x => x.ShopLists).ToListAsync(),
                

            };
            return View(productListVM);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            ShopList shopList = await _context.ShopLists.Include(x => x.ProductSingles).FirstOrDefaultAsync(x => x.Id == id);
            ViewBag.Shops = _context.ShopLists.OrderByDescending(x => x.Id).Take(4).ToList();
            if (shopList == null)
            {
                return NotFound();
            }
            return View(shopList);
        }
        public async Task<IActionResult> AddBasket(int? Id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (Id == null)
                return NotFound();

            ShopList product = await _context.ShopLists
                .FirstOrDefaultAsync(p => p.Id == Id);

            if (product == null)
                return NotFound();

            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);

            Basket existedbasketProduct = await _context.Baskets
                .FirstOrDefaultAsync(b => b.IsDeleted == false && b.AppUserId == appUser.Id && b.ShopListId == product.Id);

            if (existedbasketProduct != null)
            {
                existedbasketProduct.Count += 1;
            }
            else
            {
                Basket basketProduct = new Basket
                {
                    AppUserId = appUser.Id,
                    ShopListId = product.Id,
                    Count = 1,
                    CreatedAt = DateTime.Now
                };

                await _context.Baskets.AddAsync(basketProduct);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "ProductList");
        }
        public async Task<IActionResult> ShowBasket()
        {
            string strBasket =  HttpContext.Request.Cookies["basket"];

            List<BasketVM> products = null;

            if (strBasket == null)
            {
                products = new List<BasketVM>();
            }
            else
            {
                products = JsonConvert.DeserializeObject<List<BasketVM>>(strBasket);
            }
            return Json(products);
        }

        [HttpPost]
        public async Task<JsonResult> DeleteBasket(int? Id)
        {
            string Message = string.Empty;
            try
            {
                AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);

                if (Id == null)
                    Message = "Nullable";

                List<Basket> basketProducts = await _context.Baskets.Include(b => b.ShopList)
                        .Where(b => b.IsDeleted == false).ToListAsync();

                Basket basketProduct = basketProducts
                    .FirstOrDefault(b => b.Id == Id && b.IsDeleted == false && b.AppUserId == appUser.Id);

                if (basketProduct == null)
                    Message = "Not Found";

                basketProduct.IsDeleted = true;

                _context.SaveChanges();
            }
            catch (Exception)
            {
                Message = "Project Error";
            } 

            return Json(new { error = Message, success = Message == string.Empty });
        }
    }
}
