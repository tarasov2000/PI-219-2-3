using AutoMapper;
using DAL.Contexts;
using DAL.Entities.Identity;
using DAL.Identity;
using Repository.Entities.Identity;
using Repository.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Security.Claims;

namespace Repository.Repositories
{
    public class UserRepository : IUserRepository<UserRepo>
    {
        private IMapper mapper;
        private ShopUserManager userManager;

        public UserRepository(UserContext userContext, IMapper mapper)
        {
            userManager = new ShopUserManager(new UserStore<ShopUser>(userContext));
            this.mapper = mapper;
        }

        public UserRepo FindByName(string name)
        {
            ShopUser user = userManager.FindByName(name);
            var a = userManager.Create(user);
            return mapper.Map<ShopUser, UserRepo>(user);
        }

        public bool Create(UserRepo userRepo)
        {
            var user = mapper.Map<UserRepo, ShopUser>(userRepo);
            var result = userManager.Create(user);

            if (result.Errors.Count() > 0)
                return false;

            return true;
        }

        public void AddToRole(UserRepo userRepo)
        {
            userManager.AddToRole(userRepo.Id, userRepo.Role);
        }

        public UserRepo Find(string login, string password)
        {
            var user = userManager.Find(login, password);
            return mapper.Map<UserRepo>(user);
        }

        public ClaimsIdentity CreateIdentity(UserRepo userRepo, string authenticationType)
        {
            var shopUser = mapper.Map<ShopUser>(userRepo);
            return userManager.CreateIdentity<ShopUser, string>(shopUser, authenticationType);
        }
    }
}
