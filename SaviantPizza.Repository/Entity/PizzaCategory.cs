using System;
using System.Collections.Generic;

namespace SaviantPizza.Repository.Entity
{
    public partial class PizzaCategory
    {
        public PizzaCategory()
        {
            PizzaType = new HashSet<PizzaType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<PizzaType> PizzaType { get; set; }
    }
}
