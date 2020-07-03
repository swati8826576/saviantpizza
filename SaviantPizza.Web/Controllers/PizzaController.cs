using Microsoft.AspNetCore.Mvc;
using SaviantPizza.Business.IService;
using SaviantPizza.Web.Extension;
using SaviantPizza.Web.Models;
using System.Collections.Generic;

namespace SaviantPizza.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

       public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        /// <summary>
        /// Get pizza list with other details like vendor  , price , discount etc.
        /// </summary>
        /// <returns>List<PizzaDetailsViewModel></returns>
        [HttpGet]
        public List<PizzaDetailsViewModel> Get()
        {
          return  _pizzaService.GetPizzaList().EntityToViewModel();
        }

      
    }
}
