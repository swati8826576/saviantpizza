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


        public PizzaService( IPizzaDetailViewRepository pizzaDetailViewRepository)
        {
            _pizzaDetailViewRepository = pizzaDetailViewRepository;
        }

        /// <summary>
        /// get list of available pizza with other details like vendor , price and discount
        /// </summary>
        /// <returns>Pizza details</returns>
        public  List<PizzaDetailsView> GetPizzaList()
        {
         return  _pizzaDetailViewRepository.GetAll().ToList();
        }

       
    }
}
