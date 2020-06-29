using System;
using System.Collections.Generic;

namespace SaviantPizza.Repository.Entity
{
    public partial class User
    {
        public User()
        {
            Order = new HashSet<Order>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
