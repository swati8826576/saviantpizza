using System;
using System.Collections.Generic;

namespace SaviantPizza.Repository.Entity
{
    public partial class OrderDetails
    {
        public Guid Id { get; set; }
        public int PizzaTypeId { get; set; }
        public int VendorId { get; set; }
        public decimal? Price { get; set; }
        public decimal? Discount { get; set; }
        public decimal? OtherDiscount { get; set; }
        public decimal? TotalAfterDiscount { get; set; }

        public virtual PizzaType PizzaType { get; set; }
        public virtual VendorType Vendor { get; set; }
    }
}
