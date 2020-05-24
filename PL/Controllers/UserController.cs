using AutoMapper;
using BLL.DTO.Shop;
using BLL.Entities;
using BLL.Interfaces;
using PL.Models.Shop;
using System.Web.Http;

namespace PL.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        private IUserService userService;
        private IMapper mapper;
        private ShoppingCart shopCart;

        public UserController(IUserService userService, IMapper mapper, ShoppingCart shopCart)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.shopCart = new ShoppingCart();
        }

        [HttpPost]
        [Route("api/ShopCartPanel/addProduct")]
        public IHttpActionResult AddProduct([FromBody]ProductViewModel productView)
        {
            if (ModelState.IsValid)
            {
                var product = mapper.Map<ProductDTO>(productView);

                bool result = userService.AddItem(product, shopCart);

                if (result)
                    return Ok();
                else
                    return BadRequest();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("api/ShopCartPanel/removeProduct")]
        public IHttpActionResult RemoveItem([FromBody]ProductViewModel productView)
        {
            var product = mapper.Map<ProductDTO>(productView);
            bool result = userService.RemoveItem(product, shopCart);

            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        [Route("api/ShopCartPanel/composeOrder")]
        public IHttpActionResult ComposeCart()
        {
            var cart = userService.ComposeCart(shopCart);

            if (cart == null)
                return NotFound();

            return Ok(cart);
        }

        [HttpPost]
        [Route("api/ShopCartPanel/createOrder")]
        public IHttpActionResult MakeOrder()
        {
            var order = userService.MakeOrder(shopCart);

            if (order == null)
                return NotFound();

            OrderViewModel userOrder = mapper.Map<OrderViewModel>(order);

            return Ok(userOrder);
        }

        [HttpDelete]
        [Route("api/ShopCartPanel/clearShopCart")]
        public IHttpActionResult ClearShopCart()
        {
            if (userService.Clear(shopCart))
                return Ok(shopCart);
            else
                return NotFound();
        }
    }
}
