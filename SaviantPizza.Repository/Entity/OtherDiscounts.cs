using System;
using System.Collections.Generic;

namespace SaviantPizza.Repository.Entity
{
    public partial class OtherDiscounts
    {
        public Guid Id { get; set; }
        public decimal? Discount { get; set; }
    }
}
