using AutoMapper;
using DAL.Contexts;
using DAL.Entities.Shop;
using Repository.Entities.Shop;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;

namespace Repository.Repositories
{
    class OrderRepository : IRepository<OrderRepo>
    {
        private ShopContext db;
        private IMapper mapper;

        public OrderRepository(ShopContext shopContext, IMapper mapper)
        {
            db = shopContext;
            this.mapper = mapper;
        }

        public void Create(OrderRepo orderRepo)
        {
            Order order = mapper.Map<OrderRepo, Order>(orderRepo);
            db.Orders.Add(order);
        }

        public void Delete(OrderRepo orderRepo)
        {
            Order order = mapper.Map<OrderRepo, Order>(orderRepo);
            db.Orders.Remove(order);
        }

        public OrderRepo Get(int id)
        {
            return mapper.Map<Order, OrderRepo>(db.Orders.Find(id));
        }

        public IEnumerable<OrderRepo> GetAll()
        {
            return mapper.Map<IEnumerable<Order>, IEnumerable<OrderRepo>>(db.Orders);
        }

        public void Update(OrderRepo orderRepo)
        {
            Order order = mapper.Map<OrderRepo, Order>(orderRepo);
            db.Entry(order).State = EntityState.Modified;
        }
    }
}
