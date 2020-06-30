using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SaviantPizza.Business.IService;
using SaviantPizza.Web.Extension;
using SaviantPizza.Web.Models;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SaviantPizza.Web.Controllers
{
    [ApiController]


    [Route("[controller]")]
    public class LoginController : ControllerBase
    {

        //private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILoginService _loginService;


        public LoginController(ILoginService loginService)//, IHttpContextAccessor httpContextAccesso)
        {
            _loginService = loginService;
           // _httpContextAccessor = httpContextAccesso;
        }

            [HttpGet]
        public string[] Get()
        {
          return   new string[] { "value1", "value2" };
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
        [HttpPost]
        public void Login([FromBody] UserViewModel user)
        {
           // var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _loginService.Login(user.UserViewModelToUserEntity());
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
