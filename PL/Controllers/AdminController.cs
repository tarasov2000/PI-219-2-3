using AutoMapper;
using BLL.DTO.Shop;
using BLL.Interfaces;
using PL.Models.Shop;
using System.Web.Http;

namespace PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : ApiController
    {
        IAdminService adminService;
        IMapper mapper;

        public AdminController(IAdminService _adminService, IMapper mapper)
        {
            adminService = _adminService;
            this.mapper = mapper;
        }
        
        [HttpPost]
        [Route("api/adminPanel/categories/add")]
        public IHttpActionResult AddCategory([FromBody]CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var _category = mapper.Map<CategoryDTO>(category);
                bool result = adminService.AddCategory(_category);

                if (result)
                    return Ok();
            }
            else
                return BadRequest(ModelState);

            return BadRequest();
        }

        [HttpPut]
        [Route("api/adminPanel/categories/edit")]
        public IHttpActionResult UpdateCategory([FromBody]CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var _category = mapper.Map<CategoryDTO>(category);
                bool result = adminService.UpdateCategory(_category);

                if (result)
                    return Ok();
            }
            else
                return BadRequest(ModelState);

            return BadRequest();
        }

        [HttpDelete]
        [Route("api/adminPanel/categories/delete/{id}")]
        public IHttpActionResult DeleteCategory(int id)
        {
            bool result = adminService.RemoveCategory(id);

            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpPost]
        [Route("api/adminPanel/products/add")]
        public IHttpActionResult AddProduct([FromBody]ProductViewModel itemView)
        {
            if (ModelState.IsValid)
            {
                var _item = mapper.Map<ProductDTO>(itemView);
                bool result = adminService.AddProduct(_item);

                if (result)
                    return Ok();
            }
            else
                return BadRequest(ModelState);

            return BadRequest();
        }

        [HttpPut]
        [Route("api/adminPanel/products/edit")]
        public IHttpActionResult UpdateProduct([FromBody]ProductViewModel item)
        {
            if (ModelState.IsValid)
            {
                var _item = mapper.Map<ProductDTO>(item);
                bool result = adminService.UpdateProduct(_item);

                if (result)
                    return Ok();
            }
            else
                return BadRequest(ModelState);

            return BadRequest();
        }

        [HttpDelete]
        [Route("api/adminPanel/products/delete/{id}")]
        public IHttpActionResult DeleteProduct(int id)
        {
            bool result = adminService.RemoveProduct(id);

            if (result)
                return Ok();

            return BadRequest();
        }
    }
}
