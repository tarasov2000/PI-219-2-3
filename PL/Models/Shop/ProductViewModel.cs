using System.Collections.Generic;

namespace PL.Models.Shop
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public int CategoryId { get; set; }

        public ICollection<OrderViewModel> Orders;

        public ProductViewModel()
        {
            Orders = new List<OrderViewModel>();
        }
    }
}