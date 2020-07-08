using Microsoft.AspNetCore.Mvc;
using SaviantPizza.Business.IService;
using Serilog;
using System;

namespace SaviantPizza.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var discountDetails = _discountService.GetDiscount();
                if (discountDetails == null)
                    return NoContent();

                return Ok(discountDetails);
            }

            catch (Exception e)
            {
                Log.Error(e.Message.ToString());
                return StatusCode(500);

            }
        }

    }
}
