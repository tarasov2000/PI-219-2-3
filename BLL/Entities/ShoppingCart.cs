using BLL.DTO.Shop;
using System.Collections.Generic;

namespace BLL.Entities
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Products = new List<ProductDTO>();
        }

        public List<ProductDTO> Products { get; set; }
        public double Price { get; set; }
    }
}
