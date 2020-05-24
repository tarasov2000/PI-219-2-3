using AutoMapper;
using DAL.Contexts;
using Repository.Entities.Identity;
using Repository.Interfaces;
using System;

namespace Repository.Repositories
{
    public class IdentityUnitOfWork : IIdentityUnitOfWork
    {
        private UserContext db;
        private IMapper mapper;

        private UserProfileRepository userProfiles;
        private IUserRepository<UserRepo> users;

        private bool disposed = false;

        public IdentityUnitOfWork(string connectingString, IMapper mapper)
        {
            db = new UserContext(connectingString);
            this.mapper = mapper;
        }

        public UserProfileRepository UserProfiles
        {
            get
            {
                if (userProfiles == null)
                    userProfiles = new UserProfileRepository(db, mapper);

                return userProfiles;
            }
        }

        public IUserRepository<UserRepo> Users
        {
            get
            {
                if (users == null)
                    users = new UserRepository(db, mapper);

                return users;
            }
        }

        public IdentityUnitOfWork(UserContext context, IMapper mapper)
        {
            db = context;
            this.mapper = mapper;
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
