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
        public async Task<IActionResult> Index(int? categoryId, string search, int page = 1)
        {
            ViewBag.SelectedPage = page;

            ViewBag.SelectedPage = search;

            int totalCount;

            decimal totalPage;

            List<ShopList> shopLists = new List<ShopList>();

            if (categoryId==null)
            {
                shopLists = await _context.ShopLists.Include(x => x.ShopCatagory).Where(x => string.IsNullOrWhiteSpace(search) ? true : (x.ShopCatagory.CName.ToLower().Contains(search.ToLower())))
                .Skip((page - 1) * 6).Take(6).ToListAsync();
                totalCount = _context.ShopLists.Include(x => x.ShopCatagory).Where(x => string.IsNullOrWhiteSpace(search) ? true : (x.ShopCatagory.CName.ToLower().Contains(search.ToLower()))).Count();
            }
            else
            {
                ViewBag.SelectedCategoryId = categoryId;
                shopLists = _context.ShopLists.Include(x => x.ShopCatagory).Where(x => string.IsNullOrWhiteSpace(search) ? true : (x.ShopCatagory.CName.ToLower().Contains(search.ToLower())))
                .Where(x => x.ShopCatagoryId == categoryId).Skip((page - 1) * 6).Take(6).ToList();
                totalCount = _context.ShopLists.Include(x => x.ShopCatagory).Where(x => string.IsNullOrWhiteSpace(search) ? true : (x.ShopCatagory.CName.ToLower().Contains(search.ToLower())))
                .Where(x => x.ShopCatagoryId == categoryId).Count();
            }
            totalPage = Math.Ceiling(totalCount / 6m);

            ViewBag.TotalPageCount = totalPage;

            ProductListVM productListVM = new ProductListVM()
            {
                ShopLists = shopLists,
                ShopShopCatagorys = await _context.ShopCatagories.Include(x => x.ShopLists).ToListAsync(),
                Settings = await _context.Settings.ToListAsync()
            };
            return View(productListVM);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            ProductSingle product = await _context.ProductSingles.FirstOrDefaultAsync(x=>x.Id==id);
            ProductListVM productListVM = new ProductListVM()
            {
                Settings = await _context.Settings.ToListAsync(),
                ProductSingle = product
            };
            return View(productListVM);
        }
    }
}
