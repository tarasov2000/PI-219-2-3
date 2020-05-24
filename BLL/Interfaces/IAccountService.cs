using BLL.DTO.Identity;
using System;
using System.Security.Claims;

namespace BLL.Interfaces
{
    public interface IAccountService : IDisposable
    {
        bool Create(UserDTO userDTO);
        ClaimsIdentity Authenticate(UserDTO userDTO);
    }
}
