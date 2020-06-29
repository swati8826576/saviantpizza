using SaviantPizza.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaviantPizza.Repository.IRepository
{
   public interface ILoginRepository : IGenericRepository<User>
    {
        bool Login(User user);
    }
}
