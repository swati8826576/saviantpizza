using System;
using Microsoft.AspNetCore.Mvc;
using SaviantPizza.Business.IService;
using SaviantPizza.Web.Extension;
using Serilog;


namespace SaviantPizza.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorService _vendorService;


        public VendorController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        [HttpGet]
        public IActionResult Get()
        {

            try
            {
                var vendorDetails = _vendorService.GetAllVendors().EntityToViewModel();
                if (vendorDetails == null)
                    return NoContent();

                return Ok(vendorDetails);
            }

            catch (Exception e)
            {
                Log.Error(e.Message.ToString());
                return StatusCode(500);

            }
        }

    }
}
