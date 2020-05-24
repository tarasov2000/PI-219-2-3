using AutoMapper;
using BLL.DTO.Shop;
using BLL.Enums;
using BLL.Interfaces;
using Repository.Entities.Shop;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class OutputService : IOutputService
    {
        private IUnitOfWork db;
        private IMapper mapper;

        public OutputService(IUnitOfWork db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public ProductDTO Get(int id)
        {
            if (id <= 0)
                return null;
            ProductRepo productRepo = db.Products.Get(id);
            ProductDTO product = mapper.Map<ProductRepo, ProductDTO>(productRepo);
            return product;
        }

        private IEnumerable<ProductDTO> GetAll()
        {
            IEnumerable<ProductRepo> productRepos = db.Products.GetAll();
            IEnumerable<ProductDTO> productDTOs =
                mapper.Map<IEnumerable<ProductRepo>, IEnumerable<ProductDTO>>(productRepos);
            return productDTOs;
        }

        public IEnumerable<ProductDTO> SearchByName(string name)
        {
            IEnumerable<ProductDTO> products = GetAll();
            return products.Where(p => p.Name.ToLower().Contains(name.ToLower()));
        }

        public IEnumerable<ProductDTO> GetByCategory(int categoryId, SortCriteria sortCriteria)
        {
            if (categoryId <= 0)
                return null;
            IEnumerable<ProductDTO> products = GetAll().Where(p => p.CategoryId == categoryId);
            products = Sort(products, sortCriteria);
            return products;
        }

        public IEnumerable<ProductDTO> FilterByCompany(string[] company)
        {
            var result = new List<ProductDTO>();
            IEnumerable<ProductDTO> products = GetAll();
            for (int i = 0; i < company.Length; i++)
            {
                IEnumerable<ProductDTO> items = products.Where(p => p.Company.ToLower().Contains(company[i].ToLower()));
                result.AddRange(items);
            }
            return result;
        }

        public IEnumerable<ProductDTO> FilterByPrice(double leftBound, double rightBound)
        {
            if (leftBound > rightBound || leftBound < 0 || rightBound < 0)
                return null;
            IEnumerable<ProductDTO> products = GetAll();
            return products.Where(p => p.Price >= leftBound && p.Price <= rightBound);
        }

        private IEnumerable<ProductDTO> Sort(IEnumerable<ProductDTO> products, SortCriteria sortCriteria)
        {
            switch (sortCriteria)
            {
                case SortCriteria.ByName:
                    products = products.OrderBy(p => p.Name);
                    break;
                case SortCriteria.ByPrice:
                    products = products.OrderBy(p => p.Price);
                    break;
                case SortCriteria.ByNameDescending:
                    products = products.OrderByDescending(p => p.Name);
                    break;
                case SortCriteria.ByPriceDescending:
                    products = products.OrderByDescending(p => p.Price);
                    break;
            }
            return products;
        }

    }
}
