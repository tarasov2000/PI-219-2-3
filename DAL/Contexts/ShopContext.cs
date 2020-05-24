using DAL.Entities.Shop;
using System.Data.Entity;

namespace DAL.Contexts
{
    public class ShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ShopContext(string connectionString) : base(connectionString) { }
    }
}
