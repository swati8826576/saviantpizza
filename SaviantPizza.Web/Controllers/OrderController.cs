using Microsoft.AspNetCore.Mvc;
using SaviantPizza.Business.IService;
using SaviantPizza.Web.Models;
using SaviantPizza.Web.Extension;
using System.Linq;
using System;
using Serilog;

namespace SaviantPizza.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;


        public OrderController(IOrderService orderService, IDiscountService discountService)
        {
            _orderService =  orderService;
        }

        /// <summary>
        ///calls service to place the order made by user
        /// </summary>
        /// <param name="orders"></param>
        /// <returns>returns true if vendor accepts the order successfully</returns>
        [HttpPost]
        public IActionResult Post([FromBody] PizzaDetailsViewModel[] viewModel )
        {
            try
            {
                var orderEntity = OrderExtension.ViewModelToEntity(viewModel.ToList(), "85B7E18F-4DE9-449C-A582-EA85AE77ACC3");
                var result = _orderService.SaveOrder(orderEntity);
                return Ok(result);
            }

            catch (Exception e)
            {
                Log.Error(e.Message.ToString());
                return StatusCode(500);

            }

        }

      
    }
}
