using Microsoft.AspNetCore.Mvc;
using SaviantPizza.Business.IService;
using SaviantPizza.Web.Extension;
using SaviantPizza.Web.Models;
using Serilog;
using System;

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
        public IActionResult Login([FromBody] UserViewModel user)
        {
            try
            {
                var a = ModelState.IsValid;

                var userDetails = _loginService.Login(user.UserViewModelToUserEntity());
                return Ok(userDetails);
            }

            catch (Exception e)
            {
                Log.Error(e.Message.ToString());
                return StatusCode(500);

            }

        }
      
    }
}
