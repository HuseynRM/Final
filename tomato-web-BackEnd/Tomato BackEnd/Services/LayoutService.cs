using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomato_BackEnd.DAL;
using Tomato_BackEnd.Models;

namespace Tomato_BackEnd.Services
{
    public class LayoutService
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;

        public LayoutService(IHttpContextAccessor httpContext, UserManager<AppUser> userManager, AppDbContext context)
        {
            _httpContext = httpContext;
            _userManager = userManager;
            _context = context;
        }
        public async Task<List<Basket>> GetBasket()
        {
            List<Basket> basketProducts = new List<Basket>();

            if (_httpContext.HttpContext.User.Identity.IsAuthenticated)
            {
                AppUser appUser = await _userManager.FindByNameAsync(_httpContext.HttpContext.User.Identity.Name);

                basketProducts = await _context.Baskets.
                    Include(b=>b.ShopList).
                    Where(b => b.IsDeleted == false && b.AppUserId == appUser.Id)
                   .ToListAsync();
            }

            return basketProducts;
        }
    }
}
