using DAL.Entities.Identity;
using Microsoft.AspNet.Identity;

namespace DAL.Identity
{
    public class ShopUserManager : UserManager<ShopUser>
    {
        public ShopUserManager(IUserStore<ShopUser> store) : base(store) { }
    }
}
