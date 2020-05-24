using DAL.Entities.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace DAL.Contexts
{
    public class UserContext : IdentityDbContext<ShopUser>
    {
        public UserContext(string connectionString) : base(connectionString) { }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
