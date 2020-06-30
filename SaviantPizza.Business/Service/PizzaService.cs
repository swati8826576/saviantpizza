using SaviantPizza.Business.IService;
using System;
using System.Collections.Generic;
using System.Text;
using SaviantPizza.Repository.Entity;
using SaviantPizza.Repository.IRepository;
using System.Linq;

namespace SaviantPizza.Business.Service
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaService(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public  void GetPizzaList()
        {
            _pizzaRepository.GetAll().ToList().Where(e => e.IsActive == true);
        }

       
    }
}
