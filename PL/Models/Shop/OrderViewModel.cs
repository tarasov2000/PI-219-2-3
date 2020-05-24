using PL.Enums;
using System;
using System.Collections.Generic;

namespace PL.Models.Shop
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public OrderStatusViewModel Status { get; set; }

        public ICollection<ProductViewModel> Products { get; set; }

        public int UserProfileId { get; set; }

        public OrderViewModel()
        {
            Products = new List<ProductViewModel>();
        }
    }
}