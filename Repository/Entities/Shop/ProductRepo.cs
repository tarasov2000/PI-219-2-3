using System.Collections.Generic;

namespace Repository.Entities.Shop
{
    public class ProductRepo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public ICollection<OrderRepo> Orders { get; set; } 

        public int CategoryId { get; set; }

        public ProductRepo()
        {
            Orders = new List<OrderRepo>();
        }
    }
}
