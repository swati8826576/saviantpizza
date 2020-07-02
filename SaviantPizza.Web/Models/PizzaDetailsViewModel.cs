using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaviantPizza.Web.Models
{
    public class PizzaDetailsViewModel
    {
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public bool IsSelected { get; set; }
        public bool isClosed { get; set; }
         public List<PizzaDetails> pizzaDetails { get; set; }
    }


    public class PizzaDetails
        {

        public int PizzaId { get; set; }
         public string PizzaName { get; set; }
        public int? Price { get; set; }
         public decimal DiscountedPrice { get; set; }
         public bool IsSelected { get; set; }

}


}
