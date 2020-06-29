using System;
using System.Collections.Generic;

namespace SaviantPizza.Repository.Entity
{
    public partial class Pricing
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int VendorId { get; set; }
        public int? Price { get; set; }
        public decimal? Discount { get; set; }

        public virtual PizzaType Pizza { get; set; }
        public virtual VendorType Vendor { get; set; }
    }
}
