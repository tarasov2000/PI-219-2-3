using AutoMapper;
using BLL.DTO.Shop;
using BLL.Enums;
using BLL.Interfaces;
using Repository.Entities.Shop;
using Repository.Interfaces;
using System.Collections.Generic;

namespace BLL.Services
{
    public class ManagerService : IManagerService
    {
        private IUnitOfWork db;
        private IMapper mapper;

        public ManagerService(IUnitOfWork db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public bool ConfirmOrder(int id)
        {
            var order = mapper.Map<OrderDTO>(db.Orders.Get(id));

            if (order.Status == OrderStatusDTO.Active)
            {
                order.Status = OrderStatusDTO.Completed;

                var orderRepo = mapper.Map<OrderRepo>(order);
                db.Orders.Update(orderRepo);
                db.Save();

                return true;
            }

            return false;
        }

        public bool DeclineOrder(int id)
        {
            var order = mapper.Map<OrderDTO>(db.Orders.Get(id));

            if (order.Status == OrderStatusDTO.Active)
            {
                order.Status = OrderStatusDTO.Cancelled;

                var orderRepo = mapper.Map<OrderRepo>(order);
                db.Orders.Update(orderRepo);
                db.Save();

                return true;
            }

            return false;
        }

        public OrderDTO GetOrder(int id)
        {
            var order = db.Orders.Get(id);
            return mapper.Map<OrderDTO>(order);
        }

        public IEnumerable<OrderDTO> GetOrders()
        {
            return mapper.Map<IEnumerable<OrderDTO>>(db.Orders.GetAll());
        }
    }
}
