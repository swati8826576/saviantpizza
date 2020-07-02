using System;
using System.Collections.Generic;

namespace SaviantPizza.Repository.Entity
{
    public partial class PizzaDetailsView
    {
        public int PizzaCategoryId { get; set; }
        public string PizzaCategoryName { get; set; }
        public bool? CategoryIsActive { get; set; }
        public int PizzaTypeId { get; set; }
        public string PizzaName { get; set; }
        public bool? PizzaTypeIsActive { get; set; }
        public int CategoryId { get; set; }
        public int PricingId { get; set; }
        public int PizzaId { get; set; }
        public int VendorId { get; set; }
        public int? Price { get; set; }
        public decimal? Discount { get; set; }
        public int VendorTypeId { get; set; }
        public string VendorName { get; set; }

        public bool? VendorTypeIsActive { get; set; }
        public decimal? OtherDiscounts { get; set; }

    }
}
