using System.Collections.Generic;

namespace Repository.Entities.Shop
{
    public class CategoryRepo
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ProductRepo> Products { get; set; }

        public CategoryRepo()
        {
            Products = new List<ProductRepo>();
        }
    }
}
