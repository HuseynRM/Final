using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomato_BackEnd.Models;

namespace Tomato_BackEnd.DAL
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public virtual DbSet<AboutStory> AboutStory { get; set; }
        public virtual DbSet<SpecialService> SpecialService { get; set; }
        public virtual DbSet<AboutTeam> AboutTeams { get; set; }
        public virtual DbSet<AboutTestimonial> AboutTestimonials { get; set; }
        public virtual  DbSet<Settings> Settings { get; set; }
        public virtual DbSet<RestaurantHome> RestaurantHomes { get; set; }
        public virtual DbSet<HomeSpecial> HomeSpecials { get; set; }
        public virtual DbSet<Features> Features { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual  DbSet<ReservationInfo> ReservationInfo { get; set; }
        public virtual DbSet<ShopCatagory> ShopCatagories { get; set; }
        public virtual DbSet<ShopList> ShopLists { get; set; }
        public virtual DbSet<MenuCatagory> MenuCatagories { get; set; }
        public virtual DbSet<MenuList> MenuLists { get; set; }
        public virtual DbSet<ProductSingle> ProductSingles { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
    }
}
