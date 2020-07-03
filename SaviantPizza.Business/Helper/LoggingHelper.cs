using Microsoft.Extensions.Logging;
using SaviantPizza.Business.Service;
using SaviantPizza.Repository.Entity;
using System;

namespace SaviantPizza.Business.Helper
{
   public  class LoggingHelper : ILoggingHelper
    {
        private  readonly ILogger<OrderService> _logger;

         public LoggingHelper( ILogger<OrderService> logger) { 
            _logger = logger;

        }
        public  void LogOrderInformation ( Order order)
        {
            _logger.LogInformation("Order made by customer" + Environment.NewLine + "Order Id:" + order.Id + Environment.NewLine + "UserId:" + order.UserId);

        }
    }
}
