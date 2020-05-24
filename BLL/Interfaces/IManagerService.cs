using BLL.DTO.Shop;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IManagerService
    {
        bool ConfirmOrder(int id);
        bool DeclineOrder(int id);

        OrderDTO GetOrder(int id);
        IEnumerable<OrderDTO> GetOrders();
    }
}
