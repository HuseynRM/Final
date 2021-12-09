using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tomato_BackEnd.Models;

namespace Tomato_BackEnd.DAL
{
    public class AppDbContext:DbContext
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

    }
}
