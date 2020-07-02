using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SaviantPizza.Business.IService;
using SaviantPizza.Repository.Entity;
using SaviantPizza.Web.Models;
using SaviantPizza.Web.Extension;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.Extensions.Logging;

namespace SaviantPizza.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IHttpContextAccessor _httpContextAccessor;
      //  private readonly ILogger _logger; 


        public OrderController(IOrderService orderService, IHttpContextAccessor httpContextAccesso )
        {
            _orderService =  orderService;
             _httpContextAccessor = httpContextAccesso;
           //  _logger = logger;
        }

        [HttpGet]

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // POST api/<PizzaController>
        [HttpPost]
        public bool Post([FromBody] PizzaDetailsViewModel[] viewModel)
        {
            // var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result =   OrderExtension.ViewModelToEntity(viewModel.ToList(), "85B7E18F-4DE9-449C-A582-EA85AE77ACC3");
           return _orderService.SaveOrder(result);

           // _logger.LogInformation("Order made by customer");

        }


        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

      
    }
}
