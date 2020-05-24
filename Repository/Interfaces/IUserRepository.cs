using System.Security.Claims;

namespace Repository.Interfaces
{
    public interface IUserRepository<T>
    {
        T FindByName(string name);

        bool Create(T userRepo);

        void AddToRole(T userRepo);

        T Find(string login, string password);

        ClaimsIdentity CreateIdentity(T userRepo, string authenticationType);
    }
}
