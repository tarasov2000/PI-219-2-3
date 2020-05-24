using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Entities.Identity
{
    public class ShopUser : IdentityUser
    {
        public virtual UserProfile UserProfile { get; set; }
    }
}
