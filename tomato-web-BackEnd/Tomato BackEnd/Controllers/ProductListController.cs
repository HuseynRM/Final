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
    public class ProductListController : Controller
    {
        private readonly AppDbContext _context;
        public ProductListController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? categoryId)
        {
            List<ShopList> ShopList = new List<ShopList>();
            if (categoryId == null)
            {
                ShopList = await _context.ShopLists.Include(x => x.ShopCatagory).ToListAsync();
            }
            else
            {
                ViewBag.SelectedCategoryId = categoryId;
                ShopList = await _context.ShopLists.Include(x => x.ShopCatagory).Where(x => x.ShopCatagoryId == categoryId).ToListAsync();
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
    }
}
