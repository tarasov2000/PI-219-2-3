using System.Collections.Generic;

namespace PL.Models.Shop
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ProductViewModel> Products { get; set; }

        public CategoryViewModel()
        {
            Products = new List<ProductViewModel>();
        }
    }
}