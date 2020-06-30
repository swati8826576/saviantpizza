using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaviantPizza.Web.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
    }
}
