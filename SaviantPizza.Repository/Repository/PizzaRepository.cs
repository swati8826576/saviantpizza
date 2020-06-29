using Microsoft.EntityFrameworkCore;
using SaviantPizza.Repository.Entity;
using SaviantPizza.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaviantPizza.Repository.Repository
{
   public class PizzaRepository : IPizzaRepository
    {
        //private IGenericRepository<PizzaType> _repository;
        //PizzaRepository(IGenericRepository<PizzaType>  repository )
        //{
        //    _repository = repository;
        //}

        SaviantPizzaContext _context;
      public  PizzaRepository(SaviantPizzaContext context)
        {
            _context = context;
        }
         
        public void  GetAll()
        {
          var a =  _context.PizzaType.ToList();
        }
    }
}
