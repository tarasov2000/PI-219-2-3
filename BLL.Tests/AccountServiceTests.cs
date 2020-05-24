using AutoMapper;
using BLL.DTO.Identity;
using BLL.Services;
using Repository.Entities.Identity;
using Repository.Interfaces;
using Repository.Repositories;
using Moq;
using NUnit.Framework;
using System.Security.Claims;

namespace BLL.Tests
{
    [TestFixture]
    public class AccountServiceTests
    {
        private Mock<IIdentityUnitOfWork> uowMock;
        private AccountService accountService;
        private IMapper mapper;

        public AccountServiceTests()
        {
            uowMock = new Mock<IIdentityUnitOfWork>();
            mapper = new MapperConfiguration(cfg => cfg.AddProfile<TestsMappingConfig>()).CreateMapper();
            accountService = CreateAccountService();
        }

        private AccountService CreateAccountService()
        {
            return new AccountService(uowMock.Object, mapper);
        }

        [Test]
        public void Create_NoUserFoundWithSamePassword_ReturnsTrue()
        {
            UserDTO userDTO = new UserDTO
            {
                Name = "NewLogin"
            };
            uowMock.Setup(a => a.Users.FindByName(userDTO.Name)).Returns<UserRepo>(null);
            uowMock.Setup(a => a.Users.Create(It.IsAny<UserRepo>())).Returns(true);

            bool result = accountService.Create(userDTO);

            Assert.True(result);
        }

        [Test]
        public void Create_UserFoundWithSamePassword_ReturnsFalse()
        {
            UserDTO userDTO = new UserDTO
            {
                Name = "NewLogin"
            };
            uowMock.Setup(a => a.Users.FindByName(userDTO.Name)).Returns(
                new UserRepo { Name = userDTO.Name });

            bool result = accountService.Create(userDTO);

            Assert.False(result);
        }

        [Test]
        public void Authenticate_UserFound_ReturnsClaimsIdentity()
        {
            UserDTO userDTO = new UserDTO
            {
                Name = "NewLogin",
                Password = "NewPassword"
            };
            uowMock.Setup(a => a.Users.Find(userDTO.Name, userDTO.Password)).Returns(
                new UserRepo { Name = userDTO.Name, Password = userDTO.Password});
            uowMock.Setup(a => a.Users.CreateIdentity(It.IsAny<UserRepo>(), It.IsAny<string>()))
                .Returns(new ClaimsIdentity());

            ClaimsIdentity claims = accountService.Authenticate(userDTO);

            Assert.NotNull(claims);
        }

        [Test]
        public void Authenticate_UserNotFound_ReturnsNull()
        {
            UserDTO userDTO = new UserDTO
            {
                Name = "NewLogin",
                Password = "NewPassword"
            };
            uowMock.Setup(a => a.Users.Find(userDTO.Name, userDTO.Password)).Returns<UserRepo>(null);

            ClaimsIdentity claims = accountService.Authenticate(userDTO);

            Assert.Null(claims);
        }
    }
}
