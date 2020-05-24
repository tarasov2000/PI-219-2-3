using BLL.DTO.Shop;
using BLL.Entities;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        bool AddItem(ProductDTO productDTO, ShoppingCart shoppingCart);
        bool RemoveItem(ProductDTO productDTO, ShoppingCart shoppingCart);
        bool Clear(ShoppingCart shoppingCart);
        ShoppingCart ComposeCart(ShoppingCart shoppingCart);
        OrderDTO MakeOrder(ShoppingCart cart);
    }
}
