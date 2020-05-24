using Repository.Enums;
using System;
using System.Collections.Generic;

namespace Repository.Entities.Shop
{
    public class OrderRepo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public OrderStatusRepo Status { get; set; }

        public ICollection<ProductRepo> Products { get; set; }

        public int UserProfileId { get; set; }

        public OrderRepo()
        {
            Products = new List<ProductRepo>();
        }
    }
}
