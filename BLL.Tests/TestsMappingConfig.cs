using AutoMapper;
using BLL.DTO.Identity;
using BLL.DTO.Shop;
using Repository.Entities.Identity;
using Repository.Entities.Shop;

namespace BLL.Tests
{
    public class TestsMappingConfig : Profile
    {
        public TestsMappingConfig()
        {
            CreateMap<CategoryDTO, CategoryRepo>().ReverseMap();
            CreateMap<ProductDTO, ProductRepo>().ReverseMap();
            CreateMap<OrderDTO, OrderRepo>().ReverseMap();
            CreateMap<UserDTO, UserRepo>().ReverseMap();
        }
    }
}
