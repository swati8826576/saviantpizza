using SaviantPizza.Business.IService;
using System.Collections.Generic;
using SaviantPizza.Repository.Entity;
using SaviantPizza.Repository.IRepository;
using System.Linq;

namespace SaviantPizza.Business.Service
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaDetailViewRepository _pizzaDetailViewRepository;
        private readonly IDisountRepository  _disountRepository;



        public PizzaService( IPizzaDetailViewRepository pizzaDetailViewRepository, IDisountRepository disountRepository)
        {
            _pizzaDetailViewRepository = pizzaDetailViewRepository;
            _disountRepository = disountRepository;
        }

        public  List<PizzaDetailsView> GetPizzaList()
        {
            _disountRepository.GetAll().FirstOrDefault();
         return  _pizzaDetailViewRepository.GetAll().ToList();
        }

       
    }
}
