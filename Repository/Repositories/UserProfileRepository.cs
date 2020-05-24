using AutoMapper;
using DAL.Contexts;
using DAL.Entities.Identity;
using Repository.Entities.Identity;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;

namespace Repository.Repositories
{
    public class UserProfileRepository : IRepository<UserRepo>
    {
        private UserContext db;
        private IMapper mapper;

        public UserProfileRepository(UserContext userContext, IMapper mapper)
        {
            db = userContext;
            this.mapper = mapper;
        }

        public void Create(UserRepo userRepo)
        {
            UserProfile userProfile = mapper.Map<UserRepo, UserProfile>(userRepo);
            db.UserProfiles.Add(userProfile);
        }

        public void Delete(UserRepo userRepo)
        {
            UserProfile userProfile = mapper.Map<UserRepo, UserProfile>(userRepo);
            db.UserProfiles.Remove(userProfile);
        }

        public UserRepo Get(int id)
        {
            return mapper.Map<UserProfile, UserRepo>(db.UserProfiles.Find(id));
        }

        public IEnumerable<UserRepo> GetAll()
        {
            return mapper.Map<IEnumerable<UserProfile>, IEnumerable<UserRepo>>(db.UserProfiles);
        }

        public void Update(UserRepo userRepo)
        {
            UserProfile userProfile = mapper.Map<UserRepo, UserProfile>(userRepo);
            db.Entry(userProfile).State = EntityState.Modified;
        }
    }
}
