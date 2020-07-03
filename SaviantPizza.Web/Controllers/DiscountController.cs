using Microsoft.AspNetCore.Mvc;
using SaviantPizza.Business.IService;

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
        public decimal? Get()
        {
          return  _discountService.GetDiscount();
        }

    }
}
