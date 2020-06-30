using Microsoft.EntityFrameworkCore;
using SaviantPizza.Repository.Entity;
using SaviantPizza.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaviantPizza.Repository.Repository
{
    public class LoginRepository : GenericRepository<User> , ILoginRepository  
    {

        public LoginRepository(SaviantPizzaContext dbContext)
         : base(dbContext)
        {

        }

        public bool Login(User user)
        {
            GetAll().Where(e => e.EmailId == user.EmailId && e.Password == user.Password && e.IsActive == true);
            return true;
        }
    }
}
