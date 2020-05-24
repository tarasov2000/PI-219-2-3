using BLL.Enums;
using System;
using System.Collections.Generic;

namespace BLL.DTO.Shop
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public OrderStatusDTO Status { get; set; }

        public ICollection<ProductDTO> Products { get; set; }

        public int UserProfileId { get; set; }

        public OrderDTO()
        {
            Products = new List<ProductDTO>();
        }
    }
}
