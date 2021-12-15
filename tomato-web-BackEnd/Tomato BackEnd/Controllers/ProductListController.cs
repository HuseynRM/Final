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
            var shopLists =  _context.ShopLists.AsQueryable();
            if (categoryId != null)
            {
                shopLists.Where(x => x.ShopCatagoryId == categoryId);
            }
            ProductListVM productListVM = new ProductListVM()
            {
                ShopLists = await shopLists.Include(x => x.ShopCatagory).ToListAsync(),
                Settings = await _context.Settings.ToListAsync(),
               ShopCatagorys = await _context.ShopCatagories.Include(x=>x.ShopLists).ToListAsync() 
            };
            return View(productListVM);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            ShopList shopList = await _context.ShopLists.Include(x=>x.ProductSingle).FirstOrDefaultAsync(x => x.Id == id);
            if (shopList == null)
            {
                return NotFound();
            }
            return View(shopList);
        }
    }
}
