using AutoMapper;
using BLL.DTO.Identity;
using BLL.Interfaces;
using PL.Models.Account;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace PL.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private IAccountService accountService;
        private IMapper mapper;

        public AccountController(IAccountService accountService, IMapper mapper)
        {
            this.accountService = accountService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("login")]
        public IHttpActionResult Login(LoginModel login)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid data");
            UserDTO userDTO = mapper.Map<LoginModel, UserDTO>(login);
            ClaimsIdentity claim = accountService.Authenticate(userDTO);
            if (claim == null)
                return Ok("Wrong login or password");
            HttpContext.Current.GetOwinContext().Authentication.SignOut();
            HttpContext.Current.GetOwinContext().Authentication.SignIn(
                new AuthenticationProperties { IsPersistent = true }, claim);
            return Ok();
        }

        [Route("logout")]
        public IHttpActionResult Logout()
        {
            HttpContext.Current.GetOwinContext().Authentication.SignOut();
            return Ok();
        }

        [HttpPost]
        [Route("register")]
        public IHttpActionResult Register (RegistrationModel registration)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid data");
            UserDTO userDTO = mapper.Map<RegistrationModel, UserDTO>(registration);
            accountService.Create(userDTO);
            return Ok();
        }

    }
}
