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


namespace SaviantPizza.Web.Controllers
{
    [ApiController]


    [Route("[controller]")]
    public class LoginController : ControllerBase
    {

        private readonly ILoginService _loginService;


        public LoginController(ILoginService loginService)//, )
        {
            _loginService = loginService;
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
        public bool Login([FromBody] UserViewModel user)
        {
           return  _loginService.Login(user.UserViewModelToUserEntity());
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
