using BLL.DTO.Shop;
using BLL.Enums;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IOutputService
    {
        ProductDTO Get(int id);
        IEnumerable<ProductDTO> SearchByName(string name);
        IEnumerable<ProductDTO> GetByCategory(int categoryId, SortCriteria sortCriteria);
        IEnumerable<ProductDTO> FilterByCompany(string[] companies);
        IEnumerable<ProductDTO> FilterByPrice(double leftBound, double rightBound);
    }
}
