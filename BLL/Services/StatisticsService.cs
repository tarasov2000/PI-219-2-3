using AutoMapper;
using BLL.DTO.Shop;
using BLL.Entities;
using BLL.Enums;
using BLL.Interfaces;
using Repository.Interfaces;
using System.Collections.Generic;

namespace BLL.Services
{
    public class StatisticsService : IStatisticsService
    {
        private IUnitOfWork db;
        private IMapper mapper;

        public StatisticsService(IUnitOfWork db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public int GetCancelOrder()
        {
            var orders = db.Orders.GetAll();
            IEnumerable<OrderDTO> ordersDTO = mapper.Map<IEnumerable<OrderDTO>>(orders);

            int count = 0;
            foreach(OrderDTO order in ordersDTO)
            {
                if (order.Status == OrderStatusDTO.Cancelled)
                {
                    count++;
                }
            }

            return count;
        }

        public Statistic GetProductStatistic(int Id)
        {
            var productOrders = db.Products.Get(Id).Orders;
            IEnumerable<OrderDTO> orders = mapper.Map<IEnumerable<OrderDTO>>(productOrders);

            Statistic statistic = new Statistic();
            if(orders != null)
            {
                foreach(OrderDTO order in orders)
                {
                    if(order.Status == OrderStatusDTO.Completed)
                    {
                        statistic.Count++;
                        statistic.Money += order.Price;
                    }
                }
            }

            return statistic;
        }

        public Statistic GetStatAllOrder()
        {
            var orders = db.Orders.GetAll();
            IEnumerable<OrderDTO> ordersDTO = mapper.Map<IEnumerable<OrderDTO>>(orders);

            Statistic statistic = new Statistic();
            if (ordersDTO != null)
            {
                foreach(OrderDTO order in ordersDTO)
                {
                    if(order.Status == OrderStatusDTO.Completed)
                    {
                        statistic.Money += order.Price;
                        foreach (ProductDTO product in order.Products)
                        {
                            statistic.Count++;
                        }
                    }
                    
                }
            }

            return statistic;
        }
    }
}
