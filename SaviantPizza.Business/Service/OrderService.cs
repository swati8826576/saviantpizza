using SaviantPizza.Business.Factory;
using SaviantPizza.Business.Helper;
using SaviantPizza.Business.IService;
using SaviantPizza.Repository.Entity;
using SaviantPizza.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaviantPizza.Business.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILoggingHelper _loggingHelper;
        private readonly VendorFactoryBase _vendorFactory ;


        public OrderService(IOrderRepository orderRepository, ILoggingHelper loggingHelper, VendorFactoryBase vendorFactory)
        {
            _orderRepository = orderRepository;
            _loggingHelper = loggingHelper;
            _vendorFactory = vendorFactory;

        }

        /// <summary>
        /// Save order to database and call vendor api to place order 
        /// </summary>
        /// <param name="orders"></param>
        /// <returns>returns true if vendor accepts the order successfully</returns>
        public bool SaveOrder(List<Order> orders)
        {
            
                //save order to database
                var order = orders.FirstOrDefault();
                int vendorType = order.OrderDetails.FirstOrDefault().VendorId;
                 _orderRepository.Insert(order);
                _orderRepository.Save();

                //call external api to place order
               // VendorFactory vendorFactory = new VendorFactory();
                var vendorToCall = _vendorFactory.CreateVendor(vendorType);
                var result =  vendorToCall.PlaceOrder();


                //call loger
                _loggingHelper.LogOrderInformation(order);

                return result;
            
            
        }
    }
}
