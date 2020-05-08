using Microsoft.EntityFrameworkCore;
using ODA.Entity;
using System;

namespace ODA.DataAccess
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public ApplicationDbContext() : base(GetDefaultDbContextOptions())
        {
        }

        private static DbContextOptions GetDefaultDbContextOptions()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer("Data Source=127.0.0.1;Initial Catalog=oda_db;Persist Security Info=True;User ID=sa;Password=admin@2020;");
            return builder.Options;
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MapPopularPlace> MapPopularPlaces { get; set; }

    }
}
