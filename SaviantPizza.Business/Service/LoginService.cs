using SaviantPizza.Business.IService;
using SaviantPizza.Repository.Entity;
using SaviantPizza.Repository.IRepository;

namespace SaviantPizza.Business.Service
{
    public class LoginService : ILoginService
    {

        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        /// <summary>
        /// Allow user to log in to system if provided details match 
        /// </summary>
        /// <param name="user"></param>
        /// <returns>returns true if user is valid</returns>
        public bool Login(User user)
        {
            return _loginRepository.Login(user);
        }
    }
}
