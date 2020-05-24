using AutoMapper;
using DAL.Contexts;
using DAL.Entities.Shop;
using Repository.Entities.Shop;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;

namespace Repository.Repositories
{
    public class CategoryRepository : IRepository<CategoryRepo>
    {
        private ShopContext db;
        private IMapper mapper;

        public CategoryRepository(ShopContext shopContext, IMapper mapper)
        {
            db = shopContext;
            this.mapper = mapper;
        }

        public void Create(CategoryRepo categoryRepo)
        {
            Category category = mapper.Map<CategoryRepo, Category>(categoryRepo);
            db.Categories.Add(category);
        }

        public void Delete(CategoryRepo categoryRepo)
        {
            Category category = mapper.Map<CategoryRepo, Category>(categoryRepo);
            db.Categories.Remove(category);
        }

        public CategoryRepo Get(int id)
        {
            return mapper.Map<Category, CategoryRepo>(db.Categories.Find(id));
        }

        public IEnumerable<CategoryRepo> GetAll()
        {
            return mapper.Map<IEnumerable<Category>, IEnumerable<CategoryRepo>>(db.Categories);
        }

        public void Update(CategoryRepo categoryRepo)
        {
            Category category = mapper.Map<CategoryRepo, Category>(categoryRepo);
            db.Entry(category).State = EntityState.Modified;
        }
    }
}
