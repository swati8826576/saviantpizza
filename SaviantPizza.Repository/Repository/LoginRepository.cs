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
            var UserDetails =  Search(e => e.EmailId == user.EmailId && e.Password == user.Password);
            //var UserDetails = GetAll().Where(e => e.EmailId == user.EmailId && e.Password == user.Password && e.IsActive == true).FirstOrDefault();
             return UserDetails != null ? true : false;
        }
    }
}
