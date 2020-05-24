using AutoMapper;
using BLL.DTO.Identity;
using BLL.Interfaces;
using Repository.Entities.Identity;
using Repository.Interfaces;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace BLL.Services
{
    public class AccountService : IAccountService
    {
        private IIdentityUnitOfWork db;
        private IMapper mapper;

        public AccountService(IIdentityUnitOfWork db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public bool Create(UserDTO userDTO)
        {
            UserRepo user = db.Users.FindByName(userDTO.Name);
            if(user != null)
                return false;
            UserRepo userRepo = mapper.Map<UserDTO, UserRepo>(userDTO);
            return db.Users.Create(userRepo);
        }

        public ClaimsIdentity Authenticate(UserDTO userDTO)
        {
            ClaimsIdentity claim = null;

            UserRepo userRepo = db.Users.Find(userDTO.Name, userDTO.Password);
            if (userRepo != null)
                claim = db.Users.CreateIdentity(userRepo, DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
