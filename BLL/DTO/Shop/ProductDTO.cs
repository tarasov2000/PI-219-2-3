using System.Collections.Generic;

namespace BLL.DTO.Shop
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public int CategoryId { get; set; }

        public ICollection<OrderDTO> Orders { get; set; }

        public ProductDTO()
        {
            Orders = new List<OrderDTO>();
        }
    }
}
