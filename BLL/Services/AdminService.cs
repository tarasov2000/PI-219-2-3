using AutoMapper;
using BLL.DTO.Shop;
using BLL.Interfaces;
using Repository.Entities.Shop;
using Repository.Interfaces;

namespace BLL.Services
{
    class AdminService : IAdminService
    {
        private IUnitOfWork db;
        private IMapper mapper;

        public AdminService(IUnitOfWork db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public bool AddCategory(CategoryDTO categoryDTO)
        {
            if (categoryDTO == null) return false;

            var item = mapper.Map<CategoryRepo>(categoryDTO);
            db.Categories.Create(item);
            db.Save();

            return true;
        }

        public bool AddProduct(ProductDTO productDTO)
        {
            if (productDTO == null) return false;

            var item = mapper.Map<ProductRepo>(productDTO);
            db.Products.Create(item);
            db.Save();

            return true;
        }

        public bool RemoveCategory(int id)
        {
            db.Categories.Delete(db.Categories.Get(id));
            db.Save();
            return true;
        }

        public bool RemoveProduct(int id)
        {
            db.Products.Delete(db.Products.Get(id));
            db.Save();
            return true;
        }

        public bool UpdateCategory(CategoryDTO categoryDTO)
        {
            if(categoryDTO != null)
            {
                var category = mapper.Map<CategoryRepo>(categoryDTO);
                db.Categories.Update(category);
                db.Save();
                return true;
            }
            return false;
        }

        public bool UpdateProduct(ProductDTO productDTO)
        {
            if (productDTO != null)
            {
                var category = mapper.Map<CategoryRepo>(productDTO);
                db.Categories.Update(category);
                db.Save();
                return true;
            }
            return false;
        }
    }
}
