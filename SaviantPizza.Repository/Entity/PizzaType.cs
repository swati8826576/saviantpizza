using System;
using System.Collections.Generic;

namespace SaviantPizza.Repository.Entity
{
    public partial class PizzaType
    {
        public PizzaType()
        {
            Pricing = new HashSet<Pricing>();
        }

        public int Id { get; set; }
        public string PizzaName { get; set; }
        public bool? IsActive { get; set; }
        public int CategoryId { get; set; }

        public virtual PizzaCategory Category { get; set; }
        public virtual ICollection<Pricing> Pricing { get; set; }
    }
}
