using Repository.Entities.Identity;
using Repository.Repositories;
using System;

namespace Repository.Interfaces
{
    public interface IIdentityUnitOfWork : IDisposable
    {
        IUserRepository<UserRepo> Users { get; }
        UserProfileRepository UserProfiles {get;}
        void Save();
    }
}
