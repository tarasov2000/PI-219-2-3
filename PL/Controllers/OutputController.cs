using AutoMapper;
using BLL.DTO.Shop;
using BLL.Enums;
using BLL.Interfaces;
using PL.Models.Shop;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PL.Controllers
{
    [RoutePrefix("api/products")]
    public class OutputController : ApiController
    {
        private IOutputService outputService;
        private IMapper mapper;

        public OutputController(IOutputService outputService, IMapper mapper)
        {
            this.outputService = outputService;
            this.mapper = mapper;
        }

        public IHttpActionResult Get(int id)
        {
            if (id <= 0)
                return BadRequest();
            ProductDTO productDTO = outputService.Get(id);
            if (productDTO == null)
                return NotFound();
            ProductViewModel product = mapper.Map<ProductDTO, ProductViewModel>(productDTO);
            return Ok(product);
        }

        [HttpGet]
        [Route("Search/{name}")]
        public IHttpActionResult Search(string name)
        {
            IEnumerable<ProductDTO> productDTOs = outputService.SearchByName(name);
            IEnumerable<ProductViewModel> result =
                mapper.Map<IEnumerable<ProductDTO>, IEnumerable<ProductViewModel>>(productDTOs);
            if (result.Count() == 0)
                return NotFound();
            return Ok(result);
        }

        [HttpGet]
        [Route("Category/{categoryId}/Sort/{sortCriteria}")]
        public IHttpActionResult GetByCategory(int categotyId, SortCriteria sortCriteria)
        {
            if (categotyId <= 0)
                return BadRequest();
            IEnumerable<ProductDTO> productDTOs = outputService.GetByCategory(categotyId, sortCriteria);
            IEnumerable<ProductViewModel> result =
                mapper.Map<IEnumerable<ProductDTO>, IEnumerable<ProductViewModel>>(productDTOs);
            if (result.Count() == 0)
                return NotFound();
            return Ok(result);
        }

        [HttpGet]
        [Route("Filter/ByCompany")]
        public IHttpActionResult FilterByCompany(string[] companies)
        {
            IEnumerable<ProductDTO> productDTOs = outputService.FilterByCompany(companies);
            IEnumerable<ProductViewModel> result =
                mapper.Map<IEnumerable<ProductDTO>, IEnumerable<ProductViewModel>>(productDTOs);
            if (result.Count() == 0)
                return NotFound();
            return Ok(result);
        }

        [HttpGet]
        [Route("Filter/ByPrice/{leftBound}-{rightBound}")]
        public IHttpActionResult FilterByPrice(double leftBound, double rightBound)
        {
            IEnumerable<ProductDTO> productDTOs = outputService.FilterByPrice(leftBound, rightBound);
            IEnumerable<ProductViewModel> result =
                mapper.Map<IEnumerable<ProductDTO>, IEnumerable<ProductViewModel>>(productDTOs);
            if (result.Count() == 0)
                return NotFound();
            return Ok(result);
        }
    }
}
