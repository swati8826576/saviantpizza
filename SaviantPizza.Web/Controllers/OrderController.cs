using Microsoft.AspNetCore.Mvc;
using SaviantPizza.Business.IService;
using SaviantPizza.Web.Models;
using SaviantPizza.Web.Extension;
using System.Linq;

namespace SaviantPizza.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService =  orderService;
        }

        /// <summary>
        ///calls service to place the order made by user
        /// </summary>
        /// <param name="orders"></param>
        /// <returns>returns true if vendor accepts the order successfully</returns>
        [HttpPost]
        public bool Post([FromBody] PizzaDetailsViewModel[] viewModel)
        {
            var result =   OrderExtension.ViewModelToEntity(viewModel.ToList(), "85B7E18F-4DE9-449C-A582-EA85AE77ACC3");
           return _orderService.SaveOrder(result);

        }

      
    }
}
