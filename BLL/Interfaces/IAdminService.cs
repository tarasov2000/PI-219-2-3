using BLL.DTO.Shop;

namespace BLL.Interfaces
{
    public interface IAdminService
    {
        bool AddProduct(ProductDTO productDTO);
        bool UpdateProduct(ProductDTO productDTO);
        bool RemoveProduct(int id);

        bool AddCategory(CategoryDTO categoryDTO);
        bool UpdateCategory(CategoryDTO categoryDTO);
        bool RemoveCategory(int id);
    }
}
