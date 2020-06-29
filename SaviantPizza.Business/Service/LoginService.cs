using SaviantPizza.Business.IService;
using SaviantPizza.Repository.Entity;
using SaviantPizza.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaviantPizza.Business.Service
{
    public class LoginService : ILoginService
    {

        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository; 
                }
        public bool Login(User user)
        {
            _loginRepository.Login(user);
            return true; 
        }
    }
}
