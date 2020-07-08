using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SaviantPizza.Web.Models
{
    public class UserViewModel
    {

        public Guid Id { get; set; }
        public string EmailId { get; set; }

        public string Password { get; set; }



    }
}
