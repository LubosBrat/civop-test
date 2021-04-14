using System.Data.Entity;
using CivopApp.Domain;
using CivopApp.Migrations;

namespace CivopApp.Core
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, Configuration>());
        }

        /// <summary>
        /// Products table
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Orders table
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Cross table between Products and Orders
        /// </summary>
        public DbSet<OrderProduct> OrderProducts { get; set; }
    }
}