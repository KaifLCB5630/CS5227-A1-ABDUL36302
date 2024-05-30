using CS5227_A1_ABDUL36302.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace CS5227_ABDUL36302.data
{
    public class appDBcontext : IdentityDbContext<ApplicationUser>
    {
        public appDBcontext(DbContextOptions<appDBcontext> options) : base(options)
        {

        }
        public DbSet<FoodItem> FoodItems { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var admin = new IdentityRole("admin");
            admin.NormalizedName = "admin";

            var client = new IdentityRole("client");
            client.NormalizedName = "client";

            var seller = new IdentityRole("seller");
            seller.NormalizedName = "seller";

            builder.Entity<IdentityRole>().HasData(admin, client, seller);
        }
    }
}
