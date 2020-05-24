using System.Collections.Generic;

namespace DAL.Entities.Shop
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public Product()
        {
            Orders = new List<Order>();
        }
    }
}
