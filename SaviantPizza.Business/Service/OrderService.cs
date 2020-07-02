using SaviantPizza.Business.Enums;
using SaviantPizza.Business.Factory;
using SaviantPizza.Business.IService;
using SaviantPizza.Repository.Entity;
using SaviantPizza.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaviantPizza.Business.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly VendorFactory VendorFactory;


        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public bool SaveOrder(List<Order> orders)
        {
            try
            {
                int vendorType = 1; ;

                VendorFactory VendorFactory = new VendorFactory();
                foreach (var order in orders)
                {
                    _orderRepository.Insert(order);
                    _orderRepository.Save();

                    vendorType = order.OrderDetails.FirstOrDefault().VendorId;

                }

                var vendorToCall = VendorFactory.CreateVendor(vendorType);
                return vendorToCall.placeOrder();
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
