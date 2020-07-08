using Microsoft.AspNetCore.Mvc;
using SaviantPizza.Business.IService;
using SaviantPizza.Web.Extension;
using Serilog;
using System;

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
        public IActionResult Get()
        {
            try {

               var pizzaDetails =   _pizzaService.GetPizzaList().EntityToViewModel();
                if (pizzaDetails == null)
                    return NoContent();

                return Ok(pizzaDetails);
            }

            catch(Exception e ){
                Log.Error(e.Message.ToString());
                return StatusCode(500);
             
            }
        }

      
    }
}
