using Repository.Entities.Shop;
using System;

namespace Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<CategoryRepo> Categories { get; }
        IRepository<OrderRepo> Orders { get; }
        IRepository<ProductRepo> Products { get; }

        void Save();
    }
}
