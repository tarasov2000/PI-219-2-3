using DAL.Entities.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Identity
{
    public class ShopRoleManager : RoleManager<ShopRole>
    {
        public ShopRoleManager(RoleStore<ShopRole> store) : base(store) { }
    }
}
