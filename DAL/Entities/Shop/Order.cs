using DAL.Entities.Identity;
using DAL.Enums;
using System;
using System.Collections.Generic;

namespace DAL.Entities.Shop
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public int UserProfileId { get; set; }


        public Order()
        {
            Products = new List<Product>();
        }
    }
}
