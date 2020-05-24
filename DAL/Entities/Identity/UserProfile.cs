using DAL.Entities.Shop;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities.Identity
{
    public class UserProfile
    {
        [Key]
        [ForeignKey("ShopUser")]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }

        public virtual ShopUser ShopUser { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public UserProfile()
        {
            Orders = new List<Order>();
        }
    }
}
