using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.Data
{
    public  class DatabaseContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>().HasMany(p => p.Orders).WithMany(o => o.OrderedProducts);
            builder.Entity<Order>().HasOne(o => o.Customer).WithMany(c => c.Orders);
            builder.Entity<Order>().HasOne(o => o.Review).WithOne(r => r.Order).HasForeignKey<Review>(r => r.OrderId).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Review>().HasOne(r => r.Order).WithOne(o => o.Review).HasForeignKey<Order>(o => o.ReviewId).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Review>().HasOne(r => r.Author).WithMany(a => a.Reviews);
            builder.Entity<Category>().HasMany(c => c.Products).WithOne(p => p.Category);
            

        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);

            builder.UseLazyLoadingProxies();
        }

    }
}
