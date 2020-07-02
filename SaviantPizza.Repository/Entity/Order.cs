using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaviantPizza.Repository.Entity
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal? OrdeTotal { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
