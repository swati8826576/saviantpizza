using SaviantPizza.Repository.Entity;
using SaviantPizza.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaviantPizza.Web.Extension
{
    public static class UserModule
    {

        public static User UserViewModelToUserEntity(this UserViewModel viewModel)
        {
            User user = new User();
            user.EmailId = viewModel.EmailId;
            user.Password = viewModel.Password;

            return user;
        }
    }
}
