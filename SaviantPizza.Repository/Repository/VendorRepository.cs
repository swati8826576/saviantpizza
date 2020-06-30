using SaviantPizza.Repository.Entity;
using SaviantPizza.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaviantPizza.Repository.Repository
{
   
    public class VendorRepository : GenericRepository<VendorType>, IVendorRepository
    {

        SaviantPizzaContext _context;
        public VendorRepository(SaviantPizzaContext context)
        {
            _context = context;
        }
    }
}
