using AutoMapper;
using BLL.DTO.Shop;
using BLL.Entities;
using BLL.Enums;
using BLL.Interfaces;
using Repository.Entities.Shop;
using Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork db;
        private IMapper mapper;

        public UserService(IUnitOfWork db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public bool AddItem(ProductDTO productDTO, ShoppingCart shoppingCart)
        {
            if (productDTO != null)
            {
                shoppingCart.Products.Add(productDTO);
                return true;
            }

            return false;
        }

        public bool Clear(ShoppingCart shoppingCart)
        {
            if (shoppingCart.Products.Count != 0)
            {
                shoppingCart.Products = new List<ProductDTO>();
                return true;
            }

            return false;
        }

        public ShoppingCart ComposeCart(ShoppingCart shoppingCart)
        {
            var cartPrice = 0.00;

            foreach (var item in shoppingCart.Products)
            {
                cartPrice += item.Price;
            }

            var cart = new ShoppingCart
            {
                Products = shoppingCart.Products,
                Price = cartPrice
            };

            return cart;
        }

        public OrderDTO MakeOrder(ShoppingCart cart)
        {
            List<ProductDTO> items = new List<ProductDTO>();

            foreach (var item in cart.Products)
            {
                items.Add(item);
            }

            var order = new OrderDTO
            {
                Date = DateTime.Now,
                Price = cart.Price,
                Status = OrderStatusDTO.Active,
                Products = items
            };

            var orderRepo = mapper.Map<OrderRepo>(order);
            db.Orders.Create(orderRepo);

            return order;
        }

        public bool RemoveItem(ProductDTO productDTO, ShoppingCart shoppingCart)
        {
            return shoppingCart.Products.Remove(productDTO);
        }
    }
}
