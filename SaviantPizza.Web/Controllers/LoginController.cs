using Microsoft.AspNetCore.Mvc;
using SaviantPizza.Business.IService;
using SaviantPizza.Web.Extension;
using SaviantPizza.Web.Models;


namespace SaviantPizza.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {

        private readonly ILoginService _loginService;


        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        /// <summary>
        /// Allow user to log in to system if provided details match 
        /// </summary>
        /// <param name="user"></param>
        /// <returns>returns true if user is valid</returns>

        [HttpPost]
        public bool Login([FromBody] UserViewModel user)
        {
           return  _loginService.Login(user.UserViewModelToUserEntity());
        }

      
    }
}
