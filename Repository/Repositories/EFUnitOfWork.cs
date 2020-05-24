using AutoMapper;
using DAL.Contexts;
using Repository.Entities.Shop;
using Repository.Interfaces;
using System;

namespace Repository.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ShopContext db;
        private IMapper mapper;

        private CategoryRepository categoryRepository;
        private OrderRepository orderRepository;
        private ProductRepository productRepository;

        private bool disposed = false;

        public EFUnitOfWork(string connectingString, IMapper mapper)
        {
            db = new ShopContext(connectingString);
            this.mapper = mapper;
        }

        public IRepository<CategoryRepo> Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(db, mapper);

                return categoryRepository;
            }
        }
        public IRepository<OrderRepo> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db, mapper);

                return orderRepository;
            }
        }
        public IRepository<ProductRepo> Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db, mapper);

                return productRepository;
            }
        }

        protected void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    db.Dispose();
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
