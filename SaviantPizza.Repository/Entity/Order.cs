using System;
using System.Collections.Generic;

namespace SaviantPizza.Repository.Entity
{
    public partial class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid OrderDetailsId { get; set; }
        public decimal? OrdeTotal { get; set; }

        public virtual User User { get; set; }
    }
}
