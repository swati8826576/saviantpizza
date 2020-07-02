using SaviantPizza.Repository.Entity;
using SaviantPizza.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaviantPizza.Repository.Repository
{

    public class PizzaDetailsViewRepository : GenericRepository<PizzaDetailsView>, IPizzaDetailViewRepository
    {

        SaviantPizzaContext _context;
        public PizzaDetailsViewRepository(SaviantPizzaContext context)
        {
            _context = context;
        }
    }
}
