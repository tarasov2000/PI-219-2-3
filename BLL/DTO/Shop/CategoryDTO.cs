using System.Collections.Generic;

namespace BLL.DTO.Shop
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ProductDTO> Products { get; set; }

        public CategoryDTO()
        {
            Products = new List<ProductDTO>();
        }
    }
}

