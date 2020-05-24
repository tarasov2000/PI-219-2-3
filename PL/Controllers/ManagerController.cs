using AutoMapper;
using BLL.Interfaces;
using PL.Models.Shop;
using System.Collections.Generic;
using System.Web.Http;

namespace PL.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerController : ApiController
    {
        IMapper mapper;
        IManagerService managerService;

        public ManagerController(IManagerService managerService, IMapper mapper)
        {
            this.mapper = mapper;
            this.managerService = managerService;
        }

        [HttpGet]
        [Route("api/ManagerPanel/orders/confirm+{id}")]
        public IHttpActionResult ConfirmOrder(int id)
        {
            return Ok(managerService.ConfirmOrder(id));
        }

        [HttpGet]
        [Route("api/ManagerPanel/orders/decline+{id}")]
        public IHttpActionResult DeclineOrder(int id)
        {
            return Ok(managerService.DeclineOrder(id));
        }

        [HttpGet]
        [Route("api/ManagerPanel/orders/{id}")]
        public IHttpActionResult GetOrder(int id)
        {
            var order = managerService.GetOrder(id);

            if (order != null)
            {
                OrderViewModel orderView = mapper.Map<OrderViewModel>(order);
                return Ok(orderView);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("api/ManagerPanel/orders/")]
        public IHttpActionResult GetOrders()
        {
            var orders = managerService.GetOrders();
            var ordersView = mapper.Map<IEnumerable<OrderViewModel>>(orders);

            if (ordersView != null)
            {
                return Ok(ordersView);
            }

            return NotFound();
        }
    }
}
