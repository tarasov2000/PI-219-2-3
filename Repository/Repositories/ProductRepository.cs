using DAL.Contexts;
using Repository.Entities.Shop;
using Repository.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using DAL.Entities.Shop;
using System.Data.Entity;

namespace Repository.Repositories
{
    public class ProductRepository : IRepository<ProductRepo>
    {
        private ShopContext db;
        private IMapper mapper;

        public ProductRepository(ShopContext shopContext, IMapper mapper)
        {
            db = shopContext;
            this.mapper = mapper;
        }

        public void Create(ProductRepo productRepo)
        {
            Product product = mapper.Map<ProductRepo, Product>(productRepo);
            db.Products.Add(product);
        }

        public void Delete(ProductRepo productRepo)
        {
            Product product = mapper.Map<ProductRepo, Product>(productRepo);
            db.Products.Remove(product);
        }

        public ProductRepo Get(int id)
        {
            return mapper.Map<Product, ProductRepo>(db.Products.Find(id));
        }

        public IEnumerable<ProductRepo> GetAll()
        {
            return mapper.Map<IEnumerable<Product>, IEnumerable<ProductRepo>>(db.Products);
        }

        public void Update(ProductRepo productRepo)
        {
            Product product = mapper.Map<ProductRepo, Product>(productRepo);
            db.Entry(product).State = EntityState.Modified;
        }
    }
}
