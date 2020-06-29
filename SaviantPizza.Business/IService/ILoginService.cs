using SaviantPizza.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaviantPizza.Business.IService
{
  public  interface ILoginService
    {
        bool Login(User user);

    }
}
